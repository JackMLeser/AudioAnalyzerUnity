using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public AudioAnalyzer audioAnalyzer;
    public float forceMultiplier = 1000f;

    private Rigidbody[] ragdollRigidbodies;

    void Start()
    {
        // Find and store all Rigidbody components in the ragdoll
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();

        // Ensure the AudioAnalyzer component is assigned
        if (audioAnalyzer == null)
        {
            Debug.LogError("AudioAnalyzer is not assigned to RagdollController");
        }
    }

    void Update()
    {
        if (audioAnalyzer != null)
        {
            ApplyForcesBasedOnAudio();
        }
    }

    void ApplyForcesBasedOnAudio()
    {
        // Get the spectrum data from the AudioAnalyzer
        float[] spectrumData = audioAnalyzer.GetSpectrumData();

        // Apply forces to each Rigidbody in the ragdoll
        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            if (rb != null)
            {
                // Pick a random index in the spectrum data
                int index = Random.Range(0, spectrumData.Length);

                // Calculate a force vector based on the spectrum data at that index
                Vector3 force = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * spectrumData[index] * forceMultiplier;

                // Apply the force to the Rigidbody
                rb.AddForce(force);
            }
        }
    }
}
