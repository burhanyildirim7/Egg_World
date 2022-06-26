using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AnimalsController : MonoBehaviour
{
    Animator timsahAnim;
    GameObject tavukEggSpawn;
    int randomNumbersForAnim;
    float delayTime;
    Vector3 target;
    bool canPickNumberForAnim;
    bool goToKumes = false;
    float timeToKumes;
    bool canDo = true;
    public GameObject IsKumesEmpty;
    float randomTime;

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
            if (IsKumesEmpty.tag == "empty")
            {
                IsKumesEmpty.tag = "full";
                goToKumes = true;
                target = new Vector3(0, -3.7f, 11);
                timeToKumes = 0;
                canDo = false;
            }
            timeToKumes = 0;
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
                Debug.Log("Geldi");
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
            target = new Vector3(Random.Range(-5, 5), transform.localPosition.y, Random.Range(11, 19));
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

    public void KumesCheck()
    {
        //transform.DOLocalMove(new Vector3(0, -3.7f, 11),1).OnComplete(()=> transform.DOLocalMove(new Vector3(0, 0.8f, -0.45f), 1));

        idle = false;
        walk = true;
        TurnToTarget();
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, 4 * Time.deltaTime);

        if (transform.localPosition == new Vector3(0, -3.7f, 11))
        {

            target = new Vector3(0, 0.7f, 3);


        }
        else if (transform.localPosition == new Vector3(0, 0.7f, 3))
        {
            target = new Vector3(0, 0.7f, -1);
            tavukEggSpawn.GetComponent<CollectBoxControl>().enabled = true;
            tavukEggSpawn.GetComponent<CollectBoxControl>().canSpawn = true;
            tavukEggSpawn.GetComponent<CollectBoxControl>().spawnEggTime = 0;
        }

        else if (transform.localPosition == new Vector3(0, 0.7f, -1f))
        {

            delayTime += Time.deltaTime;

            if (delayTime >= 8)
            {
                target = new Vector3(0, 0.7f, 3.2f);



            }
        }

        else if (transform.localPosition == new Vector3(0, 0.7f, 3.2f))
        {
            target = new Vector3(0, -3.7f, 11.2f);
            Debug.Log("Ulaþtý");
        }

        else if (transform.localPosition == new Vector3(0, -3.7f, 11.2f))
        {
            IsKumesEmpty.tag = "empty";
            tavukEggSpawn.GetComponent<CollectBoxControl>().enabled = false;
            goToKumes = false;
            canDo = true;

        }


    }

}