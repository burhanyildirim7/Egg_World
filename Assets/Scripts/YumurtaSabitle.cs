using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YumurtaSabitle : MonoBehaviour
{

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 10)
        {
            if (gameObject.transform.parent == null)
            {
                Destroy(gameObject);
            }
            else
            {

            }
        }
        else
        {

        }
    }
}
