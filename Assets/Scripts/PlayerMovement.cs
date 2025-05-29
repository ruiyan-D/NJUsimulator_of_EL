using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("移动速度")]
    public float moveSpeed = 5f;

    // 内部引用
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    void Awake()
    {
        // 获取 Rigidbody2D 组件（RequireComponent 确保存在）
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. 读取玩家输入（水平：A/D 或 ←/→，垂直：W/S 或 ↑/↓）
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // 2. 组合成一个方向向量
        moveInput = new Vector2(moveX, moveY).normalized;

        // 3. 计算实际速度向量
        moveVelocity = moveInput * moveSpeed;
    }

    void FixedUpdate()
    {
        // 4. 在 FixedUpdate 中以物理方式移动角色
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
