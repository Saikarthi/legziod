using UnityEngine.Networking;
using UnityEngine;

public class sa : NetworkBehaviour
{
    public Behaviour[] com;


    Camera a;

    

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < com.Length; i++)
            {
                com[i].enabled = false;
            }
        }
        else
        {
            a = Camera.main;
            if (a != null)
            {
                a.gameObject.SetActive(false);
            }
        }
    }
    void OnDisable()
    {
        if (a != null)
        {
            a.gameObject.SetActive(true);
        }
    }
}
