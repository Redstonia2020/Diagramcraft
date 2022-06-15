using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateNewFileButton : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _nameInput;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Click()
    {
        SaveDataManagement.SaveFile = _nameInput.text + ".json";
        SceneLoader.LoadScene(Scenes.Editor);
    }
}
