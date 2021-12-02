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
        foundObjects = 34;
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
        //checkFirstHouse();
        //checkSecondHouse();
        //checkThirdHouse();
        //checkFourthHouse();
        checkFifthHouse();
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

    void checkThirdHouse()
    {
        if (foundObjects == 25 && thirdHouse == false)
        {
            if (characterController.isGrounded && characterController.velocity.magnitude > 2f && !DialogManager.activeInHierarchy)
            {
                DialogManager.SetActive(true);
                textIterator.GetComponent<TextIteretaor_UI>().myText = "I will never forget this Chirstmas... It was my favourite by far. But I need to continue. Actually, I'm not sure what's happening. I need to go outside";
                textIterator.GetComponent<TextIteretaor_UI>().Show();
                thirdHouse = true;
                ExplosionTrigger[2].gameObject.SetActive(true);
            }
        }
    }

    void checkFourthHouse()
    {
        if (foundObjects == 34 && fourthHouse == false)
        {
            if (characterController.isGrounded && characterController.velocity.magnitude > 2f && !DialogManager.activeInHierarchy)
            {
                DialogManager.SetActive(true);
                textIterator.GetComponent<TextIteretaor_UI>().myText = "Always be thankfull for having those who love close by. Atleast I'm thankfull I'm... I need to keep going. Let's go outside.";
                textIterator.GetComponent<TextIteretaor_UI>().Show();
                fourthHouse = true;
                ExplosionTrigger[3].gameObject.SetActive(true);
            }
        }
    }

    void checkFifthHouse()
    {
        if (foundObjects == 41 && fifthHouse == false)
        {
            if (characterController.isGrounded && characterController.velocity.magnitude > 2f && !DialogManager.activeInHierarchy)
            {
                DialogManager.SetActive(true);
                textIterator.GetComponent<TextIteretaor_UI>().myText = "Always be thankfull for having those who love close by. Atleast I'm thankfull I'm... I need to keep going. Let's go outside.";
                textIterator.GetComponent<TextIteretaor_UI>().Show();
                fifthHouse = true;
                ExplosionTrigger[4].gameObject.SetActive(true);
            }
        }
    }
}
