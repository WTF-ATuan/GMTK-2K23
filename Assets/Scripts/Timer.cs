using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A timer that can be added as a component
/// </summary>
public class Timer : MonoBehaviour
{
    // fields to be changed and used by methods
    #region Fields

    // timer duration
    float totalSeconds = 0;

    // timer execution
    float elapsedSeconds = 0;
    bool running = false;

    // support for Finished property
    bool started = false;

    #endregion

    /// 
    /// need to add methods next
    ///
	#region Properties
	
	/// <summary>
	/// Sets the duration of the timer the duration can only be set if the timer isn't currently running
	/// </summary>
	/// <value>duration</value>
	public float Duration
    {
		set
        {
			if (!running)
            {
				totalSeconds = value;
			}
		}
	}
	
	/// <summary>
	/// Gets whether or not the timer has finished running this property returns false if the timer has never been started
	/// </summary>
	/// <value>true if finished; otherwise, false.</value>
	public bool Finished
    {
		get { return started && !running; } 
	}
	
	/// <summary>
	/// Gets whether or not the timer is currently running
	/// </summary>
	/// <value>true if running; otherwise, false.</value>
	public bool Running
    {
		get { return running; }
	}

    #endregion

}