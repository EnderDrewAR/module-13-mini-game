using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] private float _gameTime = 60f;
    [SerializeField] private int _totalCoinsToCollect = 10;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _collectedCoinsText;
    
    private float _currentTime;
    private float _totalTime = 0f;
    private Coin[] _coins;
    private bool _gameEnded = false;

    private void Awake()
    {
        _currentTime = _gameTime;
        _coins = FindObjectsOfType<Coin>();
        
        if (_totalCoinsToCollect == 0 && _coins.Length > 0)
            _totalCoinsToCollect = _coins.Length;
    }

    private void Update()
    {
        if (_gameEnded) 
            return;

        _currentTime -= Time.deltaTime;
        
        UpdateUI();
        
        if (_currentTime <= 0f)
        {
            _currentTime = 0f;
            EndGame(false);
            return;
        }
        
        if (_player.CollectedCoins >= _totalCoinsToCollect)
            EndGame(true);
    }

    private void UpdateUI()
    {
        _timerText.text = "time: " + _currentTime.ToString("F1");
        _collectedCoinsText.text = "Coins: " + _player.CollectedCoins.ToString();
    }

    private void EndGame(bool isWin)
    {
        _gameEnded = true;
        if (isWin)
        {
            Win();
        }
        else
        {
            Lose(); 
        }
    }
    
    private void Win()
    {
        Debug.Log("ПОБЕДА");
        Debug.Log($"Вы собрали все монеты за {_gameTime - _currentTime:F1} секунд!");
        Debug.Log($"Всего собрано: {_player.CollectedCoins} монет");
    }

    private void Lose()
    {
        Debug.Log("ПОРАЖЕНИЕ");
        Debug.Log("Время вышло!");
        Debug.Log($"Собрано монет: {_player.CollectedCoins} из {_totalCoinsToCollect}");
    }

}
