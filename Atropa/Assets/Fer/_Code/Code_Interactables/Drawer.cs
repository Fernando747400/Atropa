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
			actuateDrawer(finalPosition);
			Opened = true;
		}
		else if (Opened == true)
		{
			print("CLOSE");
			actuateDrawer(startPosition);
			Opened = false;
		}
	}

	public void actuateDrawer(Vector3 position)
	{
		iTween.MoveTo(this.gameObject, iTween.Hash("position", position, "islocal", true, "time", 1f));
	}
}
