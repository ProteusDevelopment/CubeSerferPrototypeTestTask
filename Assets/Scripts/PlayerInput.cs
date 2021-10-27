using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	[SerializeField] private float _floorWidth = 3f;
	[SerializeField] private float _sensivitivity = 1f;

    private float _lastMousePositionX;

	private void Update()
	{
		if (Input.anyKeyDown)
		{
			_lastMousePositionX = Input.mousePosition.x;
		}
		else if (Input.anyKey)
		{
			Vector3 newPosition = transform.position + new Vector3(_sensivitivity * (Input.mousePosition.x - _lastMousePositionX) * Time.deltaTime, 0, 0);
			float floored = Mathf.Floor(_floorWidth / 2);
			newPosition.x = Mathf.Clamp(newPosition.x, -floored, floored);
			transform.position = newPosition;
			_lastMousePositionX = Input.mousePosition.x;
		}
	}
}
