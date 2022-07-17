using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavukMakerController : MonoBehaviour
{
    public GameObject tavuk;
    public GameObject kaz;
    public bool kuluckaMakinesiFull = false;
    float delayTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
  

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


        if (gameObject.name == "KazMaker")
        {
            if (delayTime >= 3)
            {
                var spawnKaz = Instantiate(kaz, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);

                spawnKaz.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                spawnKaz.GetComponent<KazGoKumesController>().enabled = true;
                spawnKaz.GetComponent<KazController>().enabled = false;
                delayTime = 0;
                kuluckaMakinesiFull = false;

            }
        }

        else if (gameObject.name == "TavukKuluckaMakinesi")
        {
            if (delayTime >= 3)
            {
                var spawnTavuk = Instantiate(tavuk, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);

                spawnTavuk.GetComponent<TavukGoKumesController>().enabled = true;
                spawnTavuk.GetComponent<TavukControllerReal>().enabled = false;
                delayTime = 0;
                kuluckaMakinesiFull = false;

            }
        }
       
    }
}
