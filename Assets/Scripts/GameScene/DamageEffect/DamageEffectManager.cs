using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffectManager : SingleTon<DamageEffectManager>
{
    public GameObject damageEffectUnit;
    public RectTransform targetPoint;

    private int unitNum;

	private void Start()
	{
        targetPoint = GetComponent<RectTransform>();
	}

	public void PlayDamageEffect()
    {
        StartCoroutine(CreateDamageEffect());
    }

    private IEnumerator CreateDamageEffect() {
        if (GameScene.Managers.ButtonManager.Instance.buttonNum == 0)
            unitNum = 2;
        else if (GameScene.Managers.ButtonManager.Instance.buttonNum == 1)
            unitNum = 5;
        else if (GameScene.Managers.ButtonManager.Instance.buttonNum == 2)
            unitNum = 8;

        for (int i = 0; i < unitNum; i++)
        {
            Instantiate(damageEffectUnit, GameObject.Find("Canvas").transform);
            yield return new WaitForSeconds(0.1f);
        }
    }
}