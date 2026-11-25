using UnityEngine;

public class NPCInteractor : BaseInteracteble
{
[SerializeField] private NPC _main;
	protected override void OnInteract(GameObject gameObject)
	{
		base.OnInteract(gameObject);
		Debug.Log($"{_main.name}: Interacted with NPC");
	}
}
