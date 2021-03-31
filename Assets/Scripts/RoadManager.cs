using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//길을 주기적으로 생성해서 가장 최근에 만들어진 길의 앞쪽에 가져다 놓고 싶다
//만들어진 길은 로드매니저의 자식으로 붙여주고 싶다
//로드매니저 자신이 직접 플레이어 쪽으로 이동하고 싶다
public class RoadManager : MonoBehaviour
{
    public GameObject roadFactory;
    public Transform latestRoad;
    float speed = 20f;
    float currentTime = 0.9f;
    float creatTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        /*GameObject road = Instantiate(roadFactory);
        road.transform.position = transform.position;//매니저의 위치에 길을 생성한다
        transform.position = new Vector3(0, 0, road.transform.position.z);*/
        //latestRoad = road.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //일정시간이 지나면 길을 새로 생성한다
        currentTime += Time.deltaTime;
        if(currentTime > creatTime) {
            GameObject road = Instantiate(roadFactory);
            //만들어진 길을 로드매니저의 자식으로 붙이고 싶다
            //나 로드의 부모 = 너 로드매니저
            road.transform.parent = transform;//자식으로 붙여준다

            //가장 최근에 만들어진 길의 앞쪽에 가져다 놓고 싶다.            
            road.transform.position = latestRoad.transform.position + Vector3.forward * latestRoad.transform.localScale.z;
            //road.transform.position = latestRoad.transform.position + new Vector3(0, 0, 45.0000f);
            latestRoad = road.transform;
            currentTime = 0;
        }
        //도로는 일정 속도로 뒤로 이동한다
        transform.position += Vector3.back * speed * Time.deltaTime;
    }
}
