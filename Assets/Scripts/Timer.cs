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
}