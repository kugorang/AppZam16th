using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    private const float gap = 520;

    private RectTransform rectTransform;
    public Text text;

	private void Start()
	{
        rectTransform = GetComponent<RectTransform>();
	}

	public void SetSpeechBubbleText(string s)
    {
        text.text = s;
        rectTransform.sizeDelta = new Vector2(text.preferredWidth + gap, rectTransform.sizeDelta.y);
    }
}