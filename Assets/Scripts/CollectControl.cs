using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectControl : MonoBehaviour
{
    public float eggSpawnTime;
    public float eggMoveToPlayerTime;
    float distanceY = 0;
    float delayTime = 0;
    public GameObject egg;
    bool canEggSpawn = true;
    bool canEggSpend = true;   
    public List<GameObject> eggList = new List<GameObject>();
    public List<GameObject> eggStackTransform = new List<GameObject>();
    public List<GameObject> eggSpendTransform = new List<GameObject>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (eggList.Count == eggStackTransform.Count)
        {
            canEggSpawn = false;
        }

        for (var i = eggList.Count - 1; i > -1; i--)
        {
            if (eggList[i] == null)
                eggList.RemoveAt(i);
        }

    }

     public void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "egg")
        {

            other.gameObject.transform.DOKill();
            MoveEggToSepet(other.gameObject);

        }
    }
    void OnTriggerStay(Collider other)
    {
   

        if (other.gameObject.tag == "spend")
        {
            MoveEggsToSpend(other.gameObject);
        }
    }

 

    public void MoveEggToSepet(GameObject otherObject)
    {

     
        for (int i = 0; i < eggStackTransform.Count; i++)
        {
            if (eggStackTransform[i].tag == "empty")
            {
                eggList.Add(otherObject);
                GameObject.FindGameObjectWithTag("collect").GetComponent<CollectBoxControl>().eggList2.Remove(otherObject.gameObject);
                otherObject.transform.parent.gameObject.tag = "empty";
                otherObject.transform.parent = eggStackTransform[i].transform;
                otherObject.transform.rotation = eggStackTransform[i].transform.rotation;
                otherObject.transform.DOLocalJump(new Vector3(0, 3, 0), 2, 1, (Time.deltaTime / eggMoveToPlayerTime) * 100);
                eggStackTransform[i].tag = "full";
                break;
            }
        }

    }

    void MoveEggsToSpend(GameObject otherObject)
    {

     



        for (int i = 0; i < otherObject.transform.childCount; i++)
        {

            if (otherObject.transform.GetChild(i).tag == "empty")
            {
               
                eggList[eggList.Count - 1].transform.parent.tag = "empty";
                eggList[eggList.Count - 1].transform.parent = otherObject.transform.GetChild(i).transform;
                eggList[eggList.Count - 1].transform.rotation = otherObject.transform.GetChild(i).transform.rotation;
                eggList[eggList.Count - 1].transform.DOLocalMove(Vector3.zero + Vector3.up, 1f);
                eggList[eggList.Count - 1].transform.tag = "Untagged";
                otherObject.transform.GetChild(i).transform.tag = "full";
                eggList.Remove(eggList[eggList.Count - 1]);

                break;
              

           
            }

        }

    }

}
