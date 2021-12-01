using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Door : MonoBehaviour, IUsable
{
	public UnityEvent OnUse;
	private bool Opened = false;
	[SerializeField] private bool Inverted;
	private AudioSource mySpeaker;
	[SerializeField] private AudioClip openClip;
	[SerializeField] private AudioClip closeClip;

	public bool CanInteract
	{
		get
		{
			return canInteract;
		}
		set
		{
			canInteract = value;
		}
	}
	bool canInteract;

    public void Start()
    {
		mySpeaker = this.GetComponent<AudioSource>();
	}

    public void Use()
	{
		OpenDoor();
	}
	public void OpenDoor()
	{
        if (Opened == false)
        {
		    print("OPEN");
			if (Inverted)
            {
				mySpeaker.clip = openClip;
				mySpeaker.pitch = Random.Range(0.8f, 1.0f);
				mySpeaker.Play();
				actuateDoor(-90);
			} else
            {
				mySpeaker.clip = openClip;
				mySpeaker.pitch = Random.Range(0.8f, 1.0f);
				mySpeaker.Play();
				actuateDoor(90);
			}
			Opened = true;

		} else 	if (Opened == true)
        {
			print("CLOSE");
			mySpeaker.clip = closeClip;
			mySpeaker.pitch = Random.Range(0.8f, 1.0f);
			mySpeaker.Play();
			actuateDoor(0);
			Opened = false;
		}
	}

	public void actuateDoor(int number)
    {
		iTween.RotateTo(this.gameObject, iTween.Hash("rotation",new Vector3(0,number,0),"islocal", true, "time",2f));
    }
}