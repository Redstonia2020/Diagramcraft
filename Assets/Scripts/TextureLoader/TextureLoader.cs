using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureLoader
{
    public static TextureLoaderReferences References;

    public static Sprite GetTexture(int id)
    {
        return References.Sprites[id];
    }
}
