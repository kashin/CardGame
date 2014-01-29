using UnityEngine;
using System.Collections;

abstract public class BaseTouchControl : MonoBehaviour
{

    private int touchFingerId = -1;

	void Update ()
    {
        handleTouch();
	}

    void OnMouseUpAsButton()
    {
        // touch can be considered as mouseButton's click on a touch device,
        // so if touch 'is in progress' we should skip mouse events.
        if (Input.touches.Length == 0)
        {
            onControlClicked();
        }
    }

    private void handleTouch()
    {
        for (int i = 0; i < Input.touches.Length; i++)
        {
            Touch touch = Input.touches[i];
            if (guiTexture.HitTest(touch.position))
            {
                if (touch.phase == TouchPhase.Began && touchFingerId == -1)
                {
                    touchFingerId = touch.fingerId;
                } 
                else if (touch.phase == TouchPhase.Ended &&
                         touchFingerId == touch.fingerId)
                {
                    onTouchEnded();
                    touchFingerId = -1;
                }
            }
        }
    }

    abstract protected void onTouchEnded();
    abstract protected void onControlClicked();
}
