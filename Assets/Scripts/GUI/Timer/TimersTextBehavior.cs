using UnityEngine;
using System.Collections;

public class TimersTextBehavior : MonoBehaviour
{
//------------------------------------ PUBLIC MEMBERS ------------------------------------------//
    public int topTextOffset = 40;
    public float turnTime = 10.0f;

    public EndTurnControl endTurnButton;
    
//------------------------------------ PRIVATE MEMBERS ------------------------------------------//
    /// <summary>
    /// The next turn time.
    /// Contains 'left till turn ends' time.
    /// </summary>
    private float nextTurnTime = 0.0f;

    private bool turnEndedFired = false;
	
//------------------------------------ DELEGATES ------------------------------------------//
    /**
     * called when timer 
     */
    public delegate void turnEndedEvent();
    
    public event turnEndedEvent turnEnded;
        
//------------------------------------ MONOBEHAVIOR ------------------------------------------//
    void Start()
    {
        // TODO: add some smart way to find the right Y text's position.
        Vector2 newPixelOffset = new Vector2(Screen.width / 2, Screen.height - topTextOffset);
        guiText.pixelOffset = newPixelOffset;
        onTurnStarts();
        if (endTurnButton != null)
        {
            endTurnButton.turnEnded += onTurnEnded;
        }
	  }
    
    void Update()
    {
        if (Time.time < nextTurnTime)
        {
            //just update timer's text
            updateText();
        }
        else
        {
          if (!turnEndedFired)
          {
              // turn is over, so it is time to do something
              if (turnEnded != null)
              {
                  turnEnded();
              }
              turnEndedFired = true;
          }
        }
    }
    
    //------------------------------------ CUSTOM METHODS ------------------------------------------//
    /**
     * called when turn is started
     */
    public void onTurnStarts()
    {
        initTurnTimer();
        updateText();
        turnEndedFired = false;
    }

    /**
     * called when turn is ended.
     * We just want to stop our timer till next turn is started.
     */
    public void onTurnEnded()
    {
        nextTurnTime = 0.0f;
        turnEndedFired = true;
    }
    
    /**
     * initialize turn timer
     */
    private void initTurnTimer()
    {
        nextTurnTime = Time.time + turnTime; 
    }
    
    /**
     * updates text and sets it to 'time left till turnEnded even is fired' seconds.
     */
    private void updateText()
    {
        int secondsLeft = Mathf.FloorToInt( nextTurnTime - Time.time) + 1;
        guiText.text = secondsLeft.ToString();
    }
}
