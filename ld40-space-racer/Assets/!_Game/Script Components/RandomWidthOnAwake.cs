using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.Components {
	public class RandomWidthOnAwake : MonoBehaviour {
		
	
		private float m_WidthRangeMax = 3f;

		void Start(){
			float newX = Random.Range(transform.localScale.x, transform.localScale.x + m_WidthRangeMax);
			transform.localScale = new Vector3(newX, transform.localScale.y, transform.localScale.z );
			Debug.Log(newX);	
		}

	}
}
