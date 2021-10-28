using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : OneCollidable
{
	[SerializeField] private int _crystalAmount = 1;

	public int CrystalAmount => _crystalAmount;

	protected override void OneCollide(PlayerCube playerCube)
	{
		PlayerCrystals.Instance.AddCrystal(this);
		Destroy(gameObject);
	}
}
