using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class MainMenuBottle : MonoBehaviour
{
    Mouse mouse;
    public GameObject interactPrompt;
    public PostProcessVolume myVolume;
    public PostProcessProfile myBundle;

    public void Start()
    {
        mouse = Mouse.current;    
    }

    public void Update()
    {
        if (mouse.leftButton.wasPressedThisFrame)
        {
            this.GetComponent<AudioSource>().Play();
            SceneManager.LoadScene("01_Main_Scene");
        }
    }

    public void prepareGame()
    {
        myVolume.profile = myBundle;
    }

    public void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("01_Main_Scene");
    }
    public void OnMouseEnter()
    {
        interactPrompt.SetActive(true);
    }

    public void OnMouseExit()
    {
        interactPrompt.SetActive(false);
    }
}
