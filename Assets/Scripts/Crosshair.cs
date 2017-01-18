using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public bool wyswietlicCrosshair = true;


    void OnGUI()
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (wyswietlicCrosshair)
        {
            Vector3 mousePos = Input.mousePosition;
            GUI.DrawTexture(new Rect(mousePos.x - 13, Screen.height - (mousePos.y + 1) - 13, 27, 27), crosshairTexture);
        }
    }


}
