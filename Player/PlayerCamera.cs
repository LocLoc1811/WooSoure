using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform Target;
    public float smoothing;

    Vector3 offset;

    float lowY;

    void Start()
    {
        offset = transform.position - Target.position;

        lowY = transform.position.y;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = Target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if(transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }

        if (transform.position.y > lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
