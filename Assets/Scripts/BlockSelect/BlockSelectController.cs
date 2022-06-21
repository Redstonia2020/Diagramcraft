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
        TilePlacement.IsMenuOpen = _menu.activeSelf;
    }

    public void SearchBlocks()
    {
        foreach (Transform child in _blockArea.transform)
        {
            Destroy(child.gameObject);
        }

        int placements = 0;
        float y = 511;
        List<TextureGroup> valid = new List<TextureGroup>();
        foreach (TextureGroup block in TextureLoader.TextureGroups)
        {
            if (block.Name.ToLower().Contains(_searchBar.text.ToLower()))
            {
                valid.Add(block);
                if (placements < 9)
                {
                    GameObject o = Instantiate(_itemTilePrefab, _blockArea.transform);
                    o.GetComponent<RectTransform>().sizeDelta = new Vector2(680.48f, 120f);
                    o.transform.localPosition = new Vector3(0, y);
                    o.GetComponent<ItemTileController>().ChangeTo(block.Textures[0], block.Name);
                    placements++;
                    y -= 120;
                }
            }
        }
    }
}
