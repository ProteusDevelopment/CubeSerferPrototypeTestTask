using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrystalUI : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 5f;

    private RectTransform _transform;
    private RectTransform _destintaion;

    public UnityEvent OnDestintaionReached = new UnityEvent();

	private void Awake()
	{
        _transform = GetComponent<RectTransform>();
	}

	void Update()
    {
        if (!_destintaion)
            return;

        _transform.position = Vector3.Lerp(_transform.position, _destintaion.position, _movingSpeed * Time.deltaTime);
        
        if (Vector3.Distance(_transform.position, _destintaion.position) < Random.Range(10, 20))
		{
            OnDestintaionReached.Invoke();
            Destroy(gameObject);
		}
    }

    public void SetRectTransformPosition(Vector3 newPosition)
	{
        _transform.position = newPosition;
	}

    public void SetDestintaion(RectTransform destintaion)
	{
        _destintaion = destintaion;
	}
}
