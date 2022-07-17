using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KazGoKumesController : MonoBehaviour
{
    GameObject kazKumes;
    GameObject goToKumesDoorPosition;
    GameObject kumesDoor;

    Transform target;

    bool goToKumesDoor = true;
    bool enterToKumes;

    Animator kazAnim;
    void Start()
    {
        kazAnim = GetComponent<Animator>();
        kazAnim.SetBool("canWalk", true);
        kazAnim.SetBool("canIdle", false);
        kazKumes = GameObject.FindGameObjectWithTag("KazKumes").gameObject;
        kumesDoor = GameObject.FindGameObjectWithTag("KazKumesDoor").gameObject;
        goToKumesDoorPosition = GameObject.FindGameObjectWithTag("waitKazKumes").gameObject;



    }

    // Update is called once per frame
    void Update()
    {

        

        if (goToKumesDoor)
        {
            GoToKumesFunction();
        }

        if (enterToKumes)
        {
            EnterTheKumesFunction();
        }



    
    }

    IEnumerator OpenTheKumesDoor()
    {
        kumesDoor.transform.DOLocalRotate(new Vector3(0, 0, 180), 1).OnComplete(() => {

            enterToKumes = true;

        });

        yield return new WaitForSeconds(3);
        kumesDoor.transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
    }

    void GoToKumesFunction()
    {
        target = goToKumesDoorPosition.transform;
        TurnToTarget();
        transform.position = Vector3.MoveTowards(transform.position, target.position, 5 * Time.deltaTime);

        if (transform.position == target.position)
        {
            transform.parent = kazKumes.transform;
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            StartCoroutine(OpenTheKumesDoor());
            goToKumesDoor = false;
        }
    }

    public void TurnToTarget()
    {

        if (gameObject.name == "timsahPref")
        {
            Vector3 relativePos = transform.localPosition - target.position;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up * 180);

            transform.localRotation = rotation * Quaternion.Euler(0, transform.localRotation.y + 180, 0);
        }

        else if (gameObject.name == "kazPref(Clone)")
        {
            Vector3 relativePos = transform.localPosition - target.position;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up * 180);

            transform.localRotation = rotation * Quaternion.Euler(0, transform.localRotation.y + 180, 0);
        }

        else if (gameObject.tag == "tavukPref")
        {
            Vector3 relativePos = transform.localPosition - target.position;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up * 180);

            transform.localRotation = rotation;

        }

    }

    void EnterTheKumesFunction()
    {



        target.localPosition = new Vector3(0, -2.8f, 15);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.localPosition, 5 * Time.deltaTime);

        if (transform.localPosition == target.localPosition)
        {
  
            target.localPosition = new Vector3(9.3f, -2f, 12);
            kazAnim.SetBool("canWalk", false);
         
            GetComponent<KazController>().enabled = true;
            GetComponent<KazGoKumesController>().enabled = false;


        }


    }

}
