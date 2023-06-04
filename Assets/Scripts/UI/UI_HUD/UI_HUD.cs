using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class UI_HUD : MonoBehaviour
    {
        [SerializeField] private Image _imageFilledHP;

        [SerializeField] private Cargo _cargo;

        private void Update()
        {
            _imageFilledHP.fillAmount = _cargo.CurrentCargoIntegrity / _cargo.MaxCargoIntegrity; 
        }
    }
}

