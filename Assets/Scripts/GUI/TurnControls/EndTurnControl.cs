using UnityEngine;
using System.Collections;

public class EndTurnControl : MonoBehaviour
{
    public delegate void turnEndedEvent();
    public event turnEndedEvent turnEnded;

	void Start()
    {
        Rect newPixelInset = new Rect(0,0, guiTexture.pixelInset.width, guiTexture.pixelInset.height);
        newPixelInset.x = Screen.width - newPixelInset.width;
        newPixelInset.y = 0;
        guiTexture.pixelInset = newPixelInset;
	}

	void Update()
    {
    }

    void OnMouseUpAsButton()
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
