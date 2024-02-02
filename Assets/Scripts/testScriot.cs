using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScriot : MonoBehaviour
{
    int a = 5;
    int b = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (a > 8 && b > 8)
        {
            float b1 = a * b;
            Debug.Log(b1);
        }
        else if (a < 5 || b < 5)
        {
            float b1 = a + b;
            Debug.Log(b1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
