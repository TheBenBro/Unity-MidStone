using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string PlayGame;
    public string Credits;
    public string Menu;
    // Start is called before the first frame update

    public void LoadMenu()
    {
        SceneManager.LoadScene(Menu);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(PlayGame);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(Credits);
    }
    // Update is called once per frame
public void QuitGame()
    {
        Application.Quit();
    }

    public void OnTriggerStay(Collider other)
    {
        SceneManager.LoadScene(Menu);
    }
}
