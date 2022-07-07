using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollectBoxControl : MonoBehaviour
{
    public GameObject egg;
    public List<GameObject> eggStackPlace = new List<GameObject>();
    public List<GameObject> eggList2 = new List<GameObject>();
    public float spawnEggTime = 0;
    public float spawnTime;
    public int spawnEggLimit;
    public GameObject eggSpawnPlace;

    public bool canSpawn;
    void Start()
    {
        canSpawn = true;
        spawnEggTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnEggTime += Time.deltaTime;

        if (canSpawn && spawnEggTime >= 5)
        {
            SpawnEggs();
            canSpawn = false;
            spawnEggTime = 0;
        }

    

    }

    void SpawnEggs()
    {
        var spawnedEgg = Instantiate(egg, eggSpawnPlace.transform.position, Quaternion.Euler(-90,0,0));
        spawnedEgg.name = gameObject.name;
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
