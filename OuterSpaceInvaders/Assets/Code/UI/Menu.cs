using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	[SerializeField]
	private Button _startBattleButton;
	[SerializeField]
	private Button _stopBattleButton;

    private void Awake()
    {
        _startBattleButton.onClick.AddListener(StartBattle);
        _stopBattleButton.onClick.AddListener(StopBattle);
    }

    private void StopBattle()
    {
        ServiceLocator.Instance.GetService<IGameFacade>().StopBattle();
    }

    private void StartBattle()
    {
        ServiceLocator.Instance.GetService<IGameFacade>().StartBattle();
    }
}

