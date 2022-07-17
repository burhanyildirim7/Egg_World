using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerPrefsController : MonoBehaviour
{
    public GameObject tezgahEggList;

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
                Debug.Log(PlayerPrefs.GetInt(_makineAdi + i));
                GameObject _GeciciObje =
                Instantiate(_stackObjesi[0], _girisSirasi1[i].transform);
                _GeciciObje.transform.localPosition = Vector3.zero;
                _GeciciObje.transform.localScale = new Vector3(33,33,1000);
                _GeciciObje.transform.parent.gameObject.tag = "full";
                tezgahEggList.GetComponent<SpendBoxControl>().spendEggList.Add(_GeciciObje);

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
