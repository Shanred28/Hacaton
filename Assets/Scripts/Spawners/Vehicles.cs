using UnityEngine;

namespace Hacaton
{
    public class Vehicles : MonoBehaviour
    {
        [SerializeField] private float _speedMove;


        private SpawnerVehicles _perentSpawner;
        private Vector3 _MoveTarget;
        private void Start () 
        {
            _perentSpawner.AddListVehicle(this);
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, _MoveTarget, _speedMove * Time.deltaTime);
            if (transform.position == _MoveTarget)
            {
                _perentSpawner.RemoveListVehicle(this);
                Destroy(gameObject);
            }
                
        }


        public void SetMoveTarget(Transform target)
        {
            _MoveTarget = target.position;
        }

        public void SetPerent(SpawnerVehicles perent)
        {
            _perentSpawner = perent;
        }
    }
}

