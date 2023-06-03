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
        [SerializeField] private float _smoothFlyFactor;

        private Rigidbody _rigidbody;


        [HideInInspector] public float SideMove;
        [HideInInspector] public bool Lift;


        private void Start () 
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            //Side move
            _rigidbody.AddForce(SideMove * _prowl, 0, 0, ForceMode.Impulse);

            // Up-down move
            if (Lift)
            {
                _rigidbody.AddForce(0, _Up, 0, ForceMode.Impulse);
            }
            else 
            {
                _rigidbody.AddForce(0, -_gravity, 0, ForceMode.Impulse);
            }

            // Forward Movement
            Vector3 _currentVelocity = _rigidbody.velocity;
            Vector3  forwardVelocity = transform.forward * _flySpeed;
            _rigidbody.velocity = Vector3.Lerp(_currentVelocity, forwardVelocity, Time.deltaTime * _smoothFlyFactor);


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
            // Надо сюда анимаху,после столкновения с препятствием
        }
    }
}

