using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Card : MonoBehaviour, IComparable<Card>
{
    [SerializeField]
    private int value; public int GetValue(){ return value;}
    [SerializeField]
    private char suit; public char GetSuit(){ return suit;}
    private bool held; public bool GetHeld() { return held;}
                       public void ToggleHold() { held = !held;}
   
    private void Awake()
    {
        held = false;
    }

    public void SetValueSuit(int v, char s)
    {
        value = v;
        suit = s;
    }

    //CompareTo implemented to allow cards to be sorted by value, ignoring suit.
    public int CompareTo(Card other)
    {
        if (other == null) return 1;
        return value.CompareTo(other.value);
    }
}
