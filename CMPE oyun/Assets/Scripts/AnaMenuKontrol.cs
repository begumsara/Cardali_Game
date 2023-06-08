using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenuKontrol : MonoBehaviour
{
    public GameObject surePanel;

    void Start()
    {
        
    }

    public void Oyna()
    {
        SceneManager.LoadScene(1);
    }

    public void Cik()
    {
        surePanel.SetActive(true);
    }

    public void CikisYesNo(string cevap)
    {
        switch(cevap)
        {
            case "evet":
                Application.Quit();
                break;
            case "hayir":
                surePanel.SetActive(false);
                break;
        }
    }
}
