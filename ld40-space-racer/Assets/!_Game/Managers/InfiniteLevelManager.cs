﻿using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using E4lime.LudumDare.Ld40.SpaceShip;
using E4lime.LudumDare.Ld40.Level;

namespace E4lime.LudumDare.Ld40.InfiniteLevel {
	public class InfiniteLevelManager : MonoBehaviour {

		[SerializeField]
		private LevelChunk[] m_LevelChunks;

		[SerializeField]
		private int m_MaxLoadedChunks = 10;

		[SerializeField]
		private LevelChunk[] m_GoalChunk;

		[SerializeField]
		private float m_DistanceToGoal = 2500;

		private Transform m_Transform;
		private Transform m_SpaceShipBehaviourTransform;
		private GameplayManager m_GameplayManager;
		private ObjectSpawner m_ObjectSpawner;

		private float m_NextChunkPositionZ;
		private float m_LastCreatedChunkLength = 0;
		private int m_CurrentlyLoadedChunks = 0;
		private int m_TotalCreatedChunks = 0;

		public bool PauseProcess { get; set; }

		void Awake() {
			m_Transform = transform;
			m_SpaceShipBehaviourTransform = FindObjectOfType<SpaceShipBehaviour>().transform;
			m_GameplayManager = FindObjectOfType<GameplayManager>();
			m_NextChunkPositionZ = 0;
			m_ObjectSpawner = FindObjectOfType<ObjectSpawner>();
		}

		void Start() {
			while (m_CurrentlyLoadedChunks < m_MaxLoadedChunks) {
				CreateChunk();
			}
		}

		private void Update() {

			if (PauseProcess) return;

			LevelChunk chunk = m_Transform.GetChild(0).GetComponent<LevelChunk>();

			if (m_SpaceShipBehaviourTransform.position.z > chunk.transform.position.z + (chunk.GetZLength() * 2)) {
				Destroy(chunk.gameObject);
				m_CurrentlyLoadedChunks--;
			}
			if (m_CurrentlyLoadedChunks < m_MaxLoadedChunks) {
				if (m_DistanceToGoal < m_GameplayManager.DistanceTravelled()) {
					PauseProcess = true;
					m_ObjectSpawner.PauseProcess = true;
					CreateGoalChunk();
				}
				else {
					CreateChunk();
				}
			}
		}

		private void CreateGoalChunk() {
			LevelChunk chunk = Instantiate(m_GoalChunk[Random.Range(0, m_GoalChunk.Length)], createNextVector3(), Quaternion.identity, m_Transform);
			m_LastCreatedChunkLength = chunk.GetZLength();
			m_CurrentlyLoadedChunks++;
			m_TotalCreatedChunks++;
			chunk.name += " " + m_TotalCreatedChunks;
		}

		private void CreateChunk() {
			LevelChunk chunk = Instantiate(m_LevelChunks[Random.Range(0, m_LevelChunks.Length)], createNextVector3(), Quaternion.identity, m_Transform);
			m_LastCreatedChunkLength = chunk.GetZLength();
			m_CurrentlyLoadedChunks++;
			m_TotalCreatedChunks++;
			chunk.name += " " + m_TotalCreatedChunks;
		}
		private Vector3 createNextVector3() {
			m_NextChunkPositionZ += m_LastCreatedChunkLength;
			return new Vector3(m_Transform.position.x, m_Transform.position.y, m_NextChunkPositionZ);
		}

		public float GetDistanceToGoal() {
			return m_DistanceToGoal;
		}

	}
}
