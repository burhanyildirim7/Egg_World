using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listeler : MonoBehaviour
{

    public static Listeler instance;

    public List<GameObject> _tavukKumesleri = new List<GameObject>();
    public List<GameObject> _kazKumesleri = new List<GameObject>();
    public List<GameObject> _deveKusuKumesleri = new List<GameObject>();
    public List<GameObject> _timsahKumesleri = new List<GameObject>();
    public List<GameObject> _ejderhaKumesleri = new List<GameObject>();



    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
