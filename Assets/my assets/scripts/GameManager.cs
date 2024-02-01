using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool paused = true;
    public GameObject pausemenu;
    public GameObject nextmenu;
    private void Start()
    {
        pausemenu.SetActive(false);
        nextmenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if(paused)
            {
                Time.timeScale = 0f;
                pausemenu.SetActive(true);
            }
            else
            {
               
                Resume();
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pausemenu.SetActive(false);
    }
    public void restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void NextLLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
