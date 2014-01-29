using UnityEngine;
using System.Collections;

public class ActionControl : MonoBehaviour
{
    public GameObject actionGameOnject = null;
    public ActionStats actionStats = null;

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
    }
}
