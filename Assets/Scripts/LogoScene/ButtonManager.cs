using UnityEngine;
using UnityEngine.SceneManagement;

namespace LogoScene
{
	public class ButtonManager : MonoBehaviour 
	{
		public void OnGameStartBtnClick()
		{
			SceneManager.LoadScene("Main");
		}

		public void OnOptionBtnClick()
		{
			// TODO: 옵션창 띄울 것!
		}
	}
}