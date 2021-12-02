using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.amerike.Fernando;

public class ProgressManager : MonoBehaviour
{

    public static ProgressManager current;
    public int foundObjects;
    private bool firstHouse;
    private bool secondHouse;
    private bool thirdHouse;
    private bool fourthHouse;
    private bool fifthHouse;
    private bool sixthHouse;
    private bool seventhHouse;
    private bool lastCup;
    public GameObject DialogManager;
    public GameObject textIterator;
    public CharacterController characterController;
    [SerializeField] private GameObject[] ExplosionTrigger = new GameObject[8];
    public void Awake()
    {
        current = this;
    }

    public void Start()
    {
        foundObjects = 0;
        firstHouse = false;
        secondHouse = false;
        thirdHouse = false;
        fourthHouse = false;
        fifthHouse = false;
        sixthHouse = false;
        seventhHouse = false;
        lastCup = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkFirstHouse();
        checkSecondHouse();
    }

    void checkFirstHouse()
    {
        if (foundObjects == 8 && firstHouse == false)
        {
            if (characterController.isGrounded && characterController.velocity.magnitude > 2f && !DialogManager.activeInHierarchy)
            {
                DialogManager.SetActive(true);
                textIterator.GetComponent<TextIteretaor_UI>().myText = "Those where all the memories I had in my Infancy. It's time to head outside and go to the bus stop";
                textIterator.GetComponent<TextIteretaor_UI>().Show();
                firstHouse = true;
                ExplosionTrigger[0].gameObject.SetActive(true);
            }
        }
    }

    void checkSecondHouse()
    {
        if (foundObjects == 16 && secondHouse == false)
        {
            if (characterController.isGrounded && characterController.velocity.magnitude > 2f && !DialogManager.activeInHierarchy)
            {
                DialogManager.SetActive(true);
                textIterator.GetComponent<TextIteretaor_UI>().myText = "This is where I really started to make memories. That trip really made me bond with my parents from now on. [...] I need to head outside";
                textIterator.GetComponent<TextIteretaor_UI>().Show();
                secondHouse = true;
                ExplosionTrigger[1].gameObject.SetActive(true);
            }
        }
    }
}
