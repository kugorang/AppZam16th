using UnityEngine;
using UnityEngine.SceneManagement;

namespace LogoScene
{
    public class ButtonManager : MonoBehaviour
    {
        [Space(20)]
        public GameObject BlurPanel;
        public GameObject SettingPanel;

        public void OnGameStartBtnClick()
        {
            SceneManager.LoadScene("Scenes/Tutorial");
        }

        public void OnOptionBtnClick()
        {
            BlurPanel.SetActive(true);
            SettingPanel.SetActive(true);
        }

        public void OnBackGameButtonClick()
        {
            BlurPanel.SetActive(false);
            SettingPanel.SetActive(false);
        }
    }
}