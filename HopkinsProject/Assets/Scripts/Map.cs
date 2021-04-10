using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    protected Dictionary<Vector2Int, HexTile> m_tileGrid = new Dictionary<Vector2Int, HexTile>();
    protected Dictionary<Vector2Int, Tile> m_tilesDictionary = new Dictionary<Vector2Int, Tile>();
    protected Vector3 m_oddTileOffset;
    [SerializeField] private GameObject m_hexGridPrefab;
    [SerializeField] private TileData m_tileData;
    [SerializeField] private int m_mapLayers;
    protected float yValue;
    protected List<Vector2Int> m_adjacentCoordinates = new List<Vector2Int>()
    {
        new Vector2Int(0, -1),
        new Vector2Int(-1, 0),
        new Vector2Int(-1, +1),
        new Vector2Int(0, +1),
        new Vector2Int(+1, 0),
        new Vector2Int(+1, -1)
    };
    
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
                PlaceHexTile(new Vector2Int(j, k));
            }
        }
    }

    private void GenerateHexGridAround(Vector2Int coordinates)
    {
        foreach (var value in m_adjacentCoordinates)
        {
            var calcCoordinates = coordinates + value;
            if (!m_tileGrid.ContainsKey(coordinates + value))
            {
                PlaceHexTile(calcCoordinates);
            }
        }
    }

    private void PlaceHexTile(Vector2Int coordinates)
    {
        var xTranslation = new Vector3(coordinates.x, 0, 0);
        var yTranslation = new Vector3(coordinates.y / 2.0f, -coordinates.y * yValue, 0);
        var position = xTranslation + yTranslation;
        var hexTile = Instantiate(m_hexGridPrefab, position, Quaternion.identity, transform).GetComponentInChildren<HexTile>();
        hexTile.m_coordinates = coordinates;
        m_tileGrid.Add(coordinates, hexTile);
    }

    public void PlaceTile(HexTile parent, TileCard selectedCard)
    {
        if (!parent.CanSpawnTile())
        {
            return;
        }
        if (selectedCard == null)
        {
            return;
        }
        var tile = Instantiate(selectedCard.GetTileData().Prefab, parent.transform.position + new Vector3(0, 0, -0.1f), Quaternion.LookRotation(Vector3.up, Vector3.forward), parent.transform).GetComponent<Tile>();
        parent.m_childTile = tile;
        GenerateHexGridAround(parent.m_coordinates);
        GameManager.GetInstance().PlaceCard(selectedCard);
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
