using UnityEngine;

namespace Hacaton
{
    public class Coin : MonoBehaviour
    {

        [SerializeField] private int _numMoney;
        [SerializeField] private Vector3 _rotateSpeed;
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Inventory>(out var inv))
            {
                inv.AddMoney(_numMoney);
                Destroy(gameObject);
            }
        }
    }
}