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
