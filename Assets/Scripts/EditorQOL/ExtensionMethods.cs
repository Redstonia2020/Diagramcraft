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
}
