using UnityEngine;

namespace Hacaton
{
    public class BoxMail : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                Player.Instance.AddBoxMail();
                Debug.Log(+1);
                Destroy(gameObject);
            }
        }
    }
}

