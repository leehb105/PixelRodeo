using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mount : Character
{
    /* 플레이어와 결합하지 않았을 때
     * 뛰는 모션
     * 좌우 이동 (장애물 피하기)
     * 뒤로 느린 이동
     * 
     * 플레이어와 결합한 경우
     * 뛰는 모션
     * 좌우 이동
     * 점프 (플레이어 position 을 따라움직임)
     * 플레이어에 자녀화 되서 뒤로 이동하지 않음
     * 
     */

    float rMoveTime = 0;
    float tempTime = 0;
    float hDir = 1.0f;
    // 이 마운트를 탔을때 기본 점수
    int myScore = 50;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        jumpPower = 7.0f;
        //maxJump = 2;
        rigid = GetComponent<Rigidbody>();
        rMoveTime = Random.Range(1.0f, 2.5f);
        hDir = Random.Range(-1.0f, 1.0f);
    }

    // Update is called once per frame
    public override void Update()
    {
        if (isMounting)
        {
            // 탑승상태일 때 leftCtrl 누르면 
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                // 탑승 플래그 끄고
                isMounting = false;
                // 플레이어 위치 원위치

            }
            base.Update();
        }
        else
        {
            // 플레이어가 탑승하지 않았을 시
            // 1. 좌우 랜덤 이동
            // 2. 느린 속도로 뒤로 이동
            if (tempTime > rMoveTime)
            {
                hDir = -hDir;
                rMoveTime = Random.Range(1.0f, 2.5f);
                tempTime = 0;
            }

            Vector3 dir = Vector3.right * hDir + Vector3.back;



            dir.Normalize();

            // 3. 그 방향으로 이동
            transform.position = transform.position + dir * (moveSpeed) * Time.deltaTime;

            tempTime += Time.deltaTime;
        }
    }

    int killScore = 200;
    // 
    public override void DeathSignal(GameObject killer)
    {
        print("mount's deathSignal");
        if(isMounting == false)
        {
            if(killer.tag.Contains("Mount"))
            {
                // 야생동물이 죽을때
                DeathMySelf();
                ScoreManager.Instance.SetKillScore(killScore);
                SFXPlayer.Instance.MountDieSound();
            }
        }
        else
        {
            DeathMySelf();
            GameManager.Instance.imageRestart.SetActive(true);
            GameManager.Instance.imageMenu.SetActive(true);
            MusicPlayer.Instance.StopMusic();
            SFXPlayer.Instance.PlayerDieSound();
        }

    }
    //플에이어가 올라탄 상태에서 다른 마운트를 박으면 다른 마운트는 죽는다(마운트 태그사용)
    private void OnCollisionEnter(Collision other)
    {   // 탄 상태면
        if(isMounting)
        {
            // 상대가 Mount면
            if (other.gameObject.CompareTag("Mount"))
            {
                other.gameObject.transform.GetComponent<Character>().DeathSignal(gameObject);
                //Destroy(other.gameObject);
                
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.transform.GetComponent<Character>().DeathSignal(gameObject);
            }
        }
        
    }
    //플레이어가 마운트를 탄 상태에서 닿았는데 그게 땅이면 점프초기화 한다.(무한점프 방지)
    //태우지 않은 상태에서 플레이어와 닿으면 내가 플레이어의 부모가 된다 그리고 위에 플레이어를 내 위에 올린
    //그리고 점수를 올려준다
    float targetFOV = 60;
    private void OnTriggerEnter(Collider other)
    {
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetFOV, Time.deltaTime * 20);
        if (isMounting) // 탄 상태면
        {
            if (other.gameObject.CompareTag("Ground")) // 탄 상태인데 충돌상대가 땅이면
            {
                jumpCounting = 0;       // 점프 초기화
            }
           
        }
        else//안탄 상태면
        {
            if (other.gameObject.CompareTag("Player"))  //안 탔는데 충돌상대가 플레이어면
            {
                other.transform.parent = transform;     // 플레이어의 부모를 나로
                //isMounting = true;
                //SetIsMount(true);
                isMounting = true;                      // flag true
                //other.transform.localPosition = Vector3.up; // player의 로컬포지션을 한칸 위로 수정전!!!!!
                other.transform.localPosition = new Vector3(0, 0.7f, 0); ; // player의 로컬포지션을 한칸 위로
                /*targetFOV = 40;
                Camera.main.fieldOfView = 40;*/
                // 마운트에서 탑승시 ScoreManager.Instance.SetScore(myScore);
                ScoreManager.Instance.SetComboScore(myScore);
                //
            }
        }
        //targetFOV = 60;
    }

}
