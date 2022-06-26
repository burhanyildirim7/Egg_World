using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class TavukController : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent tavukNavMeshAgent;
    public GameObject kümesDoor;
    public GameObject tavukEgg;
    bool canDo = true;
    bool startTime = false;
    bool kuluckaTime = false;
    float timeToGoKümes = 0;
    float delayTime = 0;
    public GameObject tavukEggSpawn;

    [SerializeField] bool walk, idle;
    void Start()
    {
        walk = false;
        idle = false;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        tavukEggSpawn = GameObject.FindGameObjectWithTag("tavukEggSpawn");
        tavukEggSpawn.GetComponent<CollectBoxControl>().enabled = false;


        tavukNavMeshAgent = GetComponent<NavMeshAgent>();
        kümesDoor = GameObject.FindGameObjectWithTag("kümesDoor");
        target = GameObject.FindGameObjectWithTag("waitTavukKümes").transform;
    }

    // Update is called once per frame
    void Update()
    {

       // Vector3 relativePos = transform.position - target.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(target.position, Vector3.up * 180);

        transform.rotation = rotation;
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
       
            tavukNavMeshAgent.destination = target.position;

      
        }



        if (target.name == "GameObject")
        {
            if (!tavukNavMeshAgent.pathPending)
            {
                if (tavukNavMeshAgent.remainingDistance <= tavukNavMeshAgent.stoppingDistance)
                {
                    if (!tavukNavMeshAgent.hasPath || tavukNavMeshAgent.velocity.sqrMagnitude == 0f)
                    {
                        Debug.Log("Vardý");
                        OpenKümesDoorFunction();
                        transform.parent = GameObject.FindGameObjectWithTag("tavukKümes").transform;

                    }
                   
                }
            }
            else
            {
                walk = true;
            }



        }
     
    }

    void OpenKümesDoorFunction()
    {
        kümesDoor.transform.DOLocalRotate(new Vector3(0,0,179),1).OnComplete(()=> StartCoroutine(EnterKümesFunction()));
    }
    
    IEnumerator EnterKümesFunction()
    {
      
        if (canDo)
        {
            
            target.localPosition = new Vector3(Random.Range(-5, 5), 0, Random.Range(11, 20));
            tavukNavMeshAgent.speed = 3;

            if (!tavukNavMeshAgent.pathPending)
            {
                if (tavukNavMeshAgent.remainingDistance <= tavukNavMeshAgent.stoppingDistance)
                {
                    if (!tavukNavMeshAgent.hasPath || tavukNavMeshAgent.velocity.sqrMagnitude == 0f)
                    {
                      
                  
                        yield return new WaitForSeconds(2);


                        idle = true;
                        startTime = true;

                    }
                  
                }
            }
            else
            {
                walk = true;
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


        tavukNavMeshAgent.enabled = false;
        kümesDoor.transform.DOLocalRotate(new Vector3(0, 0, 0), 1);

        timeToGoKümes += Time.deltaTime;

        if (timeToGoKümes >= 10)
        {
            gameObject.AddComponent<CurveMovement>();
            gameObject.GetComponent<CurveMovement>().CurveMovementStart(new Vector3(0, -1.8f, 10), new Vector3(0, -0.93f, 8.18f), new Vector3(0, 0.72f, 5.68f), new Vector3(0, 1.67f, 4.41f), new Vector3(0, 1.67f, 1.54f));
            walk = true;
            //tavukNavMeshAgent.enabled = true;
            // transform.DOLocalMove(new Vector3(-1.4f,0,0),2);
          
    
            startTime = false;
            kuluckaTime = true;
        }
    }

    void KuluckaFunction()
    {
        delayTime += Time.deltaTime;
 
        GetComponent<NavMeshAgent>().enabled = false;
        if (delayTime >= 4)
        {
            // gameObject.GetComponent<CurveMovement>().CurveMovementStart(new Vector3(0,0,0), new Vector3(0, 0, 1), new Vector3(0, 0, 2), new Vector3(0, 0, 3), new Vector3(0, 0, 4));

            //yukarýdaki Curve Moment kodunu burada tavuðu kümese geri göndermek için kullan
            tavukEggSpawn.GetComponent<CollectBoxControl>().enabled = true;

            if (tavukEggSpawn.GetComponent<CollectBoxControl>().eggList2.Count >= 3)
            {
                tavukEggSpawn.GetComponent<CollectBoxControl>().enabled = false;
                gameObject.GetComponent<CurveMovement>().CurveMovementStart(new Vector3(0, 1.67f, 1.54f), new Vector3(0, 1.67f, 4.41f), new Vector3(0, 0.72f, 5.68f), new Vector3(0, -0.93f, 8.18f), new Vector3(0, -1.8f, 10));
              
            }
            //Araya süre girip yumurta spawn süresini ayarla.
            //tavukEggSpawn.SetActive(false);
        }
    }
}
