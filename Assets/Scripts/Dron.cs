using UnityEngine;

namespace Hacaton
{
    [RequireComponent(typeof(Rigidbody))]
    public class Dron : MonoBehaviour
    {
        [SerializeField] private float _flySpeed;
        [SerializeField] private float _gravity;
        [SerializeField] private float _Up;
        [SerializeField] private float _prowl;

        [SerializeField] private Collider _collider;


        private Rigidbody _rigidbody;
        private bool IsCrashed = false;


        private void Start () 
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (IsCrashed == false)
            {
                _rigidbody.velocity = transform.forward * _flySpeed;
                _rigidbody.AddForce(0, -_gravity, 0, ForceMode.Impulse);
            }

            if (IsCrashed == true) 
            {
                _rigidbody.AddRelativeForce(-transform.forward * 10000);
                IsCrashed=false;
            }
        }

        public void ControllMoveDronUp()
        {
            _rigidbody.AddForce(0, _Up, 0, ForceMode.Impulse);

        }

        public void ControllMoveDronProwl(int prowl)
        {
            _rigidbody.AddRelativeForce( _prowl * prowl, 0, 0, ForceMode.Impulse);
        }

        public void TurningDron(float turning)
        { 
            var rotation = Quaternion.Euler(0, turning, 0);
           transform.rotation = rotation;
            
        }

        public void Crashed()
        {
            IsCrashed = true;
            // Надо сюда анимаху,после столкновения с препятствием
        }
    }
}

