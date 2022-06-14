using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyText : MonoBehaviour
{
    Text buyText;
    int buyPrice = 100;
    public GameObject openSpendBox;
    void Start()
    {
        buyText = GetComponent<Text>();

  
    }

    
    void Update()
    {
        buyText.text = "$" + buyPrice;

        if (buyPrice <= 0)
        {
            openSpendBox.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<CollectControl>().totalMoney> 0)
        {
            other.gameObject.GetComponent<CollectControl>().totalMoney--;
            buyPrice--;
           
        }
    }
}
