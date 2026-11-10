using UnityEngine;

public class MainMenuButton : defoltButton
{
	protected override void Initialize()
	{
		base.Initialize();
	}
	protected override void SandPayLoad()
	{
	event_Bus.OnButtonClickTrigger(_Type);
		base.SandPayLoad();
	}
}
