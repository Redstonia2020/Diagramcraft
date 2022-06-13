using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileNavigationDisplay : MonoBehaviour
{
    void Start()
    {
        var files = SaveDataManagement.GetAllAndSortByTime();
    }

    void Update()
    {
        
    }
}
