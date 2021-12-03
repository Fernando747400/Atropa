using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPrompt : MonoBehaviour
{
    //public Canvas InteractCanvas;
    //public Text interactionText;
    [HideInInspector] public string myText = "";

    public void Start()
    {
        if(TryGetComponent(out PropDialog typeofProp))
        {
            myText = "Inspect";
        } else if (TryGetComponent(out Drawer typeofDrawer) || TryGetComponent(out Door typeofDoor) || TryGetComponent(out Oven typeofOven))
        {
            myText = "Interact";
        } else if (TryGetComponent(out Grabbable typeofGrabbale))
        {
            myText = "Grab";
        } 
        
        if (TryGetComponent(out AliceBeverage typeofAlice))
        {
            myText = "Drink";
        }
    }

    /*
    public void OnMouseOver()
    {
        print(transform.name);
        InteractCanvas.gameObject.SetActive(true);
        interactionText.text = myText;
    }

    public void OnMouseExit()
    {
        print("Exited " + transform.name);
        interactionText.text = "";
        InteractCanvas.gameObject.SetActive(false);
    }
    */
}
