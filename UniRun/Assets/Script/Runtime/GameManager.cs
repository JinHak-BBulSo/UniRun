using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;
    private const string UI_OBJS = "UiObjs";
    private const string SCORE_TEXT_OBJ = "ScoreText";
    private const string GAME_OVER_UI = "GameOverUI";

    public bool isGameOver = false;
    private GameObject scoreTxtObj = default;
    private GameObject gameOverUi = default;
    private int score = default;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // Init
            isGameOver = false;
            GameObject uiObjs_ = GFunc.GetRootObj(UI_OBJS);
            scoreTxtObj = uiObjs_.FindChildObj(SCORE_TEXT_OBJ);
            gameOverUi = uiObjs_.FindChildObj(GAME_OVER_UI);
            score = 0;
        } // 게임 매니저가 존재하지 않을 시 할당 및 초기화
        else
        {
            GFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다.");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver && Input.GetMouseButtonDown(0))
        {
            GFunc.LoadScene(GFunc.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        if (!isGameOver)
        {
            score += newScore;
            scoreTxtObj.SetTmpText($"Score : {score}");
        }
    }
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }
}
