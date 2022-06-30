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

    public static TextureGroup GetGroup(string id)
    {
        return IdToGroup[id];
    }

    public static Sprite GetTexture(int id)
    {
        return References.Sprites[id];
    }
}