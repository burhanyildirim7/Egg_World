using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawn : MonoBehaviour
{
    public GameObject customer;
    Vector3 randomPlaceToSpawn;
    float delayTime;

    public GameObject ejderKumes;
    public GameObject devekusuKumes;
    public GameObject timsahKumes;
    public GameObject tavukKumes;

    bool canCustomerSpawn = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ejderKumes.transform.GetChild(0).gameObject.activeSelf || devekusuKumes.transform.GetChild(0).gameObject.activeSelf || timsahKumes.transform.GetChild(0).gameObject.activeSelf || tavukKumes.transform.GetChild(0).gameObject.activeSelf)
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

        if (delayTime >= 100)
        {
            //randomPlaceToSpawn = new Vector3(Random.Range(-5, 15), 1, Random.Range(17, 22));
            Instantiate(customer, transform.position, Quaternion.identity);
            delayTime = 0;
        }
    }
}
