using E4lime.LudumDare.Ld40.Components;
using E4lime.LudumDare.Ld40.SpaceShip;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.Level {
	public class Obstacle : MonoBehaviour {



		private Health m_HealthToAddOnHit;

		void Awake(){

			m_HealthToAddOnHit = GetComponent<Health>();
		}

		void Start() { 
		}

		void OnTriggerEnter(Collider other) {
			SpaceShipBehaviour player = other.gameObject.GetComponent<SpaceShipBehaviour>();
			if (player != null) {
				HitPlayer(player);
			}
		}

		private void HitPlayer(SpaceShipBehaviour player) {
			Health playerHealth = player.GetComponent<Health>();
			if (m_HealthToAddOnHit.HealthValue > 0) {
				PlayAudioManager.PlayHitIncrease();
			} else {
				PlayAudioManager.PlayHitDecrease();
			}
			playerHealth.HealthValue += m_HealthToAddOnHit.HealthValue;
			Destroy(this.gameObject);
		}
	}
}
