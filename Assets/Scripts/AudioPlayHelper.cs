using UnityEngine;

public class AudioPlayHelper : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.P;
    public AudioSource AudioSource;

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
            Play();
    }

    void Play()
    {
        AudioSource.Play();
    }
}
