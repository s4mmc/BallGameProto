using UnityEngine;
using UnityEngine.Networking;


public class PlayerSetUp : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera sceenCam;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }

        }
        else
        {
            sceenCam = Camera.main;
            if(sceenCam != null)
            {
                sceenCam.gameObject.SetActive(false);
            }
            
        }


    }
	

    void OnDisable()
    {
        if (sceenCam != null)
        {
            sceenCam.gameObject.SetActive(true);
        }
    }


}
