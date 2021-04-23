using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    public List<TileAmount> TileData = new List<TileAmount>();
}

[System.Serializable]
public struct TileAmount
{
    public TileData TileData;
    public int Amount;
}