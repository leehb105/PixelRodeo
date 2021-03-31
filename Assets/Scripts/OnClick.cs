using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    public GameObject soundManager;
    public void OnClickStartGame()//게임시작 시 씬 전환
    {
        SceneManager.LoadScene(1);
        SoundManager.instance.audioSource.Stop();
        SoundManager.instance.BtnClickSound();
        Time.timeScale = 1;
        DontDestroyOnLoad(soundManager);
    }
    public void OnClickEndGame()//게임종료시 프로그램 종료
    {
        SoundManager.instance.BtnClickSound();
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


}
