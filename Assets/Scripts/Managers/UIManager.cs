using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    [Header("References")]
    public Transform uiCanvasObject;

    [Header("UI Elements")]
    public GameObject quitButton;
    public GameObject tryAgainButton;
    public GameObject bacToMenuButton;
    public GameObject nextLevelButton;
    public GameObject popUpTextPrefab;
    public GameObject gemImage;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI gemAmountText;
    public Animator gemAreaAnimator;
    public GameObject levelEndCanvas;
    public TextMeshProUGUI gemMultiplierText;
    public TextMeshProUGUI collectedGemAmountText;
    public TextMeshProUGUI collectedGemSumAmountText;
    public GameObject tutorialSliderBarObject;
    
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        InitPrefValues();

    }

    void InitPrefValues()
    {
        if (PlayerPrefs.HasKey("NumberOfGems"))
        {
            gemAmountText.text = PlayerPrefs.GetInt("GemAmount").ToString();
        }

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevelText.text = (PlayerPrefs.GetInt("CurrentLevel") + 1).ToString();
        }
        else
        { 
            currentLevelText.text = SceneManager.GetActiveScene().buildIndex.ToString();
        }
    } 

    public void CreatePopUpText(Transform _transform)
    {
        GameObject tmp = Instantiate(popUpTextPrefab, _transform.position + (Vector3.right * 1.5f), Quaternion.identity, _transform);
        Destroy(tmp, 0.65f);

    } 

    public void IncreaseGemAmountText(int _amount)
    {
        TriggerCoinReachedAnimation();

        int tmp = int.Parse(gemAmountText.text);
        tmp += _amount;
        gemAmountText.text = tmp.ToString();

        PlayerPrefs.SetInt("GemAmount", tmp);

    }

    public void TriggerCoinReachedAnimation()
    {
        gemAreaAnimator.ResetTrigger("Triggered");
        gemAreaAnimator.SetTrigger("Triggered");

    }

    public void TriggerLevelEndCanvas(int _collectedGemAmount, int _multiplier, int _collectedSumGemAmount)
    {
        levelEndCanvas.SetActive(true);
        collectedGemAmountText.text = _collectedGemAmount.ToString();
        collectedGemSumAmountText.text = _collectedSumGemAmount.ToString();
        gemMultiplierText.text = "x" + _multiplier.ToString();
        

    }

    public void TriggerCloseTutorialBar()
    {
        Destroy(tutorialSliderBarObject);

    }

    public void BackToMainMenuButtonPressed()
    {
        GameManager._instance.BackToMainMenuButtonPressed();

    } 

    public void TryAgainButtonPressed()
    {
        GameManager._instance.TryAgainButtonPressed();

    }

    public void NextLevelButtonPressed()
    {
        GameManager._instance.NextLevelButtonPressed();

    }

    public void QuitButtonPressed()
    {
        GameManager._instance.QuitButtonPressed();

    }

    public void TriggerLevelFailed()
    {
        tryAgainButton.SetActive(true);
        bacToMenuButton.SetActive(true);

    }

} 
