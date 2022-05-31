using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelLayout
{
    public static List<Tile> Layout = new List<Tile>();
    public static List<GameObject> WorldTiles = new List<GameObject>();
}

[Serializable]
public class Tile
{
    public Vector2 Position;
    public Sprite Block;

    public Tile(Vector2 position, Sprite block)
    {
        Position = position;
        Block = block;
    }
}
