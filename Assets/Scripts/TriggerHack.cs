using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class TriggerHack : MonoBehaviour
    {
        [SerializeField] private Image _imageSuccessfullHack;
        [SerializeField] private MoveTo _moveTo;
        [SerializeField] private GameObject _gameObject;

        public bool IsGameWin;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                _gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if (other.transform.root.TryGetComponent<Dron>(out Dron dron))
            {
                _imageSuccessfullHack.gameObject.SetActive(false);
            }
        }

        public void GameResult()
        {
            
                _imageSuccessfullHack.gameObject.SetActive(true);
                _moveTo.IsStart = true;

                Time.timeScale = 1f;
                _gameObject.SetActive(false);
            
               
        }
    }
}

