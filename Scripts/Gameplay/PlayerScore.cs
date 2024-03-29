﻿using System.Collections;
using UnityEngine;

public class PlayerScore : MonoBehaviour, ISubscriber, IInitializable
{
    public static PlayerScore Instance;

    public int Score { get; private set; }
    public int LastHitPoint;

    private bool _isInitialized;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
    private void OnEnable()
    {
        if (!_isInitialized)
            return;

        SubscribeAll();
    }
    private void OnDisable()
    {
        UnsubscribeAll();
    }
    public void SubscribeAll()
    {
        GameState.Instance.GameFinished += Save;
    }

    public void UnsubscribeAll()
    {
        GameState.Instance.GameFinished += Save;
    }

    public void Initialize()
    {
        _isInitialized = true;
    }
    public void AddScore(int count)
    {
        if(GameState.Instance.CurrentState == GameState.State.InGame)
        {
            Score += count;
            LastHitPoint = count;
            PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins", 0) + 1));
            Save();
        }
    }
    private void Save()
    {
        if(PlayerPrefs.GetInt("HighScore", 0) < Score)
            PlayerPrefs.SetInt("HighScore", Score);
    }
}