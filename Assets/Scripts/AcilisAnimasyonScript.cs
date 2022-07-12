using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AcilisAnimasyonScript : MonoBehaviour
{

    //[SerializeField] private GameObject AcilacakObje;

    //[SerializeField] private bool _sezlong;

    void Start()
    {

        transform.localScale = Vector3.zero;

        gameObject.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f).OnComplete(() => gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));



    }


    /*
        public void ChildKapat()
        {
            AcilacakObje.SetActive(false);
        }

    */
    public void AcilisAnim()
    {


        transform.localScale = Vector3.zero;

        gameObject.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f).OnComplete(() => gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f));

    }

}
