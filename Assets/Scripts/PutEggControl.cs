using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PutEggControl : MonoBehaviour
{
    public List<GameObject> eggTransform = new List<GameObject>();
    public List<GameObject> eggList = new List<GameObject>();
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag ==  "tavukEgg")
        {

            DOTween.Kill(other.gameObject);
            for (int i = 0; i < 3 /*eggTransform.Count*/; i++)
            {
                if (eggTransform[i].tag == "empty")
                {
                    eggList.Add(other.gameObject);
                    other.gameObject.transform.DOMove(eggTransform[i].transform.position, 2).OnComplete(()=>other.transform.parent = eggTransform[i].transform);
                    
                    

                    eggTransform[i].tag = "full";
                    break;
                }
            }
        }

        if (other.gameObject.tag == "devekusuEgg")
        {

            DOTween.Kill(other.gameObject);
            for (int i = 0; i < 3 /*eggTransform.Count*/; i++)
            {
                if (eggTransform[i].tag == "empty")
                {

                    other.gameObject.transform.DOMove(eggTransform[i].transform.position, 2);


                    eggTransform[i].tag = "full";
                    break;
                }
            }
        }


    }
}
