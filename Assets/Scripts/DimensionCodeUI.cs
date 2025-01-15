using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

[Serializable]
public struct Dimension {
    [Tooltip("Code")]
    public string code;
    [Tooltip("Path to scene file")]
    public string scenePath;
}

public class DimensionCodeUI : MonoBehaviour
{
    private string code = "";

    public int codeDigits = 3;
    public Dimension[] dimensions;
    public TMPro.TextMeshProUGUI codeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        codeText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // Detect keys and numpad presses
        for (int i = 0; i <= 9; i++) {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + i)) || Input.GetKeyDown((KeyCode)((int)KeyCode.Keypad0 + i))) {
                OnDigitPress(i);
                break;
            }
        }
    }

    void OnDigitPress(int digit) {
        code += digit.ToString();
        codeText.text = code;
        // If code is right amount of digits, check if it matches any dimension to switch to
        if (code.Length >= codeDigits) {
            foreach (Dimension dimension in dimensions) {
                if (dimension.code == code) {
                    Debug.Log("Loading scene: " + dimension.scenePath);
                    SceneManager.LoadScene(dimension.scenePath);
                    return;
                }
            }
            code = "";
            codeText.text = "Invalid Code";
            Invoke("ClearText", 1);
        }
    }

    void ClearText() {
        codeText.text = "";
    }
}
