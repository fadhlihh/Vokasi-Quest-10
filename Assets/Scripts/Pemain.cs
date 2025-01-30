using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Pemain : MonoBehaviour
{
    public List<TanganPemain> ListTanganPemain = new List<TanganPemain>();
    public int Skor;
    public List<TanganPemain> KartuPilihan = new List<TanganPemain>();
    public ManagerKartu ManagerKartu;
    public AlurGame AlurGame;
    public Button ButtonBuangKartu;
    public Button ButtonKombinasi;
    public Button ButtonTambahWaktu;
    public GameObject PopUpInfo;
    public TMP_Text TextPopUpInfo;

    private void OnEnable()
    {
        for (int index = 0; index < ListTanganPemain.Count; index++)
        {
            ListTanganPemain[index].EventPilihKartu.AddListener(PilihKartu);
        }
    }

    private void OnDisable()
    {
        for (int index = 0; index < ListTanganPemain.Count; index++)
        {
            ListTanganPemain[index].EventPilihKartu.RemoveListener(PilihKartu);
        }
    }

    public void MulaiBermain()
    {

        AmbilKartuAwalan();
        MulaiMemilihKartu();
    }

    public void AmbilKartuAwalan()
    {
        for (int index = 0; index < ListTanganPemain.Count; index++)
        {
            Kartu kartu = ManagerKartu.AmbilCangkulan();
            GantiKartu(index, kartu);
        }
    }

    public void MulaiMemilihKartu()
    {
        for (int index = 0; index < ListTanganPemain.Count; index++)
        {
            ListTanganPemain[index].SimpanKartu();
        }
        ButtonBuangKartu.interactable = false;
        ButtonKombinasi.interactable = false;
        ButtonTambahWaktu.interactable = false;

        StartCoroutine(MunculkanPopUpInfo("Pilih Kombinasi Kartu atau Buang 1 Kartu"));

    }

    public void GantiKartu(int indexKartu, Kartu kartuBaru)
    {
        ListTanganPemain[indexKartu].UpdateDataKartu(kartuBaru);
    }

    public void PilihKartu(TanganPemain kartu)
    {
        kartu.UbahKartuDipilih(!kartu.KartuDipilih);
        if (kartu.KartuDipilih == true)
        {
            kartu.PilihKartu();
            KartuPilihan.Add(kartu);
        }
        else
        {
            kartu.SimpanKartu();
            KartuPilihan.Remove(kartu);
        }

        HitungSkorKartu();
    }

    public void HitungSkorKartu()
    {
        Skor = 0;
        if (KartuPilihan.Count > 0)
        {
            for (int index = 0; index < KartuPilihan.Count; index++)
            {
                Skor = Skor + KartuPilihan[index].DataKartu.Skor;
            }

            EvaluasiKartu();
        }
        else
        {
            EvaluasiKartu();
        }
    }

    public void EvaluasiKartu()
    {
        if (Skor == 10)
        {
            if (KartuPilihan.Count == 3)
            {
                ButtonBuangKartu.interactable = false;
                ButtonKombinasi.interactable = true;
                ButtonTambahWaktu.interactable = false;
            }
            else if (KartuPilihan.Count == 2)
            {
                ButtonBuangKartu.interactable = false;
                ButtonKombinasi.interactable = false;
                ButtonTambahWaktu.interactable = true;
            }
        }

        else
        {
            if (KartuPilihan.Count == 1)
            {
                ButtonBuangKartu.interactable = true;
                ButtonKombinasi.interactable = false;
                ButtonTambahWaktu.interactable = false;
            }

            else
            {
                ButtonBuangKartu.interactable = false;
                ButtonKombinasi.interactable = false;
                ButtonTambahWaktu.interactable = false;
            }
        }
    }

    public void BuangKartu()
    {
        AlurGame.KurangiWaktu();
        TukarKartu();
        StartCoroutine(MunculkanPopUpInfo("Kamu Makin Dekat Waktu Ujian"));
    }

    public void KumpulkanKombinasi()
    {
        ButtonKombinasi.interactable = false;
        AlurGame.Menang();
    }

    public void TambahWaktu()
    {
        AlurGame.TambahWaktu();
        TukarKartu();
        StartCoroutine(MunculkanPopUpInfo("Kamu Dapat Tambahan Waktu 1 Hari"));
    }

    public void TukarKartu()
    {
        for (int index = 0; index < KartuPilihan.Count; index++)
        {
            TanganPemain kartuPilihan = KartuPilihan[index];
            ManagerKartu.TambahKartuBuangan(kartuPilihan.DataKartu);

            Kartu kartuBaru = ManagerKartu.AmbilCangkulan();

            int indexKartuPemain = ListTanganPemain.IndexOf(kartuPilihan);
            GantiKartu(indexKartuPemain, kartuBaru);
        }

        KartuPilihan.Clear();
        SelesaiMemilihKartu();

    }

    public void SelesaiMemilihKartu()
    {
        for (int index = 0; index < ListTanganPemain.Count; index++)
        {
            ListTanganPemain[index].SimpanKartu();
            ListTanganPemain[index].UbahKartuDipilih(false);
        }

        MulaiMemilihKartu();
    }

    public IEnumerator MunculkanPopUpInfo(string pesan)
    {
        TextPopUpInfo.text = pesan;
        PopUpInfo.SetActive(true);
        yield return new WaitForSeconds(5);
        PopUpInfo.SetActive(false);
    }
}