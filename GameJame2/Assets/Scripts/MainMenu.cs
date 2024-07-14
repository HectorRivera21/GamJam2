using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void GoToCredits(){
        SceneManager.LoadScene("Credits");
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
