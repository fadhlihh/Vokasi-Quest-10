using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlurGame : MonoBehaviour
{
    public ManagerKartu ManagerKartu;
    public Pemain Pemain;
    public int BanyaknyaWaktu;
    public TMP_Text TextBanyaknyaWaktu;
    public GameObject PanelKalah;
    public GameObject PanelBerhasil;

    private void Start(){
        //Menyiapkan kartu cangkulan
        ManagerKartu.IsiCangkulan(ManagerKartu.DatabaseKartu.ListKartu);
        //Game dimulai
        Pemain.MulaiBermain();
    }

    public void KurangiWaktu(){
        BanyaknyaWaktu = BanyaknyaWaktu - 1;
        UpdateTextBanyaknyaWaktu();
        if(BanyaknyaWaktu<=0){
            Kalah();
        }
    }

    public void TambahWaktu(){
        BanyaknyaWaktu = BanyaknyaWaktu + 1;
        UpdateTextBanyaknyaWaktu();
    }

    public void UpdateTextBanyaknyaWaktu(){
        TextBanyaknyaWaktu.text = "Kesempatan: "+BanyaknyaWaktu;
    }

    public void Menang(){
        PanelBerhasil.SetActive(true);
    }

    public void Kalah(){
        PanelKalah.SetActive(true);
    }

    public void Retry(){
        SceneManager.("SceneGame");
    }

    public void MenuUtama(){
        SceneManager.("SceneMenuUtama");
    }

}
