using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class RotationFollower : MonoBehaviour
{
    public GameObject target;
    public float multiplier = 1;
    private Vector3 position;

    private RotationFollower rotationFollower;


    private void Start()
    {
        rotationFollower = FindFirstObjectByType<RotationFollower>();
    }

    // Update is called once per frame
    void Update()
    {
        OldRotate();
        NewRotate();
    }

    private void OldRotate()
    {
        var rotation = target.transform.localRotation;
        rotation = Quaternion.SlerpUnclamped(Quaternion.identity, rotation, multiplier);
        transform.localRotation = rotation;
    }

    private void NewRotate()
    {

    }
}
