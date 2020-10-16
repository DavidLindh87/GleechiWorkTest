using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitialTransform : MonoBehaviour
{
    private static Transform Green_Init_trans;
    private static Transform Red_Init_trans;
    public GameObject RedTank;
    public GameObject GreenTank;
    // Start is called before the first frame update
    void Start()
    {
        Green_Init_trans = GreenTank.transform;
        Red_Init_trans = RedTank.transform;
    }

    public Transform GetInitTransGreen()
    {
        return Green_Init_trans;
    }

    public Transform GetInitTransRed()
    {
        return Red_Init_trans;
    }

}
