using UnityEngine;

public class HexTile : MonoBehaviour
{
    public Vector2Int m_coordinates;
    public bool m_displayed;
    public Tile m_childTile;

    private void OnMouseEnter()
    {
        //Display
        Debug.Log("Mouse entered");
    }

    private void OnMouseDown()
    {
        //Build a tile
        GameManager.GetInstance().m_map.CreateTile(this);
    }

    public bool CanSpawnTile()
    {
        return m_childTile == null;
    }
}