using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class WorldUITransaktionStatusPopUp : MonoBehaviour
{
	//Settings
	[SerializeField]
	private GameObject PendingVisual;
	[SerializeField]
	private GameObject FailedVisual;
	[SerializeField]
	private GameObject FinishedVisual;
	[SerializeField]
	private Animation PendingAnimation;


	//Functions
	public void ShowStatus(TransactionEvents.TransactionActions status)
	{
		gameObject.SetActive(true);

		switch (status)
		{
			case TransactionEvents.TransactionActions.Loading:
			case TransactionEvents.TransactionActions.Pending:
				PendingVisual.SetActive(true);
				FailedVisual.SetActive(false);
				FinishedVisual.SetActive(false);
				PendingAnimation.Play();
				
				break;

			case TransactionEvents.TransactionActions.Failed:
				PendingVisual.SetActive(false);
				FailedVisual.SetActive(true);
				FinishedVisual.SetActive(false);
				PendingAnimation.Stop();
				break;

			case TransactionEvents.TransactionActions.Finished:
				PendingVisual.SetActive(false);
				FailedVisual.SetActive(false);
				FinishedVisual.SetActive(true);
				PendingAnimation.Stop();
				break;
		}
	}
	public void Hide()
	{
		gameObject.SetActive(false);
		PendingVisual.SetActive(false);
		FailedVisual.SetActive(false);
		FinishedVisual.SetActive(false);
		PendingAnimation.Stop();
	}


	public void SetLoading()
	{
		ShowStatus(TransactionEvents.TransactionActions.Loading);
	}


	public void SetPending()
	{
		ShowStatus(TransactionEvents.TransactionActions.Pending);
	}


	public void SetFailed()
	{
		ShowStatus(TransactionEvents.TransactionActions.Failed);
	}


	public void SetFinished()
	{
		ShowStatus(TransactionEvents.TransactionActions.Finished);
	}
}
