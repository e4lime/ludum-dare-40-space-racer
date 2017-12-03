﻿using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.Components {
	public class FollowTargetZ_Axis : MonoBehaviour {
		
		[SerializeField]
		private Rigidbody m_TargetToFollow;

		[SerializeField]
		private float m_Damp = 0.3f;

		private Transform m_Transform;
		private Vector3 m_Offset;

		private Vector3 m_Velocity;
		void Awake(){
			m_Transform = transform;
			m_Offset = m_Transform.position - m_TargetToFollow.transform.position;
		}

		private void LateUpdate() {
			Vector3 targetPos = new Vector3(m_Transform.position.x, m_Transform.position.y, m_TargetToFollow.position.z + m_Offset.z );
			m_Transform.position = Vector3.SmoothDamp(m_Transform.position, targetPos, ref m_Velocity, m_Damp);
		}
	}
}
