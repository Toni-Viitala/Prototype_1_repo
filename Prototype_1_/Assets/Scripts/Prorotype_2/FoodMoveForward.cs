using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMoveForward : MonoBehaviour
{
    public float foodSpeed = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * foodSpeed);

        //if(transform.translate.Vector3(forward)
    }
}
