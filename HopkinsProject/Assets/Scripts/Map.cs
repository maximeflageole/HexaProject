using System;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    protected Dictionary<Vector2Int, Tile> m_tilesDictionary = new Dictionary<Vector2Int, Tile>();
    protected Vector3 m_oddTileOffset;
    [SerializeField] private TileData tileData;
    protected float yValue;
    
    private void Awake()
    {
        m_oddTileOffset = new Vector3(0.5f, 0, 0);
        yValue = Mathf.Sqrt(3) / 2.0f;
    }

    public void CreateTile(Vector2Int position, TileData tileData)
    {
        if (m_tilesDictionary.ContainsKey(position))
        {
            return;
        }

        var go = Instantiate(tileData.Prefab, GetPositionFromGridCoordinates(position), Quaternion.identity);
        go.GetComponent<Tile>().Instantiation(position);
    }

    private Vector3 GetPositionFromGridCoordinates(Vector2Int gridCoordinates)
    {
        Vector3 coordinates = new Vector3(gridCoordinates.x, 0.0f, gridCoordinates.y * yValue);
        if (gridCoordinates.y % 2 == 0)
        {
            return coordinates;
        }

        return coordinates + m_oddTileOffset;
    }
}
