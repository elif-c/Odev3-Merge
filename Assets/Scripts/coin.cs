using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class coin : MonoBehaviour
{
    public int count = 0;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _text.text = $"{count}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("collectible"))
        {
            count++;
            _audio.Play();
            Destroy(collision.gameObject);
            _text.text = $"{count}";
        }

    }
    

}
