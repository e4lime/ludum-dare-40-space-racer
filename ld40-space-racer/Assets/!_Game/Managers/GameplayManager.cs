using E4lime.LudumDare.Ld40.SpaceShip;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using E4lime.LudumDare.Ld40.Components;
namespace E4lime.LudumDare.Ld40 {
	public class GameplayManager : MonoBehaviour {
		
	

		private SpaceShipBehaviour m_SpaceShipBehaviour;
		private Health m_PlayerHealth;

		void Awake(){
			m_SpaceShipBehaviour = FindObjectOfType<SpaceShipBehaviour>();
			m_PlayerHealth = m_SpaceShipBehaviour.GetComponent<Health>();
		}

		void Update() { 
			if (m_PlayerHealth.HealthValue <= 0) {
				GameOver();
			}
		}

		private void GameOver() {
			Destroy(this.m_SpaceShipBehaviour.gameObject);
		}
	}
}
