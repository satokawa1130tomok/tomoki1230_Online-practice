using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigid2D;

    Animator  animator;

    //ジャンプする力
    float jumpForce = 655.0f;

    //歩く力
    float walkForce = 30.0f;

    //歩くスピードの最大値
    float maxWalkSpeed = 2.0f;

    float threhold = 0.2f;

    public GameObject player;

    PhotonView myPhtonView;

    public bool jumpFlg;

    //Animator animator;


    void Start()
    {
        //Rigidbody2D取得する
        this.rigid2D = GetComponent<Rigidbody2D>();

        this.animator = GetComponent<Animator>();

        this.myPhtonView = GetComponent<PhotonView>();

        this.jumpFlg = false;


    }

    void Update()
    {
        if(this.myPhtonView.IsMine)
        {
            // ジャンプする
            if (Input.GetMouseButton(0) && this.rigid2D.velocity.y == 0)

            {
                this.rigid2D.AddForce(transform.up * this.jumpForce);
            }
            
            if (transform.position.y < -10)
            {
                SceneManager.LoadScene("GameScene");

            }
            if (Input.GetKey(KeyCode.UpArrow) && this.rigid2D.velocity.y == 0)

            {
                this.rigid2D.AddForce(transform.up * this.jumpForce);
            }


            //if (Input.GetKey(KeyCode.Space)&& this.rigid2D.velocity.y == 0)
            // {
            //     this.animator.SetTrigger("JumpTrigger");
            //     this.rigid2D.AddForce(transform.up * this.jumpForce);
            // }



            if (Input.GetKeyDown(KeyCode.Space) ) //this.rigid2D.velocity.y == 0)
            {
                this.jumpFlg = true;

                this.animator.SetBool ("jump Bool",true);

                this.rigid2D.AddForce(transform.up * this.jumpForce);
                //Debug.Log("a");

                
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {

                this.animator.SetBool ( "jump Bool", false);
                //Debug.Log("!");
            }



                // 左右移動
                int key = 0;

            if (Input.acceleration.x > this.threhold)
            {
                key = 1;
            }


            if (Input.acceleration.x < -this.threhold)
            {
                key = -1;
            }

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
                //  -   ×    +   =  -       + o  ×   +   =   +
                this.rigid2D.AddForce(transform.right * key * this.walkForce);
            }

            //動く方向に応じて反転
            if (key != 0)
            {
                //catのtransformのScaleのxに-がつくかつかないか
                transform.localScale = new Vector3(key, 1, 1);
            }



            //this.animator.speed = speedx / 2.0f;

            //if(player.y< -10)
            //{
            //    Debug.Log("dfdsd");
            //}
        }
    }
      
        

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "go-ru")
        {

            SceneManager.LoadScene("ClearScene");
        }
    }


    //void DelayMethod()
    //{
    //    this.animator.SetBool("jump Bool", false);
    //}





}