using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;

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
        private Animator _animator;


        [HideInInspector] public float SideMove;
        [HideInInspector] public bool Lift;

        [HideInInspector] public UnityEvent CrashedEvent;

        [HideInInspector] public float ForceCrashed;

        private float _defoultSlopeCentr = 0.50f;
        private float timeSlopeLeft = 0.50f;
        private float timeSlopeRight = 0.50f;
        private void Start () 
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _animator.SetFloat("Blend", _defoultSlopeCentr);
        }

        private void FixedUpdate()
        {
            //Side move
            _rigidbody.AddForce(transform.right * SideMove * _prowl, ForceMode.Impulse);
            if (SideMove > 0)
            {
                timeSlopeRight +=  0.01f;
                AnimationSlope(timeSlopeRight);
            }
            if (SideMove < 0)
            {
                timeSlopeLeft -= 0.01f;
                AnimationSlope(timeSlopeLeft);
            }
            if (SideMove == 0)
            {
                AnimationSlope(_defoultSlopeCentr);
                timeSlopeRight = _defoultSlopeCentr;
                timeSlopeLeft = _defoultSlopeCentr;
            }

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

        private void AnimationSlope(float timeSlope)
        {
            _animator.SetFloat("Blend", timeSlope);
            
        }


    }
}

