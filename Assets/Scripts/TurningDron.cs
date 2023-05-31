using UnityEngine;

namespace Hacaton
{
    public enum Turning
    {
        Left,
        Right,
        Forward
    }

    [RequireComponent(typeof(Collider))]
    public class TurningDron : MonoBehaviour
    {
      

        [SerializeField] private Turning turning;

        private bool IsTurn;

        private void OnTriggerEnter(Collider other)
        {

            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                if (turning == Turning.Left && IsTurn == false)
                {
                   dron.TurningDron(-90);
                    IsTurn = true;

                }           
                
                if (turning == Turning.Right)
                {
                    dron.TurningDron(0);
                    IsTurn = true;
                }        
                
                if (turning == Turning.Forward)
                {
                    dron.TurningDron(0);
                }
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
                IsTurn = false;

        }

    }
}

