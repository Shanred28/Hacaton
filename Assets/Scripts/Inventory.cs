using UnityEngine;

namespace Hacaton
{
    public class Inventory : MonoBehaviour
    {
        private int _money;
        private int _detailsOneGrade;
        private int _detailsTwoGrade;
        private int _detailsTreeGrade;

        public void AddMoney(int countMoney)
        {
            _money += countMoney;
        }
    }
}

