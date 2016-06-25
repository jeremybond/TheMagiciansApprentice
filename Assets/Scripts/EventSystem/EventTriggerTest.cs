//Created By: Jeremy Bond
//Date: 25/03/2016

using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour
{

	protected void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			EventManager.TriggerEvent ("test");
		}
	}
}
