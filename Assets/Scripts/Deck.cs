using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public static Deck instance;
    [SerializeField]
    private List<Card> deck;
    [SerializeField]
    private List<Card> discard;
    [SerializeField]
    private Card template_card;

    private void Awake()
    {
        instance = this;
        char[] suits = { 'H', 'S', 'D', 'C' };
        int[] values = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
        int counter = 0;
        foreach(char s in suits)
        {
            foreach(int v in values)
            {
                deck.Add(Instantiate(template_card, transform));
                deck[counter].SetValueSuit(v,s);
                counter++;
            }
        }
        Shuffle();
    }

    public Card GetTopCard()
    {
        return deck[0];
    }

    public void RemoveTopCard()
    {
        deck.RemoveAt(0);
    }
    public void Shuffle()
    {
        for(int i=0; i < 52; i++)
        {
            int swap_location = Random.Range(0, 51);
            Card temp;
            temp = deck[i];
            deck[i] = deck[swap_location];
            deck[swap_location] = temp;
        }
    }

    public void ReplenishDeck()
    {
        foreach(Card c in discard)
        {
            deck.Add(c);
        }
        discard.Clear();
    }
    public void DiscardCard(Card c)
    {
        c.transform.SetParent(transform);
        discard.Add(c);
    }
}
