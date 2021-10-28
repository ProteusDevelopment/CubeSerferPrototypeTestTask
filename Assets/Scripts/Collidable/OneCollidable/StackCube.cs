using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCube : OneCollidable
{
	protected override void OneCollide(PlayerCube playerCube)
	{
		playerCube.PlayerCubesSpawner.SpawnAtTop();
		Destroy(gameObject);
	}
}
