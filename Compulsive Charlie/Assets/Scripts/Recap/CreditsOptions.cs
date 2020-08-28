using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Recap
{
    public class CreditsOptions : MonoBehaviour
    {
        public void OnBack()
        {
            SceneManager.LoadScene("Profile");
        }
    }
}