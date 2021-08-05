using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float degreesPerSecond = 45f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(degreesPerSecond * Time.deltaTime, 0, 0);
    }
}
