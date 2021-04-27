using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvertiseMTEC : MonoBehaviour
{
    [SerializeField] private string _loadSceneName = default;

    public void Advertise_MTEC()
    {
        SceneManager.LoadScene(_loadSceneName);
    }
}
