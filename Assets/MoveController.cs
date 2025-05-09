using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rBody;
    [SerializeField] public bool moveable = true;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveable)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (horizontal != 0 || vertical != 0)
            {
                ani.speed = 2f; // 移动时加快动画
            }
            else
            {
                ani.speed = 1.0f; // 停止时恢复正常速度
            }

            if (horizontal != 0)
            {
                ani.SetFloat("Horizontal", horizontal);
                ani.SetFloat("Vertical", 0);
            }

            if (vertical != 0)
            {
                ani.SetFloat("Horizontal", 0);
                ani.SetFloat("Vertical", vertical);
            }

            Vector2 move = new(horizontal, vertical);
            if (move.magnitude > 1)
            {
                move.Normalize();
            }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                ani.SetFloat("Speed", move.magnitude);
                rBody.velocity = move * 4.0f;
                ani.speed = 3f;
            }
            else
            {
                ani.SetFloat("Speed", move.magnitude);
                rBody.velocity = move * 2.0f;
            }
        }
        else
        {
            ani.SetFloat("Speed", 0);
            rBody.velocity = Vector2.zero;
        }
    }
}
