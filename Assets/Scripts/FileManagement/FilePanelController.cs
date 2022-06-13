using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Globalization;
using System.IO;

public class FilePanelController : MonoBehaviour
{
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
        _fileName.text = Path.GetFileNameWithoutExtension(info.Name);

        DateTime d = info.LastEdit;
        _lastEdit.text = $"{d.ToString("g", CultureInfo.GetCultureInfo("en-NZ"))}";
    }
}
