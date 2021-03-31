using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // 재시작

    public static GameManager Instance;
    bool isPause = false;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject imageRestart;
    public GameObject imageMenu;
    public GameObject imageContinue;
    
    // Start is called before the first frame update
    void Start()
    {
        imageRestart.SetActive(false);
        imageMenu.SetActive(false);
        imageContinue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = true;
            if (isPause)//일시정지
            {
                Time.timeScale = 0;
                isPause = false;
                imageRestart.SetActive(true);
                imageMenu.SetActive(true);
                imageContinue.SetActive(true);
            }
            /*else
            {
                Time.timeScale = 1;
                isPause = true;
                imageRestart.SetActive(false);
                imageMenu.SetActive(false);
            }*/
            
        }
    }
    public void OnClickMenu()
    {
        SoundManager.instance.BtnClickSound();
        SceneManager.LoadScene(0);//메인으로 씬전환
    }
    public void OnClickRestart()
    {
        //현재 씬을 다시 로드하고 싶다
        SoundManager.instance.BtnClickSound();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//현재 씬 재시작
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClickContinue()
    {
        Time.timeScale = 1;
        isPause = false;
        imageRestart.SetActive(false);
        imageMenu.SetActive(false);
        imageContinue.SetActive(false);
    }
}
