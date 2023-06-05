using UnityEngine;

namespace Hacaton
{
    public class RotateFans : MonoBehaviour
    {
        [SerializeField] private Transform[] _transformFan;
        [SerializeField] private float _speedRotateFan;

        private void Update()
        {
            for (int i = 0; i < _transformFan.Length; ++i)
            {
                _transformFan[i].Rotate(0, _speedRotateFan, 0);
            }
        }
    }
}

