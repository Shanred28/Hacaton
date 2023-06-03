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
            _dron.Lift = _UpButton.IsHold;

            if (_LeftButton.IsHold == true)
            { 
                _dron.SideMove = -1;
            }

            else if (_RightButton.IsHold == true)
            {
                _dron.SideMove = 1;
            }

            else
            {
                _dron.SideMove = 0;
            }
        }
    }
}

