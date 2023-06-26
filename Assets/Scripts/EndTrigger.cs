using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    private bool isInEndArea = false;

    private void Update()
    {
        if (isInEndArea)
        {
            SceneManager.LoadScene("Ending");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInEndArea = true;
        }
    }
}
