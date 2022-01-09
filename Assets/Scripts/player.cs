using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float speed;

    private Vector2 moveVelocity;
    
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Rotation();
    }
    
    void FixedUpdate()
    {
        Movement();
    }

    void Rotation()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 10;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }
    void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        myBody.MovePosition(myBody.position + moveVelocity * Time.fixedDeltaTime);
    }
}
