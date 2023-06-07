using UnityEngine;
using UnityEngine.Events;

namespace Hacaton
{
    public class Player : SingletonBase<Player>
    {
        private int _countBoxMail;
        private int _countCash;
        public int CountCash => _countCash;

        public UnityEvent ChangeCash;

        private void Start()
        {
            _countBoxMail = 0;
        }

        public void AddBoxMail()
        {
            ++_countBoxMail;
        }
    }
}

