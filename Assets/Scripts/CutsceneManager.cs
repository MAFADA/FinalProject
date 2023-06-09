using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    public PlayableDirector playableDirector;
    private void Start()
    {
        playableDirector.stopped += OnCutsceneFinished;
        // Subscribe to the cutscene finish event or animation event that indicates the end of the cutscene
        // Example: cutsceneTimeline.onFinished += LoadNextScene;
    }

    private void OnCutsceneFinished(PlayableDirector director)
    {
        // Load the next scene using the SceneManager
        SceneManager.LoadScene(nextSceneName);
    }
}
