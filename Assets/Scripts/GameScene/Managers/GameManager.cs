using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EndingType
{
    HAPPY,
    BAD,
    NONE,
}

namespace GameScene.Managers
{
    public class GameManager: SingleTon<GameManager>
    {
        public void LoadEndingScene(EndingType endingType)
        {
            switch (endingType)
            {
                case EndingType.HAPPY:
                    Common.GameManager.Instance.endingType = EndingType.HAPPY;
                    break;
                case EndingType.BAD:
                    Common.GameManager.Instance.endingType = EndingType.BAD;
                    break;
            }
            SceneManager.LoadScene("EndingScene");
        }
    }
}