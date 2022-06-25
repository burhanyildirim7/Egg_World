using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavukMakerController : MonoBehaviour
{
    public GameObject tavuk;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tavuk, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
