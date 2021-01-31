using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldButton : MonoBehaviour
{
    [SerializeField]
    protected int card_number;
    private Image button_image;
    [SerializeField]
    protected Color unselected_color;
    [SerializeField]
    protected Color selected_color;
    private void Awake()
    {
        button_image = GetComponent<Image>();
    }

    private void Update()
    {
        if (Hand.instance.hand[card_number].GetHeld())
        {
            button_image.color = selected_color;
        }
        else
        {
            button_image.color = unselected_color;
        }
    }
    public void ToggleHold()
    {
        Hand.instance.hand[card_number].ToggleHold();
    }
}
