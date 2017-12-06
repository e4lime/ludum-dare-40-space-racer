using E4lime.LudumDare.Ld40.SpaceShip;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using E4lime.LudumDare.Ld40.Components;
using E4lime.LudumDare.Ld40.InfiniteLevel;
using E4lime.LudumDare.Ld40.Level;
using UnityEngine.SceneManagement;
using System;
using E4lime.LudumDare.Ld40.GUI;

namespace E4lime.LudumDare.Ld40 {
	public class GameplayManager : MonoBehaviour {
		
	

	


		[SerializeField,Range (0, 100)]
		private float m_SpaceShipMaximumSpeed = 70;
		[SerializeField, Range(0, 100)]
		private float m_SpaceShipMinimumSpeed = 5;


		private SpaceShipBehaviour m_SpaceShipBehaviour;
		private Transform m_SpaceShipBehaviourTransform;
		private Health m_PlayerHealth;
		private InfiniteLevelManager m_InfiniteLevelManager;
		private ObjectSpawner m_ObjectSpawner;
		private State m_State;
		private GUIManager m_GUIManager;

		private Vector3 m_SpaceShipStartLocation;
		private bool m_PlayerReachedGoal = false;

		public float TimeTaken { get; set; }


		public enum State {
			Running,
			GameOver,
			EndScreen
		}



		public State CurrentState {
			get { return m_State; }
			private set {
				switch (m_State) {
					case State.Running:
						switch (value) {
							case State.Running:

								break;
							case State.GameOver:
								GameOver();
								break;
							case State.EndScreen:
								ShowHighscore();
								break;
						}
					break;
					case State.GameOver:
						switch (value) {
							case State.Running:

								break;
							case State.GameOver:

								break;
							case State.EndScreen:

								break;
						}
					break;
					case State.EndScreen:
						switch (value) {
							case State.Running:

								break;
							case State.GameOver:

								break;
							case State.EndScreen:

								break;
						}
					break;
				}
				m_State = value;
			}
		}

		private void ShowHighscore() {
			m_GUIManager.ShowSubmitScore();
			PlayAudioManager.PlayGoal();
		}

		public void PlayerReachedGoal() {
			m_PlayerReachedGoal = true;
		}

		void Awake(){
			m_SpaceShipBehaviour = FindObjectOfType<SpaceShipBehaviour>();
			m_PlayerHealth = m_SpaceShipBehaviour.GetComponent<Health>();
			m_SpaceShipBehaviourTransform = m_SpaceShipBehaviour.transform;
			m_InfiniteLevelManager = FindObjectOfType<InfiniteLevelManager>();
			m_ObjectSpawner = FindObjectOfType<ObjectSpawner>();
			m_GUIManager = FindObjectOfType<GUIManager>();
			m_State = State.Running;
		}

		private void Start() {
			m_SpaceShipStartLocation = m_SpaceShipBehaviour.transform.position;
			TimeTaken = 990f;
		}

		void Update() {
			if (CurrentState == State.Running) {
				TimeTaken += Time.deltaTime;
				TimeTaken = Mathf.Min(TimeTaken, 999.999f);

				if (m_PlayerReachedGoal) {
					CurrentState = State.EndScreen;
				}
				else if (m_PlayerHealth.HealthValue <= 0) {
					CurrentState = State.GameOver;
				}
				else {
					AdjustDifficulty();
				}
			}
		}

		private float lastKnownShipZ = 0f;
		public float DistanceTravelled() {
			if (m_SpaceShipBehaviourTransform != null) lastKnownShipZ = m_SpaceShipBehaviourTransform.position.z;
			return lastKnownShipZ - m_SpaceShipStartLocation.z;
		}

		private void AdjustDifficulty() {
			float correctedSpeed = Mathf.Lerp(m_SpaceShipMaximumSpeed, m_SpaceShipMinimumSpeed, m_PlayerHealth.HealthValue/100);
			m_SpaceShipBehaviour.SetMaxSpeed(correctedSpeed);
		}

		private void GameOver() {

			m_InfiniteLevelManager.PauseProcess = true;
			m_ObjectSpawner.PauseProcess = true;
			PlayAudioManager.PlayGameover();
			m_GUIManager.ShowHighscore();
			//SceneManager.LoadScene(0);
			Destroy(this.m_SpaceShipBehaviour.gameObject);
		}
	}
}
