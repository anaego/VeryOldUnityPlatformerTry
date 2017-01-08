using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //floats
    public float maxSpeed=3;
    public float speed = 70f;
    public float jumpPower = 150f;

    //booleans
    public bool grounded;
    public bool canDoubleJump;
    public bool wallSliding;
    public bool facingRight;
    public bool gotLightQueen;
    public bool wallCheck;

    //references
    private Rigidbody2D rb2d;
    private Animator anim;
    public Transform wallCheckPoint;
    public LayerMask wallLayerMask;
    public InfoHigher info1;
    public InfoLight info2;
    public JumpOnButton LidOpener1;
    public JumpOnButton LidOpener2;
    public JumpOnButton LidOpener3;
    public GameObject lightQueen;
    public checkpoint[] checkpoints;

    public int currentCheckpoint;


    void Start () 
    {
        rb2d = gameObject.GetComponent<Rigidbody2D> ();
        anim = gameObject.GetComponent<Animator>();

        
        if (PlayerPrefs.GetInt("JUSTLOADED") == 1)
        {
            if (PlayerPrefs.GetInt("1stleveldoublejump") == 1 && Application.loadedLevel==1)
            {
                gotLightQueen = true;
                lightQueen.transform.parent = transform;
                gotLightQueen = true;
                lightQueen.transform.position = transform.position;
            }
            currentCheckpoint = PlayerPrefs.GetInt("currentcheckpoint");
            checkpoints[currentCheckpoint].savedonce = PlayerPrefs.GetInt("currentsavedonce");
            for (int i = 0; i < currentCheckpoint; i++)
            {
                if (checkpoints[i] != null)
                    Destroy(checkpoints[i]);
            }
            if (PlayerPrefs.GetInt("info1destroyed") == 1 && info1!=null)
                Destroy(info1);
            if (PlayerPrefs.GetInt("info2destroyed") == 1 && info2!=null)
                Destroy(info2);
            if (PlayerPrefs.GetInt("lid1open") == 1 && LidOpener1 != null)
                LidOpener1.OpenOrNot = true;
            if (PlayerPrefs.GetInt("lid2open") == 1 && LidOpener2 != null)
                LidOpener2.OpenOrNot = true;
            if (PlayerPrefs.GetInt("lid3open") == 1 && LidOpener3 != null)
                LidOpener3.OpenOrNot = true;

            transform.position = checkpoints[currentCheckpoint].transform.position;
            PlayerPrefs.SetInt("JUSTLOADED", 0);
        }
    }

    void Update () 
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        
            if (Input.GetAxis("Horizontal") < -0.1f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                facingRight = false;
            }
            if (Input.GetAxis("Horizontal") > 0.1f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                facingRight = true;
            }

            if (Input.GetButtonDown("Jump") && !wallSliding)
            {
                if (grounded)
                {
                    rb2d.AddForce(Vector2.up * jumpPower);
                    if (gotLightQueen)
                        canDoubleJump = true;
                }
                else
                {
                    if (canDoubleJump)
                    {
                        canDoubleJump = false;
                        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                        rb2d.AddForce(Vector2.up * jumpPower);
                    }
                }
            }
        

        
        if (!grounded)
        {
            wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, 0.1f, wallLayerMask);

            if (facingRight && Input.GetAxis("Horizontal") > 0.1f || !facingRight && Input.GetAxis("Horizontal") < 0.1f)
            {
                if (wallCheck)
                {
                    HandleWallSliding();
                }
            }
        }

        if (wallCheck == false || grounded)
        {
            wallSliding = false;
        }

        if (transform.position.y <= -5f)
            Die();

    }



    void HandleWallSliding()
    {
        wallSliding = true;
    }



    void FixedUpdate()
    {
        
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");

        //fake friction/easing the x speed of the player
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        //moving the player
            //normal speed in the air
            //rb2d.AddForce((Vector2.right * speed) * h);
        //reduced speed in the air
        
            if (grounded)
            {
                rb2d.AddForce((Vector2.right * speed) * h);
            }
            else
            {
                rb2d.AddForce((Vector2.right * speed / 2) * h);
            }

        //limiting player's speed
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y); 
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

    }



    public void Die()
    {
        PlayerPrefs.SetInt("leveltoload", Application.loadedLevel);
        if (gotLightQueen && Application.loadedLevel == 1)
            PlayerPrefs.SetInt("1stleveldoublejump", 1);
        PlayerPrefs.SetInt("currentcheckpoint", currentCheckpoint);
        PlayerPrefs.SetInt("currentsavedonce", checkpoints[currentCheckpoint].savedonce);
        if (info1 == null)
            PlayerPrefs.SetInt("info1destroyed", 1);
        if (info2 == null)
            PlayerPrefs.SetInt("info2destroyed", 1);
        if (LidOpener1 != null && LidOpener1.OpenOrNot)
            PlayerPrefs.SetInt("lid1open", 1);
        if (LidOpener2 != null && LidOpener2.OpenOrNot)
            PlayerPrefs.SetInt("lid2open", 1);
        if (LidOpener3 != null && LidOpener3.OpenOrNot)
            PlayerPrefs.SetInt("lid3open", 1);

        PlayerPrefs.SetInt("JUSTLOADED", 1);
        Application.LoadLevel(PlayerPrefs.GetInt("leveltoload", 1));
        //LoadAfterDyingOrLoading();
        //gm.InputText.text = ("REALLY WORKED");
        /*if (checkpoints[0]!=null && checkpoints[0].savedonce==0)
        {
            Application.LoadLevel(Application.loadedLevel); //restart
        }
        else
        {
            transform.position = checkpoints[currentCheckpoint].transform.position;
        }*/
    }

    


   void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

   void OnCollisionExit2D(Collision2D other)
   {
       if (other.transform.tag == "MovingPlatform")
       {
           transform.parent = null;
       }
   }



   void OnTriggerEnter2D(Collider2D col)
   {
       if (col.transform.tag == "LightQueen")
       {
           col.transform.parent = transform;
           gotLightQueen = true;
           col.transform.position = transform.position;
          
       }
   }

}