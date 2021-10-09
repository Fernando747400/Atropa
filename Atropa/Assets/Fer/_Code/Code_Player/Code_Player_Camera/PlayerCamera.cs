using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.amerike.Fernando
{
	public class PlayerCamera : MonoBehaviour
	{
		public delegate void HandlerPlayerCam (PlayerCamera sender);
		public event HandlerPlayerCam OnUse;
		public event HandlerPlayerCam OnGrab;
		public event HandlerPlayerCam onProp;

		[HideInInspector] public GameObject GrabbedObj;
		[HideInInspector] public GameObject PropWithDialog;

		Mouse mouse;
		Camera myCamera;
		float rotationLimit = 0f;
		float rotationX = 0f;

		[Header("Player")]
		[SerializeField] private Transform player;

		[Header("Camera")]
		[Range(0f, 1f)]
		[SerializeField] private float speedCamera = 1;

		[Header("Rycast")]

		[Range(0f, 100f)]
		[SerializeField] float distanceHit;

		bool active;
		bool invertedYAxis;
		bool invertedXAxis;
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}
		public bool InvertedYAxis
		{
			get { return invertedYAxis; }
			set { invertedYAxis = value; }
		}
		public bool InvertedXAxis
		{
			get { return invertedXAxis; }
			set { invertedYAxis = value; }
		}

		void Start()
		{
			Prepare();
		}


		void FixedUpdate()
		{
			if (active)
			{

				if (mouse != null && myCamera != null) CheckMouseInput();
			}
		}

		void Prepare()
		{
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR || UNITY_STANDALONE_LINUX
			mouse = Mouse.current;
#endif

			try { myCamera = Camera.main; }
			catch { myCamera = GetComponent<Camera>(); }

			active = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		void CheckMouseInput()
		{
			Vector2 mouseMovement = mouse.delta.ReadValue();
			rotationX = mouseMovement.x * speedCamera;
			rotationLimit += mouseMovement.y * speedCamera;
			rotationLimit = Mathf.Clamp(rotationLimit, -80, 80f);

			if (!invertedYAxis)
				myCamera.transform.localRotation = Quaternion.Euler(rotationLimit * -1, 0, 0);

			if (invertedYAxis)
				myCamera.transform.localRotation = Quaternion.Euler(rotationLimit * 1, 0, 0);

			if (!invertedXAxis)
				player.Rotate(Vector3.up * rotationX);
			if (invertedXAxis)
				player.Rotate(Vector3.up * rotationX * -1);


			if (mouse.leftButton.wasPressedThisFrame)
			{
				GetViewInfo();
			}

			if (mouse.rightButton.wasPressedThisFrame)
            {
				leaveObject();
            }
		}

		void GetViewInfo()
		{
			RaycastHit hit;
			Vector2 coordinate = new Vector2(Screen.width / 2, Screen.height / 2);
			Ray myRay = myCamera.ScreenPointToRay(coordinate);
			if (Physics.Raycast(myRay, out hit, distanceHit))
			{
				IUsable usable = hit.transform.GetComponent<IUsable>();
				if (usable != null)
				{
					usable.Use();
				}
				Grabbable grab = hit.transform.GetComponent<Grabbable>();
				if (grab != null)
				{
					GrabbedObj = grab.gameObject;
					if (OnGrab != null)//si alguien esta suscrito a este evento
					{
						OnGrab(this);
						player.gameObject.GetComponent<PlayerMovement>().Active = false;
					}
				}
				PropDialog propDialog = hit.transform.GetComponent<PropDialog>();
				if(propDialog != null)
                {
					PropWithDialog = propDialog.gameObject;
					if (onProp != null)
                    {
						onProp(this);
					}									
                }
			}
		}

		void leaveObject()
        {
			if (GrabbedObj != null)
            {
				GrabbedObj.GetComponent<Grabbable>().droppObject();
				GrabbedObj = null;
				player.gameObject.GetComponent<PlayerMovement>().Active = true;
			}
        }
	}
}
