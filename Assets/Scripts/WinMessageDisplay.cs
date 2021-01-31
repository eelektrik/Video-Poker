using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMessageDisplay : MonoBehaviour
{
    private Text message_text;
    // Start is called before the first frame update
    void Awake()
    {
        message_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        message_text.text = GameManager.instance.GetWinMessage();
    }
}
