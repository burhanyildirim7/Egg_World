using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class KazController : MonoBehaviour
{
    public Transform target;
    private UnityEngine.AI.NavMeshAgent kazNavMeshAgent;
    public GameObject kumesDoor;
    public GameObject kazEgg;
    bool canDo = true;
    bool startTime = false;
    bool kuluckaTime = false;
    float timeToGoKumes = 0;
    float delayTime = 0;
    Animator kazAnim;


    

    void Start()
    {


        kazAnim = GetComponent<Animator>();
        kazNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        kumesDoor = GameObject.FindGameObjectWithTag("KazKumesDoor");
        target = GameObject.FindGameObjectWithTag("waitKazKumes").transform;
    }

    // Update is called once per frame
    void Update()
    {







        if (startTime)
        {
            StartTime();
        }

        if (kuluckaTime)
        {
            KuluckaFunction();
        }
        else
        {

            kazNavMeshAgent.destination = target.position;


        }



        if (target.name == "GameObject")
        {
            if (!kazNavMeshAgent.pathPending)
            {
                if (kazNavMeshAgent.remainingDistance <= kazNavMeshAgent.stoppingDistance)
                {
                    if (!kazNavMeshAgent.hasPath || kazNavMeshAgent.velocity.sqrMagnitude == 0f)
                    {
                        
                        OpenKumesDoorFunction();
                        transform.parent = GameObject.FindGameObjectWithTag("KazKumes").transform;

                    }

                }
            }
            else
            {
                // walk = true;
                kazAnim.SetBool("canWalk", true);
            }



        }

    }

    void OpenKumesDoorFunction()
    {
        kumesDoor.transform.DOLocalRotate(new Vector3(0, 0, 179), 1).OnComplete(() => StartCoroutine(EnterKumesFunction()));
    }

    IEnumerator EnterKumesFunction()
    {

        if (canDo)
        {
            target.localPosition = new Vector3(Random.Range(2, -19), 0, Random.Range(12, 22));
            kazNavMeshAgent.speed = 3;

            if (!kazNavMeshAgent.pathPending)
            {
                if (kazNavMeshAgent.remainingDistance <= kazNavMeshAgent.stoppingDistance)
                {
                    if (!kazNavMeshAgent.hasPath || kazNavMeshAgent.velocity.sqrMagnitude == 0f)
                    {


                        yield return new WaitForSeconds(2);


                        //idle = true;
                        kazAnim.SetBool("canWalk", false);
                        kazAnim.SetBool("canIdle", true);
                        startTime = true;

                    }

                }
            }
            else
            {
                //  walk = true;
                kazAnim.SetBool("canWalk", true);
            }
            canDo = false;
        }
    }

    void TurnAI()
    {
        /*
        delayTime += Time.deltaTime;
        if (delayTime >= 4)
        {
            target.localPosition = new Vector3(Random.Range(-5, 5), transform.localPosition.y, Random.Range(11, 19));
            delayTime = 0;
        }
        */
    }


    void StartTime()
    {


        kazNavMeshAgent.enabled = false;
        kumesDoor.transform.DOLocalRotate(new Vector3(0, 0, 0), 1);

        timeToGoKumes += Time.deltaTime;

        if (timeToGoKumes >= 5)
        {
            gameObject.AddComponent<CurveMovement>();
            // walk = true;
            kazAnim.SetBool("canIdle", false);
            kazAnim.SetBool("canWalk", true);
            //tavukNavMeshAgent.enabled = true;
            // transform.DOLocalMove(new Vector3(-1.4f,0,0),2);


            startTime = false;
            kuluckaTime = true;
        }
    }

    void KuluckaFunction()
    {
        delayTime += Time.deltaTime;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        if (delayTime >= 4)
        {

            var spawnEgg = Instantiate(kazEgg, transform.position, Quaternion.identity);
            spawnEgg.name = "kuluckaEgg";
            spawnEgg.transform.parent = GameObject.FindGameObjectWithTag("KazKumes").transform;
            spawnEgg.AddComponent<CurveMovement>();
            delayTime = 0;
        }
    }
}
