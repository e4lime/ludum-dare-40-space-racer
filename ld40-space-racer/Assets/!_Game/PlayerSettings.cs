using UnityEngine;

namespace E4lime.LudumDare.Ld40 {
	public class PlayerSettings : MonoBehaviour {


#if UNITY_ANDROID
		void Awake() {


			Application.targetFrameRate = 60;

			QualitySettings.vSyncCount = 0;

			QualitySettings.antiAliasing = 0;


	
			QualitySettings.shadowCascades = 0;
			QualitySettings.shadowDistance = 15;
			


			QualitySettings.shadowCascades = 2;
			QualitySettings.shadowDistance = 70;
			

			Screen.sleepTimeout = SleepTimeout.NeverSleep;


		}

#endif
	}
}
