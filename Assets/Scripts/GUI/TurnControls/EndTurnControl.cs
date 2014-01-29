using UnityEngine;
using System.Collections;

public class EndTurnControl : BaseTouchControl
{
    public delegate void turnEndedEvent();
    public event turnEndedEvent turnEnded;
    public float bottomAutoOffset = 0.7f;

	void Start()
    {
        Rect newPixelInset = new Rect(0,0, guiTexture.pixelInset.width, guiTexture.pixelInset.height);
        newPixelInset.x = Screen.width - newPixelInset.width;
        newPixelInset.y = Screen.height * bottomAutoOffset;
        guiTexture.pixelInset = newPixelInset;
	}

    protected override void onTouchEnded()
    {
        fireTurnEnded();
    }

    protected override void onControlClicked()
    {
        fireTurnEnded();
    }

    private void fireTurnEnded()
    {
        if (turnEnded != null)
        {
            turnEnded();
        }
    }
}
