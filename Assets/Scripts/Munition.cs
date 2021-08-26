using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munition : MonoBehaviour
{
    public float SpeedMunition;
    public float Power;

    private Player player;
    private SpriteRenderer spritePlayer;
    private SpriteRenderer spriteB;

    private bool direction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spritePlayer = player.GetComponent<SpriteRenderer>();
        spriteB = GetComponent<SpriteRenderer>();
        direction = spritePlayer.flipX;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
        {
            transform.Translate(Vector2.left * Time.deltaTime * SpeedMunition);
            spriteB.flipX = false;
        }
        else
        {
            transform.Translate(Vector2.right * Time.deltaTime * SpeedMunition);
            spriteB.flipX = true;
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            print("Bateu");
            collision.gameObject.GetComponent<Animator>().SetTrigger("hit");
            Destroy(collision.gameObject, 1.5f);
            Destroy(gameObject);
        }
    }


}
