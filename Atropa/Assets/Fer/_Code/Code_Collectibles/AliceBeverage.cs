using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using com.amerike.Fernando;

public class AliceBeverage : MonoBehaviour
{
    private AudioSource myAudio;
    public PostProcessVolume postProcess;
    private Vignette vignette;
    private bool ending;
    public Animator endingAnimation;
    public GameObject mainCamera;
    public GameObject head;
    public GameObject bearUp;
    public GameObject bearDown;
    public PlayerCamera playerCamera;
    public PlayerMovement playerMovement;

    public void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
        ending = false;
        postProcess.profile.TryGetSettings(out vignette);
    }

    public void drinkAlice()
    {
        endAnim();
        StartCoroutine(endSequence());
    }

    private IEnumerator endSequence()
    {
        if (myAudio != null)
        {
            ending = true;
            myAudio.Play();
            yield return new WaitForSeconds(myAudio.clip.length);
            SceneManager.LoadScene("02_End_Credits");
        }
    }

    public void Update()
    {
        if (ending == true)
        {
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 1, Time.deltaTime/9f);
        }
    }

    public void endAnim()
    {
        playerCamera.Active = false;
        playerMovement.Active = false;
        iTween.MoveTo(mainCamera,head.transform.position,0.2f);
        mainCamera.transform.rotation = head.transform.rotation;
        mainCamera.transform.parent = head.transform;
        bearUp.SetActive(false);
        bearDown.SetActive(true);
        endingAnimation.Play("DyingAnimation");
    }
}
