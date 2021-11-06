using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPrompt : MonoBehaviour
{
    public Canvas InteractCanvas;
    public Component typeOfScript;
    public Text interactionText;
    private string myText = "";

    public void Start()
    {
        if(TryGetComponent(out PropDialog typeofProp))
        {
            myText = "Inspect";
        } else if (TryGetComponent(out Drawer typeofDrawer) || TryGetComponent(out Door typeofDoor) || TryGetComponent(out Oven typeofOven))
        {
            myText = "Interact";
        }
    }

    public void OnMouseEnter()
    {
        InteractCanvas.gameObject.SetActive(true);
        interactionText.text = myText;
    }

    public void OnMouseExit()
    {
        InteractCanvas.gameObject.SetActive(false);
        interactionText.text = myText;
    }
}
