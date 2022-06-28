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
    BlockTexture Texture;

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
        return TextureLoader.GetGroup(GroupId).Textures[BlockState];
    }
}