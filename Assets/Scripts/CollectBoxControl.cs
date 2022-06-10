using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollectBoxControl : MonoBehaviour
{
    public GameObject egg;
    public List<GameObject> eggStackPlace = new List<GameObject>();
    public List<GameObject> eggList2 = new List<GameObject>();
    float spawnEggTime = 0;
    public float spawnTime;
    public int spawnEggLimit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnEggTime += Time.deltaTime;

        if (spawnEggTime >= spawnTime && eggList2.Count <= spawnEggLimit)
        {
            SpawnEggs();
            spawnEggTime = 0;
        }

      

    }

    void SpawnEggs()
    {
        var spawnedEgg = Instantiate(egg,new Vector3(-10,1,9),Quaternion.identity);
        eggList2.Add(spawnedEgg);
        for (int i = 0; i < eggStackPlace.Count; i++)
        {
            if (eggStackPlace[i].tag == "empty")
            {
                spawnedEgg.transform.parent = eggStackPlace[i].transform;
                spawnedEgg.transform.DOLocalMove(new Vector3(0,0,0) / 2, 1);
            
                eggStackPlace[i].tag = "full";
                break;
            }
        }
   
    }
}
