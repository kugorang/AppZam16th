using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowerHpText : MonoBehaviour
{
    public Thrower thrower;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void SetThrowerHpText(int hp)
    {
        thrower.hp -= hp;
        text.text = thrower.hp.ToString() + "%";
    }
}
