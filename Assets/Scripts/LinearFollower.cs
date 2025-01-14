using System;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class LinearFollower : MonoBehaviour
{
    public GameObject target;
    public float multiplier = 1;
    public Vector3 direction;
    private Vector3 basePosition;

    // Update is called once per frame
    void Update()
    {
        var yRotation = target.transform.localEulerAngles.y;
        var linear = Mathf.Sin(yRotation * Mathf.Deg2Rad);
        var offset = linear * multiplier;
        transform.position = basePosition + direction * offset;

    }

    private void Start()
    {
        basePosition = transform.position;
    }
}
