using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class TextureLoader
{
    public static TextureLoaderReferences References;

    public static List<TextureGroup> TextureGroups = new List<TextureGroup>();
    private static Dictionary<string, TextureGroup> IdToGroup = new Dictionary<string, TextureGroup>();

    public static void GroupTextures()
    {
        string[] ids = File.ReadAllLines("Assets/Data/block_ids.txt");
        string[] englishTranslations = File.ReadAllLines("Assets/Data/english.txt");

        for (int i = 0; i < ids.Length; i++)
        {
            var group = new TextureGroup(englishTranslations[i], ids[i]);
            if (group.Textures.Count > 0)
            {
                TextureGroups.Add(group);
                IdToGroup.Add(group.ID, group);
            }
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
    public static Sprite BlockState;
    public static string BlockID;
}