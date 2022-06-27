using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TavukGoKumesController : MonoBehaviour
{
    GameObject tavukKumes;
    GameObject goToKumesDoorPosition;
    GameObject kumesDoor;

    Transform target;

    bool goToKumesDoor = true;
    bool enterToKumes;

    [SerializeField] bool walk, idle;
    void Start()
    {
        walk = true;
        idle = false;
        tavukKumes =  GameObject.FindGameObjectWithTag("tavukKumes").gameObject;
        kumesDoor = GameObject.FindGameObjectWithTag("kumesDoor").gameObject;
        goToKumesDoorPosition = GameObject.FindGameObjectWithTag("waitTavukKumes").gameObject;
       
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



        if (idle)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            idle = false;
        }
        else if (walk)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            walk = false;
        }
    }

    IEnumerator OpenTheKumesDoor()
    {
        kumesDoor.transform.DOLocalRotate(new Vector3(0, 0, 180), 1).OnComplete(() => { 
            
            enterToKumes = true;
            
        }) ;

        yield return new WaitForSeconds(3);
        kumesDoor.transform.DOLocalRotate(new Vector3(0, 0, 0), 1);
    }

    void GoToKumesFunction()
    {
        target = goToKumesDoorPosition.transform;
        transform.position = Vector3.MoveTowards(transform.position, target.position, 5 * Time.deltaTime);

        if (transform.position == target.position)
        {
            transform.parent = tavukKumes.transform;
            StartCoroutine(OpenTheKumesDoor());
            goToKumesDoor = false;
        }
    }

    void EnterTheKumesFunction()
    {
        target.localPosition = new Vector3(0, -2.8f, 15);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.localPosition, 5 * Time.deltaTime);

        if (transform.localPosition == target.localPosition)
        {
            Debug.Log("Hedefe Ulaþtý");
            GetComponent<TavukControllerReal>().enabled = true;
            GetComponent<TavukGoKumesController>().enabled = false;

        }

       
    }
}
