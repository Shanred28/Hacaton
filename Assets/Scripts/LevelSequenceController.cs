using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Hacaton
{
    public class LevelSequenceController : SingletonBase<LevelSequenceController>
    {
        public bool LastLevelResult { get; private set; }

        public Episode CurrentEpisode;

        public UnityEvent IsLevelFinish;

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void StartMission()
        {
            SceneManager.LoadScene(CurrentEpisode.Levels[0]);
        }

        public void FinishCurrentLevel(bool success)
        {
            LastLevelResult = success;
            IsLevelFinish.Invoke();
            //CalculateLevelStatistic();
            //ResultPanelController.Instance.ShowResults(LevelStatistics, success);

        }

        public void AdvanceLevel()
        {
           /* LevelStatistics.Reset();

            ++CurrentLevel;
            if (CurrentEpisode.Levels.Length <= CurrentLevel)
                SceneManager.LoadScene(MainMenuSceneNickname);
            else
                SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);*/
        }

        private void CalculateLevelStatistic()
        {
           /* float timeBonus = LevelController.Instance.TimeBonusScore;
            if (LevelController.Instance.LevelTime < timeBonus)
            {
                LevelStatistics.score = Player.Instance.Score * 2;
                LevelStatistics.IsBonusScore = true;
            }
            else
            {
                LevelStatistics.score = Player.Instance.Score;
                LevelStatistics.IsBonusScore = false;
            }

            LevelStatistics.numkills = Player.Instance.NumKills;
            LevelStatistics.time = (int)LevelController.Instance.LevelTime;*/
           //
        }
    }
}

