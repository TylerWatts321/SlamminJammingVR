using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : Button
{
    public override void PerformAction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
