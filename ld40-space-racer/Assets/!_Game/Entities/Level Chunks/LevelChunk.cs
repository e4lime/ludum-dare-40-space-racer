using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.InfiniteLevel {
	public class LevelChunk : MonoBehaviour {
		
		[SerializeField]
		private float m_ZLengthOfChunk = 10f;



		public float GetZLength() {
			return m_ZLengthOfChunk;
		}
	}
}
