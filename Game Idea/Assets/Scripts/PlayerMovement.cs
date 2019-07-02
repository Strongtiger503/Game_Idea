using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody rb;
	[SerializeField] private float ForwardForce = 300f;
	[SerializeField] private float JumpStrength = 5f;
	[SerializeField] private float moveRIGHT_AND_LEFTspeed = 10f;
	[SerializeField] private bool RightButtonPressed = false;
	[SerializeField] private bool LeftButtonPressed = false;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

	void FixedUpdate()
	{
		// auto Move Forward
		rb.AddForce(0, 0, ForwardForce * Time.deltaTime);

		// Move Right
		if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 2f && transform.position.y <= -0.299940f)
		{
			RightButtonPressed = true;
		}

		MoveRight();
		
		// Move Left
		if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -2f && transform.position.y <= -0.299940f)
		{
			LeftButtonPressed = true;
		}

		MoveLeft();

		// Jump

		if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= -0.299940f)
		{
			rb.AddForce(0, JumpStrength * Time.deltaTime, 0);

		}

		if (transform.position.x >= 2f)
		{
			RightButtonPressed = false;
		}

		if (transform.position.x <= -2f)
		{
			LeftButtonPressed = false;
		}

	}

	private void MoveRight()
	{
		if (RightButtonPressed == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(2f, transform.position.y, transform.position.z), moveRIGHT_AND_LEFTspeed * Time.deltaTime);
		}
	}

	private void MoveLeft()
	{
		if (LeftButtonPressed == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(-2f, transform.position.y, transform.position.z), moveRIGHT_AND_LEFTspeed * Time.deltaTime);
		}
	}


}

