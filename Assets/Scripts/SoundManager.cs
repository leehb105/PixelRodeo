﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        instance = this;
    }
    public AudioClip bgm;
    public AudioClip btnOn;
    public AudioClip btnClick;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;//실행시 bgm실행
        audioSource.Play();

    }
    public void BtnClickSound()
    {
        audioSource.PlayOneShot(btnClick);
    }
    public void BtnOnSound()
    {
        audioSource.PlayOneShot(btnOn);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
