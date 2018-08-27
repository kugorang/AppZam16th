using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ending
{
    public class EndingImage : MonoBehaviour
    {
        public List<Sprite> endingImages = new List<Sprite>();

        private Image image;

        void Start()
        {
            image = GetComponent<Image>();
            image.sprite = endingImages[(int)Common.GameManager.Instance.endingType];
        }
    }
}