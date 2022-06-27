using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavukMakerController : MonoBehaviour
{
    public GameObject tavuk;
    public bool kuluckaMakinesiFull = false;
    float delayTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        var spawnTavuk = Instantiate(tavuk, new Vector3(transform.position.x,0,transform.position.z), Quaternion.identity);

        spawnTavuk.GetComponent<TavukGoKumesController>().enabled = true;
        spawnTavuk.GetComponent<TavukControllerReal>().enabled = false;
        //Instantiate(animal, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (kuluckaMakinesiFull)
        {
            StartKuluckaFunction();
        }   
    }

   void StartKuluckaFunction()
    {
        delayTime += Time.deltaTime;

        if (delayTime >= 3 )
        {
            var spawnTavuk = Instantiate(tavuk, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);

            spawnTavuk.GetComponent<TavukGoKumesController>().enabled = true; 
            spawnTavuk.GetComponent<TavukControllerReal>().enabled = false; 
            delayTime = 0;
            kuluckaMakinesiFull = false;
            
        }
    }
}
