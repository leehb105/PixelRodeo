using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//효과음 플레이어
public class SFXPlayer : MonoBehaviour
{
    AudioSource coinASource;
    AudioSource jumpASource;
    AudioSource mountDieASource;
    AudioSource playerDieASource;
    public AudioClip coinClip;
    public AudioClip jumpClip;
    public AudioClip mountDieClip;
    public AudioClip playerDieClip;

    public static SFXPlayer Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void CoinSound()
    {
        coinASource.clip = coinClip;
        coinASource.loop = false;
        coinASource.Stop();
        coinASource.Play();

    }
    public void JumpSound()
    {
        jumpASource.clip = jumpClip;
        jumpASource.loop = false;
        jumpASource.Stop();
        jumpASource.Play();

    }
    public void MountDieSound()
    {
        mountDieASource.clip = mountDieClip;
        mountDieASource.loop = false;
        mountDieASource.Stop();
        mountDieASource.Play();

    }
    public void PlayerDieSound()
    {
        playerDieASource.clip = mountDieClip;
        playerDieASource.loop = false;
        playerDieASource.Stop();
        playerDieASource.Play();

    }
    // Start is called before the first frame update
    void Start()
    {
        coinASource = GetComponent<AudioSource>();
        jumpASource = GetComponent<AudioSource>();
        mountDieASource = GetComponent<AudioSource>();
        playerDieASource = GetComponent<AudioSource>();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
