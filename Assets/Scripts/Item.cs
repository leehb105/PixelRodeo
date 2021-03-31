using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어가 나에게 닿으면 게임오버 하고 싶다.
public class Item : MonoBehaviour
{
    bool check;
    //장애물속도
    float hurdleSpeed = 20;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        //뒤의 방향으로 이동한다
        dir = Vector3.back;
              

    }

    // Update is called once per frame
    void Update()
    {
        //살아가면서 계속해서 이동한다
        transform.position += dir * hurdleSpeed * Time.deltaTime;
    }

    int itemScore = 100;
    private void OnTriggerEnter(Collider other) 
    {
        if(!other.gameObject.name.Contains("DestroyZone"))
        {
            check = other.gameObject.GetComponent<Character>().GetIsMount();
            if (check == true)
            {

                print("플레이어를 태운 마운트가 아이템을 먹음");
                ScoreManager.Instance.SetItemScore(itemScore);


                Destroy(gameObject);
                
            }
            else if (other.gameObject.CompareTag("Player"))
            {
                print("플레이어가 아이템을 먹음");
                ScoreManager.Instance.SetItemScore(itemScore);
                Destroy(gameObject);
            }
            SFXPlayer.Instance.CoinSound();
        }
    }
}
