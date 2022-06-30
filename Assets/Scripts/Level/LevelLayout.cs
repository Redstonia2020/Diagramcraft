using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelLayout
{
    public static List<Tile> Layout = new List<Tile>();
    public static List<GameObject> WorldTiles = new List<GameObject>();

    public static GameLevelController LevelController;

    public static void BuildSceneFromLayout(List<Tile> tiles)
    {
        foreach (Tile tile in tiles)
        {
            tile.Create();
        }
    }
}

[Serializable]
public class Tile
{
    public Vector2 Position;
    public BlockTexture Texture;

    public Tile(Vector2 position, BlockTexture texture)
    {
        Position = position;
        Texture = texture;
    }

    public Sprite GetSprite()
    {
        return Texture.GetSprite();
    }

    public void Create()
    {
        GameObject tileObject = LevelLayout.LevelController.CreateObjectFromTile(this);

        LevelLayout.Layout.Add(this);
        LevelLayout.WorldTiles.Add(tileObject);
    }
}

[Serializable]
public class TextureGroup
{
    public string Name;
    public string ID;
    public List<BlockTexture> TextureControllers = new List<BlockTexture>();
    public List<Sprite> Textures = new List<Sprite>();

    public TextureGroup(string name, string id)
    {
        Name = name;
        ID = id;

        int i = 0;
        foreach (Sprite s in TextureLoader.References.Sprites)
        {
            if (s.name.StartsWith(id))
            {
                Textures.Add(s);
                TextureControllers.Add(new BlockTexture(ID, i));
                i++;
            }
        }
    }
}

[Serializable]
public class BlockTexture
{
    public string GroupId;
    public int BlockState;

    public BlockTexture(string id, int state)
    {
        GroupId = id;
        BlockState = state;
    }

    public Sprite GetSprite()
    {
        return GetGroup().Textures[BlockState];
    }

    public TextureGroup GetGroup()
    {
        return TextureLoader.GetGroup(GroupId);
    }
}