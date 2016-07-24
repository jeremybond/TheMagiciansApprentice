//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour 
{
	protected void Awake () 
	{
        SceneManager.LoadScene(ConstStrings.MAINSCENENAME);
	}
}
