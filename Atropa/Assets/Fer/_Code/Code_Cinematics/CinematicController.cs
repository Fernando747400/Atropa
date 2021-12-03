using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using com.amerike.Fernando;

public class CinematicController : MonoBehaviour
{
    public GameObject initialHouse;
    public GameObject initialExplosiveHouse;
    public GameObject finalHouse;
    public GameObject finalExplosiveHouse;
    public GameObject playerCamera;
    public PlayerCamera cameraScript;
    public PlayerMovement playerScript;
    public AudioSource musicSource;
    public AudioClip newSong;
    public PostProcessVolume ppVolume;
    private ColorGrading colorGrading;

    public void explodeHouses()
    {
        StartCoroutine(cinematicSecuence());
    }

    IEnumerator cinematicSecuence()
    {
        print("Entered the coroutine");
        stopInputs();
        rotatePlayer();
        initialExplosiveHouse.SetActive(true);
        finalExplosiveHouse.SetActive(true);
        initialHouse.SetActive(false);
        yield return new WaitForFixedUpdate();
        CinematicEventSystem.current.explodeScene();
        yield return new WaitForSeconds(4);
        initialExplosiveHouse.SetActive(false);
        changeMusic();
        changeSaturation();
        CinematicEventSystem.current.rollbackScene();
        yield return new WaitForSeconds(4);
        finalHouse.SetActive(true);
        finalExplosiveHouse.SetActive(false);
        yield return new WaitForSeconds(1);
        startInputs();
        
    }

    public void rotatePlayer()
    {
        iTween.LookTo(playerCamera, new Vector3(0,2,0), 1f);
    }

    public void stopInputs()
    {
        cameraScript.Active = false;
        playerScript.Active = false;
    }

    public void startInputs()
    {
        cameraScript.Active = true;
        playerScript.Active = true;
    }

    public void changeMusic()
    {
        musicSource.Stop();
        musicSource.clip = newSong;
        musicSource.Play();
        musicSource.loop = true;
        musicSource.volume = 0.1f;
    }

    public void changeSaturation()
    {
        ppVolume.profile.TryGetSettings(out colorGrading);
        colorGrading.saturation.value = colorGrading.saturation.value - 10;
    }
}
