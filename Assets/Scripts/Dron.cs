using UnityEngine;
using UnityEngine.Events;

namespace Hacaton
{
    [RequireComponent(typeof(Rigidbody))]
    public class Dron : MonoBehaviour
    {
        [Header("StatDron")]
        // Нужна будет для ускорение и взлома
        [SerializeField] private float _maxEnergy;
        [SerializeField] private float _Up;
        [SerializeField] private float _flySpeed;
        [SerializeField] private float _prowl;

        [Header("PhisicFly")]
        [SerializeField] private float _gravity;
        [SerializeField] private float _smoothFlyFactor;

        private Rigidbody _rigidbody;


        [HideInInspector] public float SideMove;
        [HideInInspector] public bool Lift;

        [HideInInspector] public UnityEvent CrashedEvent;

        [HideInInspector] public float ForceCrashed;
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

        public void Crashed(float forceCrashed)
        {
            ForceCrashed = forceCrashed;
            CrashedEvent.Invoke();
            // Надо сюда анимаху,после столкновения с препятствием
        }


    }
}

