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
            foreach (Tile t in data.Layout)
            {
                tileList.Add(t);
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
        return new SaveData
        {
            Layout = LevelLayout.Layout
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

        files.Sort((x, y) => DateTime.Compare(y.LastEdit, x.LastEdit));
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
    public List<Tile> Layout;
}

public class FileInformation
{
    public string Name;
    public DateTime LastEdit;
}