using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestEventKey : MonoBehaviour
{
    Keyboard keyBoard;
    public GameObject pivotPoint;
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

        pivotPoint.transform.Rotate(Vector3.up * Time.deltaTime * 50);
    }
}
