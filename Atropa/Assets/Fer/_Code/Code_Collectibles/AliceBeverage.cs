using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class AliceBeverage : MonoBehaviour
{
    private AudioSource myAudio;
    public PostProcessVolume postProcess;
    private Vignette vignette;
    private bool ending;

    public void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
        ending = false;
        postProcess.profile.TryGetSettings(out vignette);
    }

    public void drinkAlice()
    {
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
}
