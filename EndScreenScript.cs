using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Cryptography;
using System.Windows.Input;
using UnityEngine;

public class EndScreenScript : MonoBehaviour
{
    public Transform wall;
    public Transform red_player;
    public Transform green_player;

    // Update is called once per frame
    public void Rematch()
    {
        //reset the lane by some function
        foreach (Transform child in wall)
        {
            child.gameObject.SetActive(true);
        }
        red_player.gameObject.GetComponent<TankMoveScript>().Reset();
        green_player.gameObject.GetComponent<TankMoveScript>().Reset();
        Cursor.visible = false;
        this.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
