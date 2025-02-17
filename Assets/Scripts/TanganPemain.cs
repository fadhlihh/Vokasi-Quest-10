using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TanganPemain : MonoBehaviour
{
    public Kartu DataKartu;
    public SkinnedMeshRenderer MeshRendererKartu;
    public MeshFilter MeshFilterKartu;
    public Color WarnaNormal;
    public Color WarnaHighlight;
    public bool KartuDipilih;
    public UnityEvent<TanganPemain> EventPilihKartu;


    private void OnMouseDown()
    {
        EventPilihKartu.Invoke(this);
    }

    public void UpdateDataKartu(Kartu dataKartuBaru)
    {
        DataKartu = dataKartuBaru;
        MeshRendererKartu.material = DataKartu.MaterialKartu;
        //MeshFilterKartu.mesh = DataKartu.MeshKartu;
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
