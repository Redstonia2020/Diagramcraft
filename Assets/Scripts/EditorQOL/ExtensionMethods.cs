using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static Sprite GetSprite(this GameObject gameObject)
    {
        return gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public static void AssignSprite(this GameObject gameObject, Sprite assign)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = assign;
    }

    public static TileData ToData(this Tile t)
    {
        return new TileData
        {
            Position = t.Position,
            SpriteName = t.Block.name
        };
    }

    public static Tile ToTile(this TileData d)
    {
        return new Tile(d.Position, Resources.Load<Sprite>(d.SpriteName));
    }
}
