using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelRestart : MonoBehaviour
{
    public AudioClip _audioRestart;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            _audio.PlayOneShot(_audioRestart);
            StartCoroutine(waitForSound(collision));
        }
        
            
    }

    IEnumerator waitForSound(Collider2D collision)
    {
        while (_audio.isPlaying) 
        {
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
