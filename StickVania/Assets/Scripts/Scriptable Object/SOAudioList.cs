using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio List", menuName = "Audio/Audio List")]
public class SOAudioList : ScriptableObject
{
    [Header("Background Music")]
    public AudioClip BG_Map1Music;

    [Header("Character Music")]
    public AudioClip FootStep;
    public AudioClip JumpVoice;

    [Header("Props Music")]
    public AudioClip HangingLamp;
}
