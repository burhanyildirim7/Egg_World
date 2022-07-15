using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class KazController : MonoBehaviour
{
    Animator kazAnim;
    GameObject kazEggSpawn;
    GameObject kazEggSpawn2;
    GameObject kazEggSpawn3;
    int randomNumbersForAnim;
    float delayTime;
    Vector3 target;
    bool canPickNumberForAnim;
    bool goToKumes = false;
    float timeToKumes;
    bool canDo = true;
    public GameObject IsKumesEmpty;
    public GameObject IsKumesEmpty2;
    public GameObject IsKumesEmpty3;

    float randomTime;

    int distanceForKumes = 0;


    void Start()
    {
        kazAnim = GetComponent<Animator>();

         randomTime = Random.Range(5, 17);
        
         kazAnim.SetBool("canIdle", true);
        
        ChooseRandomTarget();

        kazEggSpawn = GameObject.FindGameObjectWithTag("kazEggSpawn");
       

        target = new Vector3(Random.Range(-4f, 9f), transform.localPosition.y, Random.Range(12, 22));

    }

    // Update is called once per frame
    void Update()
    {

        if (kazEggSpawn2 == null|| IsKumesEmpty2 == null || IsKumesEmpty3 == null || kazEggSpawn3 == null)
        {

            kazEggSpawn2 = GameObject.FindGameObjectWithTag("kazEggSpawn2");
            kazEggSpawn3 = GameObject.FindGameObjectWithTag("kazEggSpawn3");
            IsKumesEmpty2 = GameObject.Find("IsKazKumesEmpty2");
            IsKumesEmpty3 = GameObject.Find("IsKazKumesEmpty3");

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
            if (IsKumesEmpty.tag == "empty")
            {
                distanceForKumes = 0;
                IsKumesEmpty.tag = "full";
                goToKumes = true;
                //target = new Vector3(-0.5f, -0.6f, -2.3f);
                target = new Vector3(2.43f + distanceForKumes, -3.2f, 11.65f);
                timeToKumes = 0;
                canDo = false;
            }

            else if (IsKumesEmpty2.tag == "empty" && IsKumesEmpty2.activeSelf)
            {
                distanceForKumes = -15;
                IsKumesEmpty2.tag = "full";
                goToKumes = true;
                //target = new Vector3(-0.5f, -0.6f, -2.3f);
                target = new Vector3(2.43f + distanceForKumes, -3.2f, 11.65f);
                timeToKumes = 0;
                canDo = false;
            } 
            
            else if (IsKumesEmpty3.tag == "empty" && IsKumesEmpty3.activeSelf)
            {
                distanceForKumes = -20;
                IsKumesEmpty3.tag = "full";
                goToKumes = true;
                //target = new Vector3(-0.5f, -0.6f, -2.3f);
                target = new Vector3(2.43f + distanceForKumes, -3.2f, 11.65f);
                timeToKumes = 0;
                canDo = false;
            }
            if (timeToKumes >= randomTime)
            {
                timeToKumes = 0;
            }
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
             kazAnim.SetBool("canIdle", false);
             kazAnim.SetBool("canWalk", true);


            TurnToTarget();


            if (delayTime >= 5)
            {

                kazAnim.SetBool("canIdle", true);
                kazAnim.SetBool("canWalk", false);


                ChooseRandomTarget();
                canPickNumberForAnim = true;
                delayTime = 0;
            }
        }

        else if (delayTime >= 4 && randomNumbersForAnim == 1)
        {
            kazAnim.SetBool("canIdle", true);
            kazAnim.SetBool("canWalk", false);




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

        else if (gameObject.tag == "kazPref")
        {
            target = new Vector3(Random.Range(-4f, 9f), transform.localPosition.y, Random.Range(12, 22));
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

        else if (gameObject.tag == "kazPref")
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

        kazAnim.SetBool("canIdle", false);
        kazAnim.SetBool("canWalk", true);





        TurnToTarget();
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, 4 * Time.deltaTime);

        if (transform.localPosition == new Vector3(2.43f + distanceForKumes, -3.2f, 11.65f))
        {

            //target = new Vector3(-0.5f, 0.2f, -0.67f);
            target = new Vector3(2.43f + distanceForKumes, 0.6f, 3.24f);


        }
        else if (transform.localPosition == new Vector3(2.43f + distanceForKumes, 0.6f, 3.24f))
        {
            //target = new Vector3(-0.5f, 0.2f, 0.287f);
            target = new Vector3(2.43f + distanceForKumes, 0.6f, -2.49f);

         

            if (distanceForKumes == 0)
            {
                kazEggSpawn.GetComponent<CollectBoxControl>().enabled = true;
                kazEggSpawn.GetComponent<CollectBoxControl>().canSpawn = true;
                kazEggSpawn.GetComponent<CollectBoxControl>().spawnEggTime = 0;
            }

            else if (distanceForKumes == -15)
            {
                kazEggSpawn2.GetComponent<CollectBoxControl>().enabled = true;
                kazEggSpawn2.GetComponent<CollectBoxControl>().canSpawn = true;
                kazEggSpawn2.GetComponent<CollectBoxControl>().spawnEggTime = 0;
            }

            else if (distanceForKumes == -20)
            {
                kazEggSpawn3.GetComponent<CollectBoxControl>().enabled = true;
                kazEggSpawn3.GetComponent<CollectBoxControl>().canSpawn = true;
                kazEggSpawn3.GetComponent<CollectBoxControl>().spawnEggTime = 0;
            }
        }

        else if (transform.localPosition == new Vector3(2.43f + distanceForKumes, 0.6f, -2.49f))
        {

            delayTime += Time.deltaTime;

            if (delayTime >= 8)
            {
                target = new Vector3(2.43f + distanceForKumes, 0.6f, 3.27f);



            }
        }

        else if (transform.localPosition == new Vector3(2.43f + distanceForKumes, 0.6f, 3.27f))
        {
            target = new Vector3(2.43f + distanceForKumes, -3.4f, 11.80f);

        }

        else if (transform.localPosition == new Vector3(2.43f + distanceForKumes, -3.4f, 11.80f))
        {



            if (distanceForKumes == 0)
            {
                IsKumesEmpty.tag = "empty";
                goToKumes = false;
                kazEggSpawn.GetComponent<CollectBoxControl>().enabled = false;
            }

            else if (distanceForKumes == -15)
            {
                IsKumesEmpty2.tag = "empty";
                goToKumes = false;
                kazEggSpawn2.GetComponent<CollectBoxControl>().enabled = false;
            }

            else if (distanceForKumes == -20)
            {
                IsKumesEmpty3.tag = "empty";
                goToKumes = false;
                kazEggSpawn3.GetComponent<CollectBoxControl>().enabled = false;
            }

           
  
        goToKumes = false;
        canDo = true;
        }
    }
   
}
