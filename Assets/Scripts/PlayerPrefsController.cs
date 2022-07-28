using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerPrefsController : MonoBehaviour
{
    public GameObject tezgahEggList;
    public GameObject kumesSpawnEggList;

    public bool _tezgahMi;

    [SerializeField] string _makineAdi;


    [SerializeField] List<GameObject> _girisSirasi1 = new List<GameObject>(), _stackObjesi = new List<GameObject>();

    private GameObject _GeciciObje;

    private bool _ilkSefer;

    void Start()
    {
        _ilkSefer = false;

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
                _GeciciObje = Instantiate(_stackObjesi[0], _girisSirasi1[i].transform);

                //_GeciciObje.transform.parent = _girisSirasi1[i].transform;

                _GeciciObje.transform.localPosition = Vector3.zero;
                //Debug.Log(_makineAdi + " ---> " + _GeciciObje.transform.localPosition);
                _GeciciObje.transform.parent.gameObject.tag = "full";


                if (_tezgahMi)
                {
                    tezgahEggList.GetComponent<SpendBoxControl>().spendEggList.Add(_GeciciObje);
                }
                else
                {
                    kumesSpawnEggList.GetComponent<CollectBoxControl>().eggList2.Add(_GeciciObje);
                }


            }
            else
            {
            }

            //_GeciciObje.transform.localPosition = Vector3.zero;
        }
    }




    private void FixedUpdate()
    {

        ListeDuzenleme();

        //Debug.Log(_GeciciObje.transform.parent + " ---> " + _GeciciObje.transform.localPosition);
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
