using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Toggle YAxis;
    public Toggle XAxis;
    public Slider Sensitivity;
    public BoolVariable Yaxis;
    public BoolVariable Xaxis;
    public FloatVariable sensitivity; 

    // Update is called once per frame
    void Update()
    {
        if (Yaxis.Value == true)
        {
            YAxis.isOn = true;
        } else if (Yaxis.Value == false)
        {
            YAxis.isOn = false;
        }

        if (Xaxis.Value == true)
        {
            XAxis.isOn = true;
        }
        else if (Xaxis.Value == false)
        {
            XAxis.isOn = false;
        }

        Sensitivity.value = sensitivity.Value;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("00_Main_Menu");
    }
}
