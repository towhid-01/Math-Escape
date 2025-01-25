using System.Collections;
using UnityEngine;
using TMPro;  
public class CubeTrigger : MonoBehaviour
{
    public TextMeshProUGUI messageUI;     
    public GameObject player;             

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            StartCoroutine(ShowMessageForDuration("More coins aren�t always better.", 2.5f));
        }
    }

    private IEnumerator ShowMessageForDuration(string message, float duration)
    {
        
        messageUI.text = message;

        yield return new WaitForSeconds(duration);

        messageUI.text = "";
    }
}
