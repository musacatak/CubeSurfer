using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MoreMountains.NiceVibrations;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [Header("General Variables")]
    public bool isGameStarted = false;
    public bool isGameFinished = false;
    public bool isGameSucces = false;
    public int gemAmount = 0;
    public int collectedGemAmount = 0;
    public int multiplier = 1;
    

    [Header("References")]
    public Camera mainCamera;
    public MovementController move;
    public Inventory inventory;
    private void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (!isGameStarted && Input.GetMouseButtonDown(0))
        {
            isGameStarted = true;
            TriggerGameStarted();
        }

    }

    void TriggerGameStarted()
    {
        MovementController._instance.GameStarted();
        UIManager._instance.TriggerCloseTutorialBar();

    } 

    public void TriggerLevelFinish()
    {
        isGameFinished = true;
        if (isGameSucces)
        {
            TriggerLevelEndGemCalculation();
        }
        else
        {
            UIManager._instance.TriggerLevelFailed();
        }

    }

    public void TriggerLevelSuccessed(int _multiplier)
    {
        if(_multiplier > 10)
        {
            multiplier = 20;
        }
        else
        {
            multiplier = _multiplier;
        }
        
        isGameSucces = true;
    }

    public void TriggerLevelEndGemCalculation()
    {
        int gemSum = collectedGemAmount * multiplier;
        gemAmount += gemSum;
        UIManager._instance.IncreaseGemAmountText(gemSum);
        UIManager._instance.TriggerLevelEndCanvas(collectedGemAmount, multiplier, gemSum);

    }

    public void TryAgainButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void NextLevelButtonPressed()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex)%3 + 1);
    }

    public void QuitButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void BackToMainMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

} 
