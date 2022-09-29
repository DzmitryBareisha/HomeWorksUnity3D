using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private bool isTeleport = false;
    private CharacterController player;
    public Transform posStairs;   
    public GameObject[] sounds;
    private AudioSource setSounds;
    public GameObject[] lights;
    private Light setLights;
    void Update()
    {
        if (isTeleport)
        {
            ChangeSounds();
            ChangeLights();
            isTeleport = !isTeleport;
        }        
    }
    public void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponent<CharacterController>();
        player.enabled = false;
        other.gameObject.transform.position = posStairs.transform.position;
        player.enabled = true;
        isTeleport = true;
    }
    public void ChangeSounds()
    {
        int randS = Random.Range(0, sounds.Length - 1);
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].transform.position = new Vector3(Random.Range(1, -7), Random.Range(8, 12), Random.Range(-5, 5));
            sounds[randS].SetActive(false);
            sounds[randS + 1].SetActive(true);
            sounds[randS - 1].SetActive(true);
            setSounds = sounds[randS + 1].GetComponent<AudioSource>();
            setSounds.pitch = Random.Range(0.1f, 1.3f);
            setSounds = sounds[randS - 1].GetComponent<AudioSource>();
            setSounds.pitch = Random.Range(0.1f, 1.3f);
        }
        
        
    }
    public void ChangeLights()
    {
        int randL = Random.Range(0, lights.Length - 1);
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].transform.position = new Vector3(Random.Range(2, -5), Random.Range(11, 13), Random.Range(-4, 4));
            lights[randL].SetActive(false);
            lights[randL + 1].SetActive(true);
            lights[randL - 1].SetActive(true);
            setLights = lights[randL + 1].GetComponent<Light>();
            setLights.intensity = Random.Range(1.0f, 7.0f);
            setLights = lights[randL - 1].GetComponent<Light>();
            setLights.range = Random.Range(7.0f, 17.0f);
        }
    }
}
