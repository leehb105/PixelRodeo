using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class MouseOn : MonoBehaviour
{
    Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = gameObject.transform.localScale;
        
    }
    public void MouseOnEvent()
    {
        transform.localScale = transform.localScale * 1.1f;
        SoundManager.instance.BtnOnSound();
    }
    public void MounseExitEvent()
    {
        transform.localScale = origin;
    }
    
}
