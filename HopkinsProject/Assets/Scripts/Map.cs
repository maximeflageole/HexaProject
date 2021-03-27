using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    protected Dictionary<Vector2Int, Tile> m_tilesDictionary = new Dictionary<Vector2Int, Tile>();
    protected Vector3 m_oddTileOffset;
    [SerializeField] private GameObject m_hexGridPrefab;
    [SerializeField] private TileData m_tileData;
    [SerializeField] private int m_mapLayers;
    protected float yValue;
    
    private void Awake()
    {
        m_oddTileOffset = new Vector3(0.5f, 0, 0);
        yValue = Mathf.Sqrt(3) / 2.0f;
        GenerateHexGrid();
    }

    private void GenerateHexGrid()
    {
        var i = m_mapLayers;
        for (var j = -i; j < i+1; j++)
        {
            for (var k = -i; k < i+1; k++)
            {
                if ( Mathf.Abs(j + k) > i)
                {
                    continue;
                }
                var xTranslation = new Vector3(j, 0, 0);
                var yTranslation = new Vector3(k/2.0f, -k * yValue, 0);
                var position = xTranslation + yTranslation;
                var hexTile = Instantiate(m_hexGridPrefab, position, Quaternion.identity, transform).GetComponentInChildren<HexTile>();
                hexTile.m_coordinates = new Vector2Int(j, k);
            }
        }
    }

    public void CreateTile(HexTile parent)
    {
        if (parent.m_childTile != null)
        {
            return;
        }
        Instantiate(m_tileData.Prefab, parent.transform.position + new Vector3(0, 0, -0.1f), Quaternion.LookRotation(Vector3.up, Vector3.forward), parent.transform);
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
        Vector3 coordinates = new Vector3(gridCoordinates.x, gridCoordinates.y * yValue, 0.0f);
        if (gridCoordinates.y % 2 == 0)
        {
            return coordinates;
        }

        return coordinates + m_oddTileOffset;
    }
}
