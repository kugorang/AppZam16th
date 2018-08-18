using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameScene.Managers
{
    public class ButtonManager : MonoBehaviour
    {
        public List<Button> AttackBtn = new List<Button>();

        // 남은 시간 표시
        public List<Text> TimeDisplayer = new List<Text>();
        
        // 남은 시간 진행바
        public Image[] ProgressBar;

        // 현재 남은 시간
        private float LeftTime { get; set; }

        // 전체 남은 시간
        private float CoolDown { get; set; }
        
        // 스크롤
        public ScrollRect ScrollRect;
    
        // ScrollView Content
        public GameObject Content;
        
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
            foreach (var btn in AttackBtn)
            {
                btn.onClick.AddListener(() =>
                {
                    var throwerText = ConversationManager.Instance.conversationData_Throwers[targetNum].text[AttackBtn.IndexOf(btn)];
                    var receiverText = ConversationManager.Instance.conversationData_Receivers[targetNum++].text[AttackBtn.IndexOf(btn)];

                    throwerSpeechBubble.SetSpeechBubbleText(throwerText);

                    var throwerObj = Instantiate(right, content.transform);
                    throwerObj.transform.GetChild(1).GetComponent<Text>().text = throwerText;
                    var receiverObj = Instantiate(left, content.transform);
                    receiverObj.transform.GetChild(1).GetComponent<Text>().text = receiverText;

                    DamageEffectManager.Instance.PlayDamageEffect();

                    if (targetNum >= AttackBtn.Count)
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

                foreach (var btn in AttackBtn)
                {
                    // 버튼 활성화 여부 확인
                    if (!btn.IsInteractable())
                        continue;

                    // 버튼 비활성화
                    btn.interactable = false;
                }

                // 버튼 남은 시간 표시
                foreach (var time in TimeDisplayer)
                    time.text = sec.ToString("N1");
                
                // 진행바 표시
                foreach (var bar in ProgressBar)
                {
                    bar.transform.GetChild(0).GetComponent<Image>().fillAmount = ratio;

                    if (bar.IsActive())
                    {
                        continue;
                    }

                    bar.gameObject.SetActive(true);
                }
            }
            else
            {
                // 버튼 활성화
                foreach (var btn in AttackBtn)
                    btn.interactable = true;

                // 버튼 쿨다운 표시
                // timeGap을 사용하는 이유는 현재 간격이 일정하기 때문이므로 변경 가능
                var timeGap = 0.0f;

                foreach (var time in TimeDisplayer)
                    time.text = (3.0f + timeGap++).ToString("N1");
                
                foreach (var bar in ProgressBar)
                    bar.gameObject.SetActive(false);
            }
        }

        // 공격 버튼 OnClick에서 사용
        // ReSharper disable once UnusedMember.Global
        public void OnAttackBtnClick(float maxTime)
        {
            LeftTime = maxTime;
            CoolDown = maxTime;
            
            // 코루틴을 사용한 이유는 증가 시킨 후 다음 프레임에서 스크롤바를 내려야 작동이 되기 때문
            // TODO: 만약 그 프레임에서 즉시 스크롤바를 내릴 수 있다면 아래 코드를 수정할 것 
            StartCoroutine("ScrollDown");
        }
        
        private IEnumerator ScrollDown()
        {
            yield return new WaitForSeconds(0.01f);
            ScrollRect.verticalNormalizedPosition = 0f;
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
}