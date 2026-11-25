using UnityEngine;

public class INTERACTOR : MonoBehaviour
{

	[SerializeField] private float _interactDistance = 3f;
	[SerializeField] private LayerMask _interactableLayer;
	[SerializeField] private Transform _interactPoint;

	private IInteractable _interactable;

	private void Update()
	{
		CheckForInteractable();
	}

	private void CheckForInteractable()
	{
		
		Collider[] colliders = Physics.OverlapSphere(_interactPoint.position, _interactDistance, _interactableLayer);
		if (colliders.Length > 0)
		{
			if (colliders[0].TryGetComponent(out IInteractable interactable))
			{
				_interactable = interactable;
			}
			else
			{
				_interactable = null;
			}
		}
		else
		{
			_interactable = null;
		}
	}


	public void GetInteractInput()
	{
		_interactable?.Interact(gameObject);
	}


}



