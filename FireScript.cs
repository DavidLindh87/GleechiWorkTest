using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class FireScript : MonoBehaviour
{

    public string fireKey;
    public Transform firePoint;
    public GameObject BulletPrefab;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
