﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadMainScene());
    }

    private IEnumerator LoadMainScene() {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("Scenes/Main");
    }
}
