using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavukMakerController : MonoBehaviour
{
    public GameObject animal;
    // Start is called before the first frame update
    void Start()
    {
       
        Instantiate(animal, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
