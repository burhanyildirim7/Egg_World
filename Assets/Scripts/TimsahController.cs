using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimsahController : MonoBehaviour
{
    Animator timsahAnim;
    GameObject timsahEggSpawn;
    GameObject timsahEggSpawn2;
    int randomNumbersForAnim;
    float delayTime;
    Vector3 target;
    bool canPickNumberForAnim;
    bool goToKumes = false;
    bool backToMiddleKumes = false;
    float timeToKumes;
    bool canDo = true;
    public GameObject IsTimsahKumesEmpty;
    public GameObject IsTimsahKumesEmpty2;
    float randomTime;


    void Start()
    {
        timsahAnim = GetComponent<Animator>();

        randomTime = Random.Range(5, 17);

        timsahAnim.SetBool("canIdle", true);

        ChooseRandomTarget();

        if (IsTimsahKumesEmpty == null)
        {
            IsTimsahKumesEmpty = GameObject.Find("IsTimsahKumesEmpty");
        }

        timsahEggSpawn = GameObject.FindGameObjectWithTag("timsahEggSpawn");
        timsahEggSpawn2 = GameObject.Find("TimsahEgg2");

        target = new Vector3(Random.Range(-22, 30f), transform.localPosition.y, Random.Range(-26.5f, 25));

    }

    // Update is called once per frame
    void Update()
    {

        if (IsTimsahKumesEmpty2 == null)
        {
            IsTimsahKumesEmpty2 = GameObject.Find("IsTimsahKumesEmpty2");
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

        if (backToMiddleKumes)
        {

        }

        if (canDo && timeToKumes >= randomTime)
        {
            if (IsTimsahKumesEmpty.tag == "empty")
            {
                IsTimsahKumesEmpty.tag = "full";
                goToKumes = true;
                //target = new Vector3(-0.5f, -0.6f, -2.3f);
                target = IsTimsahKumesEmpty.transform.localPosition;
                timeToKumes = 0;
                delayTime = 0;
                canDo = false;
            }

            else if (IsTimsahKumesEmpty2.tag == "empty" && IsTimsahKumesEmpty2.activeSelf)
            {
                IsTimsahKumesEmpty2.tag = "full";
                goToKumes = true;
                //target = new Vector3(-0.5f, -0.6f, -2.3f);
                target = IsTimsahKumesEmpty2.transform.localPosition;
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


            timsahAnim.SetBool("canIdle", false);
            timsahAnim.SetBool("canWalk", true);
            

            TurnToTarget();


            if (delayTime >= 5)
            {

                timsahAnim.SetBool("canIdle", true);
                timsahAnim.SetBool("canWalk", false);
                

                ChooseRandomTarget();
                canPickNumberForAnim = true;
                delayTime = 0;
            }
        }

        else if (delayTime >= 4 && randomNumbersForAnim == 1)
        {

            timsahAnim.SetBool("canIdle", true);
            timsahAnim.SetBool("canWalk", false);
            



            if (delayTime >= 7)
            {


                canPickNumberForAnim = true;
                delayTime = 0;
            }




        }


    }

    public void ChooseRandomTarget()
    {

      
            target = new Vector3(Random.Range(-22, 20), transform.localPosition.y, Random.Range(-25, 15));
      

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

       

    }

    public void KumesCheck()
    {
        //transform.DOLocalMove(new Vector3(0, -3.7f, 11),1).OnComplete(()=> transform.DOLocalMove(new Vector3(0, 0.8f, -0.45f), 1));


        timsahAnim.SetBool("canIdle", false);
        timsahAnim.SetBool("canWalk", true);
        




        TurnToTarget();
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, 4 * Time.deltaTime);
      


    

        if (transform.localPosition == target)
        {
            timsahAnim.SetBool("canIdle", false);
            timsahAnim.SetBool("canWalk", false);

            if (target == IsTimsahKumesEmpty2.transform.localPosition)
            {
                timsahEggSpawn2.GetComponent<CollectBoxControl>().enabled = true;
                timsahEggSpawn2.GetComponent<CollectBoxControl>().canSpawn = true;
            }

            else if (target == IsTimsahKumesEmpty.transform.localPosition)
            {
                timsahEggSpawn.GetComponent<CollectBoxControl>().enabled = true;
                timsahEggSpawn.GetComponent<CollectBoxControl>().canSpawn = true;
            }



            delayTime += Time.deltaTime;
            if (delayTime >= 5.3f)
            {
                if (target == IsTimsahKumesEmpty2.transform.localPosition)
                {
                    IsTimsahKumesEmpty2.tag = "empty";
                    timsahEggSpawn2.GetComponent<CollectBoxControl>().enabled = false;
                    timsahEggSpawn2.GetComponent<CollectBoxControl>().spawnEggTime = 0;
                }

                else if (target == IsTimsahKumesEmpty.transform.localPosition)
                {
                    IsTimsahKumesEmpty.tag = "empty";
                    timsahEggSpawn.GetComponent<CollectBoxControl>().enabled = false;
                    timsahEggSpawn.GetComponent<CollectBoxControl>().spawnEggTime = 0;
                }
                target = new Vector3(0, transform.localPosition.y, 0);

               

            }
      
        }

        else
        {
            timsahAnim.SetBool("canIdle", false);
            timsahAnim.SetBool("canWalk", true);


        }

         if (target == new Vector3(0,transform.localPosition.y,0))
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
