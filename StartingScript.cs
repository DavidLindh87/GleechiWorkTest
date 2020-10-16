using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScript : MonoBehaviour
{

    public void Load_Scene()
    {
        SceneManager.LoadScene("TankScene", LoadSceneMode.Single);
    }
}
