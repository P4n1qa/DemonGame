using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Tilemap tilemap;
    
    [SerializeField] int moveSpeed;

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;
    void Start()
    {
        MinMaxEdge();
    }

    void Update()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;

        playerAnimator.SetFloat("movementX", rb.velocity.x);
        playerAnimator.SetFloat("movementY", rb.velocity.y);
        if (horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
        {
            playerAnimator.SetFloat("lastX", horizontalMovement);
            playerAnimator.SetFloat("lastY", verticalMovement);
        }
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,bottomLeftEdge.x,topRightEdge.x),
            Mathf.Clamp(transform.position.y,bottomLeftEdge.y,topRightEdge.y),
            Mathf.Clamp(transform.position.z,bottomLeftEdge.z,topRightEdge.z)
            );
    }
    private void MinMaxEdge()
    {
        bottomLeftEdge = tilemap.localBounds.min+new Vector3(0.8f,1f,0f);
        topRightEdge = tilemap.localBounds.max + new Vector3(-0.8f,-1f, 0f); 
    }
}
