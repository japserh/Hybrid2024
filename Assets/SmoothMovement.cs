using System;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public float positionSmoothing = .5f;
    public float rotationSmoothing = .5f;    
        
    private Transform parent;
    
    private Vector3 oldPosition;
    private Vector3 targetPosition;
    
    private Quaternion oldRotation;
    private Quaternion targetRotation;
    
    private void Start()
    {
        parent = transform.parent;
        oldPosition = parent.position;
        oldRotation = parent.rotation;
    }

    void Update()
    {
        targetPosition = parent.position;
        targetRotation = parent.rotation;

        var newPosition = Vector3.Lerp(oldPosition, targetPosition, positionSmoothing);
        var newRotation = Quaternion.Lerp(oldRotation, targetRotation, rotationSmoothing);

        transform.position = newPosition;
        transform.rotation = newRotation;

        oldPosition = newPosition;
        oldRotation = newRotation;
    }
}
