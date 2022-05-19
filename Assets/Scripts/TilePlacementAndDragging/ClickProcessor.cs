using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickProcessor : MonoBehaviour
{
    [SerializeField]
    private GameObject _tilePrefab;

    private Vector3 _clickStartLocation;
    private bool _isDragging;

    void Start()
    {
        
    }

    void Update()
    {
        if (!TilePlacement.IsMenuOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDragging = false;
                _clickStartLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                if (Vector2.Distance(_clickStartLocation, Camera.main.ScreenToWorldPoint(Input.mousePosition)) > 0.25f)
                {
                    _isDragging = true;
                }
            }

            else if (Input.GetMouseButtonUp(0))
            {
                if (!_isDragging)
                {
                    PlaceTile();
                }
            }
        }
    }

    public void PlaceTile()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        position.z = 0;
        GameObject o = Instantiate(_tilePrefab, position, Quaternion.identity, transform);
        o.GetComponent<SpriteRenderer>().sprite = TilePlacement.Tile;
    }
}
