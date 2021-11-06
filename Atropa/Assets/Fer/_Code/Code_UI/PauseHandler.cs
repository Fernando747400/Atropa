using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using com.amerike.Fernando;

public class PauseHandler : MonoBehaviour
{
    public Canvas PauseCanvas;
    Keyboard keyBoard;
    public GameObject TextCanvas;
    public PlayerMovement playerScript;
    public PlayerCamera cameraScript;
    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        keyBoard = Keyboard.current;
#endif
    }

    void Update()
    {
        if ((keyBoard.pKey.wasPressedThisFrame || keyBoard.escapeKey.wasPressedThisFrame) && PauseCanvas.gameObject.activeInHierarchy == false)
        {
            PauseCanvas.gameObject.SetActive(true);
            UnlockMouse();
        } else if ((keyBoard.pKey.wasPressedThisFrame || keyBoard.escapeKey.wasPressedThisFrame) && PauseCanvas.gameObject.activeInHierarchy == true)
        {
            PauseCanvas.gameObject.SetActive(false);
            lockMouse();
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

    public void OnEnable()
    {
        if (TextCanvas.activeInHierarchy)
        {
            TextCanvas.SetActive(false);
        }
        playerScript.Active = false;
        cameraScript.Active = false;
    }

    public void OnDisable()
    {
        playerScript.Active = true;
        cameraScript.Active = true;
    }
}
