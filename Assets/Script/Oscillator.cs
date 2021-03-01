using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosistion;
    [SerializeField] Vector3 movementVector;
   /*[SerializeField] [Range(0,1)]*/ float movementFactor;
    [SerializeField] [Range(0,15)]float period = 2f;
    float iP = Mathf.PI;
    

    // Start is called before the first frame update
    void Start()
    {
        startingPosistion = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon){return;}

        float cycles = Time.time / period; //Grow over time
        const float tau = Mathf.PI * 2; // Constant value of 6.383
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2; // recalculated to 0 to 1



        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosistion + offset;
    }
}
