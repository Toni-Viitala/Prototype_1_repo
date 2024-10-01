using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSecond : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float playerSpeed = 10f;
    public float xRange = 15;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);

        if(transform.position.x <-15)
        {
            transform.position = new Vector3(-xRange,transform.position.y, transform.position.z);
        }
        if (transform.position.x > 15)
        {
            transform.position = new Vector3(xRange,transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
