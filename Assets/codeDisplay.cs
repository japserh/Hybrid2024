using UnityEngine;

public class codeDisplay : MonoBehaviour
{
    public LaserScript laserScript;
    public GameObject code;

    private void FixedUpdate()
    {
        ShowCode();
    }

    public void ShowCode()
    {
        code.SetActive(laserScript.goalHit);
    }
  
}
