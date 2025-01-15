using System;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public Transform target;
    public float positionSmoothing = .5f;
    public float rotationSmoothing = .5f;    
    
    private Vector3 oldPosition;
    private Vector3 targetPosition;
    
    private Quaternion oldRotation;
    private Quaternion targetRotation;
    
    private void Start()
    {
        oldPosition = target.position;
        oldRotation = target.rotation;
    }

    void Update()
    {
        targetPosition = target.position;
        targetRotation = target.rotation;

        var newPosition = Vector3.Lerp(oldPosition, targetPosition, positionSmoothing);
        var newRotation = Quaternion.Lerp(oldRotation, targetRotation, rotationSmoothing);

        transform.position = newPosition;
        transform.rotation = newRotation;

        oldPosition = newPosition;
        oldRotation = newRotation;
    }
}
