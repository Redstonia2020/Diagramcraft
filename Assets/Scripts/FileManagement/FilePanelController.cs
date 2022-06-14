using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Globalization;
using System.IO;

public class FilePanelController : MonoBehaviour
{
    private string _correspondingFile;

    [SerializeField]
    private TextMeshProUGUI _fileName;
    [SerializeField]
    private TextMeshProUGUI _lastEdit;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void FillInData(FileInformation info)
    {
        _correspondingFile = Path.GetFileName(info.Name);

        _fileName.text = Path.GetFileNameWithoutExtension(info.Name);

        DateTime d = info.LastEdit;
        _lastEdit.text = $"{d.ToString("g", CultureInfo.GetCultureInfo("en-NZ"))}";
    }

    public void Click()
    {
        SaveDataManagement.SaveFile = _correspondingFile;
        SceneLoader.LoadScene(Scenes.Editor);
    }
}
