using UnityEngine;

namespace TowerDefense
{
    public class LevelDisplayController : MonoBehaviour
    {
        [SerializeField] private MapLevel[] m_MainMapLevels;
       // [SerializeField] private BranchLevel[] m_BranchMapLevels;
        private void Start()
        {
            int drawLevel = 0;
            int score = 1;
            while (score != 0 && drawLevel < m_MainMapLevels.Length)
            {
                //score = m_MainMapLevels[drawLevel++].Initialize();
            }
            for (int i = drawLevel; i < m_MainMapLevels.Length; i++)
            {
                m_MainMapLevels[i].gameObject.SetActive(false);
            }

           /* for (int i = 0; i < m_BranchMapLevels.Length; i++)
            {
                //m_BranchMapLevels[i].gameObject.SetActive(m_BranchMapLevels[i].RootConditionsMet);
                m_BranchMapLevels[i].TryActivate();
            }*/
        }
    }
}

