using UnityEngine;

namespace Hacaton
{
    public class EnemyDron : MonoBehaviour
    {
        [SerializeField] private float _speedMove;

        private Vector3 _MoveTarget;

        private void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, _MoveTarget, _speedMove * Time.deltaTime);
            if (transform.position == _MoveTarget)
            {
                Destroy(gameObject);
            }

        }

        public void SetMoveTarget(Transform target)
        {
            _MoveTarget = target.position;
        }
    }
}

