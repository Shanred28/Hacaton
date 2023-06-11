using TMPro;
using UnityEngine;

namespace Hacaton
{
    public class LevelInfoUpdaterUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_Location;
        [SerializeField] private TMP_Text m_Reward;
        [SerializeField] private TMP_Text m_Cargo;

        private void Awake()
        {
            LevelChoiceControllerUI.LevelChanged += OnLevelChange;
        }

        private void OnLevelChange(ISelectable level)
        {

            m_Location.text = $"�����: {level.EpisodeToLoad.LevelLocation}";
            m_Reward.text = $"�������: {level.EpisodeToLoad.LevelReward}";
            string cargo = "�������";
            switch (level.EpisodeToLoad.Cargo.TypeCargo)
            {
                case CargoType.VeryFragile:
                    cargo = "����� �������";
                    break;
                case CargoType.Fragily:
                    cargo = "�������";
                    break;
            }
            
            m_Cargo.text = $"����: {cargo}";            
        }
    }
}

