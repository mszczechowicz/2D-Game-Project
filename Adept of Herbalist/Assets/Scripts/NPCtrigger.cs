using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtrigger : MonoBehaviour
{

    [SerializeField] GameObject button;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("porozmawiajmy wiêc");

            button.SetActive(true);

        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("naura");

            button.SetActive(false);

        }


    }
}