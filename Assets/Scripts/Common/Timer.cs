using UnityEngine;

public class Timer : MonoBehaviour
{
    private float nowTime = 0;
    private float targetTime;
    private bool isTimeFlow = true;
    private bool isReachTime = false;

    private void Update()
    {
        TimeFlow();
    }

    public void TimeFlow()
    {
        if (isTimeFlow)
        {
            nowTime += Time.deltaTime;
            if (nowTime >= targetTime)
            {
                nowTime = 0;
                isReachTime = true;
            }
            else isReachTime = false;
        }
        else isReachTime = false;
    }

    public void SetTargetTime(float time) { targetTime = time; }
    public void SetTimeFlow(bool isChangeTimeFlow) { isTimeFlow = isChangeTimeFlow; }
    public bool GetIsReachTime() { return isReachTime; }
    public bool GetIsTimeFlow() { return isTimeFlow; }
}