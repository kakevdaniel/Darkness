using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public GameObject bullet;

    private Rigidbody2D myBody;
    private Animator legAnim;

    public float speed;

    [SerializeField]
    private int health;

    

    private Vector2 moveVelocity;

    private bool hit = true;

    public HealthBar healthBar;
    
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        legAnim = transform.GetChild(1).GetComponent<Animator>();
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
        Rotation();
        //lövés
        if (Input.GetMouseButtonDown(0))
        Instantiate(bullet, transform.position, transform.rotation); 
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
        //myBody.MovePosition(myBody.position + moveVelocity * Time.fixedDeltaTime);
        myBody.MovePosition(new Vector2((transform.position.x + moveInput.x * speed * Time.deltaTime), transform.position.y + moveInput.y * speed * Time.deltaTime));

        if (moveVelocity == Vector2.zero)
        {
            legAnim.SetBool("Moving", false);
        }else
        {
            legAnim.SetBool("Moving", true);
        }
    }

    IEnumerator HitBoxOff()
    {
        hit = false;
        yield return new WaitForSeconds(1.0f);
        hit = true;
    }

    void OnTriggerEnter2D(Collider2D target) 
    {
        if (target.tag == "Enemy")
        {
            if (hit)
            {
                StartCoroutine(HitBoxOff());
                health--;

                healthBar.SetHealth(health);
            }
            
        }
    }
    
}
