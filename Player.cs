using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public float movementSpeed;
    public float walkSpeed;
    public float runningSpeed;
    public float crouchingSpeed;
    public float jumpForce;
    public float gracityScale;
    public bool isGrounded;
    private Animator anim;

    private Vector3 moveDirection;

    private int HorzFloat = Animator.StringToHash("Horizontal");
    private int VertFloat = Animator.StringToHash("Vertical");
    public float m_Damping = 0.15f;

    private Pickup selectedItem = null;
    private PickupText pickupText;

    LoadGame playerPosData;

    private void Awake()
    {
        playerPosData = FindObjectOfType<LoadGame>();
        playerPosData.PlayerPosLoad();
    }



    void Start()
    {
       
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        pickupText = FindObjectOfType<PickupText>();
        //pickupText.gameObject.SetActive(false);
    }


    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == false)
        {
            //moveDirection.y = 0f;
            moveDirection.y = jumpForce;
            //Debug.Log("Jumping");
        }

        if(Input.GetKeyDown(KeyCode.E) && selectedItem)
        {
            Item item = selectedItem.GetItem();
            Destroy(selectedItem.gameObject);
            selectedItem = null;
            Inventory.instance.AddItem(item.itemID);
            WinCondition.CollectItem();
           
            pickupText.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        //Read player input
        float Vert = Input.GetAxis("Vertical");
        float Horz = Input.GetAxis("Horizontal");

        float yStore = moveDirection.y;
        //Walking
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical") * movementSpeed) + (transform.right * Input.GetAxisRaw("Horizontal") * movementSpeed);
        moveDirection = moveDirection.normalized * movementSpeed;


        moveDirection.y = yStore;

        //Jumping



        moveDirection.y = moveDirection.y + (Physics.gravity.y * gracityScale);
        controller.Move(moveDirection * Time.fixedDeltaTime);

        //anim.SetBool("isGrounded", controller.isGrounded);
        //anim.SetFloat("walking", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
        //Set animator floating point values

 
        //attack
        

    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<Pickup>())
        {
            selectedItem = collision.gameObject.GetComponent<Pickup>();
            pickupText.gameObject.SetActive(true);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            anim.SetBool("isGrounded", true);
            //Debug.Log("Touching ground");
        }
    }

    void OnTriggerExit(Collider collision)
    {
        anim.SetBool("isGrounded", false);
        isGrounded = true;
        if (collision.gameObject.GetComponent<Pickup>())
        {
            Pickup pickup = collision.gameObject.GetComponent<Pickup>();
            if(selectedItem == pickup)
            {
                FindObjectOfType<PickupText>().enabled = false;
                selectedItem = null;
                pickupText.gameObject.SetActive(false);
            }
        }
    }
}