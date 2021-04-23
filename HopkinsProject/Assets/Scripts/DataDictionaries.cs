using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dictionaries", menuName = "Dictionaries")]
public class DataDictionaries : ScriptableObject
{
    public List<TileColorTuple> TileColorList = new List<TileColorTuple>();
    public List<TileRarityTuple> TileRarityList = new List<TileRarityTuple>();
    public Dictionary<ETileColor, Color> ColorDictionary;
    public Dictionary<ETileRarity, Sprite> RarityDictionary;

    public Color GetColorFromTileColor(ETileColor tileColor)
    {
        if (ColorDictionary == null)
        {
            ColorDictionary = new Dictionary<ETileColor, Color>();
            foreach (var pair in TileColorList)
            {
                ColorDictionary.Add(pair.TileColor, pair.Color);
            }
        }
        return ColorDictionary[tileColor];
    }

    public Sprite GetRaritySprite(ETileRarity rarity)
    {
        if (RarityDictionary == null)
        {
            RarityDictionary = new Dictionary<ETileRarity, Sprite>();
            foreach (var pair in TileRarityList)
            {
                RarityDictionary.Add(pair.Rarity, pair.Sprite);
            }
        }
        return RarityDictionary[rarity];
    }
}

[System.Serializable]
public struct TileColorTuple
{
    public ETileColor TileColor;
    public Color Color;
}

[System.Serializable]
public struct TileRarityTuple
{
    public ETileRarity Rarity;
    public Sprite Sprite;
}