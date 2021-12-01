using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drawer : MonoBehaviour, IUsable
{
	public UnityEvent OnUse;
	private bool Opened = false;
	private Vector3 startPosition;
	private Vector3 finalPosition;
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
		startPosition = this.gameObject.transform.localPosition;
		finalPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z * 2.1f);
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
			mySpeaker.clip = openClip;
			mySpeaker.pitch = Random.Range(0.8f,1.0f);
			actuateDrawer(finalPosition);
			mySpeaker.Play();
			Opened = true;
		}
		else if (Opened == true)
		{
			print("CLOSE");
			mySpeaker.clip = closeClip;
			mySpeaker.pitch = Random.Range(0.8f, 1.0f);
			actuateDrawer(startPosition);
			mySpeaker.Play();
			Opened = false;
		}
	}

	public void actuateDrawer(Vector3 position)
	{
		iTween.MoveTo(this.gameObject, iTween.Hash("position", position, "islocal", true, "time", 2f));
	}
}
