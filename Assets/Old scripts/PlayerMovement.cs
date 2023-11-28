using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody myRigidbody;
    private Vector3 change;
    private Animator animator;
   // public VectorValue startingPosition;
    public int coins;
    private TextMeshProUGUI coinsValue;
    private GameObject shop;
    private Vector3 moveDirection;
    private Vector3 lookDirection;
    private bool grounded;
    public LayerMask ground;
    [SerializeField]public float distance;
    public float jumpForce;
    private float rotationY;
    public float sensitivity;
    private float baseSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody>();
        rotationY = Input.GetAxisRaw("Mouse X");
        Cursor.lockState = CursorLockMode.Locked;
       // transform.position = startingPosition.initialValue;
        coinsValue = GameObject.Find("Valueofcoin").GetComponent<TextMeshProUGUI>();
        baseSpeed = speed;
      //  shop = GameObject.Find("Shop");
       // shop.SetActive(false);
    }

    private void walk()
    {
        speed = baseSpeed;
    }

    private void sprint()
    {
        speed = speed * 2;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            coins++;
            Object.Destroy(collision.gameObject);
            coinsValue.text = coins.ToString();
        }
        if(collision.gameObject.tag == "shopkeeper")
        {
            shop.SetActive(true);
        }
    }
    void groundCheck()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, distance, ground);
        Debug.DrawRay(transform.position, Vector3.down * distance, Color.red);
    }
    public void UpdatingCoinValue()
    {
        coinsValue.text = coins.ToString();
    }
    // Update is called once per frame
    void jump()
    {
        if(grounded==true)
        {
            myRigidbody.AddForce(new Vector3(myRigidbody.velocity.x, jumpForce, myRigidbody.velocity.z));
            myRigidbody.drag = 0;
            Invoke("resetDrag", 0.3f);
        }
    }
    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal") * speed;
        change.y = Input.GetAxisRaw("Vertical") * speed;
        UpdateAnimationAndMove();
        rotationY = Input.GetAxisRaw("Mouse X")* sensitivity;
        Quaternion DeltaRotationY = Quaternion.Euler(transform.rotation.x, rotationY, transform.rotation.z);
        myRigidbody.MoveRotation(myRigidbody.rotation * DeltaRotationY);
    }

    void resetDrag()
    {
        myRigidbody.drag = 0;
    }
    void Update()
    {
        moveDirection = transform.forward * change.y + transform.right * change.x;
        lookDirection = transform.forward + transform.right;
        groundCheck();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        if(grounded==true)
        {
            myRigidbody.drag = 5;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprint();
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            walk(); 
        }
    }
    void UpdateAnimationAndMove() // Added parentheses here
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    } // Added closing curly brace here

    void MoveCharacter()
    {
        myRigidbody.AddForce(moveDirection, ForceMode.Force);
    }
}