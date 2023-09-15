using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject settings;
    [SerializeField] private AudioClip closeDoor;
    private AudioSource audioSource;
    private bool firstStart;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        settings.GetComponent<SettingMenu>().SetVolume(-30);
    }

    public void PlayGame ()
    {
        StartCoroutine(PlayEngineSound());
    }

    public void BackToMenu()
    {
        StartCoroutine(PlayCloseDoorSound());
    }

    private IEnumerator PlayEngineSound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator PlayCloseDoorSound()
    {
        audioSource.PlayOneShot(closeDoor);
        yield return new WaitForSeconds(0.8f);
    }

}
