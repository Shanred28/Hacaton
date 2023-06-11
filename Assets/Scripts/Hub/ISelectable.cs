using UnityEngine;
using Hacaton;
using System;

public interface ISelectable
{
    public bool IsSelected { set; }
    public GameObject Selected { get; }
    public Episode EpisodeToLoad { get; }
}
