using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;

    public float minAngle;
    public float maxAngle;

    public float RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var newAngleY = transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X");
        transform.localEulerAngles = new Vector3(0, newAngleY, 0);

        var newAnglelX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        if (newAnglelX > 180)
            newAnglelX -= 360;
        
        newAnglelX = Mathf.Clamp(newAnglelX, minAngle, maxAngle);

        CameraAxisTransform.localEulerAngles = new Vector3(newAnglelX, 0, 0);
    }
}
