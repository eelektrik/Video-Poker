using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealButtonDisplay : MonoBehaviour
{
    Text button_text;
    // Start is called before the first frame update
    void Start()
    {
        button_text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GetNextHandStatus())
        {
            button_text.text = "New Hand";
        }
        else
        {
            button_text.text = "Deal";
        }
    }
}
