using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubesController : MonoBehaviour
{
    [SerializeField] private GameObject _playerCubePrefab;
    [SerializeField] private int _startPlayerCubesCount = 3;

    private List<GameObject> _playerCubes = new List<GameObject>();

    void Start()
    {
        // Spawn first cube.
        _playerCubes.Add(Instantiate(_playerCubePrefab, Vector3.zero, Quaternion.identity, transform));

        for (int i = 1; i < _startPlayerCubesCount; i++)
        {
            SpawnAtTop();
        }
    }

    public void SpawnAtTop()
	{
        Transform lastPlayerCube = _playerCubes[_playerCubes.Count - 1].transform;
        GameObject spawnedPlayerCube = Instantiate(_playerCubePrefab);
        spawnedPlayerCube.transform.SetParent(transform);
        spawnedPlayerCube.transform.localPosition = new Vector3(
            lastPlayerCube.localPosition.x,
            lastPlayerCube.localPosition.y + _playerCubePrefab.transform.localScale.y,
            lastPlayerCube.localPosition.z
        );
        _playerCubes.Add(spawnedPlayerCube);
    }

    public void RemovePlayerCube(GameObject gameObjectToRemove)
	{
        _playerCubes.Remove(gameObjectToRemove);

        if (_playerCubes.Count == 0)
        {
            print("Game over!");
            Destroy(gameObject.GetComponent<PlayerMover>());
        }
	}
}
