using System;
using UnityEngine;

using Hacaton;

namespace TowerDefense
{
    public class MapCompletion : SingletonBase<MapCompletion>
    {
        [Serializable]
        private class EpisodeResults
        {
            public Episode EpisodeInstance;
            public int Score;
            
        }

        public const string DataFile = "EpisodeResults.dat"; 

        public int GetEpisodeScore(Episode episode)
        {
            foreach(var data in m_EpisodeData)
            {
                if (data.EpisodeInstance == episode)
                    return data.Score;
            }
            return 0;
        }

        public static void SaveEpisodeResults(int levelScore)
        {
            if (Instance)
                Instance.SaveResult(LevelSequenceController.Instance.CurrentEpisode, levelScore);
        }

        [SerializeField] private EpisodeResults[] m_EpisodeData;
        
        private int m_TotalScore;

        // [SerializeField] private EpisodeResults[] m_BranchEpisodeData;
        public int TotalScore => m_TotalScore;
        private new void Awake()
        {
            base.Awake();
            Saver<EpisodeResults[]>.TryLoad(DataFile, ref m_EpisodeData);
            foreach (var episodeData in m_EpisodeData)
                m_TotalScore += episodeData.Score;
        }
        private void SaveResult(Episode currentEpisode, int levelScore)
        {
            foreach (var data in m_EpisodeData)
            {
                if (data.EpisodeInstance == currentEpisode)
                {
                    data.Score = data.Score > levelScore ? data.Score : levelScore;
                    Saver<EpisodeResults[]>.Save(DataFile, m_EpisodeData);
                }
            }
        }
    }
}

