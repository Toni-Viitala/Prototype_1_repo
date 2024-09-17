using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 15;
    public float turnSpeed = 25;

    public float horizontalInput;
    public float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Let's move the car forward with:
        transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * forwardSpeed); // Nopeus ilmoitetaan metri‰/Sekunnissa
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

    }
}

/*// Projekti jatkuu t‰‰ll‰! : 
https://learn.unity.com/tutorial/lesson-1-4-use-user-input-to-control-the-vehicle?uv=2022.3&courseId=5cf96c41edbc2a2ca6e8810f&projectId=5caccdfbedbc2a3cef0efe63#5cbe3969edbc2a191e639155*/
