using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class SaveDataManagement
{
    public readonly static string SaveLocation = "saves/";
    public static string SaveFile = "";
    public static string SaveDirectory
    {
        get
        {
            return SaveLocation + SaveFile;
        }
        
        set { }
    }

    public static void Load()
    {
        CreateSaveDirectory();
        if (SaveFile == "")
        {
            SaveFile = "autosave.json";
        }

        if (File.Exists(SaveDirectory))
        {
            string jsonData = File.ReadAllText(SaveDirectory);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            List<Tile> tileList = new List<Tile>();
            foreach (TileData d in data.Layout)
            {
                tileList.Add(d.ToTile());
            }

            LevelLayout.BuildSceneFromLayout(tileList);
        }
    }

    public static void Save()
    {
        if (SaveFile == "")
        {
            SaveFile = "autosave.json";
        }

        SaveData data = CreateSaveData();
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(SaveDirectory, jsonData);
    }

    private static SaveData CreateSaveData()
    {
        List<TileData> tileDataList = new List<TileData>();
        foreach (Tile t in LevelLayout.Layout)
        {
            tileDataList.Add(t.ToData());
        }

        return new SaveData
        {
            Layout = tileDataList
        };
    }

    public static List<FileInformation> GetAllAndSortByTime()
    {
        string[] fileNames = Directory.GetFiles(SaveLocation);

        List<FileInformation> files = new List<FileInformation>();
        foreach (string fileName in fileNames)
        {
            files.Add(new FileInformation { Name = fileName, LastEdit = File.GetLastWriteTime(fileName) });
        }

        files.Sort((x, y) => DateTime.Compare(x.LastEdit, y.LastEdit));
        return files;
    }

    private static void CreateSaveDirectory()
    {
        if (!Directory.Exists(SaveLocation))
        {
            Directory.CreateDirectory(SaveLocation);
        }
    }
}

[Serializable]
public class SaveData
{
    public List<TileData> Layout;
}

[Serializable]
public class TileData
{
    public Vector2 Position;
    public string SpriteName;

    public static explicit operator TileData(Tile t) => new TileData
    {
        Position = t.Position,
        SpriteName = t.Block.name
    };
}

public class FileInformation
{
    public string Name;
    public DateTime LastEdit;
}