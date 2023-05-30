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
        [SerializeField] private Transform _visualModel;


        private Rigidbody _rigidbody;
        private Vector3 _directionMove = new Vector3(0,0,1);


        private void Start () 
        {
            _rigidbody = GetComponent<Rigidbody>();

        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _directionMove * _flySpeed;
            _rigidbody.AddForce(0, -_gravity, 0, ForceMode.Impulse);


            ControllMoveDronUp();
            ControllMoveDronProwl(0);
        }

        public void ControllMoveDronUp()
        {
            _rigidbody.AddForce(0, _Up, 0, ForceMode.Impulse);

        }

        public void ControllMoveDronProwl(int prowl)
        {
            _rigidbody.AddForce( _prowl * prowl, 0, 0, ForceMode.Impulse);
        }

        public void TurningDron(float turning)
        { 
            var rotation = Quaternion.Euler(0, turning, 0);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _flySpeed);
           // gameObject.transform.Rotate(new Vector3(0, 90, 0), Space.World);
           transform.rotation = rotation;
            _directionMove = new Vector3(-1, 0, 0);



        }
    }
}

