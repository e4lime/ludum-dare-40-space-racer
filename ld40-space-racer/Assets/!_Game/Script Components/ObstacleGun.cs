using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.SpaceShip {
	public class ObstacleGun : MonoBehaviour {
		
		[SerializeField]
		private Transform m_ObstacleToLaunch;

		[SerializeField]
		private Transform m_InstantiatedObjects;

		private Rigidbody m_Rigidbody;
		private Transform m_Transform;

		void Awake(){
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Transform = transform;
		}

		void Start() { 
		}

		private void Update() {
			if (Input.GetButtonDown("FireLauncher")) {
				Instantiate(m_ObstacleToLaunch,this.m_Transform.position + Vector3.forward * 130,Quaternion.identity,m_InstantiatedObjects);
			}
		}
	}
}
