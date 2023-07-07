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
      

        [SerializeField] public Turning turning;
        
        [SerializeField] private bool _isSetHight = false;
        [SerializeField] private float _hight;

        private bool IsTurn;

        private void OnTriggerEnter(Collider other)
        {

            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                if(_isSetHight)
                    LevelBoundary.Instance.SetLevelBoundary(_hight);
                if (turning == Turning.Left && IsTurn == false)
                {
                    var turnPoin = GetComponent<Chunk>().endChunks[0]; 
                    //dron.TurningDron(90);
                    //dron.TurningDron(90);
                    dron.TurningDron(turnPoin, -90);
                    IsTurn = true;
                }           
                
                if (turning == Turning.Right)
                {
                    var turnPoin = GetComponent<Chunk>().endChunks[1];
                    //dron.TurningDron(-90);
                    dron.TurningDron(turnPoin,90);
                    IsTurn = true;
                }        
                
                if (turning == Turning.Forward)
                {
                    //dron.TurningDron(0);
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

