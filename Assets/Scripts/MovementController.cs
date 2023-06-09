using UnityEngine;

namespace Hacaton
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Dron _dron;

        [SerializeField] private PointerClickHold _upButton;
        [SerializeField] private PointerClickHold _leftButton;
        [SerializeField] private PointerClickHold _rightButton;
        [SerializeField] private PointerClickHold _downButton;

        private void Update()
        {
            Control();
        }

        private void Control()
        {
            _dron.LiftUp = _upButton.IsHold;
            _dron.LiftDown = _downButton.IsHold;

            if (_leftButton.IsHold == true)
            { 
                _dron.SideMove = -1;
            }

            else if (_rightButton.IsHold == true)
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

