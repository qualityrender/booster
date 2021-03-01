using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiteApplication : MonoBehaviour
{

  // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            Debug.Log("We quite");
            Application.Quit();
        }
    }




}
