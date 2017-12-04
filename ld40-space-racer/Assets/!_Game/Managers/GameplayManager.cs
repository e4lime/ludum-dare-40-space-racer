using E4lime.LudumDare.Ld40.SpaceShip;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using E4lime.LudumDare.Ld40.Components;
using E4lime.LudumDare.Ld40.InfiniteLevel;
using E4lime.LudumDare.Ld40.Level;
using UnityEngine.SceneManagement;

namespace E4lime.LudumDare.Ld40 {
	public class GameplayManager : MonoBehaviour {
		
	

		private SpaceShipBehaviour m_SpaceShipBehaviour;
		private Transform m_SpaceShipBehaviourTransform;
		private Health m_PlayerHealth;
		private InfiniteLevelManager m_InfiniteLevelManager;
		private ObjectSpawner m_ObjectSpawner;
		private State m_State;

		[SerializeField,Range (0, 100)]
		private float m_SpaceShipMaximumSpeed = 70;
		[SerializeField, Range(0, 100)]
		private float m_SpaceShipMinimumSpeed = 5;

		private Vector3 m_SpaceShipStartLocation;


		public enum State {
			Running,
			GameOver
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
						}
						break;
					case State.GameOver:
						switch (value) {
							case State.Running:

								break;
							case State.GameOver:

								break;
						}
						break;
				}
				m_State = value;
			}
		}

		void Awake(){
			m_SpaceShipBehaviour = FindObjectOfType<SpaceShipBehaviour>();
			m_PlayerHealth = m_SpaceShipBehaviour.GetComponent<Health>();
			m_SpaceShipBehaviourTransform = m_SpaceShipBehaviour.transform;
			m_InfiniteLevelManager = FindObjectOfType<InfiniteLevelManager>();
			m_ObjectSpawner = FindObjectOfType<ObjectSpawner>();

			m_State = State.Running;
		}

		private void Start() {
			m_SpaceShipStartLocation = m_SpaceShipBehaviour.transform.position;
		}

		void Update() {
			if (CurrentState == State.Running) {
				AdjustDifficulty();

				if (m_PlayerHealth.HealthValue <= 0) {
					CurrentState = State.GameOver;
				}
			}
		}

		public float DistanceTravelled() {
			return m_SpaceShipBehaviourTransform.position.z - m_SpaceShipStartLocation.z;
		}

		private void AdjustDifficulty() {
			float correctedSpeed = Mathf.Lerp(m_SpaceShipMaximumSpeed, m_SpaceShipMinimumSpeed, m_PlayerHealth.HealthValue/100);
			m_SpaceShipBehaviour.SetMaxSpeed(correctedSpeed);
		}

		private void GameOver() {

			m_InfiniteLevelManager.PauseProcess = true;
			m_ObjectSpawner.PauseProcess = true;
			SceneManager.LoadScene(0);
			Destroy(this.m_SpaceShipBehaviour.gameObject);
		}
	}
}
