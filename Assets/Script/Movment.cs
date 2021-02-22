using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float speed = 0f;
    [SerializeField] float rotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotat();
    }

   void Thrust()
   {
       if (Input.GetKey(KeyCode.Space))
       {
           rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
       }
   }

    void Rotat() 
    {
       if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotation);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
       {
           ApplyRotation(-rotation);
       }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freez rotation so we can manual rotate
        transform.Rotate(Vector3.right * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Unfreezing so the rotation can take over
    }

}
