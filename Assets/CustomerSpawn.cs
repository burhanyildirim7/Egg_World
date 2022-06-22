using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawn : MonoBehaviour
{
    public GameObject customer;
    Vector3 randomPlaceToSpawn;
    float delayTime;

    public GameObject ejderKümes;
    public GameObject devekusuKümes;

    bool canCustomerSpawn = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ejderKümes.activeSelf)
        {
            canCustomerSpawn = true;
        }

        if (canCustomerSpawn)
        {
            SpawnCustomer();
        }
     
    }

    void SpawnCustomer()
    {
       
        delayTime += Time.deltaTime;

        if (delayTime >= 5 )
        {
            randomPlaceToSpawn = new Vector3(Random.Range(-5, 15), 1, Random.Range(17, 22));
            Instantiate(customer, randomPlaceToSpawn, Quaternion.identity);
            delayTime = 0;
        }
    }
}
