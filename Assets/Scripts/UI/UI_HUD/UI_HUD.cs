using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class UI_HUD : MonoBehaviour
    {
        [SerializeField] private Image _imageFilledHP;

        [SerializeField] private Cargo _cargo;
        [SerializeField] private Text _textCountBoxMail;

        void Start () 
        {
            Player.Instance.ChangeCountBoxMail.AddListener(ChangeBoxMail); 
        }

        private void Update()
        {
            _imageFilledHP.fillAmount = _cargo.CurrentCargoIntegrity / _cargo.MaxCargoIntegrity; 
        }

        private void ChangeBoxMail()
        {
            _textCountBoxMail.text = Player.Instance.CountBoxMail.ToString();
        }
    }
}

