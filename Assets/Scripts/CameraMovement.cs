using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{

    public GameObject target;
    public int distance;
    float delayTime = 0;
    // Update is called once per frame
    void Update()
    {

        if (target.name =="Player")
        {
            transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - distance);
        }
        else
        {
            delayTime += Time.deltaTime;
            if (delayTime <=3)
            {
              
                // transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x + 2, transform.position.y, target.transform.position.z - (distance + 5)), 1 * Time.deltaTime);
                transform.DOMove(new Vector3(target.transform.position.x + 2, transform.position.y, target.transform.position.z - (distance + 5)), 2);
            }
            else
            {
                target = GameObject.FindGameObjectWithTag("Player").gameObject;
                delayTime = 0;
            }
           
        }
        
    }

}
