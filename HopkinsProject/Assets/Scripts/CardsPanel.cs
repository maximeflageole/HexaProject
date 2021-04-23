using System.Collections.Generic;
using UnityEngine;

public class CardsPanel : MonoBehaviour
{
    [SerializeField]
    private Pile Pile;
    [SerializeField]
    private Transform m_cardsParentTransform;
    public List<TileCard> m_currentTileCards = new List<TileCard>();

    public void RefreshTiles()
    {
        ReturnCards();
        m_currentTileCards = Pile.Draw(4);
        foreach (var card in m_currentTileCards)
        {
            card.transform.SetParent(m_cardsParentTransform);
            card.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void ReturnCards()
    {
        foreach (var card in m_currentTileCards)
        {
            card.Select(false);
            Pile.Enqueue(card);
            card.transform.SetParent(Pile.transform);
        }
        m_currentTileCards.Clear();
        Pile.ShufflePile();
    }
}
