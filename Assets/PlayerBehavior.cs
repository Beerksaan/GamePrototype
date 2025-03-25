using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Movement")]
    public float moveSpeed = 5f;
    float horizontalMovement;

    [Header("Jumping")]
    public float jumpPower = 10f;

    [Header("GroundCheck")]
    public Transform GroundCheckPos;
    public Vector2 GroundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask GroundLayer;

    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    } 
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);    
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(GroundCheckPos.position, GroundCheckSize);

    }
}
