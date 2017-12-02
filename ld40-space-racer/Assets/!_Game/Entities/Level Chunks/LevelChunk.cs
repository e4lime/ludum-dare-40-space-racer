using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.InfiniteLevel {
	public class LevelChunk : MonoBehaviour {
		
		[SerializeField]
		private bool m_Foo = true;

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
