using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTemp : MonoBehaviour
{

	public SwipeAndTapForMobileAndStandalone Swipe;

	public Transform transform;

	private void Update()
	{
		if (Swipe.Tap)
		{
			Debug.Log("tap");
		}

		if (Swipe.SwipeUp)
		{
			transform.position += new Vector3(0f, 10f, 0f);
		}

		if (Swipe.SwipeDown)
		{
			transform.position += new Vector3(0f, -10f, 0f);
		}

		if (Swipe.SwipeLeft)
		{
			transform.position += new Vector3(-10f, 0f, 0f);
		}

		if (Swipe.SwipeRight)
		{
			transform.position += new Vector3(10f, 0f, 0f);
		}



	}

}

