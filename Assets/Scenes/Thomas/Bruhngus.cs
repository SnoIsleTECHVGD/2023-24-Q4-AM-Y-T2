using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bruhngus : MonoBehaviour
{
  public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
