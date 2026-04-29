using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintMultiplier = 2F;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {
        rb = GetComponent<Rigidbody2D>();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        IsShooting();
        
    }

    void FixedUpdate()
    {
        Move();
    }
void MovementInput()
{
    float moveX = Input.GetAxisRaw("Horizontal"); //A/D
    float moveY = Input.GetAxisRaw("Vertical"); //W/S

    movement = new Vector2(moveX, moveY).normalized;

}

void Move()
{
   float speed = moveSpeed;

   if (Input.GetKey(KeyCode.LeftShift))

{
    speed *= sprintMultiplier;
}
rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
}

void IsShooting()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Shoot();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ResetPlayer();
        }
    }

void ResetPlayer()
{
    Debug.Log("Player died!");
    GameManager.instance.ResetGame();
}
}
}