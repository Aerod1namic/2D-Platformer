using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float JumpCharacter;
    public Transform GroundCheck;
    bool onGround;
    Animator Character_animation;
    public Player player;
    public GameObject WinScr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Character_animation = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Flip_Character();
        Checking_Ground();
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
            rb.AddForce(transform.up * JumpCharacter, ForceMode2D.Impulse);

        if (Input.GetAxis("Horizontal") == 0 && (onGround))
            Character_animation.SetInteger("State", 1);
        else
        {
            if (onGround)
                Character_animation.SetInteger("State", 2);
        }

    }

    void Flip_Character()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);

    }


    void Checking_Ground()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, 0.2f);
        onGround = colliders.Length > 1;
        if (!onGround)
            Character_animation.SetInteger("State", 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
            Destroy(collision.gameObject);
        if (collision.gameObject.tag == "Win")
        {
            Time.timeScale = 0f;
            player.enabled = false;
            WinScr.SetActive(true);
        }
    }
}
