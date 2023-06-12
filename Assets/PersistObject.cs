using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistObject : MonoBehaviour
{
    private static PersistObject instance;

    private void Awake()
    {
        if (instance == null)
        {
            // Jika instance masih null, tetapkan instance saat ini ke instance pertama
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Jika instance sudah ada, hancurkan gameObject saat ini
            Destroy(gameObject);
        }
    }
}
