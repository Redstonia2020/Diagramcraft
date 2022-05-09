using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlockSelectController : MonoBehaviour
{
    [SerializeField]
    private Image _selectedBlock;
    [SerializeField]
    private GameObject _menu;
    [SerializeField]
    private TMP_InputField _searchBar;

    void Start()
    {
        _selectedBlock.gameObject.GetComponent<OpenSelectionMenu>().Controller = this;
        _menu.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ToggleMenu()
    {
        _menu.SetActive(!_menu.activeSelf);
    }
}
