using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static Hand instance;
    [SerializeField]
    public List<Card> hand;
    private void Start()
    {
        instance = this;
        DrawHand();
    }

    public void DrawHand()
    {
        for (int i = 0; i < 5; i++)
        {
            DrawCard();
        }
    }
    private void DrawCard()
    {
        Card c = Deck.instance.GetTopCard();
        c.transform.SetParent(transform);
        hand.Add(c);
        Deck.instance.RemoveTopCard();
    }

    private void DiscardCard(Card c)
    {
        hand.Remove(c);
        Deck.instance.DiscardCard(c);
    }

    public void ReplaceCards()
    {
        int counter = 0;
        //DebugOutputHand();
        List<Card> to_replace = new List<Card>();
        foreach(Card c in hand)
        {
            if (!c.GetHeld())
            {
                to_replace.Add(c);
                counter++;
            }
        }
        foreach(Card c in to_replace)
        {
            DiscardCard(c);
        }
        for (int i = 0; i < counter; i++)
        {
            DrawCard();
        }
        //DebugOutputHand();
    }

    public void ClearHand()
    {
        foreach(Card c in hand)
        {
            if (c.GetHeld()) { c.ToggleHold(); }
        }
        List<Card> to_replace = new List<Card>();
        foreach (Card c in hand)
        {
            to_replace.Add(c);
        }
        foreach (Card c in to_replace)
        {
            DiscardCard(c);
        }
    }

    private void DebugOutputHand()
    {
        foreach(Card c in hand)
        {
            Debug.Log("Card: " + c.GetSuit() + " " + c.GetValue());
        }
    }
}
