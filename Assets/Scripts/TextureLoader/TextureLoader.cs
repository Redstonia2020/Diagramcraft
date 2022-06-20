using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class TextureLoader
{
    public static TextureLoaderReferences References;

    public static List<TextureGroup> TextureGroups;

    public static void GroupTextures()
    {
        string[] ids = File.ReadAllLines("Assets/Data/block_ids.txt");
        string[] englishTranslations = File.ReadAllLines("Assets/Data/english.txt");

        for (int i = 0; i < ids.Length; i++)
        {
            new TextureGroup(englishTranslations[i], ids[i]);
        }
    }

    public static Sprite GetTexture(int id)
    {
        return References.Sprites[id];
    }
}

public class TextureGroup
{
    public string Name;
    public string ID;
    public List<Sprite> Textures = new List<Sprite>();

    public TextureGroup(string name, string id)
    {
        Name = name;
        ID = id;
        foreach (Sprite s in TextureLoader.References.Sprites)
        {
            if (s.name.StartsWith(id))
            {
                Textures.Add(s);
            }
        }
    }
}

public class Texture
{
    
}