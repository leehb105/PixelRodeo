using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//벽과 바닥을 계속해서 뒤로 움직이게 하고 싶다.
//-벽과 바닥
public class MoveManager : MonoBehaviour
{
    public GameObject floorFactory;
    public GameObject lWallFactory;
    public GameObject rWallFactory;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        /*GameObject floor = Instantiate(floorFactory);
        GameObject lWall = Instantiate(lWallFactory);
        GameObject rWall = Instantiate(rWallFactory);

        floor.transform.position = transform.position;
        lWall.transform.position = transform.position;
        rWall.transform.position = transform.position;*/
    }

    // Update is called once per frame
    void Update()
    {
        //일정속도로 바닥,벽들을 뒤쪽으로 움직인다
    /*    floorFactory.transform.position += Vector3.back * speed * Time.deltaTime;
        lWallFactory.transform.position += Vector3.back * speed * Time.deltaTime;
        rWallFactory.transform.position += Vector3.back * speed * Time.deltaTime;*/

        GameObject floor = Instantiate(floorFactory);
        GameObject lWall = Instantiate(lWallFactory); 
        GameObject rWall = Instantiate(rWallFactory);

        floor.transform.position += Vector3.back * speed * Time.deltaTime;
        lWall.transform.position += Vector3.back * speed * Time.deltaTime;
        rWall.transform.position += Vector3.back * speed * Time.deltaTime;
    }
}
