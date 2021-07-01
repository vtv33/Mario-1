using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    Vector2 currentMove;
    // Start is called before the first frame update
    Rigidbody2D rigid;
    public float jumpspeed = 100f;
    public float movespeed = 10f;
    float currentmovespeed = 0;
    float currentjumpspeed = -4;
    bool isGrounded = false;
    Animator anim;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //currentMove = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            currentMove.y += 1f;
        }
        else
        {
            currentMove.y -= 0.005f;
            if (currentMove.y < 0)
                currentMove.y = 0;
        }
        transform.position = currentMove;*/
        if (Input.GetKeyDown(KeyCode.Space) && rigid.IsTouchingLayers(LayerMask.GetMask("ground")))
        {
            //rigid.AddForce(new Vector2(0, jumpspeed));
            //rigid.velocity = new Vector2(0, rigid.velocity.y + jumpspeed);
            currentjumpspeed = rigid.velocity.y + jumpspeed;
        }
        else
        {
            currentjumpspeed = rigid.velocity.y;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rigid.AddForce(new Vector2(-movespeed, 0));
            //rigid.velocity = new Vector2(-movespeed, 0);
            currentmovespeed = -movespeed;
            //anim.SetTrigger("Walking");
            anim.Play("Walking");
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //rigid.AddForce(new Vector2(movespeed, 0));
                //rigid.velocity = new Vector2(movespeed, 0);
                currentmovespeed = movespeed;
                //anim.SetTrigger("Walking");
                anim.Play("Walking");
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
                currentmovespeed = 0;
        }
        if (rigid.IsTouchingLayers(LayerMask.GetMask("mob"))){
            Destroy(gameObject);
        }
        rigid.velocity = new Vector2(currentmovespeed, currentjumpspeed);

    }

    /*private void FixedUpdate()
    {
        // Cap nhat theo so fps co dinh
        // may rat manh chay khoang 120 fps => update 120 lan 1s
        // may rat yeu chay khoang 30 fps => update 30 lan 1s
        // Time.deltatime = 1/fps (1 giai phap khac cua fixedupdate)
        
    }*/
}
