using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCube : Collidable
{
	public override void Collide(PlayerCube playerCube)
	{
		if (Mathf.Abs(transform.position.y - playerCube.transform.position.y) < playerCube.transform.localScale.y / 2f)
		{
			playerCube.RemoveFromParent();
			Destroy(playerCube.gameObject, 3f);
		}
	}
}
