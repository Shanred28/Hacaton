using UnityEngine;

namespace Hacaton
{
    public class RotateScreenLandscape : MonoBehaviour
    {
        private void Start()
        {
            Screen.autorotateToLandscapeLeft = true;
        }
    }
}

