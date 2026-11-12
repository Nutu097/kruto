using UnityEngine;
using UnityEngine.UI;

public class ManagerUi : MonoBehaviour
{
	public Event_Bus _eventBus { get; private set; }
	public UiState _currentUiState { get; private set; } = UiState.SYSTEM;
	public void Init(Event_Bus eventBus)
	{
		_eventBus = eventBus;
		_eventBus.OnButtonClick += GetButtonTypes;
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
			UiChangeRequest(UiState.GAME);
				break;
			case UiState.MENU:
				UiChangeRequest(UiState.MENU);
				break;
			case UiState.LOADING:
				UiChangeRequest(UiState.LOADING); 
				break;
		}
		_currentUiState = newState;
		_eventBus.OnUiStateChangeTrigger(newState);
	}
	private void GetButtonTypes(ButtonType buttonType)
	{
	GameState state = GameManager.Instance.currentGameState;
		switch (buttonType)
		{
			case ButtonType.GAME:
			if (state == GameState.MENU)
			{
			_eventBus.OnGameChangeRequestTrigger(GameState.GAME);
				}
				break;
			case ButtonType.MENU:
				break;
			case ButtonType.SETTINGS:
			UiChangeRequest(UiState.SYSTEM); 
				break;
		}
	}
	
}
public enum UiState
{
	SYSTEM = 0,
	GAME = 1,
	MENU = 2,
	LOADING = 3
}