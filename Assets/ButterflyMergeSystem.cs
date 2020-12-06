using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMergeSystem : MonoBehaviour
{
    Texture2D patternImage;

    void Start()
    {
        patternImage = Resources.Load< Texture2D >( "Images/WingPatterns/ExamplePattern.png" );
    }

    void Update()
    {
        
    }
}
