using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hacaton
{
    public class HubNavigationPanel : SelectableNavigationUI
    {
        [SerializeField] private Selectable3D[] m_Selectables3D;
        [SerializeField] private PointerClickHold m_RightBtn;
        [SerializeField] private PointerClickHold m_LeftBtn;

        protected new void Start()
        {
            m_Selectables = m_Selectables3D;
            base.Start();
        }
        private void Update()
        {
            ISelectable newSelectable = null;
            if (m_LeftBtn.IsHold)
            {
                if (m_Fwd.TryPop(out newSelectable))
                {
                    m_Bwd.Push(newSelectable);
                }
            }
            if (m_RightBtn.IsHold)
            {
                if (m_Bwd.TryPop(out newSelectable))
                {
                    m_Fwd.Push(newSelectable);
                }
            }
            if (newSelectable != null && newSelectable != m_CurrentSelectable)
                SelectItem(newSelectable);
        }

    }
}

