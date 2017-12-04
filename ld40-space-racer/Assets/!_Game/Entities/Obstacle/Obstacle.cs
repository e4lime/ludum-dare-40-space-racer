using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.Level {
	public class Obstacle : MonoBehaviour {

		private Rigidbody m_Rigidbody;
		private Transform m_Transform;

		void Awake(){
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Transform = transform;
		}

		void Start() { 
		}

		void OnTriggerEnter(Collider other) {
			if (other.CompareTag("Player")) { 
				Destroy(this.gameObject);
			}
		}
	}
}
