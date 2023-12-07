using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public KeyCode reset;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(reset))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
