﻿using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace E4lime.LudumDare.Ld40.SpaceShip {
	public class SpaceShipController : MonoBehaviour {
		
	

		private SpaceShipBehaviour m_SpaceShipBehaviour;

		void Awake(){
			m_SpaceShipBehaviour = GetComponent<SpaceShipBehaviour>();
		}

		void Start() { 
		}

		private void Update() {
		
			if (Input.GetButtonDown("MoveLeft")) {
				m_SpaceShipBehaviour.MoveLeft();
			}

			 if (Input.GetButtonDown("MoveRight")) {
				m_SpaceShipBehaviour.MoveRight();
			}
		}


	}
}
