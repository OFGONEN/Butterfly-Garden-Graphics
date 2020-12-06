using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MergedButterflyGraphics : MonoBehaviour
{
    public Texture2D patternImage;

    public List< BaseButterflyGraphics > inputButterflies;

    private MaterialPropertyBlock propertyBlock;
    private Renderer rend;

    private static readonly int inputButterflyColorsShaderID = Shader.PropertyToID( "inputButterflyColors" );
    private static readonly int numberOfInputButterfliesShaderID = Shader.PropertyToID( "numberOfInputButterflies" );

    void Awake()
    {
        // TODO: Move this into a manager/system class that is holding an array/list of these textures and providing them randomly on demand.
        if( patternImage == null )
            patternImage = Resources.Load< Texture2D >( "Images/WingPatterns/ExamplePattern.png" );
        rend = GetComponent< Renderer >();
        propertyBlock = new MaterialPropertyBlock();

        if( patternImage != null )
        {
            rend.GetPropertyBlock( propertyBlock );
            propertyBlock.SetTexture( "_MainTex", patternImage );
            // Array sizes are determined the first time they are set, so set it to max beforehand.
            propertyBlock.SetFloatArray( inputButterflyColorsShaderID, new float[ 4 * 10 ] );
            rend.SetPropertyBlock( propertyBlock );
        }
    }

    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) )
            Merge();
    }

    public void Merge()
    {
        rend.GetPropertyBlock( propertyBlock );
        propertyBlock.SetFloatArray( inputButterflyColorsShaderID, inputButterflies.Select( bfGraphics => bfGraphics.GetColor() )
                                                                                   .SelectMany( color => new[] { color.r, color.g, color.b, color.a } )
                                                                                   .ToArray() );
        propertyBlock.SetInt( numberOfInputButterfliesShaderID, inputButterflies.Count );
        rend.SetPropertyBlock( propertyBlock );
    }
}
