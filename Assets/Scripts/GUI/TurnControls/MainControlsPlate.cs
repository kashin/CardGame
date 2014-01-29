using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainControlsPlate : MonoBehaviour
{
//------------------------------------ PUBLIC MEMBERS ------------------------------------------//
    public Vector2 plateAutoSize = new Vector2(1.0f, 0.25f);
    public GameObject[] actions; // contains all actions that could be shown on an actions bar.
    public int actionsMaximum = 10;
    public float actionsLeftAutoOffset = 0.15f;
    public float spaceBetweenActions = 0.05f; // percentage of actions bar's width.

//------------------------------------ PRIVATE MEMBERS ------------------------------------------//
    private Vector2 actionSize = new Vector2(0, 0);
    private int actionsLeftOffset = 0;
    private System.Collections.Generic.List<GameObject> shownActionObjects = new System.Collections.Generic.List<GameObject>();

	void Start()
    {
        if (guiTexture != null)
        {
            Rect newPixelInset = new Rect(0, 0, Screen.width * plateAutoSize.x, Screen.height * plateAutoSize.y);
            guiTexture.pixelInset = newPixelInset;
            actionsLeftOffset = Mathf.FloorToInt(guiTexture.pixelInset.width * actionsLeftAutoOffset);
            actionSize.x = (newPixelInset.width - actionsLeftOffset * 2) / (actionsMaximum / 2);
            actionSize.y = (newPixelInset.height - 3 * newPixelInset.height * spaceBetweenActions) / 2;
            createAndPlaceActions();
        }
    }

    void Update()
    {
    }

    private void createAndPlaceActions()
    {
        // create and set a proper positions for initial actions.
        for (int i = 0; i < actions.Length && i < actionsMaximum; i++)
        {
            if (actions[i] != null)
            {
                GameObject createdAction = (GameObject)Instantiate(actions[i]);
                shownActionObjects.Add(createdAction);
                createdAction.transform.parent = gameObject.transform;
                Rect actionPixelInset = new Rect(actionsLeftOffset, spaceBetweenActions * guiTexture.pixelInset.height, actionSize.x, actionSize.y);
                createdAction.guiTexture.pixelInset = actionPixelInset;
            }
        }
    }
}
