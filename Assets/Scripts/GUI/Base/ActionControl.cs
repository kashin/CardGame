using UnityEngine;
using System.Collections;

public class ActionControl : BaseTouchControl
{
    public delegate void actionPressed(ActionControl action);
    public event actionPressed actionPressedEvent;

//------------------------------------ PUBLIC MEMBERS ------------------------------------------//
    public GameObject actionGameOnject = null;
    public ActionStats actionStats = null;
    public bool playersAction = true;
    public StatsPanel statsPanel = null;

//------------------------------------ PRIVATE MEMBERS ------------------------------------------//
    private PlayerStats playerStats = null;
    private CharacterStats enemyStats = null;

//------------------------------------ MONOBEHAVIOR ------------------------------------------//
    void Start()
    {
        if (actionGameOnject != null)
        {
            actionStats = actionGameOnject.GetComponent<ActionStats>();
        }
        if (actionStats == null)
        {
            Debug.LogWarning("ActionControl: actionStats component is null!");
        }

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerStats = playerObj.GetComponent<PlayerStats>();
        }
        else
        {
            Debug.LogWarning("ActionControl: Player object is not found");
        }

        GameObject enemyObj = GameObject.FindGameObjectWithTag("Enemy");
        if (enemyObj != null)
        {
            enemyStats = enemyObj.GetComponent<CharacterStats>();
        }
        else
        {
            Debug.LogWarning("ActionControl: Enemy object is not found");
        }
        if (actionStats == null)
        {
            actionStats = gameObject.GetComponent<ActionStats>();
        }

        GameObject statsPanelObj = GameObject.FindGameObjectWithTag("StatsPanel");
        if (statsPanelObj != null)
        {
            statsPanel = statsPanelObj.GetComponent<StatsPanel>();
            actionPressedEvent += statsPanel.onActionPresssed;
        }
        else
        {
            Debug.LogWarning("ActionControl: StatsPanel object is not found");
        }
    }

    protected override void onTouchEnded()
    {
        onPressed();
    }

    protected override void onControlClicked()
    {
        onPressed();
    }

    protected void onPressed()
    {
        if (actionPressedEvent != null)
        {
            actionPressedEvent(this);
        }
    }

    protected void performAction()
    {
        if (playersAction)
        {
            enemyStats.applyHealthChange(actionStats.Damage);
        }
        else
        {
            playerStats.applyHealthChange(actionStats.Damage);
        }
    }
}
