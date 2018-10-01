using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoreGame.PlayerController;
using Controls;

public class Movement3D : MonoBehaviour {

    Rigidbody characterBody;
    public float speed;
    public float jumpPower;
    Animator animator;
    Transform characterTransform;

    //private bool jumped = false;

    float angle ;
    Quaternion rotation;

    float velY;

    public static bool isGrounded = false;


    // Use this for initialization
    void Start () {
        characterBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        characterTransform = GetComponent<Transform>();
        velY = characterBody.velocity.y;
    }
	
	// Update is called once per frame
	void Update () {
        

        characterBody.velocity = Input.GetAxisRaw("Horizontal") != 0f? 
            new Vector3(Input.GetAxisRaw("Horizontal") * speed, characterBody.velocity.y, characterBody.velocity.z)
            : new Vector3(0f, characterBody.velocity.y, characterBody.velocity.z);

        characterBody.velocity = Input.GetAxisRaw("Vertical") != 0f ?
            new Vector3(characterBody.velocity.x, characterBody.velocity.y, Input.GetAxisRaw("Vertical") * speed)
            : new Vector3(characterBody.velocity.x, characterBody.velocity.y, 0);


        characterBody.velocity = Input.GetButtonDown("Fire1") && isGrounded ?
            new Vector3(characterBody.velocity.x, 1 * jumpPower, characterBody.velocity.z)
            : characterBody.velocity;

        if(Input.GetAxisRaw("Vertical") != 0f || Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("walkBool", true);
        }
        else
        {
            animator.SetBool("walkBool", false);
        }

        if (!isGrounded)
        {
            //animator.SetTrigger("jumpTrigg");
            animator.SetBool("jumpBool", true);
        }
        if (isGrounded)
        {
            animator.SetBool("jumpBool", false);
        }


        /*
        if (Input.GetButtonDown("Fire1"))
        {
            characterBody.velocity = new Vector3(characterBody.velocity.x, 1 * jumpPower, characterBody.velocity.z);
        }
        */
        setCharacterRotation();
        velY = characterBody.velocity.y;
        //Debug.Log(isGrounded);
    }

    private void setCharacterRotation()
    {
        if(Controls.Controls.getAxis() != Vector2.zero)
        {
            //characterTransform.rotation();
            angle = Mathf.Atan2(Controls.Controls.getAxis().y, Controls.Controls.getAxis().x) * Mathf.Rad2Deg;
            //Debug.Log("zValue: " + angle);
            //Debug.Log("X y Y: " + Controls.LeftJoystick().x + " " + Controls.LeftJoystick().y);
            rotation = Quaternion.Euler(0, angle - 90, 0);
            transform.rotation = rotation;
        }
    }
        
}
