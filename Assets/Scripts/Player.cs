using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody>();
    }

    float tempTime = 0;
    float scoreTime = 0.5f;
    int aliveScore = 10;

    // Update is called once per frame
    public override void Update()
    {
        //플레이어가 살아있을 때 0.5초당 10점씩 증가
        tempTime += Time.deltaTime;
        if (tempTime >= scoreTime)
        {
            ScoreManager.Instance.SetAliveScore(aliveScore);
            tempTime = 0;
        }

        if (isMounting)
        {
            // 탑승상태가 되면 조작 무효
            // 탑승상태일 때 leftCtrl 누르면 
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                // 탑승 플래그 끄고
                isMounting = false;

                // 부모 해제
                gameObject.transform.parent = null;

                //콜라이더 다 키고 
                //CollidersEnable(true);

                StartCoroutine(WaitAndFlagSwitch(!isMounting));
                gameObject.GetComponent<Rigidbody>().isKinematic = false;

                //점프 함
                rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

            }

        }
        else // 아니면 조작받아 이동
        {
            base.Update();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCounting = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isMounting)
        {
        }
        else
        {
            if (other.gameObject.CompareTag("Mount"))//생성된 동물이면
            {
                isMounting = true;
                ScoreManager.Instance.AddCount();   // 마운트 횟수 증가

                CollidersOnOff(!isMounting);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
    

    IEnumerator WaitAndFlagSwitch(bool flag)
    {
        yield return new WaitForSeconds(0.3f);
        CollidersOnOff(flag);
    }

    void CollidersOnOff(bool flag)
    {
        Collider[] coll = gameObject.GetComponents<Collider>();
        for (int i = 0; i < coll.Length; i++)
        {
            coll[i].enabled = flag;
        }
    }

}
