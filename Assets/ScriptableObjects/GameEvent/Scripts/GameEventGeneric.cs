using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GameEvent<T> : ScriptableObject
{
	//Globals
	public event System.Action<T> Event;


	//Functions
	public void Invoke(T value)
	{
		Event?.Invoke(value);
	}
}
