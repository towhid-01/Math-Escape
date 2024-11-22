using System.Collections;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public ParticleSystem flame;  // The flame particle system (assign in Inspector)
    private bool isOn = false;    // To track whether the flame is currently on
    public float flameDuration = 2f;  // Duration the flame stays on/off

    void Start()
    {
        StartCoroutine(FlameLoop());
    }

    IEnumerator FlameLoop()
    {
        while (true)
        {
            flame.Play();  // Turn on the flame
            isOn = true;
            yield return new WaitForSeconds(flameDuration);  // Flame stays on for 2 seconds

            flame.Stop();  // Turn off the flame
            isOn = false;
            yield return new WaitForSeconds(flameDuration);  // Flame stays off for 2 seconds
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isOn)
        {
            // Call the player's death mechanism if the flame is on and they touch it
            other.GetComponent<PlayerDeath>().DieByFlame();
        }
    }
}
