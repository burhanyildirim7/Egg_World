using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EggEvolution : MonoBehaviour
{
    public GameObject eggForChicken;
    public GameObject chicken;

    float time = 0;

    public int chickenSpawnTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (eggForChicken != null && gameObject.tag == "full")
        {
            StartEggEvolution();
            eggForChicken = null;
            gameObject.tag = "empty";

        }
    }

    void StartEggEvolution()
    {
        
                eggForChicken.gameObject.transform.DOScale(Vector3.zero, chickenSpawnTime).OnComplete(() => FinishEggEvolution()
                ); ;

    }

    void FinishEggEvolution()
    {
        Instantiate(chicken, transform.position+Vector3.up/2, Quaternion.identity);
      
        

    }
}
