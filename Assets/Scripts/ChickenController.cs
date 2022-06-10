using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    float randomPositionX,randomPositionZ;
    Vector3 targetPosition;
    Animator chickenAnim;


  
    void Start()
    {
        transform.localScale = new Vector3(4, 4, 4);
        randomPositionX = Random.Range(-13,-5);
        randomPositionZ = Random.Range(-14,-8);

        targetPosition = new Vector3(randomPositionX,transform.position.y,randomPositionZ);

        chickenAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2 * Time.deltaTime);
            transform.LookAt(targetPosition);
            chickenAnim.SetBool("Run",true);
        }
        else
        {
            chickenAnim.SetBool("Run",false);
         
        }
    }
}
