using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    public Weapon currWeapon;
    public GameObject bullet;

    private Rigidbody2D myBody;
    private Animator legAnim;
    private Animator bodyAnim;

    public Weapon handgun;
    public Weapon shotgun;
    public Weapon ak;

    public RuntimeAnimatorController handgun1;
    public RuntimeAnimatorController shotgun1;
    public RuntimeAnimatorController ak1;

    public float speed;

    [SerializeField]
    private int health;

    private Vector2 moveVelocity;

    private float nextTimeOfFire = 0;

    private bool hit = true;

    public HealthBar healthBar;

    void callUpdateRounds()
    {
        StartCoroutine(updateRounds());
    }
    void callWeaponDamage()
    {
        StartCoroutine(handgunDamage());
        StartCoroutine(rifleDamage());
        StartCoroutine(shotgunDamage());
    }
    IEnumerator updateRounds()
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", DBmanager.userID);
        form.AddField("round", RoundCounter.roundCounter);
        WWW www = new WWW("http://localhost/darkness/round.php", form);
        yield return www;
    }

    IEnumerator handgunDamage()
    {
        WWWForm form = new WWWForm();
        form.AddField("weaponName", handgun.weaponName);
        WWW www = new WWW("http://localhost/darkness/weapon.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            int weaponDamage = int.Parse(www.text.Split('\t')[1]);
            handgun.damage = weaponDamage;
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }
    IEnumerator rifleDamage()
    {
        WWWForm form = new WWWForm();
        form.AddField("weaponName", ak.weaponName);
        WWW www = new WWW("http://localhost/darkness/weapon.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            int weaponDamage = int.Parse(www.text.Split('\t')[1]);
            ak.damage = weaponDamage;
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }
    IEnumerator shotgunDamage()
    {
        WWWForm form = new WWWForm();
        form.AddField("weaponName", shotgun.weaponName);
        WWW www = new WWW("http://localhost/darkness/weapon.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            int weaponDamage = int.Parse(www.text.Split('\t')[1]);
            shotgun.damage = weaponDamage;
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        callUpdateRounds();
    }
    void Awake()
    {
        callWeaponDamage();
        myBody = GetComponent<Rigidbody2D>();
        legAnim = transform.GetChild(1).GetComponent<Animator>();
        bodyAnim = transform.GetChild(0).GetComponent<Animator>();
        Score.scoreValue = 500;
        healthBar.SetMaxHealth(health);
        speed = 6;
        handgun.fireRate = 3;
        ak.fireRate = 6;
        shotgun.fireRate = 1;
        if (currWeapon == handgun)
        {
            Ammo.ammoValue = 100;
        }
    }

    void Update()
    {
        Rotation();
        if (health <= 0)
        {
            GameOver();
        }
        #region
        //lövés
        /* if (Input.GetMouseButtonDown(0))
            if (!PausedMenu.IsPaused)
            {
                Instantiate(bullet, transform.position, transform.rotation);
            }
            else
            {
                PausedMenu.IsPaused = false;
            }*/
        #endregion


        if (currWeapon == handgun)
        {
            if (Ammo.ammoValue > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    if (!PausedMenu.IsPaused)
                    {
                        if (Time.time >= nextTimeOfFire)
                        {
                            handgun.Shoot();
                            bodyAnim.SetTrigger("Shoot");
                            Ammo.ammoValue -= 1;
                            Sound.PlaySound("handgun");
                            nextTimeOfFire = Time.time + 1 / handgun.fireRate;
                        }
                    }
                    else
                    {
                        PausedMenu.IsPaused = false;
                    }
                }
            }
        }
        if (currWeapon == ak)
        {
            if (Ammo.ammoValue > 0)
            {
                if (Input.GetMouseButton(0))
                {
                    if (!PausedMenu.IsPaused)
                    {
                        if (Time.time >= nextTimeOfFire)
                        {
                            currWeapon.Shoot();
                            bodyAnim.SetTrigger("Shoot");
                            Ammo.ammoValue -= 1;
                            Sound.PlaySound("riffle");
                            nextTimeOfFire = Time.time + 1 / currWeapon.fireRate;
                        }
                    }
                    else
                    {
                        PausedMenu.IsPaused = false;
                    }
                }
            }
        }
        if (currWeapon == shotgun)
        {
            if (Ammo.ammoValue > 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!PausedMenu.IsPaused)
                    {
                        if (Time.time >= nextTimeOfFire)
                        {
                            currWeapon.Shoot();
                            bodyAnim.SetTrigger("Shoot");
                            Ammo.ammoValue -= 1;
                            Sound.PlaySound("shotgun");
                            nextTimeOfFire = Time.time + 1 / currWeapon.fireRate;
                        }
                    }
                    else
                    {
                        PausedMenu.IsPaused = false;
                    }
                }
            }
        }

        healthBar.SetHealth(health);
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
        }
        else
        {
            legAnim.SetBool("Moving", true);
        }
    }

    IEnumerator HitBoxOff()
    {
        hit = false;
        yield return new WaitForSeconds(.5f);
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

    
    #region shop
    public void handgunClick()
    {
        if (currWeapon != handgun)
        {
            if (Score.scoreValue >= 800)
            {
                setAnimation("handgun1");
                Score.scoreValue -= 800;
                currWeapon = handgun;

                Ammo.ammoValue = 100;

            }
        }
    }
    public void akClick()
    {
        if (currWeapon != ak)
        {
            if (Score.scoreValue >= 1500)
            {
                setAnimation("ak1");
                Score.scoreValue -= 1500;
                currWeapon = ak;

                Ammo.ammoValue = 250;

            }
        }
    }
    public void shotgunClick()
    {
        if (currWeapon != shotgun)
        {
            if (Score.scoreValue >= 1250)
            {
                setAnimation("shotgun1");
                Score.scoreValue -= 1250;
                currWeapon = shotgun;
                Ammo.ammoValue = 70;
            }
        }

    }
    public void healthClick()
    {
        if (health < 8 && healthBar.slider.maxValue > 5)
        {
            if (Score.scoreValue >= 3000)
            {
                Score.scoreValue -= 3000;
                health = 8;
            }
        }
        else if (health < 5 && healthBar.slider.maxValue == 5)
        {
            if (Score.scoreValue >= 3000)
            {
                Score.scoreValue -= 3000;
                health = 5;
            }
        }
    }
    public void ammoClick()
    {
        if (currWeapon == handgun)
        {
            if (Score.scoreValue >= 1000 && Ammo.ammoValue < 80)
            {
                Score.scoreValue -= 1000;
                Ammo.ammoValue = 80;
            }
        }
        if (currWeapon == ak)
        {
            if (Score.scoreValue >= 1000 && Ammo.ammoValue < 250)
            {
                Score.scoreValue -= 1000;
                Ammo.ammoValue = 250;
            }
        }
        if (currWeapon == shotgun)
        {
            if (Score.scoreValue >= 1000 && Ammo.ammoValue < 70)
            {
                Score.scoreValue -= 1000;
                Ammo.ammoValue = 70;
            }
        }
    }
    #endregion

    #region perks
    public void perkHealth()
    {
        if (Score.scoreValue >= 2500)
        {
            Score.scoreValue -= 2500;
            health = 8;
            healthBar.SetMaxHealth(8);
        }
    }
    public void perkRunny()
    {
        if (Score.scoreValue >= 2000)
        {
            Score.scoreValue -= 2000;
            speed = 9;
        }
    }
    public void perkFireRate()
    {
        if (Score.scoreValue >= 2000)
        {
            Score.scoreValue -= 2000;
            handgun.fireRate = 5;
            ak.fireRate = 8;
            shotgun.fireRate = 2;
        }
    }
    #endregion
    public void setAnimation(string animationName)
    {
        if (animationName == "handgun1")
        {
            bodyAnim.runtimeAnimatorController = handgun1;
        }
        if (animationName == "ak1")
        {
            bodyAnim.runtimeAnimatorController = ak1;
        }
        else if (animationName == "shotgun1")
        {
            bodyAnim.runtimeAnimatorController = shotgun1;
        }
    }
}
