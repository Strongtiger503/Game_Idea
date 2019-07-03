﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeAndTapForMobileAndStandalone : MonoBehaviour
{
	#region Intiallizattion

	private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
	private bool isDraging = false;
	private Vector2 startTouch, swipeDelta;

	#endregion

	#region Main

	// Update is called once per frame

	void Update()
    {
		#region Reset all controls

		tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;
		
		#endregion
		
		#region Standalone Inputs

		if (Input.GetMouseButtonDown(0))
		{
			tap = true;
			isDraging = true;
			startTouch = Input.mousePosition;

		}
		else if (Input.GetMouseButtonUp(0))
		{

			isDraging = false;
			Reset();

		}

		#endregion

		#region Mobile Inputs

		if (Input.touches.Length > 0)
		{

			if(Input.touches[0].phase == TouchPhase.Began)
			{

				tap = true;
				isDraging = true;
				startTouch = Input.touches[0].position;

			}
			else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{

				isDraging = false;
				Reset();

			}

		}

		#endregion

		#region Calculate the distance moved from touch or click start position

		//reset distance
		swipeDelta = Vector2.zero;

		//calculation

		if (isDraging)
		{
			if (Input.touches.Length > 0)
			{
				swipeDelta = Input.touches[0].position - startTouch;
			}
			else if (Input.GetMouseButtonDown(0))
			{
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
			}
		}

		#endregion

		#region If Deadzone was crossed do a swipe

		if(swipeDelta.magnitude > 150)
		{
			//Direction of Swipe

			float x = swipeDelta.x;
			float y = swipeDelta.y;

			if(Mathf.Abs(x) > Mathf.Abs(y))
			{
				//Left or Right

			    if(x < 0)
				{
					swipeLeft = true;
				}

				if (x > 0)
				{
					swipeLeft = true;
				}

			}

			if (Mathf.Abs(x) > Mathf.Abs(y))
			{
				//Up or Down

				if (y < 0)
				{
					swipeDown = true;
				}

				if (y > 0)
				{
					swipeUp = true;
				}

			}

			Reset();
		}

		#endregion

	}

	#endregion

	#region Functions

	private void Reset()
	{

		startTouch = swipeDelta = Vector2.zero;

		isDraging = false;

	}

	#endregion

	#region Assignment (Getters and Setters)

	public Vector2 SwipeDelta { get { return swipeDelta; } }
	public bool SwipeLeft { get { return swipeLeft; } }
	public bool SwipeRight { get { return swipeRight; } }
	public bool SwipeUp { get { return swipeUp; } }
	public bool SwipeDown { get { return swipeDown; } }
	public bool Tap { get { return tap; } }

	#endregion

}
