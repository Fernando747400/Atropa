using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseHandler : MonoBehaviour
{
    public Canvas PauseCanvas;
    Keyboard keyBoard;
    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        keyBoard = Keyboard.current;
#endif
    }

    void Update()
    {
        if (keyBoard.pKey.wasPressedThisFrame)
        {
            PauseCanvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void lockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
