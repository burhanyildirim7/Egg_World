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

     void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "egg")
        {
            /*
            delayTime += Time.deltaTime;
           

            if (delayTime >= eggSpawnTime)
            {

              //  StartCoroutine(MoveEggsToSepet());
            }
            */

            for (int i = 0; i < eggStackTransform.Count; i++)
            {
                if (eggStackTransform[i].tag == "empty")
                {

                    other.transform.parent.gameObject.tag = "empty";
                    other.transform.parent = eggStackTransform[i].transform;
                    other.transform.rotation = eggStackTransform[i].transform.rotation;
                    other.transform.DOLocalJump(new Vector3(0, 3, 0), 2, 1, (Time.deltaTime / eggMoveToPlayerTime) * 100);
                    eggStackTransform[i].tag = "full";
                    break;
                }
            }


        }
    }
    void OnTriggerStay(Collider other)
    {
   

        if (other.gameObject.tag == "spend")
        {
            Debug.Log(delayTime);
            delayTime += Time.deltaTime;
            if (delayTime >= eggSpawnTime)
            {
                canEggSpawn = true;

               MoveEggToSepet(other.gameObject);
              
            }
        }
    }

    /*
    IEnumerator MoveEggsToSepet()
    {
       
        if (canEggSpawn)
        {
            var collectBox = GameObject.FindGameObjectWithTag("collect");
            var spawnedCube = Instantiate(egg, collectBox.gameObject.transform.position + Vector3.up, Quaternion.identity);
            eggList.Add(spawnedCube);

            for (int i = 0; i < eggStackTransform.Count; i++)
            {
                if (eggStackTransform[i].tag == "empty")
                {


                    spawnedCube.transform.parent = eggStackTransform[i].transform;
                    spawnedCube.transform.rotation = eggStackTransform[i].transform.rotation;
                    spawnedCube.transform.DOLocalJump(new Vector3(0, 3, 0), 2, 1, (Time.deltaTime / eggMoveToPlayerTime) * 100).OnComplete(() => canEggSpawn = true);
                    eggStackTransform[i].tag = "full";
                    break;
                }
            }
            canEggSpawn = false;
            yield return new WaitForSeconds(0.2f);
        }
        
      

 

        delayTime = 0;
    }
    */

    void MoveEggToSepet(GameObject otherGameobject)
    {
        for (int i = 0; i < eggStackTransform.Count; i++)
        {
            if (eggStackTransform[i].tag == "empty")
            {

                otherGameobject.transform.parent.gameObject.tag = "empty";
                otherGameobject.transform.parent = eggStackTransform[i].transform;
                otherGameobject.transform.rotation = eggStackTransform[i].transform.rotation;
                otherGameobject.transform.DOLocalJump(new Vector3(0, 3, 0), 2, 1, (Time.deltaTime / eggMoveToPlayerTime) * 100);
                eggStackTransform[i].tag = "full";
                break;
            }
        }

    }
  
    void MoveEggsToSpend()
    {

            eggList[eggList.Count - 1].transform.DOLocalJump(GameObject.FindGameObjectWithTag("spend").transform.position, 2, 1, ((Time.deltaTime / eggMoveToPlayerTime) * 100) / 2).OnComplete(() => canEggSpend = true);
           


     

    }

}
