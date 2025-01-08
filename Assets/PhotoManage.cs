using UnityEngine;

public class PhotoManage : MonoBehaviour
{


    private void Update()
    {
        if (Input.GetButtonDown("Mouse0") == true)
        {
            OnMouseDown();
        }
    }

    void OnMouseDown()
    {
        var photoTex = ScreenCapture.CaptureScreenshotAsTexture();
        
    }
}
