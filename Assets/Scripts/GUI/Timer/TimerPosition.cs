using UnityEngine;
using System.Collections;

public class TimerPosition : MonoBehaviour 
{
  public int topOffset = 10;
  void Start () 
  {
    Rect newPixelInset = new Rect(0,0, guiTexture.pixelInset.width, guiTexture.pixelInset.height);
    newPixelInset.x = Screen.width / 2 - newPixelInset.width / 2;
    newPixelInset.y = Screen.height - newPixelInset.height - topOffset;
    guiTexture.pixelInset = newPixelInset;
  }
}
