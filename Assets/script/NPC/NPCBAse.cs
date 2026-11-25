using UnityEditorInternal;
using UnityEngine;

public abstract class NPCBAse : MonoBehaviour
{
  public NPCType _Type { get; private set; }
  public NPCName _Name { get; private set; }
	public  virtual void Initialize(NPSStats stats)
	{
		_Type = stats.Type;
		_Name = stats.Name;
	}
	protected abstract void OnTickAi(float deltaTime);
	protected abstract void OnTickPhisycs(float deltaTime);
	protected abstract void OnTickAnim(float deltaTime);
	private void Update()
	{
		OnTickAi(Time.deltaTime);
	}
	private void FixedUpdate()
	{
	OnTickPhisycs(Time.fixedDeltaTime);
	}
	private void LateUpdate()
	{
		OnTickAnim(Time.deltaTime);
	}
}
