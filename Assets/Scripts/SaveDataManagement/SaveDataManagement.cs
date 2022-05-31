using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveDataManagement
{
    public static void Save()
    {
        SaveData data = CreateSaveData();
        Debug.Log(JsonUtility.ToJson(data));
    }

    private static SaveData CreateSaveData()
    {
        return new SaveData
        {
            Layout = LevelLayout.Layout
        };
    }
}

[Serializable]
public class SaveData
{
    public List<Tile> Layout { get; set; }
}