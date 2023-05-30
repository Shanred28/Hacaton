using UnityEngine;

namespace Hacaton
{
    public class LevelBoundary : SingletonBase<LevelBoundary>
    {
        [SerializeField] private float _height;
        public float Height => _height;

    }

}


