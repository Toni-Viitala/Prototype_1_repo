using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float overBound = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z >  overBound || transform.position.z <-overBound)
        {
            Destroy(gameObject);

            if (transform.position.z < -overBound)
            {
                Debug.Log("DestroyOutOfBounds : Game over!");
            }
        }
        
    }
}
