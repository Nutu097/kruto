using UnityEngine;

public class candle : BaseInteracteble
{
    [SerializeField] private ParticleSystem _flame;
    [SerializeField] private GameObject _Light;
	private bool _isLit ;
    protected override void OnInteract(GameObject gameObject)
    {
        base.OnInteract(gameObject);
        
		if (!_isLit)
        {
			_flame.Play();
			
        }
        else
        {
			_flame.Stop();
		}
		_isLit = !_isLit;
		_Light.SetActive(_Light);
	}
}
