using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButterflyGraphics : MonoBehaviour
{
    private Renderer rend;
    private MaterialPropertyBlock propertyBlock;

    private static int ColorShaderID = Shader.PropertyToID( "_Color");

    void Start()
    {
        rend = GetComponent< Renderer >();
        propertyBlock = new MaterialPropertyBlock();

        rend.GetPropertyBlock( propertyBlock );
        propertyBlock.SetColor( ColorShaderID, Random.ColorHSV() );
        rend.SetPropertyBlock( propertyBlock );
    }

    public Color GetColor()
    {
        rend.GetPropertyBlock( propertyBlock );
        return propertyBlock.GetColor( ColorShaderID );
    }
}
