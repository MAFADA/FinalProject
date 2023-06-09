using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueLine : DialogueBase
{
    private TMP_Text textHolder;

    [Header("Text Options")]
    [SerializeField] private string input;
    [SerializeField] private Color textColor;

    [Header("Text Time Parameter")]
    [SerializeField] private float textSpeed;
    [SerializeField] private float textDelayBetweenLines;

    [Header("SFX")]
    // [SerializeField] private AudioClip sound;

    [Header("Character Image")]
    [SerializeField] private Sprite characterSprite;
    [SerializeField] private Image imageHolder;
    private void Awake()
    {
        textHolder = GetComponent<TMP_Text>();
        textHolder.text = "";

        imageHolder.sprite = characterSprite;
        imageHolder.preserveAspect = true;
    }

    private void Start()
    {
        StartCoroutine(WriteText(input,
                                 textHolder,
                                 textColor,
                                 textSpeed,
                                //  sound,
                                 textDelayBetweenLines));
    }
}
