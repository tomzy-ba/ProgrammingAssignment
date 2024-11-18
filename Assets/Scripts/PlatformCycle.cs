using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformCycler : MonoBehaviour
{
    private bool activated = true;
    private int platformIndex = 0;
    private List<GameObject> platforms = new List<GameObject>(); 
    private void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            platforms.Add(child.gameObject);

        }
        Debug.Log("PLATFORM COUNT: " + platforms.Count);
        StartCoroutine(PlatformCycle());
    }


    private IEnumerator PlatformCycle()
    {
        while (activated)
        {
            Debug.Log("activate platform " + platformIndex);
            MeshRenderer mr = platforms[platformIndex].GetComponent<MeshRenderer>();
            mr.material.SetColor("_BaseColor", Color.white);
            platforms[platformIndex].SetActive(true);
            yield return new WaitForSeconds(1f);
            mr.material.SetColor("_BaseColor", Color.red);
            yield return new WaitForSeconds(1f);
            platforms[platformIndex].SetActive(false);
            platformIndex++;
            if (platformIndex >= platforms.Count)
            {
                platformIndex = 0;
            }
        }
    }
}
