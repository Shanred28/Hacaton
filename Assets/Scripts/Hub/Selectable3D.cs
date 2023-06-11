using UnityEngine;
using UnityEngine.UI;

namespace Hacaton
{
    public class Selectable3D : MonoBehaviour, ISelectable
    {
        [SerializeField] private Image m_Pointer;
        [SerializeField] private Episode m_EpisodeToLoad;
        private Color m_UnselectedColor;

        private bool m_IsSelected;
        public bool IsSelected { set => m_IsSelected = value; }
        public GameObject Selected => m_IsSelected ? gameObject : null;

        public Episode EpisodeToLoad => m_EpisodeToLoad;

        private void Update()
        {
            if (m_IsSelected)
            {
                m_Pointer.gameObject.SetActive(true);
                
            }
            else
            {
                m_Pointer.gameObject.SetActive(false);
            }
        }
    }
}

