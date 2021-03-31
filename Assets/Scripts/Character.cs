using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected float moveSpeed = 10.0f;
    protected float jumpPower = 6.0f;

    protected int jumpCounting = 0;
    protected int maxJump = 1;

    protected bool isMounting = false;

    protected Rigidbody rigid;

    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    // 1. base - 입력 좌우 이동
    protected virtual void Move()
    {
        float h = Input.GetAxis("Horizontal");

        Vector3 dir = Vector3.right * h;

        dir.Normalize();

        transform.position = transform.position + dir * moveSpeed * Time.deltaTime;

    }   

    public virtual void DeathSignal(GameObject killer)
    {
        // 오버라이딩
        print("character's deathSignal that name is " + killer.name);
        DeathMySelf();
        GameManager.Instance.imageRestart.SetActive(true);
        GameManager.Instance.imageMenu.SetActive(true);
        MusicPlayer.Instance.StopMusic();
        SFXPlayer.Instance.PlayerDieSound();
    }

    protected void DeathMySelf()
    {
        print("데스스그널 받아서 자살");
        Destroy(gameObject);
        
    }

    // 1. base - Ground 판정 점프
    protected virtual void Jump()
    {
        if (jumpCounting < maxJump)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jumpCounting++;
            SFXPlayer.Instance.JumpSound();
        }

    }
    
    public bool GetIsMount()
    {
        return isMounting;
    }
    
}
