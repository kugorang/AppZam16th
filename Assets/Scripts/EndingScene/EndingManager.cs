using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ending
{
    public class EndingManager : SingleTon<EndingManager>
    {
        private void Start()
        {
            StartCoroutine(LoadStartScene());
        }

        private IEnumerator LoadStartScene()
        {
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene("Scenes/Logo");
        }
    }
}