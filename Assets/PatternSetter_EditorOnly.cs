using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternSetter_EditorOnly : MonoBehaviour
{
    public MergedButterflyGraphics referenceMergedButterfly;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent< Renderer >();
        rend.material.SetTexture( "_MainTex", referenceMergedButterfly.patternImage );
    }
}
