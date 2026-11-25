using DG.Tweening;
using UnityEngine;

public class Door : BaseInteracteble
{
	[SerializeField] private Transform _pivotPoint;
	[SerializeField] private float _rotationTime = 1.5f;
	private bool _isOpen = false;
	private Tween Tween;
	private Ease _rotation = Ease.OutBack;
	[SerializeField] private float _openRotation = 90f;


	protected override void OnInteract(GameObject gameObject)
	{

		base.OnInteract(gameObject);
		AnimateDoor(!_isOpen);
		_isOpen = !_isOpen;
	}
	private void AnimateDoor(bool isOpen)
	{
		float rotationTarget = 0f;
		if (!isOpen)
		{
			rotationTarget = _openRotation;
		}
		Tween?.Kill();
		Tween = _pivotPoint.DOLocalRotate(new Vector3(0f, rotationTarget, 0f), _rotationTime).SetEase(_rotation);
		
	}
	protected override bool CanInteractInternal(GameObject gameObject)
	{
		Debug.Log("Door Can Interact");
		return base.CanInteractInternal(gameObject);
	}
}
