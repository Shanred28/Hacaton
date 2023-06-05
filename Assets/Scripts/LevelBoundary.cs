using UnityEngine;

namespace Hacaton
{
    public class LevelBoundary : SingletonBase<LevelBoundary>
    {
        [SerializeField] private float _height;
        public float Height => _height;
        private float _defoultHeight;

        private void Start()
        {
            _defoultHeight = _height;
        }

        public void SetLevelBoundary(float setHight)
        {
            _height = setHight;
            Debug.Log(_height);
        }

        public void SetLevelBoundaryReset()
        {
            _height = _defoultHeight;
        }
    }
}


