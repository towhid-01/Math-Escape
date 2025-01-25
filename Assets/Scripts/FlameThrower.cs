using System.Collections;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public ParticleSystem flame;  
    private bool isOn = false;   
    public float flameDuration = 2f;  

    void Start()
    {
        StartCoroutine(FlameLoop());
    }

    IEnumerator FlameLoop()
    {
        while (true)
        {
            flame.Play(); 
            isOn = true;
            yield return new WaitForSeconds(flameDuration); 

            flame.Stop();  
            isOn = false;
            yield return new WaitForSeconds(flameDuration);  
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isOn)
        {
            other.GetComponent<PlayerDeath>().DieByFlame();
        }
    }
}
