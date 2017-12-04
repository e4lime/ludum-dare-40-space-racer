using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using E4lime.LudumDare.Ld40.Lanes;
using E4lime.LudumDare.Ld40.SpaceShip;


namespace E4lime.LudumDare.Ld40.Level {
	public class ObjectSpawner : MonoBehaviour {
		

		[SerializeField]
		private Transform m_Obstacle;

		[SerializeField]
		private Transform m_Health;

		[SerializeField]
		private float m_MinSpawnInterval;

		[SerializeField]
		private float m_SpawnDistanceFromShip = 100;

		[SerializeField]
		private float m_DeSpawnDistanceFromShip = -20;


		private Rigidbody m_Rigidbody;
		private Transform m_Transform;

		

		private LanesManager m_LanesManager;
		private Transform m_SpaceShipBehaviourTransform;

		private Queue<Transform> m_SpawnedObjects;
		private Vector3[] m_LanePositions;

		private Vector3 m_LastSpawnedPosition = Vector3.zero;

		void Awake(){
			m_Rigidbody = GetComponent<Rigidbody>();
			m_Transform = transform;
			m_SpawnedObjects = new Queue<Transform>();
			m_LanesManager = FindObjectOfType<LanesManager>();
			m_SpaceShipBehaviourTransform = FindObjectOfType<SpaceShipBehaviour>().transform;
		}

		void Start() {
			m_LanePositions = m_LanesManager.GetLanePositions();
		}

		private void Update() {
			SpawnProcess();
			DeSpawnProcess();
		}


		private void SpawnProcess() {

			if (m_LastSpawnedPosition.z < m_SpaceShipBehaviourTransform.position.z + m_SpawnDistanceFromShip - m_MinSpawnInterval) {
				Spawn(m_Obstacle);
			}
		}

		private void DeSpawnProcess() {
			if (m_SpawnedObjects.Count == 0) return;

			Transform peeked = m_SpawnedObjects.Peek();

			// Null if player hits object before it dequeue
			if (peeked == null) {
				m_SpawnedObjects.Dequeue();
			}
			else if (peeked.position.z < m_SpaceShipBehaviourTransform.position.z + m_DeSpawnDistanceFromShip) {
				
				Transform toRemove = m_SpawnedObjects.Dequeue();
				Destroy(toRemove.gameObject);
			}
		}

		private void Spawn(Transform toSpawn) {
			
			Vector3 lane = m_LanePositions[Random.Range(0, m_LanePositions.Length)];
			Vector3 spawnPos = new Vector3(lane.x, lane.y, m_SpaceShipBehaviourTransform.position.z + m_SpawnDistanceFromShip);

			Transform spawned = Instantiate(toSpawn, spawnPos, Quaternion.identity, m_Transform);
			if (spawned == null) Debug.Log("Added null");
			m_SpawnedObjects.Enqueue(spawned);
			m_LastSpawnedPosition = spawnPos;
		}

		
	}
}
