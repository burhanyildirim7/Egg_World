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

    public Animator _karakterAnimator;

    int lineNumber;

    List<GameObject> customerEggList = new List<GameObject>();
    public List<GameObject> customerEggPosition = new List<GameObject>();
    public GameObject _buyukEggPosition;


    float delayTime;
    float distanceY;

    public bool canShoopingStart = false;
    bool canDo = true;
    bool canDo2 = true;

    int numberOfEjderEgg;
    int numberOfDevekusuEgg;
    int numberOfTavukEgg;
    int numberOfTimsahEgg;
    int toplanmasiGerekenEgg;

    int gezilecekTezgahSayisi;
    int randonEggNumber;
    int randonEggNumber2;
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

    private GameObject _gidilecekTezgah;

    private float _terketmeTimer;

    private void Awake()
    {


    }

    private void Start()
    {
        //gezilecekTezgahSayisi = Random.Range(1, 3);
        randonEggNumber = Random.Range(1, 5);
        //randonEggNumber2 = Random.Range(1, 5);
        cashier = GameObject.FindGameObjectWithTag("cashier");

        for (int i = 0; i < cashier.GetComponent<CashierController>().lineList.Count; i++)
        {
            customerlineList.Add(cashier.GetComponent<CashierController>().lineList[i].gameObject);
        }

        //spendEggList.Add(GameObject.FindGameObjectWithTag("spendEjderEgg"));
        //spendEggList.Add(GameObject.FindGameObjectWithTag("spendDevekusuEgg"));
        //spendEggList.Add(GameObject.FindGameObjectWithTag("spendTavukEgg"));

        //spendEggList.Add(GameObject.FindGameObjectWithTag("spendTimsahEgg"));
        //spendEggList.Add(GameObject.FindGameObjectWithTag("spendKazEgg"));

        for (int i = 0; i < Listeler.instance._tezgahlar.Count; i++)
        {
            if (Listeler.instance._tezgahlar[i].activeSelf)
            {
                spendEggList.Add(Listeler.instance._tezgahlar[i]);
            }
            else
            {

            }
        }

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
                    _gidilecekTezgah = spendEggList[i];
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

        _terketmeTimer += Time.deltaTime;

        if (_terketmeTimer > 60)
        {
            //target = exit.transform;
        }
        else
        {

        }

        if (navMeshAgent.velocity.sqrMagnitude >= 0.1f)
        {
            _karakterAnimator.SetBool("Walk", true);
        }
        else
        {
            _karakterAnimator.SetBool("Walk", false);
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
                    if (customerlineList[i - 1].tag == "empty")
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
        if (toplanmasiGerekenEgg < randonEggNumber)
        {
            if (target == other.gameObject.transform)
            {

                StartCoroutine(CustomerCollectEgg(other.gameObject));
            }
        }
        /*
        if (toplanmasiGerekenEgg < toplanacakEgg)
        {
            if (other.gameObject.tag == "spendDevekusuEgg" && target == GameObject.FindGameObjectWithTag("spendDevekusuEgg"))
            {


                StartCoroutine(CustomerCollectEgg(other.gameObject));
            }
        }

        if (toplanmasiGerekenEgg < toplanacakEgg)
        {
            if (other.gameObject.tag == "spendTavukEgg" && target == GameObject.FindGameObjectWithTag("spendTavukEgg"))
            {


                StartCoroutine(CustomerCollectEgg(other.gameObject));
            }
        }

        if (toplanmasiGerekenEgg < toplanacakEgg)
        {
            if (other.gameObject.tag == "spendTimsahEgg" && target == GameObject.FindGameObjectWithTag("spendTimsahEgg"))
            {


                StartCoroutine(CustomerCollectEgg(other.gameObject));
            }
        }

        if (toplanmasiGerekenEgg < toplanacakEgg)
        {
            if (other.gameObject.tag == "spendKazEgg" && target == GameObject.FindGameObjectWithTag("spendKazEgg"))
            {


                StartCoroutine(CustomerCollectEgg(other.gameObject));
            }
        }

        */





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


        else if (other.gameObject.tag == "spendTimsahEgg" && target == GameObject.FindGameObjectWithTag("spendTimsahEgg"))
        {
            navMeshAgent.speed = 0;
            toplanmasiGerekenEgg = 0;
        }


        else if (other.gameObject.tag == "spendKazEgg" && target == GameObject.FindGameObjectWithTag("spendKazEgg"))
        {
            navMeshAgent.speed = 0;
            toplanmasiGerekenEgg = 0;
        }



    }
    void MoveTarget()
    {
        if (GetComponent<NavMeshAgent>().enabled == true)
        {
            navMeshAgent.destination = target.transform.position;
        }
        else
        {

        }

    }

    IEnumerator CustomerCollectEgg(GameObject otherObject)
    {
        if (_gidilecekTezgah.tag == "spendDevekusuEgg" || _gidilecekTezgah.tag == "spendEjderEgg")
        {
            canDo2 = false;
            randonEggNumber = 1;
        }
        else
        {

        }

        yield return new WaitForSeconds(0.5f);
        delayTime += Time.deltaTime;

        if (delayTime >= 1)
        {
            if (toplanmasiGerekenEgg < randonEggNumber)
            {
                for (int i = 0; i < otherObject.GetComponent<SpendBoxControl>().spendEggList.Count; i++)
                {

                    if (otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent.tag == "full")
                    {

                        toplanmasiGerekenEgg++;

                        //otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent = customerStackPosition.transform;
                        customerEggList.Add(otherObject.GetComponent<SpendBoxControl>().spendEggList[i]);

                        // otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.DOLocalMove(new Vector3(0, 0, 0),1);

                        if (_gidilecekTezgah.tag == "spendDevekusuEgg" || _gidilecekTezgah.tag == "spendEjderEgg")
                        {
                            if (_buyukEggPosition.tag == "empty")
                            {
                                otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent.tag = "empty";
                                otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent = _buyukEggPosition.transform;
                                otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.DOLocalJump(new Vector3(0, 0, 0), 1, 1, 1);

                                otherObject.GetComponent<SpendBoxControl>().spendEggList.Remove(otherObject.GetComponent<SpendBoxControl>().spendEggList[i]);




                                delayTime = 0;

                                _buyukEggPosition.tag = "full";
                                siraliEggPosition++;

                                if (toplanmasiGerekenEgg == randonEggNumber)
                                {


                                    MoveToCashier();


                                }
                                else
                                {
                                    //MoveToCashier();
                                }
                            }


                            break;
                        }
                        else
                        {
                            if (customerEggPosition[siraliEggPosition].tag == "empty")
                            {
                                otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent.tag = "empty";
                                otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.parent = customerEggPosition[siraliEggPosition].transform;
                                otherObject.GetComponent<SpendBoxControl>().spendEggList[i].transform.DOLocalJump(new Vector3(0, 0, 0), 1, 1, 1);

                                otherObject.GetComponent<SpendBoxControl>().spendEggList.Remove(otherObject.GetComponent<SpendBoxControl>().spendEggList[i]);




                                delayTime = 0;

                                customerEggPosition[siraliEggPosition].tag = "full";
                                siraliEggPosition++;

                                if (toplanmasiGerekenEgg == randonEggNumber)
                                {


                                    MoveToCashier();


                                }
                                else
                                {
                                    //MoveToCashier();
                                }
                            }


                            break;

                        }




                    }


                }




            }


        }


    }

    IEnumerator MoveAnotherEggCollectPlace()
    {
        gezilecekTezgahSayisi--;

        yield return new WaitForSeconds(0.5f);
        if (gezilecekTezgahSayisi == 0)
        {

            MoveToCashier();

            navMeshAgent.speed = 5;
        }
        else
        {

            yield return new WaitForSeconds(0.5f);

            //chooseRandomSpendEgg = Random.Range(0, spendEggList.Count);
            chooseRandomSpendEgg = Random.Range(0, spendEggList.Count);

            for (int i = 0; i < spendEggList.Count; i++)
            {

                if (chooseRandomSpendEgg == i)
                {

                    if (spendEggList[i] != null)
                    {


                        _gidilecekTezgah = spendEggList[i];
                        //canMove = true;

                    }


                }
            }

            if (_gidilecekTezgah.tag == "spendDevekusuEgg" || _gidilecekTezgah.tag == "spendEjderEgg")
            {
                MoveToCashier();
            }
            else
            {
                target = _gidilecekTezgah.transform;
            }

            navMeshAgent.speed = 5;

            yield return new WaitForSeconds(2);
            toplanmasiGerekenEgg = 0;
            randonEggNumber = randonEggNumber2;


        }


    }


    void SendEggToBox()
    {
        if (GetComponent<NavMeshAgent>().enabled == true)
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
        else
        {

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
                gameObject.GetComponent<BoxCollider>().size = new Vector3(1, 2, 2);
                gameObject.GetComponent<BoxCollider>().center = new Vector3(0, 0, 4);
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
        box.transform.DOLocalJump(new Vector3(0, 0, 0), 1, 1, 1).OnComplete(() =>
        {





        });
        yield return new WaitForSeconds(1);
        StartCoroutine(PayMoneyForBox());
    }



    IEnumerator PayMoneyForBox()
    {
        moneyPlaceEmptyNumber = 0;

        GetComponent<NavMeshAgent>().enabled = true;
        yield return new WaitForSeconds(1);

        GameObject cashier = GameObject.FindGameObjectWithTag("cashier");

        for (int i = 0; i < randonEggNumber; i++)
        {
            cashier.GetComponent<CashierController>()._paraGrubu.GetComponent<moneyGrubuKontrolu>().paraEklensinMi = true;
            yield return new WaitForSeconds(0.1f);
        }


        /*
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
                spawnedMoney.transform.DOLocalJump(new Vector3(0, 0, 0), 15, 1, 1).OnComplete(() =>
                {




                });
                cashier.GetComponent<CashierController>().moneyPlaceList[i].tag = "full";
                break;
            }


        }
        */
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