using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollectBoxControl : MonoBehaviour
{
    public GameObject egg;
    int eggNumber = 0;
    public List<GameObject> eggStackPlace = new List<GameObject>();
    float spawnEggTime = 1;
    public int spawnEggLimit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnEggTime += Time.deltaTime;

        if (spawnEggTime >= 2.0f && eggNumber < spawnEggLimit)
        {
            SpawnEggs();
            spawnEggTime = 0;
        }
    }

    void SpawnEggs()
    {
        var spawnedEgg = Instantiate(egg,new Vector3(-10,4,32),Quaternion.identity);
        eggNumber++;
        for (int i = 0; i < eggStackPlace.Count; i++)
        {
            if (eggStackPlace[i].tag == "empty")
            {
                spawnedEgg.transform.parent = eggStackPlace[i].transform;
                spawnedEgg.transform.DOMove(eggStackPlace[i].transform.position, 1);
            
                eggStackPlace[i].tag = "full";
                break;
            }
        }
   
    }
}
