using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//길을 주기적으로 생성해서 가장 최근에 만들어진 길의 앞쪽에 가져다 놓고 싶다
//만들어진 길은 로드매니저의 자식으로 붙여주고 싶다
public class WallManager : MonoBehaviour
{
    public GameObject leftWallFactory;
    public GameObject rightWallFactory;
    public Transform leftLatestWall;
    public Transform rightLatestRoad;
    float speed = 20f;
    float currentTime = 0.9f;
    float creatTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //일정시간이 지나면 벽을 새로 생성
        currentTime += Time.deltaTime;
        if(currentTime > creatTime) {
            GameObject leftWall = Instantiate(leftWallFactory);//Prefab 왼쪽 벽
            GameObject rightWall = Instantiate(rightWallFactory);//Prefab 오른쪽 벽
            
            leftWall.transform.parent = transform;//만들어진 벽을 벽의 자식으로 이동
            rightWall.transform.parent = transform;

            //벽 오브젝트의 끝에 동일한 오브젝트를 이어 붙임
            leftWall.transform.position = leftLatestWall.transform.position + Vector3.forward * leftLatestWall.transform.localScale.z;
            leftLatestWall = leftWall.transform;
            rightWall.transform.position = rightLatestRoad.transform.position + Vector3.forward * rightLatestRoad.transform.localScale.z;
            rightLatestRoad = rightWall.transform;
            currentTime = 0;
        }
        transform.position += Vector3.back * speed * Time.deltaTime;

       
    }
    

}
