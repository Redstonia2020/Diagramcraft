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
    [SerializeField]
    private GameObject _blockArea;

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

    public void SearchBlocks()
    {
        foreach (Transform child in _blockArea.transform)
        {
            Destroy(child.gameObject);
        }


        List<Sprite> valid = new List<Sprite>();
        foreach (Sprite sprite in TextureLoader.References.Sprites)
        {
            if (sprite.name.Contains(_searchBar.text))
            {
                valid.Add(sprite);
            }
        }
    }
}
