using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance; // Singleton yapisi icin gerekli ornek

    public GameObject TapToStartPanel, LoosePanel, GamePanel, WinPanel, startScreenCoinImage, scoreEffect;
    public Text gamePlayScoreText, levelNoText, tapToStartScoreText, totalElmasText;
    public Animator ScoreTextAnim;



    // singleton yapisi burada kuruluyor.
    private void Awake()
    {
        if (instance == null) instance = this;
        //else Destroy(this);
    }

    private void Start()
    {
        StartUI();
    }

    // Oyun ilk acildiginda calisacak olan ui fonksiyonu. 
    public void StartUI()
    {
        ActivateTapToStartScreen();
    }

    /// <summary>
    /// Level numarasini ui kisminda degistirmek icin fonksiyon. Parametre olarak level numarasi aliyor.
    /// </summary>
    /// <param name="levelNo">UI ekranina yazilmak istenen Level numaras?</param>
    public void SetLevelText(int levelNo)
    {
        levelNoText.text = "Level " + levelNo.ToString();
    }

    // TAPTOSTART TUSUNA BASILDISINDA  --- GIRIS EKRANINDA VE LEVEL BASLARINDA
    public void TapToStartButtonClick()
    {

        GameController.instance.isContinue = true;
        //PlayerController.instance.SetArmForGaming();
        TapToStartPanel.SetActive(false);
        GamePanel.SetActive(true);
        //SetLevelText(LevelController.instance.totalLevelNo);
        SetGamePlayScoreText();

    }

    // RESTART TUSUNA BASILDISINDA  --- LOOSE EKRANINDA
    public void RestartButtonClick()
    {
        GamePanel.SetActive(false);
        LoosePanel.SetActive(false);
        TapToStartPanel.SetActive(true);
        //LevelController.instance.RestartLevelEvents();
        SetTapToStartScoreText();
    }


    // NEXT LEVEL TUSUNA BASILDIGINDA... WIN EKRANINDAKI BUTON
    public void NextLevelButtonClick()
    {
        SetTapToStartScoreText();
        TapToStartPanel.SetActive(true);
        WinPanel.SetActive(false);
        GamePanel.SetActive(false);
        //LevelController.instance.NextLevelEvents();

    }



    /// <summary>
    /// Bu fonksiyon gameplay ekranindaki score textini gunceller.
    /// </summary>
    public void SetGamePlayScoreText()
    {
        gamePlayScoreText.text = PlayerPrefs.GetInt("Money").ToString();
    }


    /// <summary>
    /// Bu fonksiyon totalScore un yazilmasi gereken textleri gunceller.
    /// </summary>
    public void SetTapToStartScoreText()
    {
        tapToStartScoreText.text = PlayerPrefs.GetInt("Money").ToString();
    }

    /// <summary>
    /// Bu fonksiyon winscreen de ge?erli level scoreunun yazildigi texti gunceller.
    /// </summary>


    /// <summary>
    /// Bu fonksiyon totalElmas sayilarinin yazildigi textleri gunceller.
    /// </summary>
    public void SetTotalElmasText()
    {
        totalElmasText.text = PlayerPrefs.GetInt("totalElmas").ToString();
    }

    /// <summary>
    /// Bu fonksiyon winscreen ekranini acar.
    /// </summary>




    IEnumerator StartScreenCoinsDissolve(GameObject obj)
    {
        Color tempColor = obj.GetComponent<Image>().color;
        while (obj.transform.localScale.x > .2f)
        {
            obj.transform.localScale = new Vector3(obj.transform.localScale.x - .05f, obj.transform.localScale.y - .05f, obj.transform.localScale.z - .05f);
            tempColor.a = tempColor.a - .05f;
            obj.GetComponent<Image>().color = tempColor;
            yield return new WaitForSeconds(.03f);
        }
        Destroy(obj);
    }

    /// <summary>
    /// Bu fonksiyon loose secreeni acar. 
    /// </summary>
    public void ActivateLooseScreen()
    {
        GamePanel.SetActive(false);
        LoosePanel.SetActive(true);
    }


    /// <summary>
    /// Bu fonksiyon gamescreeni acar.
    /// </summary>
    public void ActivateGameScreen()
    {
        GamePanel.SetActive(true);
        TapToStartPanel.SetActive(false);
        SetGamePlayScoreText();
    }

    /// <summary>
    /// Bu fonksiyon taptostartscreen i acar.
    /// </summary>
    public void ActivateTapToStartScreen()
    {
        TapToStartPanel.SetActive(true);
        WinPanel.SetActive(false);
        LoosePanel.SetActive(false);
        GamePanel.SetActive(false);
        tapToStartScoreText.text = PlayerPrefs.GetInt("Money").ToString();
    }



}
