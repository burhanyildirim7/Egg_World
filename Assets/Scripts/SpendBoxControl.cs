using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpendBoxControl : MonoBehaviour
{
    
    IEnumerator Trigger()
    {
      
        transform.DOScale(new Vector3(transform.localScale.x+0.2f, transform.localScale.y+0.2f, transform.localScale.z+0.2f), 0.1f);
        yield return new WaitForSeconds(0.1f);
        transform.DOScale(new Vector3(transform.localScale.x-0.2f, transform.localScale.y-0.2f, transform.localScale.z-0.2f), 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cube")
        {
            StartCoroutine(Trigger());
        }
    }
    
}
