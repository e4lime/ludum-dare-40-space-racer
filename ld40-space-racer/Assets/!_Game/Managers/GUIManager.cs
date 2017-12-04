using E4lime.LudumDare.Ld40.Components;
using E4lime.LudumDare.Ld40.SpaceShip;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace E4lime.LudumDare.Ld40.GUI {
	public class GUIManager : MonoBehaviour {

		[SerializeField]
		private Text m_HealthDisplay;

		private Health m_PlayerHealth;
		private GameplayManager m_GameplayManager;


		void Awake(){
			m_PlayerHealth = FindObjectOfType<SpaceShipBehaviour>().GetComponent<Health>();
			m_GameplayManager = FindObjectOfType<GameplayManager>();
		}

		private void OnGUI() {
			UpdateHealth();
		}

		private void UpdateHealth() {
			m_HealthDisplay.text = "Health: " + Mathf.Max(0, m_PlayerHealth.HealthValue);
		}

	}
}
