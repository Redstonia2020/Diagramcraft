using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class FileNavigationDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject _diagramPanel;

    void Start()
    {
        var files = SaveDataManagement.GetAllAndSortByTime();
        foreach (var file in files)
        {
            GameObject panel = Instantiate(_diagramPanel, transform);
            panel.GetComponent<FilePanelController>().FillInData(file);
        }
    }

    void Update()
    {
        
    }
}
