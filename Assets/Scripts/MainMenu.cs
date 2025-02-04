using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject PanelCredit, PanelPanduan;
    
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

    public void PanduanOpen()
    {
        PanelPanduan.SetActive(true);
    }

    public void PanduanClose()
    {
        PanelPanduan.SetActive(false);
    }
}
