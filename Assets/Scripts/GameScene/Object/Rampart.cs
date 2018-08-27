using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rampart : MonoBehaviour
{
    public List<Sprite> rampartSprites = new List<Sprite>();

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void ChangeRampartSprite(int level)
    {
        image.sprite = rampartSprites[level];
    }
}