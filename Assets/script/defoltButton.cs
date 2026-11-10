using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class defoltButton : MonoBehaviour
{
	[SerializeField] private Button _button;
	[SerializeField] private TMP_Text _text;
	[SerializeField] protected ButtonType _Type;
	protected Event_Bus event_Bus;
	
	private void Awake()
	{
		Initialize();
	}
	protected virtual void Initialize()
	{
		event_Bus = GameManager.Instance._eventBus;
		_button.onClick.AddListener(SandPayLoad);
		SetText();
	}
	protected virtual void Deinitialize()
	{
		
		_button.onClick.RemoveListener(SandPayLoad);
	}
	private void OnDestroy()
	{
		Deinitialize();
	}
	private void SetText()
	{
		_text.text = _Type.ToString();
	}
	protected virtual void SandPayLoad()
	{
		
	}
	
	
}
public enum ButtonType
{
	GAME=1,
	MENU=2,
	SETTINGS=3	
}
