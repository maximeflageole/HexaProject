using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "HexagonTile")]
public class TileData : ScriptableObject
{
    public Sprite Sprite;
    public GameObject Prefab;
    public ETileColor TileColor = ETileColor.Count;
    public ETileType TileType = ETileType.Count;
    public float ProductionMultiplier = 1.0f;
    public ETileRarity TileRarity = ETileRarity.Count;
}

public enum ETileColor
{
    Green,
    Grey,
    LightBlue,
    Blue,
    Yellow,
    Dark,
    Count
}

public enum ETileType
{
    Grassland,
    Forest,
    Darkwood,
    Desert,
    Plain,
    Marsh,
    Ashland,
    Riverland,
    Lake,
    Deepsea,
    Snow,
    Mountain,
    Oasis,
    VolcanoInactive,
    VolcanoActive,
    Jungle,
    Dump,
    Count
}

public enum ETileRarity
{
    Common,
    Rare,
    Epic,
    Legendary,
    Count
}