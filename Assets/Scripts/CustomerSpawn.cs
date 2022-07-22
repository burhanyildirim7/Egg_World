using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    public GameObject _musteriParent;

    private int _oncelik;

    bool canCustomerSpawn = false;
    void Start()
    {
        _oncelik = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ejderTezgah.transform.GetChild(0).gameObject.activeSelf || devekusuTezgah.transform.GetChild(0).gameObject.activeSelf || timsahTezgah.transform.GetChild(0).gameObject.activeSelf || tavukTezgah.transform.GetChild(0).gameObject.activeSelf || kazTezgah.transform.GetChild(0).gameObject.activeSelf)
        {
            if (_musteriParent.transform.childCount < 10)
            {
                canCustomerSpawn = true;
            }
            else
            {
                canCustomerSpawn = false;
            }

        }

        if (canCustomerSpawn)
        {
            SpawnCustomer();
        }

    }

    void SpawnCustomer()
    {

        delayTime += Time.deltaTime;

        if (delayTime >= 15)
        {
            //randomPlaceToSpawn = new Vector3(Random.Range(-5, 15), 1, Random.Range(17, 22));
            GameObject musteri = Instantiate(customer, transform.position, Quaternion.identity);
            musteri.GetComponent<NavMeshAgent>().avoidancePriority = _oncelik;
            musteri.transform.parent = _musteriParent.transform;
            _oncelik++;
            delayTime = 0;
        }
    }
}
