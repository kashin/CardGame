using UnityEngine;
using System.Collections;

public class MainControlsPlate : MonoBehaviour
{
    public Vector2 plateAutoSize = new Vector2(1.0f, 0.25f);

	void Start()
    {
        if (guiTexture != null)
        {
            Rect newPixelInset = new Rect(0, 0, Screen.width * plateAutoSize.x, Screen.height * plateAutoSize.y);
            guiTexture.pixelInset = newPixelInset;
        }
    }
}
