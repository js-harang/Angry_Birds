using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sm;

    private void Awake()
    {
        if (sm == null)
            sm = this;
        else
            Destroy(gameObject);
    }

    public AudioSource audioSource;
    public List<AudioClip> audioList;

    public void Bgm(int index)
    {
        audioSource.clip = audioList[index];
        audioSource.Play();
    }
}
