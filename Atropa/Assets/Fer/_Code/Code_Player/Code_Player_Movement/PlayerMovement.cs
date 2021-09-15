using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace com.amerike.Fernando
{
	[RequireComponent(typeof(CharacterController))]

	//Receives input and moves the main player
	public class PlayerMovement : MonoBehaviour
	{
		public UnityEvent OnPrepare;
		public bool Active
		{
			get
			{
				return active;
			}
			set
			{
				active = value;
			}
		}

		Keyboard keyBoard;
		Gamepad gamePad;
		CharacterController characterController;

		private bool active;
		private Vector3 movementDirection;
		private Vector3 velocity;
		private Vector3 CamRight;
		private Vector3 CamForward;
		private float verticalSpeed;
		public float movementSpeed = 1.0f;
		public float gravity = 9.8f;
		public float jumpHeight = 1.0f;

		void Prepare()
		{
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
			keyBoard = Keyboard.current;
#endif
			gamePad = Gamepad.current;
			characterController = GetComponent<CharacterController>();
			active = true;
			if (OnPrepare != null)
			{
				OnPrepare.Invoke();
			}
		}

		public void Start()
		{
			Prepare();
		}
		void FixedUpdate()
		{
			if (active)
			{
				if (keyBoard != null)
				{
					CheckInputKeyBoard();
				}
			}
		}
		void CheckInputKeyBoard()
		{
			movementDirection = Vector3.zero;
			CamForward = Camera.main.transform.forward;
			CamRight = Camera.main.transform.right;
			CamForward.y = 0;
			CamRight.y = 0;
			if (keyBoard.wKey.isPressed)
			{
				movementDirection += CamForward;
			}
			if (keyBoard.sKey.isPressed)
			{
				movementDirection -= CamForward;
			}
			if (keyBoard.aKey.isPressed)
			{
				movementDirection -= CamRight;
			}
			if (keyBoard.dKey.isPressed)
			{
				movementDirection += CamRight;
			}
			if (characterController.isGrounded)
			{
				verticalSpeed = 0;
				if (keyBoard.spaceKey.isPressed)
				{
					verticalSpeed = jumpHeight;
				}
			}
			verticalSpeed -= gravity * Time.deltaTime;
			movementDirection.y = verticalSpeed;
			movementDirection.Normalize();
			Move(movementDirection);
		}
		void Move(Vector3 direction)
		{
			characterController.Move((direction * 0.1f) * movementSpeed);
		}
	}
}
