using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class gotomenu : MonoBehaviour
    {

        private void OnEnable()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}