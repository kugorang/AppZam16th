using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class GameManager : SingleTon<GameManager>
    {
        //사운드
        public AudioClip audioClip;
        private AudioSource audioSource;

        //엔딩 관련
        [HideInInspector] public EndingType endingType;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
        }
	}
}