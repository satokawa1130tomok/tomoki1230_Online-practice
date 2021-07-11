using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigid2D;

    Animator animator;

    //ジャンプする力
    float jumpForce = 655.0f;

    //歩く力
    float walkForce = 30.0f;

    //歩くスピードの最大値
    float maxWalkSpeed = 2.0f;
    

    void Start()
    {
        //Rigidbody2D取得する
        this.rigid2D = GetComponent<Rigidbody2D>();

        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ジャンプする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //↑×ジャンプする力
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            
        }                                                                     



        // 左右移動
        int key = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }

        //                      　-5      0      5  ⇦この絶対値は5     
        // プレイヤの速度  絶対値　 ーーーーーーーーーーーー
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            //(Key)   （歩く力）　      (Key)  (歩く力)
            //  -   ×    +   =  -       +   ×   +   =   +
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //動く方向に応じて反転
        if (key != 0)
        {
            //catのtransformのScaleのxに-がつくかつかないか
            transform.localScale= new Vector3(key, 1, 1);
        }



        this.animator.speed = speedx / 2.0f;
    }

}