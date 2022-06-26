using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CurveMovement : MonoBehaviour
{
     Transform player;
    public PathType pathsystem = PathType.CatmullRom;

    public Vector3[] pathval = new Vector3[6];


    public void CurveMovementStart(Vector3 transform0, Vector3 transform1, Vector3 transform2, Vector3 transform3, Vector3 transform4)
    {
        /*
        if (gameObject.name == "tavukPref(Clone)")
        {
            player = gameObject.transform;
            pathval[0] = new Vector3(0, -1.8f, 10);
            pathval[1] = new Vector3(0, -0.93f, 8.18f);
            pathval[2] = new Vector3(0, 0.72f, 5.68f);
            pathval[3] = new Vector3(0, 1.67f, 4.41f);
            pathval[4] = new Vector3(0, 1.67f, 1.54f);

            player.transform.DOLocalPath(pathval, 5, pathsystem);
        }
        else if (gameObject.tag == "tavukEgg")
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

        else if (gameObject.tag == "devekusuEgg")
        {
            player = gameObject.transform;
            pathval[0] = new Vector3(8.43f, 1.853f, -0.257f);
            pathval[1] = new Vector3(10.16f, 1.853f, -0.257f);
            pathval[2] = new Vector3(12.36f, 1.296f, -0.608f);
            pathval[3] = new Vector3(13.732f, 0.598f, -1.073f);
            pathval[4] = new Vector3(15.55f, -1f, -2.104f);
            pathval[5] = new Vector3(16f, -2.31f, -3.666f);
            player.transform.DOLocalPath(pathval, 5, pathsystem);
        }

        if (gameObject.name == "kazPref(Clone)")
        {
            player = gameObject.transform;
            pathval[0] = new Vector3(2.62f, -2.78f, 11.5f);
            pathval[1] = new Vector3(2.62f, -1.25f, 8.76f);
            pathval[2] = new Vector3(2.62f, 0, 5.3f);
            pathval[3] = new Vector3(2.62f, 0.8f, 2.45f);
            pathval[4] = new Vector3(2.62f, 0.8f, -1);

            player.transform.DOLocalPath(pathval, 5, pathsystem);
        }
        */
        if (gameObject.name == "tavukPref(Clone)")
        {
            player = gameObject.transform;
            pathval[0] = transform0;
            pathval[1] = transform1;
            pathval[2] = transform2;
            pathval[3] = transform3;
            pathval[4] = transform4;

            player.transform.DOLocalPath(pathval, 5, pathsystem);
        }
    }
    private void Start()
    {

        if (gameObject.tag == "tavukEgg")
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

        else if (gameObject.tag == "devekusuEgg")
        {
            player = gameObject.transform;
            pathval[0] = new Vector3(8.43f, 1.853f, -0.257f);
            pathval[1] = new Vector3(10.16f, 1.853f, -0.257f);
            pathval[2] = new Vector3(12.36f, 1.296f, -0.608f);
            pathval[3] = new Vector3(13.732f, 0.598f, -1.073f);
            pathval[4] = new Vector3(15.55f, -1f, -2.104f);
            pathval[5] = new Vector3(16f, -2.31f, -3.666f);
            player.transform.DOLocalPath(pathval, 5, pathsystem);
        }

        if (gameObject.name == "kazPref(Clone)")
        {
            player = gameObject.transform;
            pathval[0] = new Vector3(2.62f, -2.78f, 11.5f);
            pathval[1] = new Vector3(2.62f, -1.25f, 8.76f);
            pathval[2] = new Vector3(2.62f, 0, 5.3f);
            pathval[3] = new Vector3(2.62f, 0.8f, 2.45f);
            pathval[4] = new Vector3(2.62f, 0.8f, -1);

            player.transform.DOLocalPath(pathval, 5, pathsystem);
        }
    }

  
}
