using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public class SpawnerVehicles : MonoBehaviour
    {
        [SerializeField] private Vehicles[] _prefabVechicles;
        [SerializeField] private Transform[] _spawnPlace;

        [SerializeField] private float _timeRespawn;
        [SerializeField] private float _timeIntervalSpawn;
        [SerializeField] private int _maxRespawnVechicles;
        [SerializeField] private Transform[] _targetMove;

        private List<Vehicles> _listVehicles;


        private Timer _timeRespawnTimer;
        private Timer _timeIntervalSpawnTimer;



        private void Start () 
        {
            InitTimers();
           _listVehicles = new List<Vehicles>();
            SpawnVehicle();
        }

        private void Update()
        {
            UpdateTimers();
            if(_timeIntervalSpawnTimer.IsFinished == true && _listVehicles.Count < _maxRespawnVechicles)
                 SpawnVehicle();
        }

        private void SpawnVehicle()
        {

            int rndPrefVehicle = Random.Range(0, _prefabVechicles.Length);
            int rndTargetPoint = Random.Range(0, _spawnPlace.Length);
            Vector3 pos = _targetMove[rndTargetPoint].position - _spawnPlace[rndTargetPoint].position;
            _prefabVechicles[rndPrefVehicle] = Instantiate(_prefabVechicles[rndPrefVehicle], _spawnPlace[rndTargetPoint].position, Quaternion.LookRotation(pos));
           // _prefabVechicles[rndPrefVehicle] = Instantiate(_prefabVechicles[rndPrefVehicle], _spawnPlace[rndTargetPoint].position, Quaternion.Euler(_targetMove[rndTargetPoint].position));
            Debug.Log(_prefabVechicles[rndPrefVehicle]);

            _prefabVechicles[rndPrefVehicle].SetMoveTarget(_targetMove[rndTargetPoint]);
            _prefabVechicles[rndPrefVehicle].SetPerent(this);
            _timeIntervalSpawnTimer.Restart();
                 
        }
        public void AddListVehicle(Vehicles vehicle)
        {
            _listVehicles.Add(vehicle);
        }

        public void RemoveListVehicle(Vehicles vehicle)
        {
            _listVehicles.Remove(vehicle);
        }

        private void InitTimers()
        {
            _timeRespawnTimer = new Timer(_timeRespawn);
            _timeIntervalSpawnTimer = new Timer(_timeIntervalSpawn);
        }

        private void UpdateTimers()
        {
            _timeRespawnTimer.RemoveTime(Time.deltaTime);
            _timeIntervalSpawnTimer.RemoveTime(Time.deltaTime);
        }
    
    }
}

