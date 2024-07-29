using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [HideInInspector] public Transform player;

    public CinemachineVirtualCamera VirtualCamera;
    private void Start()
    {
        player = SpawnerManager.Instance.player;
        VirtualCamera.Follow = player;
        VirtualCamera.LookAt = player;
    }



}
