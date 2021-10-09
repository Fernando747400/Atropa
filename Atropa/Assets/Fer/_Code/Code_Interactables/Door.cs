using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Door : MonoBehaviour, IUsable
{
	public UnityEvent OnUse;
	private bool Opened = false;
	[SerializeField] private bool Inverted;

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
				actuateDoor(-90);
			} else
            {
				actuateDoor(90);
			}
			Opened = true;

		} else 	if (Opened == true)
        {
			print("CLOSE");
			actuateDoor(0);
			Opened = false;
		}
	}

	public void actuateDoor(int number)
    {
		iTween.RotateTo(this.gameObject, iTween.Hash("rotation",new Vector3(0,number,0),"islocal", true, "time",2f));
    }
}