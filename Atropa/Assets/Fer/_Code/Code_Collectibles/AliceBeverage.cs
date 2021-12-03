using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AliceBeverage : MonoBehaviour
{
    private AudioSource myAudio;

    public void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
    }

    public void drinkAlice()
    {
        StartCoroutine(endSequence());
    }

    private IEnumerator endSequence()
    {
        if (myAudio != null)
        {
            myAudio.Play();
            yield return new WaitForSeconds(myAudio.clip.length);
            SceneManager.LoadScene("02_End_Credits");
        }
    }
}
