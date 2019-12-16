using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Instantiate_Player : MonoBehaviour
{
    public GameObject player, mite, playerInstance;
    public CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        playerInstance = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);

        Instantiate(mite, new Vector3(-2, 0, 0), Quaternion.identity);

        vcam.Follow = playerInstance.transform;
    }

}
