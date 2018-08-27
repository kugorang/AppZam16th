using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameScene.Managers
{
    public class ButtonManager : SingleTon<ButtonManager>
    {
        public List<Button> attackBtns = new List<Button>();
        
        // 남은 시간 진행바
        public Image[] progressBar;

        // 현재 남은 시간
        private float leftTime { get; set; }

        // 전체 남은 시간
        private float coolDownTime { get; set; }
        
        // 스크롤
        public ScrollRect scrollRect;
    
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

        public int targetNum = 0;
        public int buttonNum = 0;

        private void Start()
        {
            foreach (var btn in attackBtns)
            {
                btn.onClick.AddListener(() =>
                {
                    buttonNum = attackBtns.IndexOf(btn);
                    var throwerText = ConversationManager.Instance.conversationData_Throwers[targetNum].text[attackBtns.IndexOf(btn)];
                    var receiverText = ConversationManager.Instance.conversationData_Receivers[targetNum++].text[attackBtns.IndexOf(btn)];

                    throwerSpeechBubble.SetSpeechBubbleText(throwerText);

                    var throwerObj = Instantiate(right, content.transform);
                    throwerObj.transform.GetChild(1).GetComponent<Text>().text = throwerText;
                    var receiverObj = Instantiate(left, content.transform);
                    receiverObj.transform.GetChild(1).GetComponent<Text>().text = receiverText;

                    DamageEffectManager.Instance.PlayDamageEffect();

                    if (targetNum >= attackBtns.Count)
                        targetNum = 0;
                });
            }
        }

        // 시간당 게이지 채우기, 남은 시간 표시
        private void Update()
        {
            // 남은 시간 감소
            leftTime -= Time.deltaTime;

            if (leftTime > 0)
            {
                var ratio = 1.0f - leftTime / coolDownTime;

                foreach (var btn in attackBtns)
                {
                    // 버튼 활성화 여부 확인
                    if (!btn.IsInteractable())
                        continue;

                    // 버튼 비활성화
                    btn.interactable = false;
                }
                
                // 진행바 표시
                foreach (var bar in progressBar)
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
                foreach (var btn in attackBtns)
                    btn.interactable = true;

                foreach (var bar in progressBar)
                    bar.gameObject.SetActive(false);
            }
        }

        // 공격 버튼 OnClick에서 사용
        // ReSharper disable once UnusedMember.Global
        public void OnAttackBtnClick(float maxTime)
        {
            leftTime = maxTime;
            coolDownTime = maxTime;
            
            // 코루틴을 사용한 이유는 증가 시킨 후 다음 프레임에서 스크롤바를 내려야 작동이 되기 때문
            // TODO: 만약 그 프레임에서 즉시 스크롤바를 내릴 수 있다면 아래 코드를 수정할 것 
            StartCoroutine("ScrollDown");
        }
        
        private IEnumerator ScrollDown()
        {
            yield return new WaitForSeconds(0.01f);
            scrollRect.verticalNormalizedPosition = 0f;
        }

        public void OnSettingButtonClick()
        {
            blurPanel.SetActive(true);
            settingPanel.SetActive(true);
        }

        public void OnBackGameButtonClick()
        {
            blurPanel.SetActive(false);
            settingPanel.SetActive(false);
        }
    }
}