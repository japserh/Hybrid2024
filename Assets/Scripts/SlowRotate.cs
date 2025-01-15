using UnityEngine;

public class SlowRotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotateDirection;
    [SerializeField] private float rotateSpeed;


    private void FixedUpdate()
    {
        transform.localEulerAngles = transform.localEulerAngles + rotateDirection.normalized * Time.deltaTime * rotateSpeed;
    }
}
