﻿using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace GameScene.Character
{
    public class Receiver : MonoBehaviour
    {
        private const float maxHp = 100;
        [HideInInspector] 
        public float hp;

        private Image image;

        public Text hpText;

        private void Start()
        {
            image = GetComponent<Image>();

            //PlayerPrefs.GetString("Player");
            image.sprite = CharacterManager.Instance.womanSprites[0];

            hp = maxHp;
        }
    }
}
