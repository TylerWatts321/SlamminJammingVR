using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(2f * Time.deltaTime, 3f * Time.deltaTime, 6f * Time.deltaTime, Space.Self);
    }
}
