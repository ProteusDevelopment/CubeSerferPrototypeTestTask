using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
	private PlayerCubesController _playerCubesSpawner;

	public PlayerCubesController PlayerCubesSpawner => _playerCubesSpawner;

	private void Start()
	{
		_playerCubesSpawner = GetComponentInParent<PlayerCubesController>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.TryGetComponent<Collidable>(out var collidable))
		{
			collidable.Collide(this);
		}
	}
	
	public void RemoveFromParent()
	{
		_playerCubesSpawner.RemovePlayerCube(gameObject);
		transform.parent = null;
	}
}
