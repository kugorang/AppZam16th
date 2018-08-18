using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffectManager : SingleTon<DamageEffectManager>
{
    public GameObject damageEffectUnit;
    public RectTransform targetPoint;

	private void Start()
	{
        targetPoint = GetComponent<RectTransform>();
	}

	public void PlayDamageEffect()
    {
        StartCoroutine(CreateDamageEffect());
    }

    private IEnumerator CreateDamageEffect() {
        for (int i = 0; i < Random.Range(7, 11); i++)
        {
            Instantiate(damageEffectUnit, GameObject.Find("Canvas").transform);
            yield return new WaitForSeconds(0.1f);
        }
    }
}