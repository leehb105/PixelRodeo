using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어가 나에게 닿으면 게임오버 하고 싶다.
public class Hurdle : MonoBehaviour
{
    bool check;
    //장애물속도
    float hurdleSpeed = 20;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        //태어나면 뒤의 방향으로 이동한다
        dir = Vector3.back;
    }

    // Update is called once per frame
    void Update()
    {
        //살아가면서 계속해서 이동한다
        transform.position += dir * hurdleSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        print("뭔가가 장애물에 닿아서 죽음신호를 보냄");
        other.gameObject.transform.GetComponent<Character>().DeathSignal(gameObject);
    }
}
