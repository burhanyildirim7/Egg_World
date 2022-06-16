using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
   private Transform target;

    public GameObject customerStackPosition;
    List<GameObject> customerEggList = new List<GameObject>();

    float delayTime;
    float distanceY;

    int numberOfEjderEgg = 3;
    int numberOfDevekusuEgg = 1;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("spendEjderEgg").gameObject.transform;
    }

    private void Update()
    {
        MoveTarget();
        
      
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "spendEjderEgg")
        {
           
            CustomerCollectEgg(other.gameObject);
        }

        if (other.gameObject.tag == "spendDevekusuEgg")
        {
            Debug.Log("Temas var");
            CustomerCollectEgg2(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "spendEjderEgg")
        {
            navMeshAgent.speed = 0;
        }
    }
    void MoveTarget()
    {
        navMeshAgent.destination = target.transform.position;
    }

    void CustomerCollectEgg(GameObject otherObject)
    {
     
        delayTime += Time.deltaTime;

        if (delayTime >= 1)
        {
            if (customerEggList.Count <numberOfEjderEgg)
            {
                for (int i = 0; i < numberOfEjderEgg; i++)
                {
                    if (otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent.tag == "full")
                    {
                        otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent.tag = "empty";
                        otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent = customerStackPosition.transform;
                        // otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.DOLocalMove(new Vector3(0, 0, 0),1);
                        otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.DOLocalJump(new Vector3(0, distanceY, 0), 2, 1, 1).OnComplete(() => {

                            if (customerEggList.Count >= numberOfEjderEgg)
                            {
                                Debug.Log("Gitti aslýnda");
                                StartCoroutine(MoveToCashier());
                            }
                        });
                        customerEggList.Add(otherObject.GetComponent<SpendBoxControl>().spendEggList[i]);
                        delayTime = 0;
                        distanceY += 1.0f;
                        break;
                    }


                }
            }
           
        
        }


    }

    void CustomerCollectEgg2(GameObject otherObject)
    {

        delayTime += Time.deltaTime;

        if (delayTime >= 2)
        {
            for (int i = 0; i < numberOfEjderEgg; i++)
            {
                if (otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent.tag == "full")
                {
                    otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent.tag = "empty";
                    otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent = customerStackPosition.transform;
                    // otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.DOLocalMove(new Vector3(0, 0, 0),1);
                    otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.DOLocalJump(new Vector3(0, distanceY, 0), 2, 1, 1).OnComplete(() => {

                    
                    });
                    customerEggList.Add(otherObject.GetComponent<SpendBoxControl>().spendEggList[i]);
                    delayTime = 0;
                    distanceY += 1.0f;
                    break;
                }


            }

        }


    }
    IEnumerator MoveToCashier()
    {
        yield return new WaitForSeconds(1);
        navMeshAgent.speed = 5;
        target = GameObject.FindGameObjectWithTag("spendDevekusuEgg").gameObject.transform;
        numberOfEjderEgg = numberOfDevekusuEgg;
        
    }


}
