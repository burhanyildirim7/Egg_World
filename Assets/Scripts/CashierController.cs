using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierController : MonoBehaviour
{
    public List<GameObject> lineList = new List<GameObject>();
    public List<GameObject> moneyPlaceList = new List<GameObject>();
    public GameObject box;

    float time = 0;
    void Start()
    {
    
    }


    void Update()
    {
        if (transform.GetChild(transform.childCount-1).transform.tag == "box")
        {
            Debug.Log("Kutu Childda Var");
        }
        else
        {
            time += Time.deltaTime;
            if (time >= 2)
            {
                var spawnedBox = Instantiate(box, new Vector3(-1.4f, 0.66f, 0), Quaternion.identity);
                spawnedBox.transform.parent = transform;
                spawnedBox.transform.tag = "box";
                spawnedBox.transform.localScale = new Vector3(0.4f, 0.2f, 0.4f);
                spawnedBox.transform.localPosition = new Vector3(-1.4f, 0.66f, 0);
                time = 0;
            }
           
        }
    }
}
