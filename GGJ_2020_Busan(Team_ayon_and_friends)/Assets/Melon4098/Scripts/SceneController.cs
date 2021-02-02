using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Gamestart()
    {
        Invoke("ChangeScene_opening", 2.5f);
    }

    void ChangeScene_opening()
    {
        SceneManager.LoadScene("Opening");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Exit()
    {
       
    }
}
