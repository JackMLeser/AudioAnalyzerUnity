using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalyzer : MonoBehaviour
{
    private AudioSource audioSource;
    public float[] spectrumData;
    public int sampleSize = 1024;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spectrumData = new float[sampleSize];
    }

    void Update()
    {
        // Get the spectrum data
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
    }

    public float[] GetSpectrumData()
    {
        return spectrumData;
    }
}
