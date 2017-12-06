using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace E4lime.LudumDare.Ld40 {

	
	public class HighscoreManager : MonoBehaviour {

		public Highscore[] highscoresList;
		private static HighscoreManager INSTANCE;
		
		
		private void Awake() {
			INSTANCE = this;
		}

		public static void AddNewTime(string username, float time) {
			int fixedtime = int.MaxValue - (int)(time * 1000);
			INSTANCE.StartCoroutine(_UploadNewHighscore(username, fixedtime));
		}

		public static void DownloadHighscores(Text displayHere) {
			INSTANCE.StartCoroutine(_DownloadHighscoresFromDatabase(displayHere));
		}

		private static IEnumerator _UploadNewHighscore(string username, int score) {
			WWW www = new WWW(HighscoreCodes.webURL + HighscoreCodes.privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
			yield return www;

		}

		private static IEnumerator _DownloadHighscoresFromDatabase(Text displayHere) {
			WWW www = new WWW(HighscoreCodes.webURL + HighscoreCodes.publicCode + "/pipe/");
			yield return www;
			if (string.IsNullOrEmpty(www.error))
				FormatHighscores(www.text, displayHere);
		
		}

		private static string[] FormatHighscores(string textStream, Text displayHere) {
			string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
			INSTANCE.highscoresList = new Highscore[entries.Length];
			string[] output = new string[entries.Length];
			for (int i = 0; i < entries.Length; i++) {
				string[] entryInfo = entries[i].Split(new char[] { '|' });
				string username = entryInfo[0];
				int score = int.Parse(entryInfo[1]);
				INSTANCE.highscoresList[i] = new Highscore(username, score);
			}

			displayHere.text = "Highscore (in seconds) \n\n";

			for (int i = 0; i < output.Length; i++) {
				output[i] = INSTANCE.highscoresList[i].username + ": " + ((int.MaxValue - INSTANCE.highscoresList[i].score) / 1000.0) + " s";
			}
			int rank = 1;
			for (int i = 0; i < output.Length; ++i) {
				displayHere.text += rank + ") " + output[i] +"\n";
				rank++;
			}

			if (output.Length == 0) displayHere.text += "No highscore yet";
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