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

     
        if (gameObject.transform.parent.name == "OpenTavukKumes" && PlayerPrefs.GetInt("openTavukKumesAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenTavukKumesBuyPrice");
        } 

        if (gameObject.transform.parent.name == "PutTavukEggsCanvas" && PlayerPrefs.GetInt("PutTavukEggsCanvasAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("PutTavukEggsCanvasBuyPrice");
        }
        
        if (gameObject.transform.parent.name == "ResearchPlaceCanvas" && PlayerPrefs.GetInt("ResearchPlaceCanvasAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("ResearchPlaceCanvasBuyPrice");
        }
        
        if (gameObject.transform.parent.name == "OpenKazKumes" && PlayerPrefs.GetInt("OpenKazKumesAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenKazKumesBuyPrice");
        }
        
        if (gameObject.transform.parent.name == "OpenPutKazEgg" && PlayerPrefs.GetInt("OpenPutKazEggAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenPutKazEggBuyPrice");
        } 
        
        if (gameObject.transform.parent.name == "OpenTavukKumesLevel2" && PlayerPrefs.GetInt("OpenTavukKumesLevel2Azaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenTavukKumesLevel2BuyPrice");
        } 
        
        if (gameObject.transform.parent.name == "OpenDevekusuKumes" && PlayerPrefs.GetInt("OpenDevekusuKumesAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenDevekusuKumesBuyPrice");
        }

        if (gameObject.transform.parent.name == "OpenPutDevekusu" && PlayerPrefs.GetInt("OpenPutDevekusuAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenPutDevekusuBuyPrice");
        }  
        
        if (gameObject.transform.parent.name == "KazKumesLevel2" && PlayerPrefs.GetInt("KazKumesLevel2Azaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("KazKumesLevel2BuyPrice");
        } 
        
        if (gameObject.transform.parent.name == "OpenTimsahKumes" && PlayerPrefs.GetInt("OpenTimsahKumesAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenTimsahKumesBuyPrice");
        } 
        if (gameObject.transform.parent.name == "OpenPutTimsah" && PlayerPrefs.GetInt("OpenPutTimsahAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenPutTimsahBuyPrice");
        }

         if (gameObject.transform.parent.name == "OpenDevekusuKumesLevel2" && PlayerPrefs.GetInt("OpenDevekusuKumesLevel2Azaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenDevekusuKumesLevel2BuyPrice");
        }
         if (gameObject.transform.parent.name == "TavukKumesLevel3" && PlayerPrefs.GetInt("TavukKumesLevel3Azaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("TavukKumesLevel3BuyPrice");
        }

        if (gameObject.transform.parent.name == "KazKumesLevel3" && PlayerPrefs.GetInt("KazKumesLevel3Azaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("KazKumesLevel3BuyPrice");
        }

        if (gameObject.transform.parent.name == "OpenTimsahLevel2" && PlayerPrefs.GetInt("OpenTimsahLevel2Azaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenTimsahLevel2BuyPrice");
        }

        if (gameObject.transform.parent.name == "OpenEjderKumes" && PlayerPrefs.GetInt("OpenEjderKumesAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenEjderKumesBuyPrice");
        } 
        
        if (gameObject.transform.parent.name == "OpenEjderTezgah" && PlayerPrefs.GetInt("OpenEjderTezgahAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenEjderTezgahBuyPrice");
        }

        if (gameObject.transform.parent.name == "OpenTimsahLevel3" && PlayerPrefs.GetInt("OpenTimsahLevel3Azaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenTimsahLevel3BuyPrice");
        }

         if (gameObject.transform.parent.name == "OpenDevekusuLevel3" && PlayerPrefs.GetInt("OpenDevekusuLevel3Azaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("OpenDevekusuLevel3BuyPrice");
        }

         if (gameObject.transform.parent.name == "EjderKumesLevel2Canvas" && PlayerPrefs.GetInt("EjderKumesLevel2CanvasAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("EjderKumesLevel2CanvasBuyPrice");
        }
        
        if (gameObject.transform.parent.name == "TavukEggNeededMoney" && PlayerPrefs.GetInt("TavukEggNeededMoneyAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("TavukEggNeededMoneyBuyPrice");
        }  
        
        if (gameObject.transform.parent.name == "KazEggNeededMoney" && PlayerPrefs.GetInt("KazEggNeededMoneyAzaldi") == 1)
        {
            buyPrice = PlayerPrefs.GetInt("KazEggNeededMoneyBuyPrice");
        }
  

     
        

         
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
        if (gameObject.name == "ToLevel1"
            || gameObject.name == "UpgradeKazLevel2" 
            || gameObject.name == "UpgradeDevekusuLevel2" 
            || gameObject.name == "UpgradeLevel3" 
            || gameObject.name == "UpgradeKazLevel3" 
            || gameObject.name == "UpgradeTimsahLevel2" 
            || gameObject.name == "EjderKumesLevel2"
            || gameObject.name == "UpgradeTimsahLevel3")
        {
            if (openNextLevelTezgah1.gameObject.activeSelf)
            {
               gameObject.SetActive(false);
            }
        }




        if (buyPrice <= 0)
        {
            if (gameObject.name == "ToLevel1")
            {
                openNextLevelTezgah1.SetActive(true);
                openNextLevelTezgah2.SetActive(false);
                
                Destroy(gameObject);

                if (openNextLevelTezgah1.gameObject.activeSelf)
                {
                    Destroy(gameObject);
                }
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

            buyPrice -= 10;


            if (gameObject.transform.parent.name == "OpenTavukKumes")
            {
                PlayerPrefs.SetInt("openTavukKumesAzaldi", 1);
                PlayerPrefs.SetInt("OpenTavukKumesBuyPrice", buyPrice);
            } 
            
            if (gameObject.transform.parent.name == "PutTavukEggsCanvas")
            {
                PlayerPrefs.SetInt("PutTavukEggsCanvasAzaldi", 1);
                PlayerPrefs.SetInt("PutTavukEggsCanvasBuyPrice", buyPrice);
            }
            
            if (gameObject.transform.parent.name == "ResearchPlaceCanvas")
            {
                PlayerPrefs.SetInt("ResearchPlaceCanvasAzaldi", 1);
                PlayerPrefs.SetInt("ResearchPlaceCanvasBuyPrice", buyPrice);
            } 
            
            if (gameObject.transform.parent.name == "OpenKazKumes")
            {
                PlayerPrefs.SetInt("OpenKazKumesAzaldi", 1);
                PlayerPrefs.SetInt("OpenKazKumesBuyPrice", buyPrice);
            }

            if (gameObject.transform.parent.name == "OpenPutKazEgg")
            {
                PlayerPrefs.SetInt("OpenPutKazEggAzaldi", 1);
                PlayerPrefs.SetInt("OpenPutKazEggBuyPrice", buyPrice);
            }
            
            if (gameObject.transform.parent.name == "OpenTavukKumesLevel2")
            {
                PlayerPrefs.SetInt("OpenTavukKumesLevel2Azaldi", 1);
                PlayerPrefs.SetInt("OpenTavukKumesLevel2BuyPrice", buyPrice);
            }
            
            if (gameObject.transform.parent.name == "OpenDevekusuKumes")
            {
                PlayerPrefs.SetInt("OpenDevekusuKumesAzaldi", 1);
                PlayerPrefs.SetInt("OpenDevekusuKumesBuyPrice", buyPrice);
            } 
            
            if (gameObject.transform.parent.name == "OpenPutDevekusu")
            {
                PlayerPrefs.SetInt("OpenPutDevekusuAzaldi", 1);
                PlayerPrefs.SetInt("OpenPutDevekusuBuyPrice", buyPrice);
            }
            
            if (gameObject.transform.parent.name == "KazKumesLevel2")
            {
                PlayerPrefs.SetInt("KazKumesLevel2Azaldi", 1);
                PlayerPrefs.SetInt("KazKumesLevel2BuyPrice", buyPrice);
            } 
            
            if (gameObject.transform.parent.name == "OpenTimsahKumes")
            {
                PlayerPrefs.SetInt("OpenTimsahKumesAzaldi", 1);
                PlayerPrefs.SetInt("OpenTimsahKumesBuyPrice", buyPrice);
            }  
            
            if (gameObject.transform.parent.name == "OpenPutTimsah")
            {
                PlayerPrefs.SetInt("OpenPutTimsahAzaldi", 1);
                PlayerPrefs.SetInt("OpenPutTimsahBuyPrice", buyPrice);
            } 
            
            if (gameObject.transform.parent.name == "OpenDevekusuKumesLevel2")
            {
                PlayerPrefs.SetInt("OpenDevekusuKumesLevel2Azaldi", 1);
                PlayerPrefs.SetInt("OpenDevekusuKumesLevel2BuyPrice", buyPrice);
            } 
            
            if (gameObject.transform.parent.name == "TavukKumesLevel3")
            {
                PlayerPrefs.SetInt("TavukKumesLevel3Azaldi", 1);
                PlayerPrefs.SetInt("TavukKumesLevel3BuyPrice", buyPrice);
            }  
            if (gameObject.transform.parent.name == "KazKumesLevel3")
            {
                PlayerPrefs.SetInt("KazKumesLevel3Azaldi", 1);
                PlayerPrefs.SetInt("KazKumesLevel3BuyPrice", buyPrice);
            } 
            
            if (gameObject.transform.parent.name == "OpenTimsahLevel2")
            {
                PlayerPrefs.SetInt("OpenTimsahLevel2Azaldi", 1);
                PlayerPrefs.SetInt("OpenTimsahLevel2BuyPrice", buyPrice);
            }
            
            if (gameObject.transform.parent.name == "OpenEjderKumes")
            {
                PlayerPrefs.SetInt("OpenEjderKumesAzaldi", 1);
                PlayerPrefs.SetInt("OpenEjderKumesBuyPrice", buyPrice);
            } 
            
            if (gameObject.transform.parent.name == "OpenEjderTezgah")
            {
                PlayerPrefs.SetInt("OpenEjderTezgahAzaldi", 1);
                PlayerPrefs.SetInt("OpenEjderTezgahBuyPrice", buyPrice);
            } 
            
            if (gameObject.transform.parent.name == "OpenTimsahLevel3")
            {
                PlayerPrefs.SetInt("OpenTimsahLevel3Azaldi", 1);
                PlayerPrefs.SetInt("OpenTimsahLevel3BuyPrice", buyPrice);
            }

               if (gameObject.transform.parent.name == "OpenDevekusuLevel3")
            {
                PlayerPrefs.SetInt("OpenDevekusuLevel3Azaldi", 1);
                PlayerPrefs.SetInt("OpenDevekusuLevel3BuyPrice", buyPrice);
            }

               if (gameObject.transform.parent.name == "EjderKumesLevel2Canvas")
            {
                PlayerPrefs.SetInt("EjderKumesLevel2CanvasAzaldi", 1);
                PlayerPrefs.SetInt("EjderKumesLevel2CanvasBuyPrice", buyPrice);
            } 
            
            if (gameObject.transform.parent.name == "TavukEggNeededMoney")
            {
                PlayerPrefs.SetInt("TavukEggNeededMoneyAzaldi", 1);
                PlayerPrefs.SetInt("TavukEggNeededMoneyBuyPrice", buyPrice);
            } 
            
            
            if (gameObject.transform.parent.name == "KazEggNeededMoney")
            {
                PlayerPrefs.SetInt("KazEggNeededMoneyAzaldi", 1);
                PlayerPrefs.SetInt("KazEggNeededMoneyBuyPrice", buyPrice);
            }




            Destroy(other.gameObject);
        }   
    }
}
