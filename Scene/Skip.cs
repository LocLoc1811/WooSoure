using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    [SerializeField] GameObject Continue;

    public void ContinueMenu()
    {
        Continue.SetActive(false);
    }
}
