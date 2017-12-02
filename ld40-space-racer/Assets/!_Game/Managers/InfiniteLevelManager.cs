using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.InfiniteLevel {
	public class InfiniteLevelManager : MonoBehaviour {

		[SerializeField]
		private LevelChunk[] m_LevelChunks;

		private Rigidbody m_Rigidbody;
		private Transform m_Transform;

		

		void Awake(){
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Transform = transform;
		}

		void Start() { 
		}

	}
}
