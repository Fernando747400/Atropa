using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    public AudioClip endSong;
    public GameObject mainMenuButton;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        mainMenuButton.SetActive(false);
        StartCoroutine(endSequence());
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("00_Main_Menu");
    }

    IEnumerator endSequence()
    {
        yield return new WaitForSecondsRealtime(170);
        mainMenuButton.SetActive(true);
    }
}
