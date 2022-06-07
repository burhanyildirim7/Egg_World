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
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "collect")
        {
            delayTime += Time.deltaTime;


            if (delayTime >= eggSpawnTime)
            {
              
                StartCoroutine(MoveEggsToSepet());
            }

           

        }

        if (other.gameObject.tag == "spend")
        {
            Debug.Log(delayTime);
            delayTime += Time.deltaTime;
            if (delayTime >= eggSpawnTime)
            {
                canEggSpawn = true;

                for (int i = 0; i < other.transform.childCount; i++)
                {
                    if (other.transform.GetChild(i).tag == "empty")
                    {
                        eggList[eggList.Count - 1].transform.DOLocalJump(other.transform.GetChild(i).transform.position+Vector3.up,2,1, ((Time.deltaTime / eggMoveToPlayerTime) * 100) / 2);
                        eggList[eggList.Count - 1].transform.parent.tag = "empty";
                        eggList[eggList.Count - 1].transform.rotation = other.transform.GetChild(i).transform.rotation;
                        other.transform.GetChild(i).transform.tag = "full";
                        eggList[eggList.Count - 1].transform.parent = null;

                        eggList.Remove(eggList[eggList.Count - 1]);

                        delayTime = 0;
                        break;
                    }
                }
                //MoveEggsToSpend();
              
            }
        }
    }

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
  
    void MoveEggsToSpend()
    {

            eggList[eggList.Count - 1].transform.DOLocalJump(GameObject.FindGameObjectWithTag("spend").transform.position, 2, 1, ((Time.deltaTime / eggMoveToPlayerTime) * 100) / 2).OnComplete(() => canEggSpend = true);
           


     

    }

}
