using System.Collections;

using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

using E4lime.LudumDare.Ld40.Lanes;

namespace E4lime.LudumDare.Ld40.SpaceShip {
	public class SpaceShipBehaviour : MonoBehaviour {


		[SerializeField]
		private Transform m_GroundRaycasterOrigin;

		[SerializeField]
		private float m_MaxSpeed = 2f;

		[SerializeField]
		private float m_DistanceToGround = 0.5f;


		[Header("Horizontal Tween"),SerializeField]
		private float m_HoriTweenDuration = 1f;

		[SerializeField]
		private Ease m_HoriTweenEase;
		

		private Rigidbody m_Rigidbody;
		private Transform m_Transform;
		

		private LanesManager m_LanesManager;

		private Vector3 m_NextPosition;


		void Awake(){
			m_Rigidbody = GetComponent<Rigidbody>();
			
			m_Transform = transform;
			m_LanesManager = FindObjectOfType<LanesManager>();

			m_NextPosition = m_Transform.position;

		}

		void FixedUpdate() {


			//Vector3 yPos = currentShipPosition - Vector3.up * m_DistanceToGround; 
			MoveForward();

			m_Rigidbody.MovePosition(m_NextPosition);
		}

		private void MoveForward() {
			Vector3 currentShipPosition = m_Rigidbody.transform.position;

			Vector3 forwardPosition = currentShipPosition + Vector3.forward * m_MaxSpeed * Time.fixedDeltaTime;

			m_NextPosition = new Vector3(m_NextPosition.x, m_NextPosition.y, forwardPosition.z);
		}

		public void MoveLeft() {
			MoveHorizontalTo(m_LanesManager.MoveOneToLeft());
		}

		public void MoveRight() {
			MoveHorizontalTo(m_LanesManager.MoveOneToRight());
		}

		
		private void MoveHorizontalTo(Transform destination) {

			// On edge if null
			if (destination != null) {
				DOTween.To(TweenHorizontal,m_Rigidbody.transform.position.x, destination.position.x, m_HoriTweenDuration)
					.SetEase(m_HoriTweenEase);	
			}
		}

		private void TweenHorizontal(float xVal) {
			m_NextPosition = new Vector3(xVal, m_NextPosition.y, m_NextPosition.z);
		}
	}
}
