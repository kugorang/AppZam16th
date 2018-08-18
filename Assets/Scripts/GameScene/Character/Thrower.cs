using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thrower: MonoBehaviour
{
    private const float maxHp = 100;
    [HideInInspector] public float hp;

    private Image image;

	private void Start()
	{
        image = GetComponent<Image>();

        //PlayerPrefs.GetString("Player");
        image.sprite = CharacterManager.Instance.manSprites[0];

        hp = maxHp;
	}
}
