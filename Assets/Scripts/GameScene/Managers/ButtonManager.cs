using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public List<Button> Btn = new List<Button>();

    // 남은 시간 표시
    public List<Text> TimeDisplayer = new List<Text>();

    // 현재 남은 시간
    private float LeftTime { get; set; }

    // 전체 남은 시간
    private float CoolDown { get; set; }

    public SpeechBubble throwerSpeechBubble;
    public SpeechBubble receiverSpeechBubble;

    [Space(20)]
    public GameObject content;
    public GameObject left;
    public GameObject right;

    [Space(20)]
    public GameObject blurPanel;
    public GameObject settingPanel;
    public Background background;

    private int targetNum = 0;

    private void Start()
    {
        foreach (var btn in Btn)
        {
            btn.onClick.AddListener(() =>
            {
                string throwerText = ConversationManager.Instance.conversationData_Throwers[targetNum].text[Btn.IndexOf(btn)];
                string receiverText = ConversationManager.Instance.conversationData_Receivers[targetNum++].text[Btn.IndexOf(btn)];

                throwerSpeechBubble.SetSpeechBubbleText(throwerText);

                GameObject throwerObj = Instantiate(right, content.transform);
                throwerObj.transform.GetChild(1).GetComponent<Text>().text = throwerText;
                GameObject receiverObj = Instantiate(left, content.transform);
                receiverObj.transform.GetChild(1).GetComponent<Text>().text = receiverText;

                DamageEffectManager.Instance.PlayDamageEffect();

                if (targetNum >= Btn.Count)
                    targetNum = 0;
            });
        }
    }

    // 시간당 게이지 채우기, 남은 시간 표시
    private void Update()
    {
        // 남은 시간 감소
        LeftTime -= Time.deltaTime;

        if (LeftTime > 0)
        {
            // 초 및 비율 초기화
            var sec = LeftTime % 60;
            var ratio = 1.0f - LeftTime / CoolDown;

            foreach (var btn in Btn)
            {
                // 버튼 비율 설정
                if (btn.image)
                    btn.image.fillAmount = ratio;

                // 버튼 활성화 여부 확인
                if (!btn.enabled)
                    continue;

                // 버튼 비활성화
                btn.enabled = false;
            }

            // 버튼 남은 시간 표시
            foreach (var time in TimeDisplayer)
                time.text = sec.ToString(CultureInfo.CurrentCulture);
        }
        else
        {
            // 버튼 활성화
            foreach (var btn in Btn)
                btn.enabled = true;

            // 버튼 쿨다운 표시
            // timeGap을 사용하는 이유는 현재 간격이 일정하기 때문이므로 변경 가능
            var timeGap = 0.0f;

            foreach (var time in TimeDisplayer)
                time.text = (3.0f + timeGap++).ToString("N1");
        }
    }

    // 공격 버튼 OnClick에서 사용
    // ReSharper disable once UnusedMember.Global
    public void OnAttackBtnClick(float maxTime)
    {
        LeftTime = maxTime;
        CoolDown = maxTime;
    }

    public void OnSettingButtonClick()
    {
        blurPanel.SetActive(true);
        settingPanel.SetActive(true);
        background.animator.speed = 0;
        print(background.animator.speed);
    }

    public void OnBackGameButtonClick()
    {
        blurPanel.SetActive(false);
        settingPanel.SetActive(false);
        background.animator.speed = 1;
    }
}