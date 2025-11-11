using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class DrumTrigger : MonoBehaviour
{
    public AudioClip drumSound;    
    public float triggerDistance = 3f; 
    public KeyCode triggerKey = KeyCode.E; 
    public Transform player;        
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        // Player close enough + presses E
        if (distance <= triggerDistance && Input.GetKeyDown(triggerKey))
        {
            PlayDrumSound();
        }
    }

    void PlayDrumSound()
    {
        if (drumSound != null)
        {
            audioSource.PlayOneShot(drumSound);
        }
        else
        {
            Debug.LogWarning("No drum sound assigned to DrumTrigger on " + gameObject.name);
        }
    }
}
