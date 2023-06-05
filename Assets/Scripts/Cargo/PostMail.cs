using UnityEngine;

namespace Hacaton
{
    public class PostMail : MonoBehaviour
    {
        [SerializeField] private Cargo[] _cargoPreefab;
        [SerializeField] private Transform[] _pointSpawnCargo;
        [SerializeField] private Transform[] _pointCargoDelivery;

        private void Start()
        {
                
        }

        private void SpawnMail()
        {
            int rndPrefVehicle = Random.Range(0, _cargoPreefab.Length);
            int rndTargetPoint = Random.Range(0, _pointSpawnCargo.Length);
        }
    }
}