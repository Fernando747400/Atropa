using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace com.amerike.Fernando
{
    public class TextIteretaor_UI : MonoBehaviour
    {
		public PlayerMovement playerScript;
		public PlayerCamera cameraScript;
		public GameObject DialogCanvas;
		public float textSpeed = 0.5f;
		TextMeshProUGUI textMesh;
		Coroutine corIterateText;
		public string myText;
		Mouse raton;
		private bool finished = false;

        public void Awake()
        {
			textMesh = GetComponent<TextMeshProUGUI>();
			/*
			if (textMesh != null)
			{
				myText = textMesh.text;
				textMesh.text = "";
			}
			//Show();
			*/
		}

        public void OnEnable()
        {		
			finished = false;
			textMesh.text = "";
		}

        void Update()
		{
			raton = Mouse.current;
			if (raton.middleButton.wasPressedThisFrame)
			{
				Skip();
			}

			if (raton.rightButton.wasPressedThisFrame && finished == true)
            {
				playerScript.Active = true;
				cameraScript.Active = true;
				DialogCanvas.SetActive(false);
            }
		}
		void Skip()
		{
			if (corIterateText != null)
			{
				StopCoroutine(corIterateText);
			}
			textMesh.text = myText;
			finished = true;
		}
		public void Show()
		{
			textMesh.text = "";
			if (corIterateText != null)
			{
				StopCoroutine(corIterateText);
			}
			playerScript.Active = false;
			cameraScript.Active = false;
			finished = false;
			corIterateText = StartCoroutine(CorIterateText(myText));
		}

		IEnumerator CorIterateText(string text)
		{
			char[] charArray = text.ToCharArray();
			for (int i = 0; i < charArray.Length; i++)
			{
				textMesh.text += charArray[i];
				yield return new WaitForSeconds(textSpeed);
			}
			finished = true;
		}
	}
}
