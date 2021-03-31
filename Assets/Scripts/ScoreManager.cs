using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public Text scoreText;
    private int totalScore = 0;
    public Text bestScoreText;
    public Text bestScoreRecordText;
    private int bestScore;
    public Text itemScoreText;
    public Text comboText;
    public Text comboScoreText;
    int mountCount = 0;

    bool onceCheckNewRecord = true;
    // 점수 획득, 표시
    // 아이템 획득시 점수획득
    // 탑승 시 점수획득 (가산점 적용)
    // 플레이어가 탑승할때마다 카운트 1씩 증가
    // ScoreManager.Instance.AddCount(); 
    // 마운트에서 탑승시 ScoreManager.Instance.SetScore(myScore);
    // SetScore에서 totalScore = _count * myScore;

    // 최대 점수 표시 , 저장


    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        scoreText.text = "SCORE : " + totalScore;
        // 하이스코어 읽기
        HIGHSCORE = PlayerPrefs.GetInt("bestScore");
        itemScoreText.text = "";
        comboScoreText.text = "";
        bestScoreRecordText.text = "";

    }
    
    private void Update()
    {

        if (totalScore > bestScore)
        {
            HIGHSCORE = totalScore;
            if (onceCheckNewRecord)
            {
                onceCheckNewRecord = false;
                bestScoreRecordText.text = "NEW RECORD!!";
                StartCoroutine(WaitBestScoreTextOff());
            }

        }

    }

    public void AddCount()
    {
        mountCount++;
        comboText.text = "HIT : " + mountCount;
    }

    void CalcScore(int value)
    {
        totalScore += value * mountCount;
    }

    public int HIGHSCORE
    {
        get
        {
            return bestScore;
        }
        set
        {
            bestScore = value;
            bestScoreText.text = "HIGH SCORE : " + bestScore;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
    }

    public void SetComboScore(int value)
    {
        comboScoreText.text = "+ 1";//갈아탈 시 +1 텍스트 노출
        totalScore += value * mountCount;
        scoreText.text = "SCORE : " + totalScore;


        StartCoroutine(WaitComboScoreTextOff());
    }

    public void SetAliveScore(int value)
    {
        totalScore += value;
        scoreText.text = "SCORE : " + totalScore;


    }
    IEnumerator WaitItemScoreTextOff()
    {
        yield return new WaitForSeconds(0.4f);
        itemScoreText.text = "";
    }
    IEnumerator WaitComboScoreTextOff()
    {
        yield return new WaitForSeconds(0.6f);
        comboScoreText.text = "";
    }
    IEnumerator WaitBestScoreTextOff()
    {
        yield return new WaitForSeconds(2.0f);
        bestScoreRecordText.text = "";
    }
    public void SetItemScore(int value)
    {
        itemScoreText.text = "+" + value.ToString();//아이템 획득 시 +10 텍스트 노출
        totalScore += value;
        scoreText.text = "SCORE : " + totalScore;


         StartCoroutine(WaitItemScoreTextOff());
    }

    public void SetKillScore(int value)
    {
        itemScoreText.text = "+" + value.ToString();//아이템 획득 시 +10 텍스트 노출
        totalScore += value;
        scoreText.text = "SCORE : " + totalScore;

        StartCoroutine(WaitItemScoreTextOff());
    }
}
