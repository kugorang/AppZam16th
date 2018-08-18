using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSlider : MonoBehaviour
{
    private Slider slider;

	private void Start()
	{
        slider = GetComponent<Slider>();

        slider.value = PlayerPrefs.GetFloat("SoundValue");
        slider.onValueChanged.AddListener(delegate
        {
            PlayerPrefs.SetFloat("SoundValue", slider.value);
        });
	}
}
