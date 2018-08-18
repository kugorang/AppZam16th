using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Background : MonoBehaviour
{
    public List<float> backgroundTimes = new List<float>();

    [HideInInspector] public Animator animator;
    private AnimationState animationState;

    private float time = 0;
    private int index = 0;

	private void Start()
	{
        animator = GetComponent<Animator>();
	}

	private void Update()
	{
        time += Time.deltaTime;

        if (index < backgroundTimes.Count)
        {
            if (backgroundTimes[index] <= time)
            {
                time = 0;
                index++;
                animator.SetTrigger("Move");
            }
        }
        else
        {
            PlayerPrefs.SetInt("EndingNum", 0);
            SceneManager.LoadScene("Scenes/Ending");
        }
	}
}