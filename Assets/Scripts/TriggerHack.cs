using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class TriggerHack : MonoBehaviour
    {
        [SerializeField] private Image _imageSuccessfullHack;
        [SerializeField] private MoveTo _moveTo;

        public bool IsGameWin;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                IsGameWin = true;
                GameResult();
                // Start mini game "Hack"
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                _imageSuccessfullHack.gameObject.SetActive(false);
            }
        }

        private void GameResult()
        {
            if (IsGameWin)
            {
                _imageSuccessfullHack.gameObject.SetActive(true);
                _moveTo.IsStart = true;

            }
               
        }
    }
}

