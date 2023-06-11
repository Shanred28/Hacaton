using Hacaton;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectableNavigationUI : MonoBehaviour
{
    protected ISelectable[] m_Selectables;
    protected Stack<ISelectable> m_Fwd = new Stack<ISelectable>();
    protected Stack<ISelectable> m_Bwd = new Stack<ISelectable>();
    protected ISelectable m_CurrentSelectable;

    protected void Start()
    {
        for (int i = m_Selectables.Length - 1; i >= 0; i--)
        {
            m_Fwd.Push(m_Selectables[i]);
        }
        if (m_Fwd.TryPop(out m_CurrentSelectable))
        {
            m_Bwd.Push(m_CurrentSelectable);
        }
        SelectItem(m_CurrentSelectable);

    }
    protected virtual void SelectItem(ISelectable selectable)
    {
        m_CurrentSelectable.IsSelected = false;
        m_CurrentSelectable = selectable;
        m_CurrentSelectable.IsSelected = true;
        LevelSequenceController.Instance.CurrentEpisode = m_CurrentSelectable.EpisodeToLoad;
    }
}
