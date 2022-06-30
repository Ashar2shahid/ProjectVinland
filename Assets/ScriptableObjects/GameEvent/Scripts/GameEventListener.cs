using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour
{
	public GameEvent gameEvent;
	public UnityEvent response;


	private void OnEnable()
	{
		gameEvent.Event += response.Invoke;
	}

	private void OnDisable()
	{
		gameEvent.Event -= response.Invoke;
	}
}
