using UnityEngine;
using System.Collections;

public class TimersTextBehavior : MonoBehaviour
{
//------------------------------------ PUBLIC MEMBERS ------------------------------------------//
    public int topTextOffset = 40;
    
    public float turnTime = 10.0f;
    
//------------------------------------ PRIVATE MEMBERS ------------------------------------------//
    /// <summary>
    /// The next turn time.
    /// Contains 'left till turn ends' time.
    /// </summary>
    private float nextTurnTime = 0.0f;
	
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
        turnStarts();
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
            // turn is over, so it is time to do something
            if (turnEnded != null)
            {
                turnEnded();
            }
        }
    }
    
    //------------------------------------ CUSTOM METHODS ------------------------------------------//
    /**
     * called when turn is started
     */
    public void turnStarts()
    {
        initTurnTimer();
        updateText();
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
