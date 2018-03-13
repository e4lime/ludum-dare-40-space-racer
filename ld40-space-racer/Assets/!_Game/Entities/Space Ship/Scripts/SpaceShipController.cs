using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.SpaceShip {
	public class SpaceShipController : MonoBehaviour {
		
	

		private SpaceShipBehaviour m_SpaceShipBehaviour;

		void Awake(){
			m_SpaceShipBehaviour = GetComponent<SpaceShipBehaviour>();
		}

		void Start() { 
		}

		private void Update() {
#if UNITY_STANDALONE || UNITY_EDITOR
			if (Input.GetButtonDown("MoveLeft")) {
				m_SpaceShipBehaviour.MoveLeft();
			}

			if (Input.GetButtonDown("MoveRight")) {
				m_SpaceShipBehaviour.MoveRight();
			}

#endif

#if UNITY_ANDROID
			foreach (Touch touch in Input.touches) {
				if (touch.phase != TouchPhase.Began)
					return;
				if (touch.position.x < Screen.width / 2) {
					m_SpaceShipBehaviour.MoveLeft();
				}
				else {
					m_SpaceShipBehaviour.MoveRight();
				}
			}
#endif
		}
	}
}
