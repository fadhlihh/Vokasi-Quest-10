using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Database Kartu", menuName = "Database/Kartu")]
public class DatabaseKartu : ScriptableObject
{
    public List<Kartu> ListKartu = new List<Kartu>();
}


