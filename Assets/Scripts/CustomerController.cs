using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CustomerController : MonoBehaviour
{
    Animator customerAnim;
    public Transform target;
    bool canWalk = true;
    bool walkToCashier = false;
    float time;
    float distanceY;
    public GameObject customerStackMaterialTransform;
    public GameObject box;
    List<GameObject> customerEggList = new List<GameObject>();
    public GameObject money;
    public GameObject cashier;
    int numberOfEggs;

 
    float delayTime = 0;

    bool canTakeBox = false;
    void Start()
    {
        customerAnim = GetComponent<Animator>();
        //target = GameObject.FindGameObjectWithTag("spend").transform;
        target = GameObject.FindGameObjectWithTag("spendEjderEgg").gameObject.transform;
        numberOfEggs = Random.Range(0,3);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Alýnmasý Gereken yumurta sayýsý = " + numberOfEggs);

        if (!canTakeBox)
        {
            if (walkToCashier)
            {
                MoveToCashier();

            }
            else
            {
                MoveToBuyEgg();
            }
        }
           
        
     



    }

    void MoveToBuyEgg()
    {
        Debug.Log("MOVETOEGG ÇALIÞIYOR");
        if (transform.position != new Vector3(target.transform.position.x, 0, target.transform.position.z) &&canWalk)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x,0, target.transform.position.z), 5 * Time.deltaTime);
            customerAnim.SetBool("run", true);
            transform.LookAt(target);       
        }
        else
        {
            canWalk = false;
            customerAnim.SetBool("run", false);
        }

    }

    void MoveToCashier()
    {
        Debug.Log("MOVETOCASHIER ÇALIÞIYOR");
        if (transform.position != new Vector3(target.transform.position.x, 0, target.transform.position.z) && canWalk)
        {

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x, 0, target.transform.position.z), 5 * Time.deltaTime);
            customerAnim.SetBool("run", true);
            transform.LookAt(target);


        }
        else
        {
            canWalk = false;
            customerAnim.SetBool("run", false);

            box.transform.GetChild(0).transform.DOLocalRotate(new Vector3(0, 0, -90), 1);
            box.transform.GetChild(1).transform.DOLocalRotate(new Vector3(0, 0, 90), 1).OnComplete(() => ShoppingStart());
          


        }


    }


    void ShoppingStart()
    {
        Debug.Log("SHOPPUNGSTART ÇALIÞIYOR");
        delayTime += Time.deltaTime;

        if (delayTime >= 1)
        {
            if (customerEggList.Count <= 0)
            {
                canTakeBox = true;
                box.transform.GetChild(0).transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
                box.transform.GetChild(1).transform.DOLocalRotate(new Vector3(0, 0, 0), 1).OnComplete(() => TakeBoxAndLeave());

             
            }
            else
            {
                customerEggList[customerEggList.Count - 1].transform.DOJump(box.transform.position, 3, 1, 1).OnComplete(() =>


                {
                    




                });
                customerEggList[customerEggList.Count - 1].transform.parent = box.transform;
                customerEggList.Remove(customerEggList[customerEggList.Count - 1].gameObject);


                delayTime = 0;
            }
          
        }
     
    }

    void OnTriggerStay(Collider other)
    {
 
        if (other.gameObject.tag == "spendEjderEgg"|| other.gameObject.tag == "spendTimsahEgg"|| other.gameObject.tag == "spendTavukEgg" || other.gameObject.tag == "spendDevekusuEgg" )
        {
            canWalk = false;
          
            CustomerCollectEgg(other.gameObject);
            Debug.Log("Temas var");
        }
    }

    void CustomerCollectEgg(GameObject otherObject)
    {
        Debug.Log("CUSTOMERCOLLECTEGG ÇALIÞIYOR");
        time += Time.deltaTime;

        if (time >=1 &&canWalk==false)
        {
            GameObject SpendBoxControl = otherObject.gameObject;

            SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1].transform.parent.tag = "empty";
            SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1].transform.parent = customerStackMaterialTransform.transform;
            SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1].transform.rotation = customerStackMaterialTransform.transform.rotation;

            SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1].transform.DOLocalJump
                (new Vector3(0, distanceY, 0), 2, 1, 1).OnComplete(() => {

                    if (customerEggList.Count == numberOfEggs)
                    {
                        Debug.Log("Eþitlenme tamam");
                        canWalk = true;
                        walkToCashier = true;
                        
                    }
                    for (int i = 0; i < customerEggList.Count; i++)
                    {
                        if (GameObject.FindGameObjectWithTag("cashier").GetComponent<CashierController>().lineList[i].tag == "empty")
                        {
                            target = GameObject.FindGameObjectWithTag("cashier").GetComponent<CashierController>().lineList[i].transform;
                            
                            break;
                        }
                      
                    }
                    

                  
                });
            customerEggList.Add(SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1]);
            SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.RemoveAt(SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1);
            distanceY += 0.5f;

            time = 0;
        }

       
       
    }

    void TakeBoxAndLeave()
    {
        box.transform.parent = customerStackMaterialTransform.transform;
        box.transform.DOLocalJump(new Vector3(0,0,0), 1, 1, 1).OnComplete(()=> PayMoneyForBox());
    }

    void PayMoneyForBox()
    {
        for (int i = 0; i < numberOfEggs; i++)
        {
        

            if (cashier.GetComponent<CashierController>().moneyPlaceList[i].tag == "empty")
            {
                var spawnedMoney = Instantiate(money, transform.position, Quaternion.identity);
                spawnedMoney.transform.localScale = new Vector3(200, 200, 200);
                spawnedMoney.transform.parent = cashier.GetComponent<CashierController>().moneyPlaceList[i].transform;
                spawnedMoney.transform.rotation = cashier.GetComponent<CashierController>().moneyPlaceList[i].transform.rotation;
                spawnedMoney.transform.DOLocalJump(new Vector3(0, 0, 0), 15, 1, 1);
                cashier.GetComponent<CashierController>().moneyPlaceList[i].tag = "full";
                break;
            }
        }
    }
}
