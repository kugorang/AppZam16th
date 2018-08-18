using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameScene.Character
{
    public class Thrower : MonoBehaviour
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

        private void Update()
        {
            if (hp <= 0)
            {
                PlayerPrefs.SetInt("EndingNum", 1);
                SceneManager.LoadScene("Scenes/Ending");
            }
        }
    }
}