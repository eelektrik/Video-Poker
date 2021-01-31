using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    private Text money_text;

    private void Awake()
    {
        money_text = GetComponent<Text>();
    }

    void Update()
    {
        money_text.text = "Money: " + GameManager.instance.GetPlayerMoney();
    }
}
