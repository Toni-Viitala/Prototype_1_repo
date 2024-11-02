using UnityEngine;

public class ColliderScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        //Debug.Log("Trigger entered by Player!");
        StatsManager.score++;
    }
}

}
