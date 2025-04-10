using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D body;
    public Player_Stats PLstats;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 10f;
    float dashSpeed = 30;
   [SerializeField] float trueSpeed;

    bool canDash;
    
    float dashTime = 0.5f;
    
   [SerializeField] float dashCooldown ;
    private float CD;
    float currentDashTime;

    public Camera cam;
    public Vector2 mousePos;
    public Weapon weapon;
    


    void Start()
    {
        PLstats = GetComponent<Player_Stats>();
        body = GetComponent<Rigidbody2D>();
        canDash = true;
        trueSpeed = runSpeed;
        PLstats.dash = 3;
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (( PLstats.dash > 0 ) && canDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            PLstats.dash--;
            StartCoroutine(Dash(body.velocity));
        }

        velocity();

        if (PLstats.dash < 3) 
        {
            CD += Time.deltaTime;
            if (CD >= dashCooldown)
            {
                CD = 0f;
                PLstats.dash++;
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
      if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * trueSpeed, vertical * trueSpeed    );
        Vector2 aimDir = mousePos - body.position;
        float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
        body.rotation = aimAngle;
    }

    IEnumerator Dash(Vector2 direction)
    {
       
        canDash = false;
        currentDashTime = dashTime;
        
        while (currentDashTime > 0f)
        {
           
            currentDashTime -= Time.deltaTime;
            body.velocity = direction * dashSpeed;

            yield return null;
        }
        
        
        canDash = true;

        Debug.Log(PLstats.dash);

        if (PLstats.lives <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    

    

    void velocity()
    {
        if (!canDash)
        {
            trueSpeed = dashSpeed;
        }
        else
        {
            trueSpeed = runSpeed;
        }



    }
}
