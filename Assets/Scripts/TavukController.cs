using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TavukController : MonoBehaviour
{
    Animator timsahAnim;
    GameObject tavukEggSpawn;
    GameObject tavukEggSpawn2;
    GameObject tavukEggSpawn3;
    int randomNumbersForAnim;
    float delayTime;
    Vector3 target;
    bool canPickNumberForAnim;
    bool goToKumes = false;
    bool goToSecondKumes = false;
    bool goToThirdKumes = false;
    float timeToKumes;
    bool canDo = true;
    public GameObject IsKumesEmpty;
    public GameObject IsKumesEmpty2;
    public GameObject IsKumesEmpty3;
    float randomTime;
    float level2Distance = 0;

    [SerializeField] bool walk, idle;
    void Start()
    {
        timsahAnim = GetComponent<Animator>();

        randomTime = Random.Range(5, 17);
        walk = false;
        idle = true;
        ChooseRandomTarget();

        tavukEggSpawn = GameObject.FindGameObjectWithTag("tavukEggSpawn");


        target = new Vector3(Random.Range(-5, 5), transform.localPosition.y, Random.Range(11, 19));

    }

    // Update is called once per frame
    void Update()
    {


        if (tavukEggSpawn2 == null || IsKumesEmpty2 == null || IsKumesEmpty3 == null || tavukEggSpawn3 == null)
        {

            tavukEggSpawn2 = GameObject.FindGameObjectWithTag("tavukEggSpawn2");
            tavukEggSpawn3 = GameObject.FindGameObjectWithTag("tavukEggSpawn3");

            IsKumesEmpty = Listeler.instance._tavukKumesleri[0];
            IsKumesEmpty2 = Listeler.instance._tavukKumesleri[1];
            IsKumesEmpty3 = Listeler.instance._tavukKumesleri[2];

        }


        if (!goToKumes)
        {
            ChooseRandomAnimFunction();
            timeToKumes += Time.deltaTime;
        }
        else
        {
            if (goToSecondKumes)
            {
                SecondKumesCheck();
            }

            if (!goToSecondKumes && !goToThirdKumes)
            {
                FirstKumesCheck();

            }
            if (goToThirdKumes)
            {
                ThirdKumesCheck();
            }

        }

        if (canDo && timeToKumes >= randomTime)
        {

            if (IsKumesEmpty.tag == "empty")
            {
                IsKumesEmpty.tag = "full";
                goToKumes = true;
                goToSecondKumes = false;
                target = new Vector3(0, -3f, 11);
                timeToKumes = 0;
                canDo = false;
            }

            else if (IsKumesEmpty2.gameObject.transform.parent.gameObject.activeSelf && IsKumesEmpty2.tag == "empty")
            {


                level2Distance = 10;
                goToSecondKumes = true;
                IsKumesEmpty2.tag = "full";
                goToKumes = true;
                target = new Vector3(-9.3f, -2.8f, 10.5f);
                timeToKumes = 0;
                canDo = false;




            }
            else if (IsKumesEmpty3.gameObject.transform.parent.gameObject.activeSelf && IsKumesEmpty3.tag == "empty")
            {


                level2Distance = 20;
                goToSecondKumes = false;
                goToThirdKumes = true;
                IsKumesEmpty3.tag = "full";
                goToKumes = true;
                target = new Vector3(-17.3f, -2.8f, 10.5f);
                timeToKumes = 0;
                canDo = false;




            }
            if (timeToKumes >= randomTime)
            {
                timeToKumes = 0;
            }

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
            //timsahAnim.SetBool("canWalk", true);
            walk = true;
            idle = false;


            TurnToTarget();


            if (delayTime >= 5)
            {

                walk = false;
                idle = true;


                ChooseRandomTarget();
                canPickNumberForAnim = true;
                delayTime = 0;
            }
        }

        else if (delayTime >= 4 && randomNumbersForAnim == 1)
        {
            walk = false;
            idle = true;

            if (delayTime >= 7)
            {


                canPickNumberForAnim = true;
                delayTime = 0;
            }




        }


    }

    public void ChooseRandomTarget()
    {

        if (gameObject.name == "timsahPref")
        {
            target = new Vector3(Random.Range(-22, 20), transform.localPosition.y, Random.Range(-25, 15));
        }

        else if (gameObject.name == "kazPref")
        {
            target = new Vector3(Random.Range(-36, 8.5f), transform.localPosition.y, Random.Range(12, 20.5f));
        }

        else if (gameObject.tag == "tavukPref")
        {
            target = new Vector3(Random.Range((-5 + level2Distance), 5), transform.localPosition.y, Random.Range(11, 19));
        }

    }

    public void TurnToTarget()
    {

        if (gameObject.name == "timsahPref")
        {
            Vector3 relativePos = transform.localPosition - target;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up * 180);

            transform.localRotation = rotation * Quaternion.Euler(0, transform.localRotation.y + 180, 0);
        }

        else if (gameObject.name == "kazPref")
        {
            Vector3 relativePos = transform.localPosition - target;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up * 180);

            transform.localRotation = rotation * Quaternion.Euler(0, transform.localRotation.y + 180, 0);
        }

        else if (gameObject.tag == "tavukPref")
        {
            Vector3 relativePos = transform.localPosition - target;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up * 180);

            transform.localRotation = rotation;

        }

    }

    public void FirstKumesCheck()
    {
        goToSecondKumes = false;
        //transform.DOLocalMove(new Vector3(0, -3.7f, 11),1).OnComplete(()=> transform.DOLocalMove(new Vector3(0, 0.8f, -0.45f), 1));

        idle = false;
        walk = true;
        TurnToTarget();
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, 4 * Time.deltaTime);

        if (transform.localPosition == new Vector3(0, -3f, 11))
        {

            target = new Vector3(0, 0.8f, 3);


        }
        else if (transform.localPosition == new Vector3(0, 0.8f, 3))
        {
            target = new Vector3(0, 0.8f, -1);
            tavukEggSpawn.GetComponent<CollectBoxControl>().enabled = true;
            tavukEggSpawn.GetComponent<CollectBoxControl>().canSpawn = true;
            tavukEggSpawn.GetComponent<CollectBoxControl>().spawnEggTime = 0;
        }

        else if (transform.localPosition == new Vector3(0, 0.8f, -1f))
        {

            delayTime += Time.deltaTime;

            if (delayTime >= 8)
            {
                target = new Vector3(0, 0.8f, 3.2f);



            }
        }

        else if (transform.localPosition == new Vector3(0, 0.8f, 3.2f))
        {
            target = new Vector3(0, -3f, 11.2f);

        }

        else if (transform.localPosition == new Vector3(0, -3f, 11.2f))
        {

            target = new Vector3(0, -3f, 16);



        }

        else if (transform.localPosition == new Vector3(0, -3f, 16))
        {
            IsKumesEmpty.tag = "empty";
            tavukEggSpawn.GetComponent<CollectBoxControl>().enabled = false;
            goToKumes = false;
            canDo = true;
        }


    }

    public void SecondKumesCheck()
    {
        //transform.DOLocalMove(new Vector3(0, -3.7f, 11),1).OnComplete(()=> transform.DOLocalMove(new Vector3(0, 0.8f, -0.45f), 1));

        idle = false;
        walk = true;
        TurnToTarget();
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, 4 * Time.deltaTime);

        if (transform.localPosition == new Vector3(-9.3f, -2.8f, 10.5f))
        {

            target = new Vector3(-9.5f, 1f, 4f);


        }
        else if (transform.localPosition == new Vector3(-9.5f, 1f, 4f))
        {
            target = new Vector3(-9.5f, 1f, 0);

            tavukEggSpawn2.GetComponent<CollectBoxControl>().enabled = true;
            tavukEggSpawn2.GetComponent<CollectBoxControl>().canSpawn = true;
            tavukEggSpawn2.GetComponent<CollectBoxControl>().spawnEggTime = 0;

        }


        else if (transform.localPosition == new Vector3(-9.5f, 1f, 0))
        {

            delayTime += Time.deltaTime;

            if (delayTime >= 8)
            {
                target = new Vector3(-9.5f, 1f, 4.2f);

            }
        }

        else if (transform.localPosition == new Vector3(-9.5f, 1f, 4.2f))
        {
            target = new Vector3(-9.63f, -2.8f, 10.7f);
        }

        else if (transform.localPosition == new Vector3(-9.63f, -2.8f, 10.7f))
        {


            target = new Vector3(-9.63f, -2.8f, 16f);

        }

        else if (transform.localPosition == new Vector3(-9.63f, -2.8f, 16f))
        {
            tavukEggSpawn2.GetComponent<CollectBoxControl>().enabled = false;
            IsKumesEmpty2.tag = "empty";
            goToSecondKumes = false;
            goToKumes = false;
            canDo = true;

        }


    }

    public void ThirdKumesCheck()
    {
        //transform.DOLocalMove(new Vector3(0, -3.7f, 11),1).OnComplete(()=> transform.DOLocalMove(new Vector3(0, 0.8f, -0.45f), 1));

        idle = false;
        walk = true;
        TurnToTarget();
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, 4 * Time.deltaTime);

        if (transform.localPosition == new Vector3(-17.3f, -2.8f, 10.5f))
        {

            target = new Vector3(-17.5f, 1f, 4f);


        }
        else if (transform.localPosition == new Vector3(-17.5f, 1f, 4f))
        {
            //Debug.Log("Vard�");
            target = new Vector3(-17.5f, 1f, 0);

            tavukEggSpawn3.GetComponent<CollectBoxControl>().enabled = true;
            tavukEggSpawn3.GetComponent<CollectBoxControl>().canSpawn = true;
            tavukEggSpawn3.GetComponent<CollectBoxControl>().spawnEggTime = 0;

        }


        else if (transform.localPosition == new Vector3(-17.5f, 1f, 0))
        {

            delayTime += Time.deltaTime;

            if (delayTime >= 8)
            {
                target = new Vector3(-17.5f, 1f, 4.2f);



            }
        }

        else if (transform.localPosition == new Vector3(-17.5f, 1f, 4.2f))
        {
            target = new Vector3(-17.63f, -2.8f, 10.7f);

        }

        else if (transform.localPosition == new Vector3(-17.63f, -2.8f, 10.7f))
        {
            target = new Vector3(-17.63f, -2.8f, 16f);

        }

        else if (transform.localPosition == new Vector3(-17.63f, -2.8f, 16f))
        {
            IsKumesEmpty3.tag = "empty";
            tavukEggSpawn3.GetComponent<CollectBoxControl>().enabled = false;
            goToKumes = false;
            goToSecondKumes = false;
            goToThirdKumes = false;
            canDo = true;
        }


    }
}
