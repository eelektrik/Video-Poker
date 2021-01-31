using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDisplay : MonoBehaviour
{
    private Image image;
    public int card_number;
    private void Awake()
    {
        image = this.GetComponent<Image>();
    }
    void Update()
    {
        image.sprite = 
            ImagesLibrary.instance.image_dict[(Hand.instance.hand[card_number].GetValue(),
                                               Hand.instance.hand[card_number].GetSuit())];
    }
}
