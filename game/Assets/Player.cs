using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

            Rigidbody2D playerRigidbody2D;

            [Header("目前的水平速度")]
            public float speedX;

            [Header("目前的水平方向")]
            public float horizontalDirection;// 數值在 -1~1之間, 負:向左 正:向右

            const string HORIZONTAL = "Horizontal";

            [Header("水平推力")]
            [Range(0, 150)]
            public float xForce;

            //目前垂直速度
            float speedY;

            [Header("最大水平速度")]
            public float maxSpeedX;

            public void ControlSpeed()
            {
                        speedX = playerRigidbody2D.velocity.x;
                        speedY = playerRigidbody2D.velocity.y;
                        float newSpeedX = Mathf.Clamp(speedX, -maxSpeedX, maxSpeedX);  //鎖定變數最大最小值
                        playerRigidbody2D.velocity = new Vector2(newSpeedX, speedY);
             }


            [Header("垂直向上推力")]
            public float yForce;

            public bool JumpKey
            {
                        get{
                                    return Input.GetKeyDown(KeyCode.Space);
                        }
            }

            void TryJump()
            {
                        if (IsGround && JumpKey)
                        {
                                    playerRigidbody2D.AddForce(Vector2.up * yForce);    //Vector2.up:往上給個推力
                        }
            }

            [Header("感應地板的距離")]
            [Range(0, 1)]
            public float distance;

            [Header("偵測地板的射線起點")]
            public Transform groundcheck;

            [Header("地面圖層")]
            public LayerMask groundLayer;

            public bool grounded;
            //在玩家的底部設一條很短的射線 如果射線有打到地板圖層的話 代表正踩著地板
            bool IsGround
            {
                        get {
                                    Vector2 start = groundcheck.position;
                                    Vector2 end = new Vector2(start.x, start.y - distance);
                                    Debug.DrawLine(start, end, Color.red);
                                    grounded = Physics2D.Linecast(start, end, groundLayer);//起點到終點如果有打到地面圖層的話
                                    return grounded;



                        }
            }

            void Start () 
            {
                        playerRigidbody2D = GetComponent<Rigidbody2D>();
		
	        }


            /// <summary> 水平移動    /// </summary>
            void MovementX()
            {
                        horizontalDirection = Input.GetAxis(HORIZONTAL);

                        playerRigidbody2D.AddForce(new Vector2(xForce * horizontalDirection, 0));
            }
	
	        // Update is called once per frame
	        void Update () 
            {
                        MovementX();//控制水平移動
                        ControlSpeed();//控制最大速度
                        TryJump();//控制跳躍

                        //speedX = playerRigidbody2D.velocity.x;//儀錶板
            }
}
