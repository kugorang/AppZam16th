using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public List<float> backgroundTimes = new List<float>();

    private Material backgroundMaterial;
    private Timer backgroundTimer;

    private int targetTimeIndex;

    private void Start()
    {
        backgroundMaterial = GetComponent<Image>().material;
        backgroundMaterial.mainTextureOffset = Vector2.zero;

        targetTimeIndex = 0;

        backgroundTimer = GetComponent<Timer>();
        backgroundTimer.SetTargetTime(backgroundTimes[targetTimeIndex]);
    }

    private void Update()
    {
        if (targetTimeIndex == 2 && backgroundTimer.GetIsReachTime())
            GameScene.Managers.GameManager.Instance.LoadEndingScene(EndingType.BAD);
        else if (backgroundTimer.GetIsReachTime())
            StartCoroutine(ChangeBackgroundMaterialOffset());
    }

    private IEnumerator ChangeBackgroundMaterialOffset()
    {
        if (backgroundTimer.GetIsTimeFlow())
        {
            backgroundTimer.SetTimeFlow(false);
            targetTimeIndex++;
        }

        var offset = backgroundMaterial.mainTextureOffset;
        while (offset.x < 0.33333f * targetTimeIndex)
        {
            offset.Set(offset.x + Time.deltaTime, 0);
            backgroundMaterial.mainTextureOffset = offset;

            yield return null;
        }

        offset.Set(0.33333f * targetTimeIndex, 0);
        backgroundMaterial.mainTextureOffset = offset;

        if (targetTimeIndex < backgroundTimes.Count)
        {
            backgroundTimer.SetTargetTime(backgroundTimes[targetTimeIndex]);
            backgroundTimer.SetTimeFlow(true);
        }
    }
}