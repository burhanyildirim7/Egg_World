using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CurveMovement : MonoBehaviour
{
     Transform player;
    public PathType pathsystem = PathType.CatmullRom;

    public Vector3[] pathval = new Vector3[6];

    private void Start()
    {
        if (gameObject.name == "tavukPref(Clone)")
        {
            player = gameObject.transform;
            pathval[0] = new Vector3(0,-1.8f,10);
            pathval[1] = new Vector3(0,-0.93f,8.18f);
            pathval[2] = new Vector3(0,0.72f,5.68f);
            pathval[3] = new Vector3(0,1.67f,4.41f);
            pathval[4] = new Vector3(0,1.67f,1.54f);
           
            player.transform.DOLocalPath(pathval, 5, pathsystem);
        }
        else
        {
            player = gameObject.transform;
            pathval[0] = new Vector3(3.36f, 1.58f, 0);
            pathval[1] = new Vector3(7, 0.23f, -1f);
            pathval[2] = new Vector3(8f, -0.921f, -1.9f);
            pathval[3] = new Vector3(8.69f, -2.25f, -2.9f);
            pathval[4] = new Vector3(8.94f, -2.25f, -5.50f);
            pathval[5] = new Vector3(8.94f, -2.25f, -5.50f);
            player.transform.DOLocalPath(pathval, 5, pathsystem);
        }
      
    }

  
}
