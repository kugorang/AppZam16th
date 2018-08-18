using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiverHpText : MonoBehaviour
{
    public Receiver receiver;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void SetReceiverHpText(int hp)
    {
        receiver.hp -= hp;
        text.text = receiver.hp.ToString() + "%";
    }
}