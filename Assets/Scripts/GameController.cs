using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    private bool _hasWon, _hasLost;
    private float timer;
    public string currentLevel;

    public AudioSource[] audioData;
    //public List<GameObject> keepSake;

    public CanvasGroup winScreen, lossScreen;
    public float fadeDuration, imageDuration;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this);
        }

        /*foreach (GameObject gobj in keepSake)
        {
            DontDestroyOnLoad(gobj);
        }*/

        currentLevel = "Level1";
    }


    void Start() 
    {
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

    public void EndLevel(CanvasGroup canvas) 
    {

        timer += Time.deltaTime;
        canvas.alpha = timer/fadeDuration;

        if (timer > fadeDuration + imageDuration)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void LevelTransition(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            currentLevel = sceneName;
            SceneManager.LoadScene(sceneName);
        }
    }
/*
    [ContextMenu("LevelTest")]
    public void test()
    {
        LevelTransition("Level2");*/
    //}
}
