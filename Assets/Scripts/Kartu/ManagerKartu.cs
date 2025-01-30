using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ManagerKartu : MonoBehaviour
{
    public DatabaseKartu DatabaseKartu;
    public Stack<Kartu> KartuCangkulan  = new Stack<Kartu>();
    public List<Kartu> KartuBuangan  = new List<Kartu>();
    public TMP_Text TextBanyaknyaCangkulan;

    public void IsiCangkulan(List<Kartu> ListKartu){
        for(int index = 0; KartuCangkulan.Count < ListKartu.Count; index++){
            int indexAcak = Random.Range(0, DatabaseKartu.ListKartu.Count);
            while(!KartuCangkulan.Contains(DatabaseKartu.ListKartu[indexAcak])){
                KartuCangkulan.Push(DatabaseKartu.ListKartu[indexAcak]);
                UpdateTextBanyaknyaCangkulan();
            }
        }
    }

    public Kartu AmbilCangkulan(){
        Kartu kartu = KartuCangkulan.Pop();
        UpdateTextBanyaknyaCangkulan();
        if(KartuCangkulan.Count <= 0){
            IsiCangkulan(KartuBuangan);
            KartuBuangan.Clear();
        }
        return kartu;
    }

    public void UpdateTextBanyaknyaCangkulan(){
        TextBanyaknyaCangkulan.text = KartuCangkulan.Count.ToString();
    }

    public void TambahKartuBuangan(Kartu kartu){
        KartuBuangan.Add(kartu);
    }

}

