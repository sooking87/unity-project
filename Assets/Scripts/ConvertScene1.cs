using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConvertScene1 : MonoBehaviour
{
     public void SceneChange()
    {
        SceneManager.LoadScene("Main2");
    }
}
