using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Attributes")]
    public float Speed;
    public float JumpForce;
    public List<GameObject> Munition = new List<GameObject>();
    public float StartTimeAttack;
    public Transform Point;
    public Transform BackPoint;
    public Image vida;
    public Image magic;


    [Header("Components")]
    private Rigidbody2D Rig;
    private Animator Anim;
    private SpriteRenderer Sprite;
    private float TimeAttack;
    private GameController GC;

    [Header("Bools")]
    public bool isGround;
    public bool isAtk;


    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        GC = GameObject.FindGameObjectWithTag("GC").GetComponent<GameController>();
        transform.position = GC.lastCheckPoint;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
        Jump();
        Fire();
        Attack();
        RestartGame();
    }



    public void Move()
    {
        

        if (Input.GetKey(KeyCode.LeftArrow) && !isAtk)
        {
            Rig.velocity = new Vector2(-Speed, Rig.velocity.y);
            Anim.SetBool("isWalking",true);
            Sprite.flipX = true;
        }
        else
        {
            Rig.velocity = new Vector2(0, Rig.velocity.y);
            Anim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.RightArrow) && !isAtk)
        {
            Rig.velocity = new Vector2(Speed, Rig.velocity.y);
            Anim.SetBool("isWalking", true);
            Sprite.flipX = false;
        }
        
    }

    public void Jump()
    {
        if (isGround && Input.GetKey(KeyCode.Space))
        {
            Rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse );
            Anim.SetBool("isJumping",true );
            isGround = false;
        }
    }

    public void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Z) && magic.fillAmount > 0)
        {
            GameObject bullet = Instantiate(Munition[Random.Range(0,Munition.Count)]);
            if (!Sprite.flipX)
            {
                bullet.transform.position = Point.transform.position;
            }
            else
            {
                bullet.transform.position = BackPoint.transform.position;
            }
            
            Destroy(bullet, 1.5f);
            magic.fillAmount -= 0.25f;
            print("atiro");

        }
    }

    public void Attack()
    {
        if (TimeAttack <= 0)
        {
            isAtk = false;

            if (Input.GetKeyDown(KeyCode.X))
            {
                Anim.SetBool("isAtk", true);
                TimeAttack = StartTimeAttack;
                isAtk = true;
            } 
        }
        else
        {
            TimeAttack -= Time.deltaTime;
            Anim.SetBool("isAtk", false);
        }

        Anim.SetBool("isAtk", isAtk);
    }

    public void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            print("toco");
            isGround = true;
            Anim.SetBool("isJumping", false);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            print("Bateu");
            collision.gameObject.GetComponent<Animator>().SetTrigger("hit");
            Destroy(collision.gameObject, 1.5f);
            Rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            magic.fillAmount += 0.25f;
            AudioController.current.PlayMusic(AudioController.current.sfx);
            
        }

        if(collision.gameObject.tag == "Damage")
        {
            print("Dano");
            vida.fillAmount -= 0.25f;
            AudioController.current.PlayMusic(AudioController.current.anotherSfx);
        }
        

        


    }


}
