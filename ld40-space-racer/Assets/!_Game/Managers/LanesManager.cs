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

		public Transform MoveOneToLeft() {
			--m_CurrentLaneIndex;
			if (m_CurrentLaneIndex < 0) {
				m_CurrentLaneIndex = 0;
				return null;
			}
	
			return m_Lanes[m_CurrentLaneIndex];
		}

		public Transform MoveOneToRight() {
			
			++m_CurrentLaneIndex;
			if (m_CurrentLaneIndex >= m_Lanes.Length) {
				m_CurrentLaneIndex = m_Lanes.Length-1;
				return null;
			}
		
			return m_Lanes[m_CurrentLaneIndex];
		}

		public Vector3[] GetLanePositions() {
			Vector3[] vectors = new Vector3[m_Lanes.Length];
			for (int i = 0; i < m_Lanes.Length; ++i) {
				vectors[i] = m_Lanes[i].position;
			}
			return vectors;
		}
	}
}
