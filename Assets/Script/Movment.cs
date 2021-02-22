using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{

    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float speed = 0f;
    [SerializeField] float rotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
           if(!audioSource.isPlaying){
           audioSource.Play();
           }
       }
       else
       {
           audioSource.Stop();
       }

   }

    void Rotat() 
    {
       if (Input.GetKey(KeyCode.LeftArrow)) // Rotation to the left
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
