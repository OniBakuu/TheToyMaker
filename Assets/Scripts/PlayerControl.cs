using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerControl : MonoBehaviour
{

    [Header("Movement Settings")] 
    public float speed;
    public float movementSmoothing = 0.05f;
    //Player's current direction is stored as a vector updated with horizontal and vertical
    private Vector2 direction { get; set; }
    //Reference to gameObj's rigidbody to set its velocity for movement
    private Rigidbody2D rb;
    //m_velocity is the current velocity to pass into smoothdamp starts at 0 and should be updated
    private Vector2 m_velocity = Vector2.zero;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
    }

    void FixedUpdate()
    {
        MoveRigidbody(direction, speed, movementSmoothing);
    }

    private void MoveRigidbody(Vector2 direction, float speed, float movementSmoothing)
    {
        //Target velocity
        Vector2 target = new Vector2(speed * 10 * direction.x * Time.fixedDeltaTime, speed * 10 * direction.y * Time.fixedDeltaTime);
        //Set the velocity with smoothdamp
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target, ref m_velocity, movementSmoothing);
    }
}
