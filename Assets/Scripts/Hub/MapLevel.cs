using UnityEngine;
using Hacaton;

namespace TowerDefense
{
    public class MapLevel : MonoBehaviour
    {
        //[SerializeField] private Episode m_LevelEpisode;
        //public Episode LevelEpisode => m_LevelEpisode;

        public bool IsCompleted => m_Score > 0;
        private int m_Score = 0;

        public void LoadLevel()
        {
            //if (!m_LevelEpisode) return;
            LevelSequenceController.Instance.StartMission(/*m_LevelEpisode*/);
        }

        /*public int Initialize()
        {
            //var score = MapCompletion.Instance.GetEpisodeScore(m_LevelEpisode);
            //m_Score = score;
            //for (int i = 0; i < score; i++)
            //{
                //m_StarSlots[i].sprite = m_FilledStar;
            //}
            //return score;
        }*/
    }
}

