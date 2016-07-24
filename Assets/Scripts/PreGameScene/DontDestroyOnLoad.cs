//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour 
{
	protected void Awake () 
	{
        DontDestroyOnLoad(transform.gameObject);
    }
}
