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
    public GameObject money;
    List<GameObject> customerEggList = new List<GameObject>();
    public GameObject exit;

    float delayTime;
    float distanceY;

    int numberOfEjderEgg = 2;
    int numberOfDevekusuEgg = 3;
    int toplanmasiGerekenEgg;
    int totalEggNumber = 0;

    bool startShopping = true;
    public GameObject box;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("spendEjderEgg").gameObject.transform;
    }

    private void Update()
    {
        MoveTarget();

        if (startShopping)
        {
            SendEggToBox();

        }

       

    }

    private void OnTriggerStay(Collider other)
    {
        if (toplanmasiGerekenEgg < numberOfEjderEgg)
        {
            if (other.gameObject.tag == "spendEjderEgg")
            {

                CustomerCollectEgg(other.gameObject);
            }
        }
      

        if (other.gameObject.tag == "spendDevekusuEgg")
        {
            Debug.Log("Temas var");
   
            CustomerCollectEgg(other.gameObject);
        }

        if (other.gameObject.tag=="Exit")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "spendEjderEgg" || other.gameObject.tag == "spendDevekusuEgg")
        {
            navMeshAgent.speed = 0;
            toplanmasiGerekenEgg = 0;
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
            if (toplanmasiGerekenEgg <numberOfEjderEgg)
            {
                for (int i = 0; i < numberOfEjderEgg; i++)
                {
                    if (otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent.tag == "full")
                    {
                        toplanmasiGerekenEgg++;
                        otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent.tag = "empty";
                        otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent = customerStackPosition.transform;
                        // otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.DOLocalMove(new Vector3(0, 0, 0),1);
                        otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.DOLocalJump(new Vector3(0, distanceY, 0), 2, 1, 1).OnComplete(() => {

                            if (toplanmasiGerekenEgg >= numberOfEjderEgg )
                            {
                                Debug.Log("Gitti aslýnda");
                                
                                StartCoroutine(MoveAnotherEggCollectPlace());
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
    /*
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


    }*/
    IEnumerator MoveAnotherEggCollectPlace()
    {

       
        yield return new WaitForSeconds(1);

        if (target == GameObject.FindGameObjectWithTag("spendDevekusuEgg").gameObject.transform)
        {
            MoveToCashier();


        }
        else
        {

            target = GameObject.FindGameObjectWithTag("spendDevekusuEgg").gameObject.transform;
        }
        navMeshAgent.speed = 5;
       
        numberOfEjderEgg = numberOfDevekusuEgg;

     
    }



    void MoveToCashier()
    {
        for (int i = 0; i < GameObject.FindGameObjectWithTag("cashier").GetComponent<CashierController>().lineList.Count; i++)
        {
            if (GameObject.FindGameObjectWithTag("cashier").GetComponent<CashierController>().lineList[i].tag == "empty")
            {
                GameObject.FindGameObjectWithTag("cashier").GetComponent<CashierController>().lineList[i].tag = "full";
                target = GameObject.FindGameObjectWithTag("cashier").GetComponent<CashierController>().lineList[i].transform;
             
                break;
            }
        }
        
       

    }

    void SendEggToBox()
    {
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {


                    box.transform.GetChild(0).transform.DOLocalRotate(new Vector3(0, 0, -90), 1);
                    box.transform.GetChild(1).transform.DOLocalRotate(new Vector3(0, 0, 90), 1).OnComplete(() => ShoppingStart());

                }
            }
        }
    }


    void ShoppingStart()
    {
        delayTime += Time.deltaTime;

        if (delayTime >= 1)
        {
            if (customerEggList.Count <= 0)
            {
                //canTakeBox = true;
                box.transform.GetChild(0).transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
                box.transform.GetChild(1).transform.DOLocalRotate(new Vector3(0, 0, 0), 1).OnComplete(() => {

                    startShopping = false;
                    TakeBoxAndLeave();


                });


            }
            else
            {
                totalEggNumber++;
                customerEggList[customerEggList.Count - 1].transform.DOJump(box.transform.position, 3, 1, 1).OnComplete(() =>


                {
                  




                });
                customerEggList[customerEggList.Count - 1].transform.parent = box.transform;
                customerEggList.Remove(customerEggList[customerEggList.Count - 1].gameObject);


                delayTime = 0;
            }

        }
 
    
}

    void TakeBoxAndLeave()
    {
        box.transform.parent = customerStackPosition.transform;
        box.transform.DOLocalJump(new Vector3(0, 0, 0), 1, 1, 1).OnComplete(() => PayMoneyForBox());
    }



    void PayMoneyForBox()
    {
        for (int i = 0; i < totalEggNumber; i++)
        {
            GameObject cashier = GameObject.FindGameObjectWithTag("cashier");

            if (cashier.GetComponent<CashierController>().moneyPlaceList[i].tag == "empty")
            {
                var spawnedMoney = Instantiate(money, transform.position, Quaternion.identity);
                spawnedMoney.transform.localScale = new Vector3(200, 200, 200);
                spawnedMoney.transform.parent = cashier.GetComponent<CashierController>().moneyPlaceList[i].transform;
                spawnedMoney.transform.rotation = cashier.GetComponent<CashierController>().moneyPlaceList[i].transform.rotation;
                spawnedMoney.transform.DOLocalJump(new Vector3(0, 0, 0), 15, 1, 1).OnComplete(()=> MoveToExit());
                cashier.GetComponent<CashierController>().moneyPlaceList[i].tag = "full";
                break;
            }
        }
    }

    void MoveToExit()
    {
        target = exit.transform;

       
    }
}
