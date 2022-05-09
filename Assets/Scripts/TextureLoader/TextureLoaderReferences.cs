using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureLoaderReferences : MonoBehaviour
{
    public Sprite[] Sprites;

    void Start()
    {
        TextureLoader.References = this;
    }

    void Update()
    {
        
    }
}
