using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool next_hand;   public bool GetNextHandStatus() { return next_hand; }
    [SerializeField]
    private int player_money; public int GetPlayerMoney() { return player_money; }
    [SerializeField]
    private int player_bet;
    [SerializeField]
    private int royal_flush_payout, straight_flush_payout, four_kind_payout,
                  full_house_payout, flush_payout, straight_payout,
                  three_kind_payout, two_pair_payout, jacks_payout;
    private string win_message; public string GetWinMessage() { return win_message; }
    private void Start()
    {
        instance = this;
        next_hand = true;
        win_message = "Welcome, press New Hand to deal.";
    }

    public void Deal()
    {
        if (next_hand)
        {
            ClearWinMessage();
            player_money -= player_bet;
            Hand.instance.ClearHand();
            Deck.instance.ReplenishDeck();
            Deck.instance.Shuffle();
            Hand.instance.DrawHand();
            next_hand = false;
        }
        else
        {
            Hand.instance.ReplaceCards();
            next_hand = true;
            player_money += WinAmount();
            UpdateWinMessage();
        }
       
    }

    private int WinAmount()
    {
        Hand.instance.hand.Sort();
        if (IsRoyalFlush())         { return player_bet * royal_flush_payout; }
        else if (IsStraightFlush()) { return player_bet * straight_flush_payout; }
        else if (IsFourKind())      { return player_bet * four_kind_payout; }
        else if (IsFullHouse())     { return player_bet * full_house_payout; }
        else if (IsFlush())         { return player_bet * flush_payout; }
        else if (IsStraight())      { return player_bet * straight_payout; }
        else if (IsThreeKind())     { return player_bet * three_kind_payout; }
        else if (IsTwoPair())       { return player_bet * two_pair_payout; }
        else if (IsJacks())         { return player_bet * jacks_payout; }
        else                        { return 0; }
    }
    private void UpdateWinMessage()
    {
        if (IsRoyalFlush())
        {
            Debug.Log("Royal Flush ");
            win_message = "Royal Flush! You won " + (player_bet * royal_flush_payout);
        }
        else if (IsStraightFlush())
        {
            Debug.Log("Straight Flush");
            win_message = "Straight Flush! You won " + (player_bet * straight_flush_payout);
        }
        else if (IsFourKind())
        {
            Debug.Log("Four of a Kind");
            win_message = "Four of a Kind! You won " + (player_bet * four_kind_payout);
        }
        else if (IsFullHouse())
        {
            Debug.Log("Full House");
            win_message = "Full House! You won " + (player_bet * full_house_payout);
        }
        else if (IsFlush())
        {
            Debug.Log("Flush");
            win_message = "Flush! You won " + (player_bet * flush_payout);
        }
        else if (IsStraight())
        {
            Debug.Log("Straight");
            win_message = "Straight! You won " + (player_bet * three_kind_payout);
        }
        else if (IsThreeKind())
        {
            Debug.Log("Three of a Kind");
            win_message = "Three of a Kind, You Won " + (player_bet * three_kind_payout);
        }
        else if (IsTwoPair())
        {
            Debug.Log("Two Pair");
            win_message = "Two Pairs, You won " + (player_bet * two_pair_payout);
        }
        else if (IsJacks())
        {
            Debug.Log("Jacks or Better");
            win_message = "Jacks or Better, You won " + (player_bet * jacks_payout);
        }
        else
        {
            Debug.Log("No Win");
            win_message = "Nothing";
        }
    }

    private void ClearWinMessage()
    {
        win_message = "";
    }
    private bool IsRoyalFlush()
    {
        if(IsStraightFlush() && 
           Hand.instance.hand[0].GetValue() == 1 && //First card in the hand is an Ace
           Hand.instance.hand[4].GetValue() == 13)  //Last card in the hand is a king
        {
            return true;
        }
        return false;
    }

    private bool IsStraightFlush()
    {
        return IsStraight() && IsFlush();
    }

    private bool IsFourKind()
    {
        for (int i = 0; i < 2; i++)
        {
            //Given a sorted hand, if cards three cards away are matching, the cards in between will match as well
            if (Hand.instance.hand[i].GetValue() == Hand.instance.hand[i + 3].GetValue())
            {
                return true;
            }
        }
        return false;
    }

    private bool IsFullHouse()
    {
        //Given a sorted hand, card layout for a full house will be **XXX or ***XX
        //Check for **XXX match
        if (Hand.instance.hand[0].GetValue() == Hand.instance.hand[1].GetValue())
        {
            if (Hand.instance.hand[2].GetValue() == Hand.instance.hand[4].GetValue())
            {
                return true;
            }
        }
        //Check for ***XX match
        if (Hand.instance.hand[0].GetValue() == Hand.instance.hand[2].GetValue())
        {
            if (Hand.instance.hand[3].GetValue() == Hand.instance.hand[4].GetValue())
            {
                return true;
            }
        }
        return false;
    }

    private bool IsFlush()
    {
        //Check the suit of the 1st card against the 4 other cards
        if(Hand.instance.hand[0].GetSuit() == Hand.instance.hand[1].GetSuit() &&
           Hand.instance.hand[0].GetSuit() == Hand.instance.hand[2].GetSuit() &&
           Hand.instance.hand[0].GetSuit() == Hand.instance.hand[3].GetSuit() &&
           Hand.instance.hand[0].GetSuit() == Hand.instance.hand[4].GetSuit())
        {
            return true;
        }
        return false;
    }

    private bool IsStraight()
    {
        //Checks for Aces first, followed by a 2 for A-2-3-4-5 or followed by a 10 for 10-J-Q-K-A
        //Any other values starting a straight would be caught by the first half of the Or statement
        if (Hand.instance.hand[0].GetValue() == Hand.instance.hand[1].GetValue() - 1 ||
            Hand.instance.hand[0].GetValue() == Hand.instance.hand[1].GetValue() - 9)
        {
            //Check the rest of the hand for values being 1 apart
            if (Hand.instance.hand[1].GetValue() == Hand.instance.hand[2].GetValue()-1 &&
                Hand.instance.hand[2].GetValue() == Hand.instance.hand[3].GetValue()-1 &&
                Hand.instance.hand[3].GetValue() == Hand.instance.hand[4].GetValue() - 1)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsThreeKind()
    {
        for (int i = 0; i < 3; i++)
        {
            //Given a sorted hand, if cards two cards away are matching, the card in between will match as well
            if (Hand.instance.hand[i].GetValue() == Hand.instance.hand[i+2].GetValue())
            {
                return true;
            }
        }
        return false;
    }

    private bool IsTwoPair()
    {
        int pairs = 0;
        for(int i = 0; i < 4; i++)
        {
            //Given a sorted hand, check each pair of adjacent cards for matching values.
            if (Hand.instance.hand[i].GetValue() == Hand.instance.hand[i + 1].GetValue())
            {
                pairs++;
            }
        }
        if (pairs == 2)
        { 
            return true;
        }
        return false;
    }

    private bool IsJacks()
    {
        Dictionary<int, int> totals = new Dictionary<int, int>
        {
            [1] = 0,    //Aces
            [11] = 0,   //Jacks
            [12] = 0,   //Queens
            [13] = 0    //Kings
        };

        foreach(Card c in Hand.instance.hand)
        {
            if (totals.ContainsKey(c.GetValue())) { totals[c.GetValue()]++; }
        }

        //Jacks or better is checked last, if total was 3+ it would get caught by IsThreeKind(), IsFourKind(), or IsFullHouse()
        if (totals.ContainsValue(2))
        { 
            return true;
        } 
        return false;
    }
}
