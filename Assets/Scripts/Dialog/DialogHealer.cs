using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHealer : MonoBehaviour
{
    public string[] sentences;

    private bool canActivateBox;
    void Start()
    {
        
    }

    void Update()
    {
        if(canActivateBox && Input.GetButtonDown("Fire1") && !DialogController.instance.IsDialogBoxActive())
        {
            DialogController.instance.ActivatedDialog(sentences);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            canActivateBox = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canActivateBox = false;
        }

    }
}
