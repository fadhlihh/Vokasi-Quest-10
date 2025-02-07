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
    public AudioSource EfekSuaraMenang;
    public AudioSource EfekSuaraKalah;
    public AudioSource EfekSuaraWaktuBertambah;
    public AudioSource EfekSuaraWaktuBerkurang;
    public AudioSource MusikLatarBelakang;

    private void Start(){
        //Menyiapkan kartu cangkulan
        ManagerKartu.IsiCangkulan(ManagerKartu.DatabaseKartu.ListKartu);
        //Game dimulai
        Pemain.MulaiBermain();
    }

    public void KurangiWaktu(){
        BanyaknyaWaktu = BanyaknyaWaktu - 1;
        UpdateTextBanyaknyaWaktu();
        if(BanyaknyaWaktu>0){
            EfekSuaraWaktuBerkurang.Play();
        }
        if(BanyaknyaWaktu<=0){
            Kalah();
        }
    }

    public void TambahWaktu(){
        BanyaknyaWaktu = BanyaknyaWaktu + 1;
        UpdateTextBanyaknyaWaktu();
        EfekSuaraWaktuBertambah.Play();
    }

    public void UpdateTextBanyaknyaWaktu(){
        TextBanyaknyaWaktu.text = BanyaknyaWaktu.ToString();
    }

    public void Menang(){
        PanelBerhasil.SetActive(true);
        EfekSuaraMenang.Play();
        MusikLatarBelakang.Pause();
    }

    public void Kalah(){
        PanelKalah.SetActive(true);
        EfekSuaraKalah.Play();
        MusikLatarBelakang.Pause();
    }

    public void Retry(){
        SceneManager.LoadScene("Game");
    }

    public void MenuUtama(){
        SceneManager.LoadScene("MenuUtama");
    }

}
