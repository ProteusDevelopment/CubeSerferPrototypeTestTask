using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCrystals : MonoBehaviour
{
    public static PlayerCrystals Instance;

	[SerializeField] private Transform _crystalsUIParent;
	[SerializeField] private CrystalUI _crystalUIPrefab;
	[SerializeField] private Text _crystalsText;

	private int _playerLevelCrystals = 0;

	private void Awake()
	{
		Instance = this;

		UpdateCrystalsText();
	}

	public void AddCrystal(Crystal crystal)
	{
		var crystalAmount = crystal.CrystalAmount;

		var creaedCrystalUI = Instantiate(_crystalUIPrefab, _crystalsUIParent);
		creaedCrystalUI.SetRectTransformPosition(Camera.main.WorldToScreenPoint(crystal.transform.position));
		creaedCrystalUI.SetDestintaion(_crystalsText.rectTransform);
		creaedCrystalUI.OnDestintaionReached.AddListener(() =>
		{
			_playerLevelCrystals += crystalAmount;
			UpdateCrystalsText();
		});
	}

	private void UpdateCrystalsText()
	{
		_crystalsText.text = _playerLevelCrystals.ToString();
	}
}
