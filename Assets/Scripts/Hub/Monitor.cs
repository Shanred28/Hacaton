using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Hacaton
{
    //[RequireComponent(typeof(PointerClickHold))]
    public class Monitor : MonoBehaviour
    {
        [SerializeField] private string m_MonitorSceneName;

        private PointerClickHold m_Handler;

       //public UnityEvent OnMonitorSelection;

        private void Start()
        {
            m_Handler = transform.root.GetComponent<PointerClickHold>();
        }

        private void Update()
        {
            //Select();
        }

        private void Select()
        {
            if (m_Handler.IsHold)
            {
                LoadMonitorScene();
            }
        }

        private void LoadMonitorScene()
        {
            SceneManager.LoadScene(m_MonitorSceneName);
        }
    }
}

