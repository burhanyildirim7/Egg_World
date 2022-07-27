using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerPrefsController : MonoBehaviour
{
    public GameObject tezgahEggList;
    public GameObject kumesSpawnEggList;

    [SerializeField] string _makineAdi;


    [SerializeField] List<GameObject> _girisSirasi1 = new List<GameObject>(), _stackObjesi = new List<GameObject>();


    void Start()
    {


        if (PlayerPrefs.GetInt(_makineAdi + "ilkseferstackkontrtolu") == 0)
        {
            PlayerPrefs.SetInt(_makineAdi + "ilkseferstackkontrtolu", 1);
            for (int m = 0; m < _girisSirasi1.Count; m++)
            {
                PlayerPrefs.SetInt(_makineAdi + m, -1);
            }
        }
        for (int i = 0; i < _girisSirasi1.Count; i++)
        {

            if (PlayerPrefs.GetInt(_makineAdi + i) >= 0)
            {
                //Debug.Log(PlayerPrefs.GetInt(_makineAdi + i));
                GameObject _GeciciObje =
                Instantiate(_stackObjesi[0], _girisSirasi1[i].transform);
                //_GeciciObje.transform.eulerAngles = new Vector3(-90, 0, 0);

                _GeciciObje.transform.localPosition = Vector3.zero;

                if (_makineAdi == "deveLevel1Tezgah1" || _makineAdi == "ejderLevel1Tezgah1")
                {
                    // _GeciciObje.transform.eulerAngles = new Vector3(-90, 0, 0);
                    //_GeciciObje.transform.localScale = new Vector3(33, 1000, 33);

                    tezgahEggList.GetComponent<SpendBoxControl>().spendEggList.Add(_GeciciObje);
                }
                if (_makineAdi == "tavukLevel1Tezgah1" || _makineAdi == "kazLevel1Tezgah1")
                {

                    //_GeciciObje.transform.localScale = new Vector3(33, 33, 1000);
                    tezgahEggList.GetComponent<SpendBoxControl>().spendEggList.Add(_GeciciObje);
                }

                if (_makineAdi == "timsahLevel1Tezgah1")
                {
                    //_GeciciObje.transform.eulerAngles = new Vector3(-90, 0, 0);
                    //_GeciciObje.transform.localScale = new Vector3(66, 66, 2000);
                    tezgahEggList.GetComponent<SpendBoxControl>().spendEggList.Add(_GeciciObje);
                }

                if (_makineAdi == "TavukEggSpawn1" || _makineAdi == "TavukEggSpawn2" || _makineAdi == "TavukEggSpawn3" || _makineAdi == "KazEggSpawn1" || _makineAdi == "KazEggSpawn2" || _makineAdi == "KazEggSpawn3")
                {
                    //_GeciciObje.transform.eulerAngles = new Vector3(-90, 0, 0);
                    //_GeciciObje.transform.localScale = new Vector3(16, 16, 100);
                    kumesSpawnEggList.GetComponent<CollectBoxControl>().eggList2.Add(_GeciciObje);


                }

                if (_makineAdi == "DevekusuEggSpawn1" || _makineAdi == "DevekusuEggSpawn2" || _makineAdi == "DevekusuEggSpawn3")
                {
                    //_GeciciObje.transform.eulerAngles = new Vector3(-90, 0, 0);
                    //_GeciciObje.transform.localScale = new Vector3(5, 63, 5);
                    kumesSpawnEggList.GetComponent<CollectBoxControl>().eggList2.Add(_GeciciObje);


                }

                if (_makineAdi == "TimsahEggSpawn1" || _makineAdi == "TimsahEggSpawn2" || _makineAdi == "TimsahEggSpawn3")
                {
                    _GeciciObje.transform.eulerAngles = new Vector3(-90, 0, 0);
                    //_GeciciObje.transform.localScale = new Vector3(30, 30, 200);
                    kumesSpawnEggList.GetComponent<CollectBoxControl>().eggList2.Add(_GeciciObje);


                }

                if (_makineAdi == "EjderhaEggSpawn1" || _makineAdi == "EjderhaEggSpawn2")
                {

                    //_GeciciObje.transform.localScale = new Vector3(4, 4, 25);
                    _GeciciObje.transform.eulerAngles = new Vector3(-90, 0, 0);
                    kumesSpawnEggList.GetComponent<CollectBoxControl>().eggList2.Add(_GeciciObje);


                }

                _GeciciObje.transform.parent.gameObject.tag = "full";


                if (PlayerPrefs.GetInt(_makineAdi + i) > 7)
                {
                    _GeciciObje.transform.GetChild(0).gameObject.SetActive(false);
                    _GeciciObje.transform.GetChild(1).gameObject.SetActive(true);

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




    private void FixedUpdate()
    {
        ListeDuzenleme();




    }

    private void ListeDuzenleme()
    {
        for (int i = 0; i < _girisSirasi1.Count; i++)
        {
            if (_girisSirasi1[i].transform.childCount == 1)
            {

                PlayerPrefs.SetInt(_makineAdi + i, 1);
            }
            else
            {
                PlayerPrefs.SetInt(_makineAdi + i, -1);
            }
        }
    }
}
