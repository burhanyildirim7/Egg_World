using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyText : MonoBehaviour
{
    Text buyText;
    int buyPrice = 100;
    public GameObject openNextLevelTezgah1;
    public GameObject openNextLevelTezgah2;
    public GameObject openNextLevelTezgah3;
    public GameObject openNextLevelTezgah4;
    
    void Start()
    {
        buyText = GetComponent<Text>();

        if (gameObject.name == "UpgradeLevel2")
        {
            
            openNextLevelTezgah3.SetActive(true);

         
        }

        else if (gameObject.name == "UpgradeKazLevel2")
        {
         
            openNextLevelTezgah4.SetActive(true);

        }

        else if (gameObject.name == "ToLevel2")
        {
          
            openNextLevelTezgah2.SetActive(true);

        }


    }

    
    void Update()
    {
        buyText.text = "$" + buyPrice ;

        if (buyPrice <= 0)
        {
            if (gameObject.name == "ToLevel1")
            {
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(false);
                
                Destroy(gameObject);
            }
            else if (gameObject.name == "ToLevel2")
            {
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(false);
        
                Destroy(gameObject);
            }
            else if (gameObject.name == "ToLevel3")
            {
                openNextLevelTezgah3.SetActive(true);
                Destroy(openNextLevelTezgah2);
                Destroy(gameObject);
            }
            else if (gameObject.name == "ToLevel4")
            {
                openNextLevelTezgah4.SetActive(true);
                Destroy(openNextLevelTezgah3);
                Destroy(gameObject);
            }

            else if (gameObject.name == "OpenToResarchPlace")
            {
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(false);
          
                Destroy(gameObject);

            }

            else if (gameObject.name == "UpgradeLevel2")
            {
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(false);
                openNextLevelTezgah3.SetActive(false);

                Destroy(gameObject);
            }

            else if (gameObject.name == "UpgradeKazLevel2")
            {
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(true);
                openNextLevelTezgah3.SetActive(false);
                openNextLevelTezgah4.SetActive(false);
           

                Destroy(gameObject);
            }

            else if (gameObject.name == "UpgradeDevekusuLevel2")
            {
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(false);


                Destroy(gameObject);
            }


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<CollectControl>().totalMoney> 0 && other.gameObject.GetComponent<CollectControl>().isPlayerMove == false)
        {
            other.gameObject.GetComponent<CollectControl>().totalMoney--;
            buyPrice--;
           
        }
    }
}
