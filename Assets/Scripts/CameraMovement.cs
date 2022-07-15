using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{

    private GameObject Player;
    public GameObject ManagementPlace;

    Vector3 aradakiFark;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        aradakiFark = transform.position - Player.transform.position;
    }


    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + aradakiFark.y, Player.transform.position.z + aradakiFark.z), Time.deltaTime * 5f);

    }


    public void KamerayiYonlendir(GameObject odakNoktasi)
    {
        //transform.position = Vector3.Lerp(transform.position, new Vector3(odakNoktasi.transform.position.x, odakNoktasi.transform.position.y + aradakiFark.y, odakNoktasi.transform.position.z + aradakiFark.z), Time.deltaTime * 5f);

     
        Player = odakNoktasi;
        //GameController.instance._kameraHareketli = true;

        Invoke("KamerayiResetle", 3f);
    }

    public void KamerayiResetle()
    {
        ManagementPlace.GetComponent<ManagementPlaces>().locationArrow.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
        //GameController.instance._kameraHareketli = false;
    }

}
