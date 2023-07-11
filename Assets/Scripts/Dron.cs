using UnityEngine;
using UnityEngine.Events;

namespace Hacaton
{
    [RequireComponent(typeof(Rigidbody))]
    public class Dron : SingletonBase<Dron>
    {
        [Header("StatDron")]
        // ����� ����� ��� ��������� � ������
        [SerializeField] private float _maxEnergy;
        public float MaxEnergy => _maxEnergy;
        private float _currentEnergy;
        public float CurrentEnergy => _currentEnergy;
        [SerializeField] private int _removeEnergyHack;
        [SerializeField] private float _Up;
        [SerializeField] private float _flySpeed;
        
        [SerializeField] private float _prowl;

        [Header("PhisicFly")]
        //[SerializeField] private float _gravity;
        [SerializeField] private float _smoothFlyFactor;

        [Header("BoostSpeed")]
        [SerializeField] private float _addBoostSpeed;
        [SerializeField] private int _countEnergyBoostSpeed;
        [SerializeField] private float _timeBoostSpeed;

        private bool _IsBoostSpeed = false;

        private Rigidbody _rigidbody;
        private Animator _animator;


        [HideInInspector] public float SideMove;
        [HideInInspector] public bool LiftUp;
        [SerializeField] private float _upSide;
        [HideInInspector] public bool LiftDown;
        [SerializeField] private float _downSide;

        [HideInInspector] public UnityEvent CrashedEvent;

        [HideInInspector] public float ForceCrashed;

        private Timer _timerBoostSpeed;

        private bool isRotating = false;

        // �������� ���� ����, �� State Mashin
        private float _defoultSlopeCentr = 0.50f;
        private float timeSlopeLeft = 0.50f;
        private float timeSlopeRight = 0.50f;


        private void Start () 
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _animator.SetFloat("Blend", _defoultSlopeCentr);
            _currentEnergy = _maxEnergy;
            InitTimers();
        }

        private void Update()
        {
            UpdateTimers();
            if (_timerBoostSpeed.IsFinished)
            {
                _IsBoostSpeed = false;
                NormalSpeed();
            }               
        }

        private void FixedUpdate()
        {
            //Side move
            _rigidbody.AddForce(transform.right * SideMove * _prowl, ForceMode.Impulse);

            // �������� ���� ����, �� State Mashin
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
            if (LiftUp)
            {
                // _rigidbody.AddForce(0, _Up, 0, ForceMode.Impulse);
                if (transform.position.y < _upSide && LiftUp == true)
                {
                    transform.position += Vector3.up * Time.fixedDeltaTime;
                    LiftDown = false;
                }
                else
                {
                    LiftUp = false;
                }


            }
            if (LiftDown) 
            {
                //_rigidbody.AddForce(0, -_Up, 0, ForceMode.Impulse);
                if (transform.position.y > _downSide && LiftDown == true)
                {
                    LiftUp = false;
                    transform.position += (Vector3.up * -1) * Time.fixedDeltaTime;
                }
                else
                {
                    LiftDown = false;
                }
            }

            // Forward Movement
            Vector3 _currentVelocity = _rigidbody.velocity;
            Vector3  forwardVelocity = transform.forward * _flySpeed;
            _rigidbody.velocity = Vector3.Lerp(_currentVelocity, forwardVelocity, Time.fixedDeltaTime * _smoothFlyFactor);

            if (isRotating)
            {
                //float rotationProgress = Mathf.Clamp01((_initialRotation.eulerAngles.y - transform.rotation.eulerAngles.y )/ Time.fixedTime);
                //Debug.Log(rotationProgress);

                _rigidbody.rotation = Quaternion.Lerp(transform.rotation, _targetQuateruion, Time.fixedTime);

                /*transform.rotation = Quaternion.Lerp(transform.rotation, _targetQuateruion, Time.fixedTime)*/
               /* if (rotationProgress >= 1f)
                { 
                    isRotating = false;
                }*/
            }
        }

        private Quaternion _targetQuateruion;
        private float _targetRotation;
        private Quaternion _initialRotation;

        
        public void TurningDron(/*float turning*/ Transform targetTransform, float angle )
        {
            // var rotation = Quaternion.Euler(0, transform.eulerAngles.y - turning, 0);
            //transform.rotation = rotation;
            /*var target = new Vector3(targetTransform.position.x, 0, targetTransform.position.z);
            var posDron = new Vector3(transform.position.x, 0, transform.position.z); 
            *//*var rotation = Quaternion.LookRotation(target - posDron);
            transform.rotation = Quaternion.RotateTowards (transform.rotation, rotation,  _flySpeed * Time.fixedTime);*//*
            var dir = target - posDron;
            var rotation = Quaternion.LookRotation(dir);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _flySpeed * Time.fixedTime);*/

            isRotating = true;
            _targetRotation = angle;
            _initialRotation = targetTransform.localRotation;
            _targetQuateruion = Quaternion.Euler(transform.eulerAngles + new Vector3(0, angle, 0));




        }

        public void Crashed(float forceCrashed)
        {
            ForceCrashed = forceCrashed;
            CrashedEvent.Invoke();
            // ���� ���� �������,����� ������������ � ������������
        }

        private void AnimationSlope(float timeSlope)
        {
            _animator.SetFloat("Blend", timeSlope);
            
        }

        public void BoostSpeed()
        {
            if (_currentEnergy >= _countEnergyBoostSpeed && _IsBoostSpeed == false)
            {
                _flySpeed = _flySpeed * _addBoostSpeed;
                _timerBoostSpeed.Start(_timeBoostSpeed);
                _IsBoostSpeed = true;
                RemoveEnergy(_countEnergyBoostSpeed);
            }           
        }
        private void NormalSpeed()
        {
            _flySpeed = _flySpeed / _addBoostSpeed;
            _timerBoostSpeed.Stop();
        }

        private void InitTimers()
        {
            _timerBoostSpeed = new Timer(_timeBoostSpeed);
            _timerBoostSpeed.Stop();
        }

        private void UpdateTimers()
        {
            _timerBoostSpeed.RemoveTime(Time.deltaTime);
        }

        private void RemoveEnergy(int energy)
        {
            _currentEnergy = _currentEnergy - energy;
        }

        public void AddEnergy(int energy)
        {
            _currentEnergy += energy;
            if(_currentEnergy > _maxEnergy)
                _currentEnergy = _maxEnergy;
        }

        public void Hack()
        {
            RemoveEnergy(_removeEnergyHack);
        }
    }
}

