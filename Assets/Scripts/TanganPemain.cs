using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TanganPemain : MonoBehaviour
{
    public Kartu DataKartu;
    public MeshRenderer MeshRendererKartu;
    public MeshFilter MeshFilterKartu;
    public Color WarnaNormal;
    public Color WarnaHighlight;
    public bool KartuDipilih;
    public UnityEvent<TanganPemain> EventPilihKartu;


    public void OnMouseDown()
    {
        EventPilihKartu.Invoke(this);
    }

    public void UpdateDataKartu(Kartu dataKartuBaru)
    {
        DataKartu = dataKartuBaru;
        MeshRendererKartu.material = DataKartu.MaterialKartu;
        MeshFilterKartu.material = DataKartu.MeshKartu;
        KartuDipilih = false;
    }

    public void PilihKartu()
    {
        MeshRendererKartu.material.color = WarnaHighlight;
    }

    public void SimpanKartu()
    {
        MeshRendererKartu.material.color = WarnaNormal;
    }

    public void UbahKartuDipilih(bool statusKartuDipilih)
    {
        KartuDipilih = statusKartuDipilih;
    }
}
