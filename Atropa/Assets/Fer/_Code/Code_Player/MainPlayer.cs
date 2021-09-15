using UnityEngine;
using com.amerike.Fernando;

public class MainPlayer : MonoBehaviour
{
	public com.amerike.Fernando.PlayerMovement _PlayerMovement;
	public com.amerike.Fernando.PlayerCamera _PlayerCamera;
	public Transform myHand;
	void Awake()
	{
		Prepare();
	}
	void Prepare()
	{
		if(_PlayerCamera != null)
		{
			_PlayerCamera.OnGrab += HandleOnGrab;
		}
	}
	void HandleOnGrab (PlayerCamera sender)
	{
		sender.GrabbedObj.transform.position = myHand.transform.position;
		sender.GrabbedObj.transform.rotation = myHand.transform.rotation;
		sender.GrabbedObj.transform.parent = myHand.transform;
	}
}
