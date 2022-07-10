using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjderController : MonoBehaviour
{
    Animator ejderAnim;
    GameObject ejderEggSpawn;
    int randomNumbersForAnim;
    float delayTime;
    Vector3 target;
    bool canPickNumberForAnim;
    bool goToKumes = false;
    bool backToMiddleKumes = false;
    float timeToKumes;
    bool canDo = true;
    public GameObject IsKumesEmpty;
    float randomTime;
    public int ejderMoveSpeed;


    void Start()
    {
        ejderAnim = GetComponent<Animator>();

        randomTime = Random.Range(5, 17);

        ejderAnim.SetBool("canIdle", true);

        ChooseRandomTarget();

        ejderEggSpawn = GameObject.FindGameObjectWithTag("ejderEggSpawn");

        target = new Vector3(Random.Range(-60, 60f), transform.localPosition.y, Random.Range(-30f, 70));

    }

    // Update is called once per frame
    void Update()
    {
        if (!goToKumes)
        {
            ChooseRandomAnimFunction();
            timeToKumes += Time.deltaTime;
        }
        else
        {

            KumesCheck();
        }

        if (backToMiddleKumes)
        {

        }

        if (canDo && timeToKumes >= randomTime)
        {
            if (IsKumesEmpty.tag == "empty")
            {
                IsKumesEmpty.tag = "full";
                goToKumes = true;
                //target = new Vector3(-0.5f, -0.6f, -2.3f);
                target = IsKumesEmpty.transform.localPosition;
                timeToKumes = 0;
                delayTime = 0;
                canDo = false;
            }
            timeToKumes = 0;
        }





    }

    void ChooseRandomAnimFunction()
    {
        if (canPickNumberForAnim)
        {

            randomNumbersForAnim = Random.Range(0, 2);
            canPickNumberForAnim = false;
        }


        delayTime += Time.deltaTime;
        if (delayTime >= 4 && randomNumbersForAnim == 0)
        {




            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, ejderMoveSpeed * Time.deltaTime);


            ejderAnim.SetBool("canIdle", false);
            ejderAnim.SetBool("canWalk", true);


            TurnToTarget();


            if (delayTime >= 5)
            {

                ejderAnim.SetBool("canIdle", true);
                ejderAnim.SetBool("canWalk", false);


                ChooseRandomTarget();
                canPickNumberForAnim = true;
                delayTime = 0;
            }
        }

        else if (delayTime >= 4 && randomNumbersForAnim == 1)
        {

            ejderAnim.SetBool("canIdle", true);
            ejderAnim.SetBool("canWalk", false);




            if (delayTime >= 7)
            {


                canPickNumberForAnim = true;
                delayTime = 0;
            }




        }


    }

    public void ChooseRandomTarget()
    {


        target = new Vector3(Random.Range(-60, 60f), transform.localPosition.y, Random.Range(-30f, 70));


    }

    public void TurnToTarget()
    {

        if (gameObject.name == "Ejder1Pref")
        {
            Vector3 relativePos = transform.localPosition - target;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up * 180);

            transform.localRotation = rotation * Quaternion.Euler(0, transform.localRotation.y + 180, 0);
        }



    }

    public void KumesCheck()
    {
        //transform.DOLocalMove(new Vector3(0, -3.7f, 11),1).OnComplete(()=> transform.DOLocalMove(new Vector3(0, 0.8f, -0.45f), 1));


        ejderAnim.SetBool("canIdle", false);
        ejderAnim.SetBool("canWalk", true);





        TurnToTarget();
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, ejderMoveSpeed * Time.deltaTime);





        if (transform.localPosition == target)
        {
            ejderAnim.SetBool("canIdle", false);
            ejderAnim.SetBool("canWalk", false);

            ejderEggSpawn.GetComponent<CollectBoxControl>().enabled = true;
            ejderEggSpawn.GetComponent<CollectBoxControl>().canSpawn = true;


            delayTime += Time.deltaTime;
            if (delayTime >= 5.3f)
            {
                ejderEggSpawn.GetComponent<CollectBoxControl>().enabled = false;
                ejderEggSpawn.GetComponent<CollectBoxControl>().spawnEggTime = 0;
                target = new Vector3(0, transform.localPosition.y, 0);



            }

        }

        else
        {
            ejderAnim.SetBool("canIdle", false);
            ejderAnim.SetBool("canWalk", true);


        }

        if (target == new Vector3(0, transform.localPosition.y, 0))
        {
            if (transform.localPosition == target)
            {
                randomNumbersForAnim = 0;
                IsKumesEmpty.tag = "empty";
                canDo = true;
                goToKumes = false;
            }
        }
    }
}
