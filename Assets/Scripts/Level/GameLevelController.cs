using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject _tilePrefab;

    void Start()
    {
        LevelLayout.LevelController = this;
        SaveDataManagement.Load();
    }

    void Update()
    {
        
    }

    public GameObject CreateObjectFromTile(Tile tile)
    {
        GameObject tileObject = Instantiate(_tilePrefab, tile.Position, Quaternion.identity, transform);
        tileObject.AssignSprite(tile.GetSprite());
        return tileObject;
    }
}
