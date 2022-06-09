using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpendBoxControl : MonoBehaviour
{

    public List<GameObject> spendEggList = new List<GameObject>();

    private void Update()
    {
        for (var i = spendEggList.Count - 1; i > -1; i--)
        {
            if (spendEggList[i] == null)
                spendEggList.RemoveAt(i);
        }
    }

}
