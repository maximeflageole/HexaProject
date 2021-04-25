using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileCard : MonoBehaviour
{
    [SerializeField] private TileData m_tileData;
    [SerializeField] private Image m_borderSprite;
    [SerializeField] private Image m_tileImage;
    [SerializeField] private Image m_rarityImage;
    [SerializeField] private TextMeshProUGUI m_tileType;
    [SerializeField] private Image m_cardBackground;
    [SerializeField] private TextMeshProUGUI m_tileCost;

    private bool m_selected;

    public void Instantiate(TileData tileData)
    {
        m_tileData = tileData;
        m_tileImage.sprite = tileData.Sprite;
        var dataDict = GameManager.GetInstance().m_dataDictionaries;
        m_rarityImage.sprite = dataDict.GetRaritySprite(tileData.TileRarity);
        m_cardBackground.color = dataDict.GetColorFromTileColor(tileData.TileColor);
        m_tileType.text = tileData.TileType.ToString();
        m_tileCost.text = tileData.TileCost.ToString();
    }

    public void OnClick()
    {
        Select(!m_selected);
        if (m_selected)
            GameManager.GetInstance().SelectCard(this);
        else
            GameManager.GetInstance().SelectCard(null);
    }

    public void Select(bool selected)
    {
        m_selected = selected;
        m_borderSprite.enabled = selected;
    }

    public TileData GetTileData()
    {
        return m_tileData;
    }

    public void Remove()
    {
        Select(false);
        gameObject.SetActive(false);
    }
}
