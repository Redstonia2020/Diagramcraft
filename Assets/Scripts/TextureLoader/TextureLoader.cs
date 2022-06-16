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

    public static List<TextureGroup> TextureGroups = new List<TextureGroup>
    {
        new TextureGroup("Acacia Door", ("Top", "acacia_door_top"), ("Bottom", "acacia_door_bottom")),
        new TextureGroup("Acacia Log", ("Side", "acacia_log"), ("Top", "acacia_log_top")),
        new TextureGroup("Activator Rail", ("Off", "activator_rail"), ("On", "activator_rail_on")),
        new TextureGroup("Ancient Debris", ("Top", "ancient_debris_top"), ("Side", "ancient_debris_side")),
        new TextureGroup("Anvil", ("Texture", "anvil"), ("Top", "anvil_top")),
        //azalea plant
    };
}

public class TextureGroup
{
    public string Name;
    public List<Texture> Textures;

    public TextureGroup(string name, params (string name, string file)[] textures)
    {
        Name = name;
        foreach (var t in textures)
        {
            Textures.Add(new Texture
            {
                Name = t.name,
                Sprite = Resources.Load<Sprite>(t.file)
            });
        }
    }
}

public class Texture
{
    public string Name;
    public Sprite Sprite;
}