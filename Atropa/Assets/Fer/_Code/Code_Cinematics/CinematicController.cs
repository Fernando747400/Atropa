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
        StartCoroutine(cinematicSecuence());
    }

    IEnumerator cinematicSecuence()
    {
        print("Entered the coroutine");
        stopInputs();
        print("stopedinputs");
        rotatePlayer();
        yield return new WaitForSeconds(1);
        print("waited");
        initialExplosiveHouse.SetActive(true);
        print("explosive house tunred on");
        initialHouse.SetActive(false);
        print("initial house turned off");
        CinematicEventSystem.current.explodeScene();
        print("Explode house");
        yield return new WaitForSeconds(5);
        print("Waited 5 secs");
        finalExplosiveHouse.SetActive(true);
        print("Explosive house turned on");
        CinematicEventSystem.current.rollbackScene();
        print("unexploded house");
        yield return new WaitForSeconds(5);
        print("waited 5 sec again");
        finalHouse.SetActive(true);
        print("final house turned on");
        finalExplosiveHouse.SetActive(false);
        print("ecploded house turned off");
        yield return new WaitForSeconds(1);
        print("waited final 1 sec");
        startInputs();
        print("turned on inputs");
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
