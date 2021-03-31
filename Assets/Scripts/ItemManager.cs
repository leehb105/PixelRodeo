using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//허들을 만들어서 랜덤으로 생성하고 싶다
public class ItemManager : MonoBehaviour
{
    
    //허들공장
    public GameObject itemFactory;
    //랜덤시간
    float rndTime = 0.5f;
    //현재시간
    float curTime;
    //랜덤배열
    public Transform[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime > rndTime)
        {
            GameObject item = Instantiate(itemFactory);
            //0부터 배열의 크기까지 그 중 하나 랜덤 생성
            int rVal = Random.Range(0, spawns.Length);
            Vector3 pos = spawns[rVal].position;
            //print("Nomal"+spawns[rVal]);
            item.transform.position = pos;
            curTime = 0;
        }
        
    }
}
