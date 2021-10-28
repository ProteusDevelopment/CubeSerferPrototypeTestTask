using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OneCollidable : Collidable
{
	private bool _isCollide = false;

	public override void Collide(PlayerCube playerCube)
	{
		if (_isCollide)
			return;
		_isCollide = true;

		OneCollide(playerCube);
	}

	protected abstract void OneCollide(PlayerCube playerCube);
}
