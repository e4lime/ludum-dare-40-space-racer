using System.Collections;

using System.Collections.Generic;
using UnityEngine;

using E4lime.LudumDare.Ld40.Lanes;

namespace E4lime.LudumDare.Ld40.SpaceShip {
	public class SpaceShipBehaviour : MonoBehaviour {

		[SerializeField]
		private LanesManager m_LanesManager;

		[SerializeField]
		private Transform m_GroundRaycasterOrigin;

		[SerializeField]
		private float m_MaxSpeed = 2f;

		[SerializeField]
		private float m_DistanceToGround = 0.5f;

		private Rigidbody m_Rigidbody;
		private Transform m_Transform;

		private Vector3 m_NextPosition;


		void Awake(){
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Transform = transform;
			m_NextPosition = m_Transform.position;
			m_LanesManager = FindObjectOfType<LanesManager>();
		}

		void FixedUpdate() {


			//Vector3 yPos = currentShipPosition - Vector3.up * m_DistanceToGround; 
			MoveForward();

			m_Rigidbody.MovePosition(m_NextPosition);
		}

		private void MoveForward() {
			Vector3 currentShipPosition = m_Rigidbody.transform.position;

			Vector3 forwardPosition = currentShipPosition + Vector3.forward * m_MaxSpeed * Time.fixedDeltaTime;

			m_NextPosition = forwardPosition;
		}

		public void MoveLeft() {
			m_LanesManager.GetLeftLane();
		}

		public void MoveRight() {
			m_LanesManager.GetRightLane();
		}
	}
}
