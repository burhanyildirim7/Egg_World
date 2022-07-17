using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawn : MonoBehaviour
{
    public GameObject customer;
    Vector3 randomPlaceToSpawn;
    float delayTime;

    public GameObject ejderTezgah;
    public GameObject devekusuTezgah;
    public GameObject timsahTezgah;
    public GameObject tavukTezgah;
    public GameObject kazTezgah;

    bool canCustomerSpawn = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ejderTezgah.transform.GetChild(0).gameObject.activeSelf || devekusuTezgah.transform.GetChild(0).gameObject.activeSelf || timsahTezgah.transform.GetChild(0).gameObject.activeSelf || tavukTezgah.transform.GetChild(0).gameObject.activeSelf|| kazTezgah.transform.GetChild(0).gameObject.activeSelf)
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

        if (delayTime >= 50)
        {
            //randomPlaceToSpawn = new Vector3(Random.Range(-5, 15), 1, Random.Range(17, 22));
            Instantiate(customer, transform.position, Quaternion.identity);
            delayTime = 0;
        }
    }
}
