using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using E4lime.LudumDare.Ld40.Lanes;
using E4lime.LudumDare.Ld40.SpaceShip;


namespace E4lime.LudumDare.Ld40.Level {
	public class ObjectSpawner : MonoBehaviour {
		

		[SerializeField]
		private Transform m_DecreaseHealthObstacle;

		[SerializeField]
		private Transform m_IncreaseHealthObstacle;

		[SerializeField]
		private float m_MinSpawnInterval;

		[SerializeField]
		private float m_SpawnDistanceFromShip = 100;

		[SerializeField]
		private float m_DeSpawnDistanceFromShip = -20;

		[SerializeField, Header("Minumum spawned health decrease objects before an increase can spawn")]
		private int m_MinDecreaseObstaclesBeforeIncrease = 15;
		[SerializeField]
		private int m_SpawnIncreaseHealthRandomRangeStart = 0;
		[SerializeField]
		private int m_SpawnIncreaseHealthRandomRangEnd = 15;

		private Rigidbody m_Rigidbody;
		private Transform m_Transform;

		

		private LanesManager m_LanesManager;
		private Transform m_SpaceShipBehaviourTransform;

		private Queue<Transform> m_SpawnedObjects;
		private Vector3[] m_LanePositions;

		private Vector3 m_LastSpawnedPosition = Vector3.zero;
		private int m_SpawnsSinceLastIncrease = 0;
		private int m_NextHealthSpawn = -1;

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
				Spawn(m_DecreaseHealthObstacle);
				m_SpawnsSinceLastIncrease++;
				Debug.Log(m_NextHealthSpawn + " " + m_SpawnsSinceLastIncrease + " " + m_MinDecreaseObstaclesBeforeIncrease);
				if (m_SpawnsSinceLastIncrease >= m_MinDecreaseObstaclesBeforeIncrease && m_NextHealthSpawn == -1) {
					m_NextHealthSpawn = Random.Range(m_SpawnIncreaseHealthRandomRangeStart, m_SpawnIncreaseHealthRandomRangEnd);
					Debug.Log(m_NextHealthSpawn);
				}
				else if ( m_NextHealthSpawn != -1 && m_SpawnsSinceLastIncrease == m_MinDecreaseObstaclesBeforeIncrease + m_NextHealthSpawn) {
					Spawn(m_IncreaseHealthObstacle);
					m_SpawnsSinceLastIncrease = 0;
					m_NextHealthSpawn = -1;
				}
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
			Vector3 lane;
			Vector3 spawnPos;

			// Avoid spawning on same column when multiple spawnes on one row
			do {
				lane  = m_LanePositions[Random.Range(0, m_LanePositions.Length)];
				spawnPos   = new Vector3(lane.x, lane.y, m_SpaceShipBehaviourTransform.position.z + m_SpawnDistanceFromShip);
			} while (spawnPos.z == m_LastSpawnedPosition.z && spawnPos.x == m_LastSpawnedPosition.x);
		
			Transform spawned = Instantiate(toSpawn, spawnPos, Quaternion.identity, m_Transform);
			m_SpawnedObjects.Enqueue(spawned);
			m_LastSpawnedPosition = spawnPos;
		}

		
	}
}
