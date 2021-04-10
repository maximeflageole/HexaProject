using UnityEngine;
using UnityEngine.UI;

public class TileCard : MonoBehaviour
{
    [SerializeField] private TileData m_tileData;
    [SerializeField] private Image m_borderSprite;
    private bool m_selected;

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
