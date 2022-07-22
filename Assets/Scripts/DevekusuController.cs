using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevekusuController : MonoBehaviour
{
    Animator devekusuAnim;
    GameObject devekusuEggSpawn;
    GameObject devekusuEggSpawn2;
    public GameObject devekusuEggSpawn3;
    int randomNumbersForAnim;
    float delayTime;
    Vector3 target;
    bool canPickNumberForAnim;
    bool goToKumes = false;
    bool backToMiddleKumes = false;
    float timeToKumes;
    bool canDo = true;
    public GameObject IsDevekusuKumesEmpty;
    public GameObject IsDevekusuKumesEmpty2;
    public GameObject IsDevekusuKumesEmpty3;
    float randomTime;


    void Start()
    {
        devekusuAnim = GetComponent<Animator>();

        randomTime = Random.Range(5, 17);

        devekusuAnim.SetBool("canIdle", true);

        ChooseRandomTarget();

        devekusuEggSpawn = GameObject.FindGameObjectWithTag("devekusuEggSpawn");
        devekusuEggSpawn2 = GameObject.Find("DeveKusu2");

        target = new Vector3(Random.Range(-15, 15), transform.localPosition.y, Random.Range(-18.7f, 11));

    }

    // Update is called once per frame
    void Update()
    {

        if (IsDevekusuKumesEmpty == null || IsDevekusuKumesEmpty2 == null || IsDevekusuKumesEmpty3 == null)
        {

            IsDevekusuKumesEmpty = Listeler.instance._deveKusuKumesleri[0];
            IsDevekusuKumesEmpty2 = Listeler.instance._deveKusuKumesleri[1];
            IsDevekusuKumesEmpty3 = Listeler.instance._deveKusuKumesleri[2];


        }

        if (!goToKumes)
        {
            ChooseRandomAnimFunction();
            timeToKumes += Time.deltaTime;
        }
        else
        {

            KumesCheck();
        }



        if (canDo && timeToKumes >= randomTime)
        {

            if (IsDevekusuKumesEmpty.tag == "empty")
            {
                IsDevekusuKumesEmpty.tag = "full";
                goToKumes = true;
                //target = new Vector3(-0.5f, -0.6f, -2.3f);
                target = IsDevekusuKumesEmpty.transform.localPosition;
                timeToKumes = 0;
                delayTime = 0;
                canDo = false;
            }

            else if (IsDevekusuKumesEmpty2.activeSelf && IsDevekusuKumesEmpty2.tag == "empty")
            {

                IsDevekusuKumesEmpty2.tag = "full";
                goToKumes = true;
                //target = new Vector3(-0.5f, -0.6f, -2.3f);
                target = IsDevekusuKumesEmpty2.transform.localPosition;
                timeToKumes = 0;
                delayTime = 0;
                canDo = false;


            }
            else if (IsDevekusuKumesEmpty3.activeSelf && IsDevekusuKumesEmpty3.tag == "empty")
            {

                IsDevekusuKumesEmpty3.tag = "full";
                goToKumes = true;
                //target = new Vector3(-0.5f, -0.6f, -2.3f);
                target = IsDevekusuKumesEmpty3.transform.localPosition;
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




            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, 5 * Time.deltaTime);


            devekusuAnim.SetBool("canIdle", false);
            devekusuAnim.SetBool("canWalk", true);


            TurnToTarget();


            if (delayTime >= 5)
            {

                devekusuAnim.SetBool("canIdle", true);
                devekusuAnim.SetBool("canWalk", false);


                ChooseRandomTarget();
                canPickNumberForAnim = true;
                delayTime = 0;
            }
        }

        else if (delayTime >= 4 && randomNumbersForAnim == 1)
        {

            devekusuAnim.SetBool("canIdle", true);
            devekusuAnim.SetBool("canWalk", false);




            if (delayTime >= 7)
            {


                canPickNumberForAnim = true;
                delayTime = 0;
            }




        }


    }

    public void ChooseRandomTarget()
    {


        target = new Vector3(Random.Range(-15, 15), transform.localPosition.y, Random.Range(-18.7f, 11));


    }

    public void TurnToTarget()
    {

        if (gameObject.name == "devekusuPref")
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

        TurnToTarget();
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, 4 * Time.deltaTime);

        if (transform.localPosition == target)
        {

            devekusuAnim.SetBool("canIdle", false);
            devekusuAnim.SetBool("canWalk", false);
            devekusuAnim.SetBool("canSit", true);


            if (target == IsDevekusuKumesEmpty2.transform.localPosition)
            {
                devekusuEggSpawn2.GetComponent<CollectBoxControl>().enabled = true;
                devekusuEggSpawn2.GetComponent<CollectBoxControl>().canSpawn = true;
            }

            else if (target == IsDevekusuKumesEmpty.transform.localPosition)
            {
                devekusuEggSpawn.GetComponent<CollectBoxControl>().enabled = true;
                devekusuEggSpawn.GetComponent<CollectBoxControl>().canSpawn = true;
            }
            else if (target == IsDevekusuKumesEmpty3.transform.localPosition)
            {
                devekusuEggSpawn3.GetComponent<CollectBoxControl>().enabled = true;
                devekusuEggSpawn3.GetComponent<CollectBoxControl>().canSpawn = true;
            }



            delayTime += Time.deltaTime;
            if (delayTime >= 5.3f)
            {

                devekusuEggSpawn.GetComponent<CollectBoxControl>().enabled = false;
                devekusuEggSpawn.GetComponent<CollectBoxControl>().spawnEggTime = 0;

                if (target == IsDevekusuKumesEmpty2.transform.localPosition)
                {
                    IsDevekusuKumesEmpty2.tag = "empty";
                    devekusuEggSpawn2.GetComponent<CollectBoxControl>().enabled = false;
                    devekusuEggSpawn2.GetComponent<CollectBoxControl>().spawnEggTime = 0;
                }

                else if (target == IsDevekusuKumesEmpty.transform.localPosition)
                {
                    IsDevekusuKumesEmpty.tag = "empty";
                    devekusuEggSpawn.GetComponent<CollectBoxControl>().enabled = false;
                    devekusuEggSpawn.GetComponent<CollectBoxControl>().spawnEggTime = 0;
                }

                else if (target == IsDevekusuKumesEmpty3.transform.localPosition)
                {
                    IsDevekusuKumesEmpty3.tag = "empty";
                    devekusuEggSpawn3.GetComponent<CollectBoxControl>().enabled = false;
                    devekusuEggSpawn3.GetComponent<CollectBoxControl>().spawnEggTime = 0;
                }
                target = new Vector3(0, transform.localPosition.y, 0);
            }

        }

        else
        {
            devekusuAnim.SetBool("canIdle", false);
            devekusuAnim.SetBool("canWalk", true);
            devekusuAnim.SetBool("canSit", false);

        }

        if (target == new Vector3(0, transform.localPosition.y, 0))
        {
            if (transform.localPosition == target)
            {
                randomNumbersForAnim = 0;


                canDo = true;
                goToKumes = false;

            }
        }

    }
}
