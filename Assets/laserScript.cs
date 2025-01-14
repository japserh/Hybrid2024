using UnityEngine;
using UnityEngine.Events;



[RequireComponent(typeof(LineRenderer))]
public class LaserScript : MonoBehaviour
{
    [Header("Settings")]
    public LayerMask layerMask;
    public LayerMask goalMask;
    public float defaultLength = 50;
    public int numOfReflections = 5;

    private LineRenderer _lineRenderer;
    private RaycastHit hit;

    private Ray ray;

    public bool goalHit = false;

    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ReflectLaser();
    }

    void ReflectLaser()
    {
        ray = new Ray(transform.position, transform.forward);


        _lineRenderer.positionCount = 1;
        _lineRenderer.SetPosition(0, transform.position);

        float remainLength = defaultLength;


        for(int i = 0; i < numOfReflections; i++)
        {

            // Does the ray intersect any objects
            if (Physics.Raycast(ray.origin, ray.direction, out hit, defaultLength, layerMask))
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount -1, hit.point);

                remainLength -=Vector3.Distance(ray.origin, hit.point);

                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
            }
            else
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit, defaultLength, goalMask))
                {
                    goalHit = true;
                    remainLength = hit.distance;
                }
                else
                {
                    goalHit = false;
                }
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, ray.origin + (ray.direction * remainLength));
            }
        }

        // Does the ray intersect any objects
        if (Physics.Raycast(transform.position, transform.forward, out hit, defaultLength, layerMask))
        {
            _lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            _lineRenderer.SetPosition(1, transform.position + (transform.forward * defaultLength));
        }
    }


    void NormalLaser()
    {
        _lineRenderer.SetPosition(0, transform.position);

        // Does the ray intersect any objects
        if (Physics.Raycast(transform.position, transform.forward, out hit, defaultLength, layerMask))
        {
            _lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            _lineRenderer.SetPosition(1, transform.position + (transform.forward * defaultLength));
        }
    }
}
