using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public float turnspeed = 100f;
    void Update()
    {
        transform.Rotate(0, 0, turnspeed* Time.deltaTime);
    }
}
