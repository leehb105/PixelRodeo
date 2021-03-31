using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 오브젝트가 닿으면 죽었다는 신호를 준다
    // 누가 죽음신호를 보냈는지 정보 전달

    private void OnCollisionEnter(Collision other)
    {
        print("뭔가가 벽에 닿아서 죽음 신호를 보냄");
        other.gameObject.transform.GetComponent<Character>().DeathSignal(gameObject);
    }
    
}
