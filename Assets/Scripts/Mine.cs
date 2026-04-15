using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public ResourceType resourceType;
    public bool inside;
    private Coroutine currentCoroutine;
    private Resource resource;
    private ProgressBarUI progressBar;
    
    
    private void Start()
    {
        progressBar = GetComponent<ProgressBarUI>();
        inside = false;
        resource = ResourceManager.instance.GetResource(resourceType);
    }

    private IEnumerator CollectResource()
    {
        while (inside)
        {
            float timer = 0f;
            while (timer < resource.collectTime)
            {
                timer += Time.deltaTime;
                progressBar.SetProgress(timer / resource.collectTime);
                yield return null;
            }

            if (inside)
            {
                ResourceManager.instance.AddResource(resourceType);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        inside = true;

        if (currentCoroutine == null)
        {
            progressBar.Show();
            currentCoroutine = StartCoroutine(CollectResource());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        inside = false;
        
        if (currentCoroutine != null)
        {
            progressBar.Hide();
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }
    }
}
