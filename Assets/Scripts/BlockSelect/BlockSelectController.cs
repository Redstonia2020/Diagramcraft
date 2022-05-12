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

    [SerializeField]
    private GameObject _itemTilePrefab;

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

        int placements = 0;
        float y = 485;
        List<Sprite> valid = new List<Sprite>();
        foreach (Sprite sprite in TextureLoader.References.Sprites)
        {
            if (sprite.name.Contains(_searchBar.text))
            {
                valid.Add(sprite);
                if (placements < 6)
                {
                    GameObject o = Instantiate(_itemTilePrefab, _blockArea.transform);
                    o.transform.localPosition = new Vector3(0, y);
                    o.GetComponent<ItemTileController>().ChangeTo(sprite, sprite.name);
                    placements++;
                    y -= 185;
                }
            }
        }
    }
}
