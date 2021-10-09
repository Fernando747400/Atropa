using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{ 
    public void loadGame()
    {
        SceneManager.LoadScene("01_Main_Scene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
