using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTileController : MonoBehaviour
{
    [SerializeField]
    private Image _blockImage;
    [SerializeField]
    private TextMeshProUGUI _blockName;

    public BlockTexture CorrespondingBlock;

    private Collider2D _collider;

    void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (_collider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        //    {
        //        Debug.Log("eea");

        //        GameObject.FindGameObjectWithTag("blockSelectMenu").GetComponent<BlockSelectController>().ToggleMenu();
        //        TilePlacement.Tile = _blockImage.sprite;
        //    }
        //}
    }

    public void Click()
    {
        GameObject.FindGameObjectWithTag("blockSelectMenu").GetComponent<BlockSelectController>().ToggleMenu();
        TilePlacement.CurrentTile = CorrespondingBlock;
    }

    public void ChangeTo(BlockTexture block)
    {
        _blockImage.sprite = block.GetSprite();
        _blockName.text = block.GetGroup().Name;
    }
}
