using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PhotonのRPC送受信を担うコンポーネント
/// </summary>
[DisallowMultipleComponent, RequireComponent(typeof(PhotonView))]
public class RPCManager : MonoBehaviour
{
    #region Private Member

    private PhotonView _photonView;

    #endregion

    #region Event

    public event Action OnReceiveStartGame;
    public event Action<Vector3> OnMovePlayer;

    #endregion

    #region Unity Method

    private void Awake()
    {
        TryGetComponent(out _photonView);
    }

    #endregion

    #region Public Methods

    public void SendStartGame()
    {
        _photonView.RPC(nameof(StartGame), RpcTarget.AllViaServer);
    }

    public void SendMovePlayer(Vector3 velocity)
    {
        _photonView.RPC(nameof(MovePlayer), RpcTarget.Others, velocity);
    }

    #endregion

    #region PunRPC Methods

    [PunRPC]
    private void StartGame()
    {
        OnReceiveStartGame?.Invoke();
    }

    [PunRPC]
    private void MovePlayer(Vector3 velocity)
    {
        OnMovePlayer?.Invoke(velocity);
    }

    #endregion
}