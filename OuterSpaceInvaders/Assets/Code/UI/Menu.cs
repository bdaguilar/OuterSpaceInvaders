using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Button _pauseBattleButton;

    private void Awake()
    {
        _pauseBattleButton.onClick.AddListener(PauseBattle);
    }

    private void PauseBattle()
    {
        //ServiceLocator.Instance.GetService<IGameFacade>().PauseBattle();
        //gameObject.SetActive(false);
    }
}

