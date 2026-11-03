using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
   [SerializeField] private Transform _cameraPivot;
   [SerializeField] private float lastActionTime;
	[SerializeField] private float _rotationSpeed = 5f;
   [SerializeField] private float _maxPitch = 80f;
   [SerializeField] private float _maxCameraYaw = 60f;
   [SerializeField] private float _returnSpeed = 3f;
   [SerializeField] private float _returnDelay = 2000f;
	private float _currentRotationX;
	private float _currentRotationY;
	private float rotationX;
	private float rotationY;
	private void Start()
	{
		Vector3 angle = _cameraPivot.localEulerAngles;

		rotationX = angle.x > 0 ? angle.x - 360 : angle.x;
		rotationY = angle.y > 0 ? angle.y - 360 : angle.y;
	}
	public void RotateCamera(Vector2 input)
	{
		if (input.sqrMagnitude < 0.1f) return;
		
	
		rotationX -= input.y * _rotationSpeed ;
		rotationY += input.x * _rotationSpeed;
		rotationX = Mathf.Clamp(rotationX, -_maxCameraYaw, _maxCameraYaw);
		rotationY = Mathf.Clamp(rotationY, -_maxPitch, _maxPitch);
		lastActionTime = Time.time;

		//_cameraPivot.localRotation = Quaternion.Euler(_currentRotationX + rotationX, _currentRotationY + rotationY, 0f);
	}
	private void LateUpdate()
	{
	Vector3 Target = new Vector3(rotationX, rotationY, 0f);
		_cameraPivot.localRotation = Quaternion.Euler(Target);
	}
	private void Update()
	{
		if (Time.time - lastActionTime  > _returnDelay)
		{
			rotationX = Mathf.Lerp(rotationX, 0f, Time.deltaTime * _returnSpeed);
			rotationY = Mathf.Lerp(rotationY, 0f, Time.deltaTime * _returnSpeed);
		}
	}
}
