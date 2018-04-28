using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;
    public float speed = 7.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0f;
    public float gravity = 12.0f;
    private float animationDuration = 3.0f;
    public float jumpSpeed = 60.0f;
    Animator anim;
    bool isGrounded;
    private bool isDead = false;



    void Start()
    {

        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        isGrounded = true;
        moveVector = Vector3.zero;
    }

    void movementControl(string state)
    {
        switch (state)
        {
            case "sprint":
                anim.SetBool("Sprint", true);
                anim.SetBool("Rolling", false);
                anim.SetBool("Running", false);
                anim.SetBool("Dying", false);

                break;
            case "rolling":
                anim.SetBool("Sprint", false);
                anim.SetBool("Rolling", true);
                anim.SetBool("Running", false);
                anim.SetBool("Dying", false);

                break;
            case "running":
                anim.SetBool("Sprint", false);
                anim.SetBool("Rolling", false);
                anim.SetBool("Running", true);
                anim.SetBool("Dying", false);
                break;

            case "die":
                anim.SetBool("Sprint", false);
                anim.SetBool("Rolling", false);
                anim.SetBool("Running", false);
                anim.SetBool("Dying", true);
                break;
        }
    }

    void Update()
    {
        
        if (isDead)
        {
            movementControl("die");
            return;
        }
        

        if (isGrounded)
        {
            
        

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {

                movementControl("rolling");
            }

            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                 speed = 7.0f;
                movementControl("sprint");
            }


            else
            {
                //speed = 5.0f;
                movementControl("running");
            }

        }   
               if (Input.GetButton("Jump"))
               // moveVector.y = jumpSpeed;
               anim.SetTrigger("Jumping");
        
      

        if (controller.isGrounded)
        {
            verticalVelocity = 0.5f;
        }


        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        //if (Input.GetButton("Jump"))
        //  moveVector.y = jumpSpeed;


        if (Time.deltaTime < animationDuration)
        {
            controller.Move(moveVector * Time.deltaTime);
            return;
        }


    }

    public void SetSpeed(float modifier)
    {
        float setspeed = 8.0f;

        speed = setspeed + modifier;
        setspeed++;
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            return;
        }
        if (hit.point.z > transform.position.z + controller.radius && isGrounded)
        {
            Death();
        }
    }

    private void Death()
    {
        //movementControl("die");
        Debug.Log("Deth");
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}



