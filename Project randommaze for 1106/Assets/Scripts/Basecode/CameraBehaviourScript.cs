using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviourScript : MonoBehaviour
{
    public Transform PlayerCapsule;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerCapsule.position;
        transform.rotation = PlayerCapsule.rotation;

        Vector3 currentPosition = transform.position;

        currentPosition.y += 0.9f;

        transform.position = currentPosition;
    }
}
