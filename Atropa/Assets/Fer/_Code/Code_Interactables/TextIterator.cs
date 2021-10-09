﻿using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

namespace com.amerike.Fernando
{
	public class TextIterator : MonoBehaviour
	{
		public float textSpeed = 0.5f;
		TextMeshPro textMesh;
		Coroutine corIterateText;
		string myText;
		Mouse raton;
		
		void Start()
		{
			textMesh = GetComponent<TextMeshPro>();
			if(textMesh != null)
			{
				myText = textMesh.text;
				textMesh.text = "";
			}
			Show();
		}

		void Update()
		{
			raton = Mouse.current;
			if(raton.middleButton.wasPressedThisFrame)
			{
				Skip();
			}
		}
		void Skip()
		{
			if(corIterateText != null)
			{
				StopCoroutine (corIterateText);
			}
			textMesh.text = myText;
		}
		void Show()
		{
			if(corIterateText != null)
			{
				StopCoroutine (corIterateText);
			}
			corIterateText = StartCoroutine (CorIterateText (myText) );
		}
	
		IEnumerator CorIterateText(string text)
		{
			char[] charArray = text.ToCharArray();
			for(int i = 0; i < charArray.Length; i++)
			{
				textMesh.text += charArray[i];
				yield return new WaitForSeconds(textSpeed);
			}
		}
	}
}