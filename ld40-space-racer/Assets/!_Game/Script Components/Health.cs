using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.Components {
	public class Health : MonoBehaviour {
		
		[SerializeField]
		private float m_Health = 100f;

		public float HealthValue {
			get { return m_Health; }
			set { m_Health = value; }
		}
	}
}
