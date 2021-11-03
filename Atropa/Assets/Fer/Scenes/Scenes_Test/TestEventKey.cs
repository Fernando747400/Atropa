using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestEventKey : MonoBehaviour
{
    Keyboard keyBoard;
    public void Start()
    {        
        keyBoard = Keyboard.current;
    }
    void Update()
    {
        if (keyBoard.spaceKey.wasPressedThisFrame)
        {
            TestEventManager.current.explodeScene();
        }
    }
}
