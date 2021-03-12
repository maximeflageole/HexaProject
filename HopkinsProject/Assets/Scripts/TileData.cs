using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "HexagonTile")]
public class TileData : ScriptableObject
{
    public Sprite Sprite;
    public GameObject Prefab;
}