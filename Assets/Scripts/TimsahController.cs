using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimsahController : MonoBehaviour
{
    Animator timsahAnim;

    int randomNumbersForAnim;
    float delayTime;
     Vector3 target;
    bool canPickNumberForAnim;
    void Start()
    {
        timsahAnim = GetComponent<Animator>();

        randomNumbersForAnim = 1;
        ChooseRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        ChooseRandomAnimFunction();
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
          
        
     
          
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target,5*Time.deltaTime);
            timsahAnim.SetBool("canWalk", true);

            Vector3 relativePos = transform.localPosition - target;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up*180);
          
            transform.localRotation = rotation * Quaternion.Euler(0, transform.localRotation.y+180, 0);


            if (transform.localPosition == target)
            {
                Debug.Log("Geldi");
                timsahAnim.SetBool("canWalk", false);
                ChooseRandomTarget();
                canPickNumberForAnim = true;
                delayTime = 0;
            }
        }

        else if (delayTime >= 4 && randomNumbersForAnim == 1)
        {
            timsahAnim.SetBool("canIdle", true);
            
            if (timsahAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !timsahAnim.IsInTransition(0))
            {
                if (delayTime >= 7)
                {
                    timsahAnim.SetBool("canIdle", false);
                    canPickNumberForAnim = true;
                    delayTime = 0;
                }
            
            }
          
                
        }

       
    }

    public void ChooseRandomTarget()
    {
        target = new Vector3(Random.Range(-22,20), transform.localPosition.y, Random.Range(-25,15));
    }



}
