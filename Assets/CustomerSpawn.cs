using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawn : MonoBehaviour
{
    public GameObject customer;
    float delayTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCustomer();
    }
    
    void SpawnCustomer()
    {
        delayTime += Time.deltaTime;

        if (delayTime>= 10)
        {
            Instantiate(customer,new Vector3(12,1,17),Quaternion.identity);
            delayTime = 0;
        }
    }
}
