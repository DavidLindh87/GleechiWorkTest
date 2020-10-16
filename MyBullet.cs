using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start() => rb.velocity = transform.up * speed;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        //Debug.Log(this.name);
        //hitInfo.gameObject.GetComponent<Enemy>().Print();
        if (hitInfo.name == "PlayerRed" || hitInfo.name == "PlayerGreen")
        {
            hitInfo.gameObject.GetComponent<Enemy>().TakeDamage();
            //Debug.Log("player hit");
            Destroy(gameObject);
        }
        else if (hitInfo.transform.parent.name == "Walls")
        {
            hitInfo.gameObject.SetActive(false);
            //Debug.Log("wall hit");
            Destroy(gameObject);
        }
        else
        {
            //Debug.Log("Hit indestructible");
            Destroy(gameObject);
        }
    }
}
