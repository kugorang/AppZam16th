using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffectUnit : MonoBehaviour
{
    private RectTransform rectTransform;
    private Animator animator;
    private AnimatorStateInfo animatorStateInfo;

    private float speed;

    [HideInInspector] public int damage;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();

        float newScale = Random.Range(0.75f, 1f);
        rectTransform.localScale = new Vector3(newScale, newScale);

        animator.speed = Random.Range(0.5f, 1f);
    }

	private void Update()
	{
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorStateInfo.normalizedTime >= 1.0f)
            Destroy(gameObject);
	}
}