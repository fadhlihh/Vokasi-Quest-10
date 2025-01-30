using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject PanelCredit;
    
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MunculkanKredit()
    { 
        PanelCredit.SetActive(true);
    }

    public void TutupKredit()
    {
        PanelCredit.SetActive(false);
    }
}
