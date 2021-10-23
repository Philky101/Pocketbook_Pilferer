using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
	float playerSpeed = 3000f;
	Rigidbody2D playerBody;
	
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
	
	void Move()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		Vector2 movement = new Vector2(inputX, inputY);
		
		playerBody.velocity = movement * Time.deltaTime * playerSpeed;
	}
}
