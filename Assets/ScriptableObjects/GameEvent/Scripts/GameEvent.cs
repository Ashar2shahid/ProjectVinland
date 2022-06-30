using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvent/GameEvent")]
public class GameEvent : ScriptableObject
{
	//Globals
	public event Action Event;


	//Functions
	public void Invoke()
	{
		Event?.Invoke();
	}
}
