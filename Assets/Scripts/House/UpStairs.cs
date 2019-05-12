// Created By: Jeremy Bond
// Date: 12/05/2019

using UnityEngine;
using UnityEngine.SceneManagement;

public class UpStairs : MonoBehaviour
{
    [SerializeField] private bool GoingUp;
    [SerializeField] private GameObject groundFloor;
    [SerializeField] private GameObject upStairs;


    /// <summary>
    /// The OnTrigger function is used to check when a player will enter the collider.
    /// </summary>
    /// <param name="col"></param>
    protected void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name == ConstStrings.PLAYERTAG)
        {
            if (GoingUp)
            {
                groundFloor.SetActive (false);
                upStairs.SetActive(true);
            }
            else
            {
                groundFloor.SetActive(true);
                upStairs.SetActive(false);
            }
        }
    }
}
