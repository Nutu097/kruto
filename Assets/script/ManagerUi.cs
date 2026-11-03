using UnityEngine;

public class ManagerUi : MonoBehaviour
{
	public Event_Bus _eventBus { get; private set; }
	public UiState _currentUiState { get; private set; } = UiState.SYSTEM;
	public void Init(Event_Bus eventBus)
	{
		_eventBus = eventBus;
		_eventBus.UiChangeRequest += UiChangeRequest;
		_eventBus.OnGameStateChanged += OnGameStateChanged;
	}
	
	private void OnGameStateChanged(GameState newState)
	{
		switch (newState)
		{
			case GameState.GAME:
				break;
			case GameState.MENU:
				break;
			case GameState.LOADING:
				break;
		}
	}
	private void UiChangeRequest(UiState newState)
	{
		if (_currentUiState == newState) return;
		switch (newState)
		{
			case UiState.GAME:
				break;
			case UiState.MENU:
				break;
			case UiState.LOADING:
				break;
		}
		_currentUiState = newState;
		_eventBus.OnUiStateChangeTrigger(newState);
	}
}
public enum UiState
{
	SYSTEM = 0,
	GAME = 1,
	MENU = 2,
	LOADING = 3
}