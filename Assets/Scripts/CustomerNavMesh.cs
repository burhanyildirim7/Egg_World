using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerNavMesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
   public Transform target;

    public GameObject customerStackPosition;
    public GameObject money;
    public GameObject box;
    public GameObject exit;

    int lineNumber;
   
    List<GameObject> customerEggList = new List<GameObject>();
    public List<GameObject> customerEggPosition = new List<GameObject>();


    float delayTime;
    float distanceY;

    public bool canShoopingStart = false;
    bool canDo = true;
    bool canDo2 = true;

    int numberOfEjderEgg ;
    int numberOfDevekusuEgg;
    int numberOfTavukEgg;
    int numberOfTimsahEgg;
    int toplanmasiGerekenEgg;

    int toplanacakEgg = 2;
    int totalEggNumber = 0;
    int chooseRandomSpendEgg;
    int siraliEggPosition = 0;

     GameObject spendEjderEgg;
     GameObject spendDevekusuEgg;
     GameObject spendTavukEgg;
     GameObject spendTimsahEgg;

     GameObject cashier;

    public List<GameObject> customerlineList = new List<GameObject>();

    public List<GameObject> spendEggList = new List<GameObject>();

    bool startShopping = false;
    public bool moveToCashier = false;
    bool moveToExit = false;
    bool canMove = false;

  
    int moneyPlaceEmptyNumber;
    private void Awake()
    {
       

    }

    private void Start()
    {
        cashier = GameObject.FindGameObjectWithTag("cashier");

        for (int i = 0; i < cashier.GetComponent<CashierController>().lineList.Count; i++)
        {
            customerlineList.Add(cashier.GetComponent<CashierController>().lineList[i].gameObject);
        }

        spendEggList.Add(GameObject.FindGameObjectWithTag("spendEjderEgg"));
        spendEggList.Add(GameObject.FindGameObjectWithTag("spendDevekusuEgg"));
        spendEggList.Add(GameObject.FindGameObjectWithTag("spendTavukEgg"));
       
        spendEggList.Add(GameObject.FindGameObjectWithTag("spendTimsahEgg"));



        for (var i = spendEggList.Count - 1; i > -1; i--)
        {
            if (spendEggList[i] == null)
                spendEggList.RemoveAt(i);
        }

        chooseRandomSpendEgg = Random.Range(0, spendEggList.Count);
        for (int i = 0; i < spendEggList.Count; i++)
        {

            if (chooseRandomSpendEgg == i)
            {
               
                if (spendEggList[i] != null)
                {
                   
                    target = spendEggList[i].transform;
                    //canMove = true;

                }
             
              
           


            }
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        // target = GameObject.FindGameObjectWithTag("spendEjderEgg").gameObject.transform;
        exit = GameObject.FindGameObjectWithTag("Exit");
    }


    private void FixedUpdate()
    {
       

            MoveTarget();

            if (startShopping)
            {
                SendEggToBox();

            }

            if (moveToCashier)
            {
                if (target.name == "1.Line")
                {
                    if (!navMeshAgent.pathPending)
                    {
                        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                        {
                            if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                            {


                                box = GameObject.FindGameObjectWithTag("box");
                        

                                startShopping = true;
                                moveToCashier = false;

                            }
                        }
                    }


                }

            else
            {
                BirSiraIleriKay();
            }

             


            }

            if (moveToExit)
            {
                target = exit.transform;
            }

        
    }

    public void BirSiraIleriKay()
    {

        for (int i = 0; i < customerlineList.Count; i++)
        {
            if (customerlineList[i].name == target.name)
            {
              

                if (i != 0)
                {
                    if (customerlineList[i - 1 ].tag == "empty")
                    {
                        customerlineList[i].transform.tag = "empty";
                        target = customerlineList[i - 1].transform;
                        customerlineList[i - 1].tag = "full";
                        moveToCashier = true;
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (toplanmasiGerekenEgg < toplanacakEgg)
        {
            if (other.gameObject.tag == "spendEjderEgg")
            {

                StartCoroutine(CustomerCollectEgg(other.gameObject));
            }
        }

        if (toplanmasiGerekenEgg < toplanacakEgg)
        {
            if (other.gameObject.tag == "spendDevekusuEgg")
            {


                StartCoroutine(CustomerCollectEgg(other.gameObject));
            }
        }

        if (toplanmasiGerekenEgg < toplanacakEgg)
        {
            if (other.gameObject.tag == "spendTavukEgg")
            {
           

                StartCoroutine(CustomerCollectEgg(other.gameObject));
            }
        }

        if (toplanmasiGerekenEgg < toplanacakEgg)
        {
            if (other.gameObject.tag == "spendTimsahEgg")
            {


                StartCoroutine(CustomerCollectEgg(other.gameObject));
            }
        }







        if (other.gameObject.name == "Exit")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "spendEjderEgg" && target == GameObject.FindGameObjectWithTag("spendEjderEgg"))
        {
            
            navMeshAgent.speed = 0;
            toplanmasiGerekenEgg = 0;
        }

        else if (other.gameObject.tag == "spendDevekusuEgg" && target == GameObject.FindGameObjectWithTag("spendDevekusuEgg"))
        {
            navMeshAgent.speed = 0;
            toplanmasiGerekenEgg = 0;
        }

        else if (other.gameObject.tag == "spendTavukEgg" && target == GameObject.FindGameObjectWithTag("spendTavukEgg"))
        {
            navMeshAgent.speed = 0;
            toplanmasiGerekenEgg = 0;
        }


        else if (other.gameObject.tag == "spendTimsahEgg" &&target == GameObject.FindGameObjectWithTag("spendTimsahEgg"))
        {
            navMeshAgent.speed = 0;
            toplanmasiGerekenEgg = 0;
        }



    }
    void MoveTarget()
    {
        navMeshAgent.destination = target.transform.position;
    }

    IEnumerator CustomerCollectEgg(GameObject otherObject)
    {
        yield return new WaitForSeconds(0.1f);
           delayTime += Time.deltaTime;

        if (delayTime >= 1)
        {
            if (toplanmasiGerekenEgg < toplanacakEgg)
            {
                for (int i = 0; i < otherObject.GetComponent<SpendBoxControl>().spendEggList.Count; i++)
                {

                    

                    if (otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent.tag == "full")
                    {
                        
                        toplanmasiGerekenEgg++;
                        otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent.tag = "empty";
                        //otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent = customerStackPosition.transform;
                        customerEggList.Add(otherObject.GetComponent<SpendBoxControl>().spendEggList[i]);

                        // otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.DOLocalMove(new Vector3(0, 0, 0),1);

                        
                        if (customerEggPosition[siraliEggPosition].tag == "empty")
                        {
                         
                            otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent = customerEggPosition[siraliEggPosition].transform;
                            otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.DOLocalJump(new Vector3(0, 0, 0), 2, 1, 1).OnComplete(() => {
                             
                                if (toplanmasiGerekenEgg == toplanacakEgg && canDo2)
                                {
                                    Debug.Log("Burasý Çalýþýyor.");
                                    
                                    StartCoroutine(MoveAnotherEggCollectPlace());
                                    canDo2 = false;


                                }

                            });

                            otherObject.GetComponent<SpendBoxControl>().spendEggList.Remove(otherObject.GetComponent<SpendBoxControl>().spendEggList[i]);




                            delayTime = 0;

                            customerEggPosition[siraliEggPosition].tag = "full";
                            siraliEggPosition++;
                           
                            break;

                        }


                      

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
        yield return new WaitForSeconds(0.2f);
        if (numberOfDevekusuEgg == 0)
        {
            MoveToCashier();

            navMeshAgent.speed = 5;
        }
        else
        {
            yield return new WaitForSeconds(0.2f);

            if (target == GameObject.FindGameObjectWithTag("spendDevekusuEgg").gameObject.transform)
            {

                MoveToCashier();


            }
            else
            {

                target = GameObject.FindGameObjectWithTag("spendDevekusuEgg").gameObject.transform;
            }
            navMeshAgent.speed = 5;

            toplanacakEgg = 2;
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

                 
                    ShoppingStart();

                }
            }
        }
    }


    void ShoppingStart()
    {
        if (canDo)
        {
            transform.LookAt(cashier.transform);
            canDo = false;
        }

        delayTime += Time.deltaTime;
      

        if (delayTime >= 0.5f)
        {
            if (customerEggList.Count <= 0)
            {
                //canTakeBox = true;
                GetComponent<NavMeshAgent>().enabled = false;
                Debug.Log("Animasyon oynadý");
                StartCoroutine(TakeBoxAndLeave());

                /*
                box.transform.GetChild(0).transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
                box.transform.GetChild(1).transform.DOLocalRotate(new Vector3(0, 0, 0), 1).OnComplete(() => {

                   
                    StartCoroutine(TakeBoxAndLeave());


                });
                */


            }
            else
            {
                gameObject.tag = "customer";
                gameObject.GetComponent<BoxCollider>().size = new Vector3(1,2,6);
                gameObject.GetComponent<BoxCollider>().center = new Vector3(0,0,6);
                if (canShoopingStart)
                {
                    totalEggNumber++;

                    customerEggList[customerEggList.Count - 1].transform.DOJump(box.transform.position + Vector3.up / 4, 3, 1, 1).OnComplete(() =>


                    {




                    });
                    customerEggList[customerEggList.Count - 1].transform.parent = box.transform;
                    customerEggList.Remove(customerEggList[customerEggList.Count - 1].gameObject);


                    delayTime = 0;
                }
               
                
            }

        }
 
    
}

    IEnumerator TakeBoxAndLeave()
    {
       
        yield return new WaitForSeconds(1);
        box.gameObject.tag = "Untagged";
        startShopping = false;
        box.transform.parent = customerStackPosition.transform;
        box.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2);
        box.transform.DOLocalJump(new Vector3(0, 0, 0), 1, 1, 1).OnComplete(() => {

           
          

        
        });
        yield return new WaitForSeconds(1);
        StartCoroutine(PayMoneyForBox());
    }



    IEnumerator PayMoneyForBox()
    {
        moneyPlaceEmptyNumber = 0;
    
        GetComponent<NavMeshAgent>().enabled = true;
        yield return new WaitForSeconds(1);


        for (int i = moneyPlaceEmptyNumber; i < cashier.GetComponent<CashierController>().moneyPlaceList.Count; i++)
        {
           
            GameObject cashier = GameObject.FindGameObjectWithTag("cashier");

            for (int a = 0; a < cashier.GetComponent<CashierController>().moneyPlaceList.Count; a++)
            {
                if (cashier.GetComponent<CashierController>().moneyPlaceList[a].tag == "empty")
                {
                    moneyPlaceEmptyNumber++;
                }
            }



            if (cashier.GetComponent<CashierController>().moneyPlaceList[i].tag == "empty")
            {
          
                var spawnedMoney = Instantiate(money, transform.position, Quaternion.identity);
                spawnedMoney.transform.localScale = new Vector3(200, 200, 200);
                spawnedMoney.GetComponent<BoxCollider>().size = new Vector3(0.02f, 0.002f, 0.0008f);
                spawnedMoney.transform.parent = cashier.GetComponent<CashierController>().moneyPlaceList[i].transform;
                spawnedMoney.transform.rotation = cashier.GetComponent<CashierController>().moneyPlaceList[i].transform.rotation;
                spawnedMoney.transform.DOLocalJump(new Vector3(0, 0, 0), 15, 1, 1).OnComplete(()=> {
                 
          
                  
                
                });
                cashier.GetComponent<CashierController>().moneyPlaceList[i].tag = "full";
                break;
            }

          
        }
        yield return new WaitForSeconds(0.1f);
      MoveToExit();

    }

    void MoveToExit()
    {
        moveToExit = true;
       
        target.transform.tag = "empty";
       
       




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

          moveToCashier = true;
     



    }
}
