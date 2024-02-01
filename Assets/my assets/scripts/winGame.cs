using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winGame : MonoBehaviour
{
    [SerializeField]private AudioSource win;
    private bool LevelComplete=false;
    public GameObject nextmenu;
    private void Start()
    {
        win= GetComponent<AudioSource>();
       // nextmenu.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(SceneManager.GetActiveScene().name=="level 10")
        {
            win.Play();
            LevelComplete = true;
            Invoke("completeLevel",1f);
            Debug.Log("level10");
        }
        else if (collision.gameObject.name == "player" && !LevelComplete)
        {
            win.Play();
            LevelComplete = true;
            nextmenu.SetActive(true);
        }
    }
    private void completeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
