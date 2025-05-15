using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float currentRotationY = transform.rotation.eulerAngles.y;
        currentRotationY += 0.3f;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, currentRotationY, transform.rotation.eulerAngles.z);
    }
}
