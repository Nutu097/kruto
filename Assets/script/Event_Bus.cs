using System;
using UnityEngine;

public class Event_Bus 
{
	public event Action<Vector2> OnMovePressed;
	public event Action OnSpacePressed;
	public event Action<bool> OnAttackPressed;
	public event Action<bool> OnShiftPressed;
	public event Action<Vector2> OnLookPressed;
	public event Action <GameState> OnGameStateChanged;
	public event Action <GameState> GameChangeRequest;
	public event Action<UiState> OnUiStateChanged;
	
	public event Action<ButtonType> OnButtonClick;
	public event Action OnInteractPressed;


	public void TriggerMove(Vector2 data)
	{
		OnMovePressed?.Invoke(data);
	}

	public void OnSpaceTrigger()
	{
		OnSpacePressed?.Invoke();
	}

	public void OnShiftTrigger(bool isPressed)
	{
		OnShiftPressed?.Invoke(isPressed);
	}
	public void OnInteractTrigger( )
	{
		OnInteractPressed?.Invoke();
	}
	public void OnAttackTrigger(bool isPressed)
	{
		OnAttackPressed?.Invoke(isPressed);
	}

	public void OnLookTrigger(Vector2 data)
	{
		OnLookPressed?.Invoke(data);
	}
	public void OnGameStateChangeTrigger(GameState newState)
	{
		OnGameStateChanged?.Invoke(newState);
	}
	public void OnGameChangeRequestTrigger(GameState newState)
	{
		GameChangeRequest?.Invoke(newState);
	}
	public void OnUiStateChangeTrigger(UiState newState)
	{
		OnUiStateChanged?.Invoke(newState);
	}
	public void OnButtonClickTrigger(ButtonType buttonType)
	{
		OnButtonClick?.Invoke(buttonType);
	}

}   
