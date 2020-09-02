using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public void ResetButton()
    {
        SceneManager.LoadScene("Start");
    }
}
