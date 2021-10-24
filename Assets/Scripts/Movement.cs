using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float walkSpeed = 2.5f;
    [SerializeField] private float sprintSpeed = 5.5f;
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isSprinting;
    public Rigidbody2D rb;

    Vector2 movement;

    private Stealth playerNoise;

    private void Start()
    {
        isMoving = false;
        isWalking = true;
        playerNoise = GetComponentInChildren<Stealth>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isWalking == true)
            { 
                isSprinting = true;
                isWalking = false;
            }
            else
            {
                isWalking = true;
                isSprinting = false;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            isMoving = true;
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
        }
        
         movement.x = Input.GetAxisRaw("Horizontal");
         movement.y = Input.GetAxisRaw("Vertical");



        if ((movement.x > 0 || movement.y > 0) || (movement.x > 0 && movement.y > 0))
        {
            playerNoise.isPlayerMoving(isMoving, isWalking, isSprinting);
        }
        else if ((movement.x == 0 || movement.y == 0) || (movement.x == 0 && movement.y == 0))
        {
            playerNoise.isPlayerMoving(isMoving, isWalking, isSprinting);
        }
    }

    void FixedUpdate()
    {
        if (isMoving && isWalking == true)
        {
            rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
        }
        else if (isSprinting == true)
        {
            rb.MovePosition(rb.position + movement * sprintSpeed * Time.fixedDeltaTime);
        }
    }
}
