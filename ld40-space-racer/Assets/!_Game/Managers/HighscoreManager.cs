using UnityEngine;
using System.Collections;
namespace E4lime.LudumDare.Ld40 {

	
	public class HighscoreManager : MonoBehaviour {

		public Highscore[] highscoresList;
		private static HighscoreManager INSTANCE;

		private void Awake() {
			INSTANCE = this;
		}

		private void Start() {
			DownloadHighscores();
		}
		public static void AddNewHighscore(string username, int score) {
			INSTANCE.StartCoroutine(_UploadNewHighscore(username, score));
		}

		public static void DownloadHighscores() {
			INSTANCE.StartCoroutine(_DownloadHighscoresFromDatabase());
		}

		private static IEnumerator _UploadNewHighscore(string username, int score) {
			WWW www = new WWW(HighscoreCodes.webURL + HighscoreCodes.privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
			yield return www;

		}

		private static IEnumerator _DownloadHighscoresFromDatabase() {
			WWW www = new WWW(HighscoreCodes.webURL + HighscoreCodes.publicCode + "/pipe/");
			yield return www;
			if (string.IsNullOrEmpty(www.error))
				foreach (string s in FormatHighscores(www.text))
					Debug.Log(s);
			else {
				Debug.Log("Error Downloading: " + www.error);
			}
		}

		private static string[] FormatHighscores(string textStream) {
			string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
			INSTANCE.highscoresList = new Highscore[entries.Length];
			string[] output = new string[entries.Length];
			for (int i = 0; i < entries.Length; i++) {
				string[] entryInfo = entries[i].Split(new char[] { '|' });
				string username = entryInfo[0];
				int score = int.Parse(entryInfo[1]);
				INSTANCE.highscoresList[i] = new Highscore(username, score);
			}

			for (int i = 0; i < output.Length; i++) {
				output[i] = INSTANCE.highscoresList[i].username + ": " + INSTANCE.highscoresList[i].score;
			}
			return output;
		}
	}

	public struct Highscore {
		public string username;
		public int score;

		public Highscore(string username, int score) {
			this.username = username;
			this.score = score;
		}
	}
}