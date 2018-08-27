using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ending
{
    public class EndingText : MonoBehaviour
    {
        public List<string> endingTexts = new List<string>();

        private Text text;

        void Start()
        {
            text = GetComponent<Text>();

            text.text = endingTexts[(int)Common.GameManager.Instance.endingType];
        }
    }
}