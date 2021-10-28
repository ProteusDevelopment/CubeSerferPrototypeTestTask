using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiveFloor : Collidable
{
	[SerializeField] private float _destructTime = 2f;

	private float _destructTimer = 0;

	private void Update()
	{
		_destructTimer += Time.deltaTime;
	}

	public override void Collide(PlayerCube playerCube)
	{
		if (_destructTimer < _destructTime)
			return;

		_destructTimer = 0f;
		playerCube.RemoveFromParent();
		Destroy(playerCube.gameObject);
	}
}
