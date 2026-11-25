using UnityEngine;

public abstract class BaseInteracteble : MonoBehaviour, IInteractable
{

	public void Interact(GameObject go)
    {
    OnInteract(go);
	}
    protected virtual void OnInteract(GameObject go)
	{

	}


    /// <summary>
    /// /////////////////
    /// </summary>
   

	public bool CanInteract(GameObject go)
    {
    return CanInteractInternal(go);
	}
    protected virtual bool CanInteractInternal(GameObject go)
    {
        return true;
    }

}
