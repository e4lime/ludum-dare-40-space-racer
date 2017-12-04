using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40 {
	public class PlayAudioManager : MonoBehaviour {
		private static PlayAudioManager INSTANCE;

		[SerializeField]
		private AudioClip[] m_HitIncrease;

		[SerializeField]
		private AudioClip[] m_HitDecrease;

		[SerializeField]
		private AudioClip m_Gameover;

		[SerializeField]
		private AudioClip m_Goal;

		[SerializeField]
		private float m_Volume = 1f;

	
		private AudioSource m_Source;


		private bool m_Mute = false;
		private float m_PrevMuteVolume = 0;


	
	

		void Awake() {
			INSTANCE = this;
			m_Source = FindObjectOfType<AudioSource>();
		}


		public static void PlayHitIncrease() {
			AudioClip rand = INSTANCE.m_HitIncrease[Random.Range(0, INSTANCE.m_HitIncrease.Length)];
			Play(rand);
		}

		public static void PlayHitDecrease() {
			AudioClip rand = INSTANCE.m_HitDecrease[Random.Range(0, INSTANCE.m_HitDecrease.Length)];
			Play(rand);
		}

		public static void PlayGameover() {
			AudioClip rand = INSTANCE.m_Gameover;
			Play(rand);
		}

		public static void PlayGoal() {
			AudioClip rand = INSTANCE.m_Goal;
			Play(rand);
		}

		private static void Play(AudioClip clip) {
			INSTANCE.m_Source.PlayOneShot(clip, INSTANCE.m_Volume);
		}


		private void Update() {
			if (Input.GetButtonDown("Mute")) {
				m_Mute = !m_Mute;
				if (m_Mute) {
					m_PrevMuteVolume = m_Volume;
					m_Volume = 0;

				}
				else {
					m_Volume = m_PrevMuteVolume;
				}
			}
		}
	}
}
