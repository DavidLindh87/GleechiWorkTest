using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hit_points = 100;
    public int damage = 10;
    public Slider slider;
    public Text winner;
    public GameObject endScreen;

    public void TakeDamage()
    {
        hit_points -= damage;
        slider.value += damage;
        if(hit_points <= 0)
        {
            Die();
        }
    }

    public void Reset()
    {
        hit_points = 100;
        slider.value = 0;
        winner.text = string.Empty;
    }

    public void Print()
    {
        Debug.Log("Funkar");
    }

    void Die()
    {
        //change scene or activate death/win screen
        if(gameObject.name == "PlayerRed")
        {
            winner.text = "Green player has won the game!";
        }
        else
        {
            winner.text = "Red player has won the game!";
        }
        endScreen.SetActive(true);
        Cursor.visible = true;
    }

}
