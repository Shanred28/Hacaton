using UnityEngine;

namespace Hacaton
{
    public class CrashedObstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                dron.Crashed();
            }
        }
    }
}

