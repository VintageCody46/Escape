﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    private bool _hasWon, _hasLost;
    private float timer;

    public AudioSource[] audioData;

    public CanvasGroup winScreen, lossScreen;
    public float fadeDuration, imageDuration;

    // Start is called before the first frame update
    void Awake()
    {
      if (Instance == null) {
        Instance = this;
      } else {
        Destroy(this);
      }
    }


    void Start() {
      audioData = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

      if (_hasWon) {
        EndLevel(winScreen);
      }

      else if (_hasLost) {

        EndLevel(lossScreen);
      }

    }


    public void WinGame() {

      if (!_hasWon) {
        audioData[1].Play(0);
      }

      _hasWon = true;
    }

    public void LoseGame() {

      if (!_hasLost) {
        audioData[0].Play(0);
      }

      _hasLost = true;
    }

    public void EndLevel(CanvasGroup canvas) {

      timer += Time.deltaTime;
      canvas.alpha = timer/fadeDuration;

      if (timer > fadeDuration + imageDuration) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
    }

    public event Action onAlertTriggered;

    public void AlertTriggered() {

      if (onAlertTriggered != null) {
        onAlertTriggered();
      }
    }
}