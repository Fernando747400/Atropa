using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public void explodeHouses()
    {
        cinematicSecuence();
    }

    IEnumerator cinematicSecuence()
    {
        stopInputs();
        rotatePlayer();
        yield return new WaitForSeconds(1);
        initialExplosiveHouse.SetActive(true);
        initialHouse.SetActive(false);
        CinematicEventSystem.current.explodeScene();
        yield return new WaitForSeconds(5);
        finalExplosiveHouse.SetActive(true);
        CinematicEventSystem.current.rollbackScene();
        yield return new WaitForSeconds(5);
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
}