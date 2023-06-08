using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject patron;
   
    void Start()
    {
        
    }

    public void Kazandin()
    {
        patron.GetComponent<Animator>().Play("patron_kaybetme");
        Cursor.lockState = CursorLockMode.None;
        Invoke("winPanelPlay", 3f); 
    }

    public void winPanelPlay()
    {
        winPanel.SetActive(true);
    }

    public void Kaybettin()
    { 
        Cursor.lockState = CursorLockMode.None;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void YenidenOyna()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void AnaMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
