using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public class SpawnerVehicles : MonoBehaviour
    {
        [SerializeField] private Vehicles[] _prefabVechicles;
        [SerializeField] private Transform[] _spawnPlace;

        [SerializeField] private float _timeIntervalSpawn;
        [SerializeField] private int _maxRespawnVechicles;
        [SerializeField] private Transform[] _targetMove;

        private List<Vehicles> _listVehicles;


        private Timer _timeIntervalSpawnTimer;



        private void Start () 
        {
            InitTimers();
           _listVehicles = new List<Vehicles>();
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
            Vehicles car = Instantiate(_prefabVechicles[rndPrefVehicle], _spawnPlace[rndTargetPoint].position, Quaternion.LookRotation(pos));
            
            car.SetMoveTarget(_targetMove[rndTargetPoint]);
            car.SetPerent(this);
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
            _timeIntervalSpawnTimer = new Timer(_timeIntervalSpawn);
        }

        private void UpdateTimers()
        {
            _timeIntervalSpawnTimer.RemoveTime(Time.deltaTime);
        }
    
    }
}

