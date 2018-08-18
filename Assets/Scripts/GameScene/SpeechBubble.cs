using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    private const float gap = 520;

    private RectTransform rectTransform;
    private Animator animator;
    public Text text;

	private void Start()
	{
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
	}

	public void SetSpeechBubbleText(string s)
    {
        animator.SetTrigger("FadeIn");   
        text.text = s;
        rectTransform.sizeDelta = new Vector2(text.preferredWidth + gap, rectTransform.sizeDelta.y);
    }
}