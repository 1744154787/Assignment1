using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    // The audio source component
    public AudioSource audioSource;

    // The array of footstep sound clips
    public AudioClip[] footstepSounds;

    // The minimum and maximum pitch of the sound
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

    // The minimum and maximum volume of the sound
    public float minVolume = 0.2f;
    public float maxVolume = 0.8f;

    // The character controller component
    private CharacterController characterController;

    // The previous position of the character
    private Vector3 previousPosition;

    // The distance traveled by the character
    private float distanceTraveled;

    // The distance threshold to play a sound
    private float distanceThreshold = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the character controller component
        characterController = GetComponent<CharacterController>();

        // Get the previous position of the character
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // If the character is grounded and moving
        if (characterController.isGrounded && characterController.velocity.magnitude > 0)
        {
            // Calculate the distance traveled by the character
            distanceTraveled += Vector3.Distance(transform.position, previousPosition);

            // If the distance traveled is greater than or equal to the distance threshold
            if (distanceTraveled >= distanceThreshold)
            {
                // Play a random footstep sound with a random pitch and volume
                PlayFootstepSound();

                // Reset the distance traveled
                distanceTraveled = 0;
            }
        }

        // Update the previous position of the character
        previousPosition = transform.position;
    }

    // Play a random footstep sound with a random pitch and volume
    void PlayFootstepSound()
    {
        // If there are no footstep sounds, return
        if (footstepSounds.Length == 0) return;

        // Choose a random footstep sound from the array
        int index = Random.Range(0, footstepSounds.Length);
        AudioClip clip = footstepSounds[index];

        // Choose a random pitch and volume within the range
        float pitch = Random.Range(minPitch, maxPitch);
        float volume = Random.Range(minVolume, maxVolume);

        // Set the audio source pitch and volume
        audioSource.pitch = pitch;
        audioSource.volume = volume;

        // Play the clip
        audioSource.PlayOneShot(clip);
    }
}