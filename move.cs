using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float runSpeed ;
    public float jumpSpeed;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDir = Input.GetAxis("Horizontal"); 
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("ISRUN", playerHasXAxisSpeed);
        fan();
        tiao();
        SwichAimation();
        //gongji();
    }
    void fan()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0,0,0);
            }
            if (myRigidbody.velocity.x < 0f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
    void tiao()
    {
        if (Input.GetKey(KeyCode.K))
        {
            myAnim.SetBool("ISJUMP", true);
            myAnim.SetBool("ISRUN", false);
            Vector2 jumpVel = new Vector2(0, jumpSpeed);
            myRigidbody.velocity = Vector2.up * jumpVel;
        }
    }
    void SwichAimation()
    {
        if (myAnim.GetBool("ISJUMP"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("ISFALL", true);
                    myAnim.SetBool("ISJUMP",false);
                myAnim.SetBool("ISRUN", false);
            }
        }
        else if(myRigidbody.velocity.y ==0.0f)
        {
            
            myAnim.SetBool("ISFALL", false);
            myAnim.SetBool("ISIDLE", true);
        }
    }
    void gongji()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            myAnim.SetTrigger("ISATTACK");
        }
    }
}
