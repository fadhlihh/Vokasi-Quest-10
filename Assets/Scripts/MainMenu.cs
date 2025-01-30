using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject PanelCredit;
    
    public void Play()
    {
        SceneManager.LoadScene("SceneGame");
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
