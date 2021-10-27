using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
	private PlayerCubesSpawner _playerCubesSpawner;

	private void Start()
	{
		_playerCubesSpawner = GetComponentInParent<PlayerCubesSpawner>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("BarrierCube") &&
			Mathf.Abs(collision.collider.transform.position.y - transform.position.y) < transform.localScale.y/2f)
		{
			_playerCubesSpawner.RemovePlayerCube(gameObject);
			transform.parent = null;
			Destroy(gameObject, 2f);
		}
		else if (collision.collider.CompareTag("StackCube"))
		{
			collision.collider.tag = "Untagged";
			_playerCubesSpawner.SpawnAtTop();
			Destroy(collision.collider.gameObject);
		}
	}
}
