//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour 
{
	/// <summary>
	/// Awake function that calls the dont destory on load function for the object this script is attachted to.
	/// </summary>
	protected void Awake () 
	{
        DontDestroyOnLoad(transform.gameObject);
    }
}
