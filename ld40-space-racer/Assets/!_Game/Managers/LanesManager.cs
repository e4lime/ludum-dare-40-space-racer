using UnityEngine;
using System.Collections;

namespace E4lime.LudumDare.Ld40.Lanes {
	public class LanesManager : MonoBehaviour {

		[SerializeField]
		private Transform[] m_Lanes;

		private int m_CurrentLaneIndex;

		void Awake() {
			m_CurrentLaneIndex = 1;
		}

		public Transform GetLeftLane() {
			--m_CurrentLaneIndex;
			if (m_CurrentLaneIndex < 0) {
				m_CurrentLaneIndex = 0;
				return null;
			}
	
			return m_Lanes[m_CurrentLaneIndex];
		}

		public Transform GetRightLane() {
			
			++m_CurrentLaneIndex;
			if (m_CurrentLaneIndex >= m_Lanes.Length) {
				m_CurrentLaneIndex = m_Lanes.Length-1;
				return null;
			}
		
			return m_Lanes[m_CurrentLaneIndex];
		}

	}
}
