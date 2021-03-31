using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnDescript : MonoBehaviour
{
    public GameObject gameDescript;
    // Start is called before the first frame update
    void Start()
    {
        gameDescript.SetActive(false);
    }

    public void MouseOnEvent()
    {
        gameDescript.SetActive(true);
        SoundManager.instance.BtnOnSound();
    }
    public void MounseExitEvent()
    {
        gameDescript.SetActive(false);
    }
}
