using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CustomerController : MonoBehaviour
{
    Animator customerAnim;
    Transform target;
    bool canWalk = true;
    float distanceY;
    public GameObject customerStackMaterialTransform;
    void Start()
    {
        customerAnim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("spend").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToBuyEgg();
    }

    void MoveToBuyEgg()
    {
        if (transform.position != new Vector3(target.transform.position.x, 0, target.transform.position.z) &&canWalk)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x,0, target.transform.position.z), 5 * Time.deltaTime);
            customerAnim.SetBool("run", true);
            transform.LookAt(target);
            Debug.Log("Yürüyor");
        }
        else
        {
            canWalk = false;
            customerAnim.SetBool("run", false);
        }

    }

     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "spend")
        {
            CustomerCollectEgg(other.gameObject);
            Debug.Log("Temas var");
        }
    }

    void CustomerCollectEgg(GameObject otherObject)
    {
        GameObject SpendBoxControl = otherObject.gameObject;

       
        SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1].transform.parent = customerStackMaterialTransform.transform;
        SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1].transform.rotation = customerStackMaterialTransform.transform.rotation;
        SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList[SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1].transform.DOLocalJump
            (new Vector3(0, distanceY, 0), 2, 1, 1).OnComplete(()=> {

                target = GameObject.FindGameObjectWithTag("cashier").transform;
                canWalk = true;
        
        });
        SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.RemoveAt(SpendBoxControl.GetComponent<SpendBoxControl>().spendEggList.Count - 1);
        distanceY+= 0.5f;
    }

}
