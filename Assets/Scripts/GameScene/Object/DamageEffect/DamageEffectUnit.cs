using UnityEngine;

namespace GameScene.DamageEffect
{
    public class DamageEffectUnit : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Animator animator;
        private AnimatorStateInfo animatorStateInfo;

        private float speed;

        [HideInInspector] 
        private const int damage = 5;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            animator = GetComponent<Animator>();

            var newScale = Random.Range(0.75f, 1f);
            rectTransform.localScale = new Vector3(newScale, newScale);

            animator.speed = Random.Range(0.5f, 1f);
        }

        private void Update()
        {
            animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (animatorStateInfo.normalizedTime >= 1.0f)
            {
                CharacterManager.Instance.receiver.hp -= damage;
                CharacterManager.Instance.receiver.hpText.text = CharacterManager.Instance.receiver.hp.ToString() + "%";
                Destroy(gameObject);
            }
        }
    }
}