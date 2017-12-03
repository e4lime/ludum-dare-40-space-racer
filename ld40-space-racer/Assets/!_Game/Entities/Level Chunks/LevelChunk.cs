using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.InfiniteLevel {
	public class LevelChunk : MonoBehaviour {
		
		[SerializeField]
		private float m_ZLengthOfChunk = 10f;

		private Rigidbody m_Rigidbody;
		private Transform m_Transform;

		void Awake(){
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Transform = transform;
		}



		public float GetZLength() {
			return m_ZLengthOfChunk;
		}
	}
}
