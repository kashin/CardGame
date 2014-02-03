using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatsPanel : MonoBehaviour
{
    public delegate void onAddActionError(ActionControl action);
    public event onAddActionError addActionError;
//------------------------------------ PUBLIC MEMBERS ------------------------------------------//
    public Vector2 panelAutoSize = new Vector2(0.15f, 0.25f);
    public PlayerStats playerStats = null;
    public GUIText actionPointsText = null;
    public float elementsSpace = 5.0f;

    public string availableActionPointsString = " AP";

//------------------------------------ PRIVATE MEMBERS ------------------------------------------//
    // actions that are selected for a current turn.
    private System.Collections.Generic.List<ActionControl> selectedActions = new System.Collections.Generic.List<ActionControl>();

    // available Action Points.
    private int maxActionPoints = 10;
    private int usedActionPoints = 10;

//------------------------------------ MONOBEHAVIOR ------------------------------------------//
    void Start()
    {
        if (guiTexture != null)
        {
            Rect newPixelInset = new Rect(0, 0, Screen.width * panelAutoSize.x, Screen.height * panelAutoSize.y);
            guiTexture.pixelInset = newPixelInset;
        }
        else
        {
            Debug.LogWarning("StatsPanel: guiTexture is not found");
        }
        updateTexts();
        updateTextPositions();
    }

//------------------------------------ CUSTOM METHODS ------------------------------------------//
    public void onActionPresssed(ActionControl action)
    {
        addAction(action);
    }

    private void addAction(ActionControl action)
    {
        if (usedActionPoints - action.actionStats.ActionPoints >= 0)
        {
            selectedActions.Add(action);
            usedActionPoints -= action.actionStats.ActionPoints;
            updateTexts();
        }
        else if (addActionError != null)
        {
            addActionError(action);
        }
    }

    private void updateTexts()
    {
        actionPointsText.text = usedActionPoints.ToString() + " / " + maxActionPoints.ToString() + availableActionPointsString;
    }

    private void updateTextPositions()
    {
        Rect textRect = actionPointsText.GetScreenRect();
        Vector2 newPixelOffset = new Vector2(elementsSpace, guiTexture.pixelInset.height - elementsSpace - textRect.height);
        actionPointsText.pixelOffset = newPixelOffset;
    }
}
