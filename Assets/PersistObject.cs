using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistObject : MonoBehaviour
{
    [SerializeField] private GameObject inventory;

    private void Awake()
    {
        DontDestroyOnLoad(inventory);
    }

    private void Update() {
        Scene scene = SceneManager.GetActiveScene();
        
        if (scene.name == "CutsceneBossIntro")
        {
            Destroy(inventory);
        } 
    }
}
