using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CinematicEventSystem : MonoBehaviour
{
    public static CinematicEventSystem current;

    public void Awake()
    {
        current = this;
    }

    public event Action OnExplodeScene;

    public void explodeScene()
    {
        OnExplodeScene?.Invoke();
    }

    public event Action OnRollbackScene;

    public void rollbackScene()
    {
        OnRollbackScene?.Invoke();
    }
}
