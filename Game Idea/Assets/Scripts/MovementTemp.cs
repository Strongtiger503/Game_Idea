using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTemp : MonoBehaviour
{

	public SwipeAndTapForMobileAndStandalone Swipe;

	private void Update()
	{
		if (Swipe.Tap)
		{
			Debug.Log("tap");
		}

		if (Swipe.SwipeUp)
		{
			Debug.Log("swipe up");
		}

		if (Swipe.SwipeDown)
		{
			Debug.Log("swipe down");
		}

		if (Swipe.SwipeLeft)
		{
			Debug.Log("swipe left");
		}

		if (Swipe.SwipeRight)
		{
			Debug.Log("swipe right");
		}



	}

}

