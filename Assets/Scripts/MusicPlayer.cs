using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임이 시작되면 음악을 켜고 게임오버가 되면 음악을 끄고 싶다
//게임을 재식작하면 음악을 다시 켜고 싶다
public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance;

    private void Awake()
    {
        Instance = this;
    }
    AudioSource audioSource;
    public AudioClip bgm;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.volume = 0.4f;
        audioSource.Play();
        //audioSource.Stop();
        audioSource.playOnAwake = true;
        audioSource.loop = true;

    }
    
    public void StopMusic()
    {
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
