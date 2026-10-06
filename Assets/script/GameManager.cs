using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public GameState currentGameState { get; private set; } = GameState.SYSTEM;
	public Event_Bus eventBus { get; private set; }
	[SerializeField] private my_input_manger inputManager;

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(this);
		Instance = this;
		
		eventBus = new Event_Bus();
		inputManager.Initialized(eventBus);
		OnChangeScene(scene.GAME);
	}
	private void ChangeGameState(GameState newState)
	{
		if (currentGameState == newState) return;

		currentGameState = newState;
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

