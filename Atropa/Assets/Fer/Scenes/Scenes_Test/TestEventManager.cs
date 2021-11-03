using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestEventManager : MonoBehaviour
{
    public static TestEventManager current;

    public void Awake()
    {
        current = this;
    }

    public event Action OnExplodeScene;

    public void explodeScene()
    {
        OnExplodeScene?.Invoke();
    }
}
