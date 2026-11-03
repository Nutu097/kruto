using UnityEngine;

public class graund_detector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance = 0.1f;
    [SerializeField] private Transform _groundCheckTransform;



    public bool IsGrounded()
	{
		return Physics.OverlapSphere(_groundCheckTransform.position, _groundCheckDistance, _groundLayer).Length > 0;
	}
}
