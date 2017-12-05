using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace E4lime.LudumDare.Ld40.GUI {
	public class Buttons : MonoBehaviour {

		[SerializeField]
		public GameObject m_HideOnContinue;

		[SerializeField]
		public GameObject m_ShowOnContinue;

		public void OnContinue() {
			m_HideOnContinue.SetActive(false);
			m_ShowOnContinue.SetActive(true);
		}

		public void OnStartGame() {
			SceneManager.LoadScene(1);
		}

	}
}
