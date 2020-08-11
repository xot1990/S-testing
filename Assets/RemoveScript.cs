using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveScript : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(Deth());
    }

    
    IEnumerator Deth()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
