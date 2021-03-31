using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountSpawner : MonoBehaviour
{
    // 마운트 캐릭터를 일정한 랜덤 시간마다 생성

    public GameObject[] mountFactory;

    // Start is called before the first frame update
    void Start()
    {

    }

    float tempTime = 0f;
    public float respawnTime = 1.0f;
    int rndIndex;
    // Update is called once per frame
    void Update()
    {
        if (tempTime > respawnTime)
        {
            rndIndex = Random.Range(0, mountFactory.Length);

            GameObject mount = Instantiate(mountFactory[rndIndex]);
            mount.transform.position = transform.position;

            tempTime = 0;
        }

        tempTime += Time.deltaTime;
    }
}