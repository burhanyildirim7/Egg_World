using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyText : MonoBehaviour
{
    Text buyText;
    public int buyPrice = 100;
    public GameObject openNextLevelTezgah1;
    public GameObject openNextLevelTezgah2;
    public GameObject openNextLevelTezgah3;
    public GameObject openNextLevelTezgah4;
    public GameObject openNextLevelTezgah5;
    
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
            
            else if (gameObject.name == "DevekusuKumesLevel3")
            {
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(false);


                Destroy(gameObject);
            } 

            else if (gameObject.name == "UpgradeLevel3")
            {
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(true);
                openNextLevelTezgah3.SetActive(false);


                Destroy(gameObject);
            } 
            else if (gameObject.name == "UpgradeKazLevel3")
            {
    
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(true);
                openNextLevelTezgah3.SetActive(false);


                Destroy(gameObject);
            }  
            else if (gameObject.name == "EjderKumesLevel2")
            {
    
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(false);
       


                Destroy(gameObject);
            }

            else if (gameObject.name == "UpgradeTimsahLevel2")
            {
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(false);


                Destroy(gameObject);
            }
            else if (gameObject.name == "UpgradeTimsahLevel3")
            {
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(false);


                Destroy(gameObject);
            }

            else if (gameObject.name == "TavukEggNeededMoneyText")
            {
        

                Destroy(gameObject);
            }
            else if (gameObject.name == "KazEggNeededMoneyText")
            {
        

                Destroy(gameObject);
            }

              else if (gameObject.name == "DevekusuEggNeededMoneyText")
            {
        

                Destroy(gameObject);
            }  
            
            else if (gameObject.name == "TimsahEggNeededMoneyText")
            {
        

                Destroy(gameObject);
            }


        }
    }

    

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BedelOdemeMoney")
        {
         
       
            GameObject.FindGameObjectWithTag("Player").GetComponent<CollectControl>().totalMoney-=10;
            buyPrice-=10;

            Destroy(other.gameObject);
        }   
    }
}
