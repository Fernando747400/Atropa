using UnityEngine;
using TMPro;
using com.amerike.Fernando;

public class MainPlayer : MonoBehaviour
{
	public com.amerike.Fernando.PlayerMovement _PlayerMovement;
	public com.amerike.Fernando.PlayerCamera _PlayerCamera;
	public Transform myHand;
	public GameObject DialogManager;
	public GameObject textIterator;
	void Awake()
	{
		Prepare();
	}
	void Prepare()
	{
		if(_PlayerCamera != null)
		{
			_PlayerCamera.OnGrab += HandleOnGrab;
			_PlayerCamera.onProp += HandleOnProp;
		}
	}
	void HandleOnGrab (PlayerCamera sender)
	{
		sender.GrabbedObj.transform.position = myHand.transform.position;
		sender.GrabbedObj.transform.rotation = myHand.transform.rotation;
		sender.GrabbedObj.transform.parent = myHand.transform;
	}

	void HandleOnProp(PlayerCamera sender)
	{
		DialogManager.SetActive(true);
		textIterator.GetComponent<TextIteretaor_UI>().myText = sender.PropWithDialog.GetComponent<PropDialog>().Dialog;
		textIterator.GetComponent<TextIteretaor_UI>().Show();
	}
}
