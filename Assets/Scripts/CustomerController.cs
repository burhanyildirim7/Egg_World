using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CustomerController : MonoBehaviour
{
    Animator customerAnim;
    Transform target;
    bool canWalk = true;
    bool walkToCashier = false;
    float time;
    float distanceY;
    public GameObject customerStackMaterialTransform;

    List<GameObject> customerEggList = new List<GameObject>();
    void Start()
    {
        customerAnim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("spend").transform;
    }

    // Update is called once per frame
    void Update()
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

    void MoveToBuyEgg()
    {
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


            ShoppingStart();

        }


    }

    void ShoppingStart()
    {
        for (int i = customerEggList.Count-1; i >= 0; i--)
        {

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "spend" && canWalk == false)
        {
            CustomerCollectEgg(other.gameObject);
            Debug.Log("Temas var");
        }
    }

    void CustomerCollectEgg(GameObject otherObject)
    {

        time += Time.deltaTime;

        if (time >=1)
        {
            GameObject SpendBoxControl = otherObject.gameObject;

            SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1].transform.parent.tag = "empty";
            SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1].transform.parent = customerStackMaterialTransform.transform;
            SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1].transform.rotation = customerStackMaterialTransform.transform.rotation;

            SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1].transform.DOLocalJump
                (new Vector3(0, distanceY, 0), 2, 1, 1).OnComplete(() => {

                    for (int i = 0; i < customerEggList.Count; i++)
                    {
                        if (GameObject.FindGameObjectWithTag("cashier").GetComponent<CashierController>().lineList[i].tag == "empty")
                        {
                            target = GameObject.FindGameObjectWithTag("cashier").GetComponent<CashierController>().lineList[i].transform;
                            
                            break;
                        }
                      
                    }
                    

                    if (customerEggList.Count >= 5)
                    {
                        canWalk = true;
                        walkToCashier = true;
                    }
                });
            customerEggList.Add(SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1]);
            SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.RemoveAt(SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1);
            distanceY += 0.5f;

            time = 0;
        }

       
       
    }

}
