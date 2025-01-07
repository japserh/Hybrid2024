using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class CaptureCamera : MonoBehaviour
{
    public Canvas canvas;
    public RawImage canvasImage;

    void Start()
    {
        // Set rect to full screensize (didn't know where to in Rect Transform)
        RectTransform rt = canvasImage.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    void Update()
    {
        // On LeftClick, refresh screen
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Capture());
        }
    }

    // Render the camera view and apply it to the canvas
    public IEnumerator Capture()
    {
        canvas.enabled = false;
        yield return new WaitForEndOfFrame(); // Wait to make canvas invisible
        
        Camera cam = GetComponent<Camera>();

        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        
        cam.targetTexture = renderTexture;
        cam.Render();

        yield return new WaitForEndOfFrame(); // Wait until ReadPixels is allowed
        screenShot.ReadPixels(rect, 0, 0);
        screenShot.Apply();

        cam.targetTexture = null;
        RenderTexture.active = null;

        canvasImage.texture = screenShot;
        canvas.enabled = true;
    }
}
