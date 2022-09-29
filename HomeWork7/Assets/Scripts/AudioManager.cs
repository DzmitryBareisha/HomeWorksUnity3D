using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private int index = 0;
    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private GameObject[] backMusic;
    // Start is called before the first frame update
    void Start()
    {
        backMusic[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
       {
            PlayAudio();
       }
       if (Input.GetMouseButtonDown(1))
       {
            ChangeBackGround();
       }        
    }
    public void PlayAudio()
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
    public void ChangeBackGround()
    {
        backMusic[index].SetActive(false);
        index++;
        if (index > backMusic.Length - 1)
        {
            index = 0;
        }
        backMusic[index].SetActive(true);
    }
}
