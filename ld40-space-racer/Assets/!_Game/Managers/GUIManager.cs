using E4lime.LudumDare.Ld40.Components;
using E4lime.LudumDare.Ld40.SpaceShip;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using E4lime.LudumDare.Ld40.InfiniteLevel;

namespace E4lime.LudumDare.Ld40.GUI {
	public class GUIManager : MonoBehaviour {

		[SerializeField]
		private Text m_HealthDisplay;

		[SerializeField]
		private Text m_TimerDisplay;

		[SerializeField]
		public Text m_DistanceLeftDisplay;

		[SerializeField]
		private GameObject m_HighscoreGUI;

		[SerializeField]
		private GameObject m_SubmitHighscoreGUI;

		[SerializeField]
		private Text m_HighScoreText;

		[SerializeField]
		public InputField m_SubmitHighscoreNameField;

		[SerializeField]
		public Button m_RefreshListButton;


		private Health m_PlayerHealth;
		private GameplayManager m_GameplayManager;
		private InfiniteLevelManager m_InfiniteLevelManager;

		void Awake() {
			SpaceShipBehaviour spaceship = FindObjectOfType<SpaceShipBehaviour>();
			if (spaceship != null) m_PlayerHealth = spaceship.GetComponent<Health>();
			m_GameplayManager = FindObjectOfType<GameplayManager>();
			m_InfiniteLevelManager = FindObjectOfType<InfiniteLevelManager>();
		}

		private void OnGUI() {
			UpdateHealth();
			UpdateTimer();
			UpdateDistanceLeft();
		}

		
		private void UpdateTimer() {
			m_TimerDisplay.text = string.Format("{0:#,0.000}", m_GameplayManager.TimeTaken);

		}

		private void UpdateHealth() {
			m_HealthDisplay.text = "Health: " + Mathf.Max(0, m_PlayerHealth.HealthValue);
		}

		private void UpdateDistanceLeft() {
			m_DistanceLeftDisplay.text = "" + (int)(Math.Max(0, m_InfiniteLevelManager.GetDistanceToGoal() - m_GameplayManager.DistanceTravelled() + 300));
		}


		public void ShowSubmitScore() {
			m_HighscoreGUI.SetActive(true);
			m_SubmitHighscoreGUI.SetActive(true);
			HighscoreManager.DownloadHighscores(m_HighScoreText);
			m_RefreshListButton.gameObject.SetActive(false);
		}

		public void ShowHighscore() {
			m_HighscoreGUI.SetActive(true);
			HighscoreManager.DownloadHighscores(m_HighScoreText);
			m_RefreshListButton.gameObject.SetActive(true);

		}

		public void OnRefreshList() {
			m_HighScoreText.text = "Refreshing...";
			m_RefreshListButton.interactable = false;
			HighscoreManager.DownloadHighscores(m_HighScoreText);
			StartCoroutine(_RenableRefreshButton());
		}

		private IEnumerator _RenableRefreshButton() {
			yield return new WaitForSeconds(5);
			m_RefreshListButton.interactable = true;
			
		}

		public void OnSubmitHighscore() {
			string trimmed = m_SubmitHighscoreNameField.text.Trim();
			if (trimmed == "") return;
			SubmitHighscore(trimmed, m_GameplayManager.TimeTaken);
		}

		private void SubmitHighscore(string name, float time) {
			HighscoreManager.AddNewTime(name, time);
			m_SubmitHighscoreGUI.SetActive(false);
			m_RefreshListButton.gameObject.SetActive(true);
			ShowHighscore();
		}
	}
}
