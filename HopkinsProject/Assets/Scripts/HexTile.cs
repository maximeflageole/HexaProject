using UnityEngine;

public class HexTile : MonoBehaviour
{
    public Vector2Int m_coordinates;
    public bool m_displayed;

    void OnMouseOver2D()
    {
        Debug.Log("Mouse over me");
    }
}