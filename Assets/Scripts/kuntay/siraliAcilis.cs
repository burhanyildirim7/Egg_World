using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siraliAcilis : MonoBehaviour
{
    [SerializeField] GameObject _kontrolEdilenObje, _acilacakObje;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_kontrolEdilenObje.activeSelf)
        {
            _acilacakObje.SetActive(true);
            Destroy(gameObject);
        }
    }
}
