using UnityEngine;

namespace Hacaton
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Dron _dron;

        [SerializeField] private PointerClickHold _UpButton;
        [SerializeField] private PointerClickHold _LeftButton;
        [SerializeField] private PointerClickHold _RightButton;

        private void Update()
        {
            Control();
        }

        private void Control()
        {
            if (_UpButton.IsHold == true)
            { 
                _dron.ControllMoveDronUp();
            }

            if (_LeftButton.IsHold == true)
            { 
                _dron.ControllMoveDronProwl(-1);
            }

            if (_RightButton.IsHold == true)
            {
                _dron.ControllMoveDronProwl(1);
            }
        }
    }
}

