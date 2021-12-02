using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace com.amerike.Fernando
{
	public class PlayerCamera : MonoBehaviour
	{
		public delegate void HandlerPlayerCam (PlayerCamera sender);
		public event HandlerPlayerCam OnUse;
		public event HandlerPlayerCam OnGrab;
		public event HandlerPlayerCam onProp;
		public event HandlerPlayerCam onPrompt;

		[HideInInspector] public GameObject GrabbedObj;
		[HideInInspector] public GameObject PropWithDialog;
		[HideInInspector] public GameObject PropPrompt;

		Mouse mouse;
		Camera myCamera;
		float rotationLimit = 0f;
		float rotationX = 0f;

		[Header("Player")]
		[SerializeField] private Transform player;

		[Header("Camera")]
		[SerializeField] private FloatVariable speedCamera;
		[SerializeField] private BoolVariable invertedYAxis;
		[SerializeField] private BoolVariable invertedXAxis;

		[Header("Rycast")]
		[Range(0f, 100f)]
		[SerializeField] float distanceHit;

		[Header("Prompt Canvas")]
		[SerializeField] private GameObject promptCanvas;
		[SerializeField] private Text promptText;

		bool active;
		public bool Active
		{
			get { return active; }
			set { active = value; }
		}

		void Start()
		{
			Prepare();
		}


		void Update()
		{
			if (active)
			{
				if (mouse != null && myCamera != null) CheckMouseInput();
				checkInteractable();
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
			Application.targetFrameRate = 60;
		}

		void CheckMouseInput()
		{
			Vector2 mouseMovement = mouse.delta.ReadValue();
			rotationX = mouseMovement.x * speedCamera.Value * Time.deltaTime * 25f;
			rotationLimit += mouseMovement.y * speedCamera.Value * Time.deltaTime * 25f;
			rotationLimit = Mathf.Clamp(rotationLimit, -80, 80f);

			if (invertedYAxis.Value == false)
				myCamera.transform.localRotation = Quaternion.Euler(rotationLimit * -1, 0, 0);

			if (invertedYAxis.Value)
				myCamera.transform.localRotation = Quaternion.Euler(rotationLimit * 1, 0, 0);

			if (invertedXAxis.Value == false)
				player.Rotate(Vector3.up * rotationX);
			if (invertedXAxis.Value)
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

		void checkInteractable()
        {
			RaycastHit rayHit;
			Vector2 coordinate = new Vector2(Screen.width / 2, Screen.height / 2);
			Ray myRay = myCamera.ScreenPointToRay(coordinate);
			if (Physics.Raycast(myRay, out rayHit, distanceHit))
			{
				IUsable usable = rayHit.transform.GetComponent<IUsable>();
				Grabbable grab = rayHit.transform.GetComponent<Grabbable>();
				PropDialog propDialog = rayHit.transform.GetComponent<PropDialog>();
				if (usable != null || grab != null || propDialog != null)
				{
					promptCanvas.SetActive(true);
					promptText.text = "";
					promptText.text = rayHit.transform.GetComponent<InteractPrompt>().myText;
				} else
                {
					promptText.text = "";
					promptCanvas.SetActive(false);
                }
			} else
            {
				promptText.text = "";
				promptCanvas.SetActive(false);
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
