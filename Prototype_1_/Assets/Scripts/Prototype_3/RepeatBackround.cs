using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackround : MonoBehaviour    // We repeat the backround seamlessly.
{
    private Vector3 startPosition;
    private float repeatWidht;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWidht = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPosition.x - repeatWidht)
        {
            transform.position = startPosition;
        }
    }
}
