using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pile : MonoBehaviour
{
    protected Queue<TileCard> m_queuedPile = new Queue<TileCard>();
    protected bool m_isDisplayed = false;

    public List<TileCard> GetPileAsList()
    {
        var arrayPile = m_queuedPile.ToArray();
        List<TileCard> listPile = new List<TileCard>();
        foreach (var card in arrayPile)
        {
            listPile.Add(card);
        }
        return listPile;
    }

    public Queue<TileCard> GetQueuedPile()
    {
        return m_queuedPile;
    }

    public void ShufflePile()
    {
        var arrayPile = m_queuedPile.ToArray();
        List<TileCard> listPile = new List<TileCard>();
        foreach (var card in arrayPile)
        {
            listPile.Add(card);
        }
        Queue<TileCard> shuffledDrawPile = new Queue<TileCard>();
        for (int i = listPile.Count; i > 0; i--)
        {
            int randomInt = Random.Range(0, i);
            shuffledDrawPile.Enqueue(listPile[randomInt]);
            listPile.RemoveAt(randomInt);
        }
        m_queuedPile.Clear();
        m_queuedPile = shuffledDrawPile;
    }

    public TileCard Draw()
    {
        return m_queuedPile.Dequeue();
    }

    public List<TileCard> Draw(int amount)
    {
        List<TileCard> tileCards = new List<TileCard>();
        for (var i = 0; i < amount; i++)
        {
            tileCards.Add(Draw());
        }
        return tileCards;
    }

    public void Enqueue(TileCard card)
    {
        m_queuedPile.Enqueue(card);
        Debug.Log("Card amount: " + m_queuedPile.Count);
    }

    public void Clear()
    {
        m_queuedPile.Clear();
    }

    public int Count()
    {
        return m_queuedPile.Count;
    }

    public void AddCard(TileCard card)
    {
        //card.info = cardInfo;
        card.gameObject.SetActive(false);
        Enqueue(card);
    }

    public void AddCardOnTop(TileCard card)
    {
        card.gameObject.SetActive(false);
        List<TileCard> cardList = new List<TileCard>();
        cardList.Add(card);
        cardList.AddRange(GetPileAsList());
        m_queuedPile.Clear();

        foreach (var cardInPile in cardList)
        {
            m_queuedPile.Enqueue(cardInPile);
        }
    }

    public List<TileCard> Peek(int number = 1)
    {
        List<TileCard> listCard = GetPileAsList();
        List<TileCard> returnList = new List<TileCard>();
        for (int i = 0; i < number && i < listCard.Count; i++)
        {
            returnList.Add(listCard[i]);
        }

        return returnList;
    }

    public void InsertAtBottom(TileCard card)
    {
        List<TileCard> cardList = GetPileAsList();
        cardList.Remove(card);
        cardList.Add(card);
        m_queuedPile.Clear();

        foreach (var cardInPile in cardList)
        {
            m_queuedPile.Enqueue(cardInPile);
        }
    }
}