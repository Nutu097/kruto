using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public GameState currentGameState { get; private set; } = GameState.SYSTEM;
	public Event_Bus _eventBus { get; private set; }
	[SerializeField] private ManagerUi _managerUi;
	[SerializeField] private my_input_manger _inputManager;
	

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(this);
		Instance = this;
		
		_eventBus = new Event_Bus();
		_inputManager.Initialized(_eventBus);
		_managerUi.Init(_eventBus);
		_eventBus.GameChangeRequest += ChangeGameState;
		ChangeGameState(GameState.MENU);
	}
	private void ChangeGameState(GameState newState)
	{
		if (currentGameState == newState) return;
		switch(newState)
		{
			case GameState.GAME:
				OnChangeScene(scene.GAME);
				break;
			case GameState.MENU:
				OnChangeScene(scene.MENU);
				break;
			case GameState.LOADING:
				OnChangeScene(scene.LOADING);
				break;
		}
		currentGameState = newState;
		_eventBus.OnGameStateChangeTrigger(newState);

	}
	private void OnChangeScene(string name)
	{
 	SceneManager.LoadScene(name);
	}
}

public enum GameState
{
	SYSTEM=0,
	GAME=1,
	MENU=2,
	LOADING=3
}

