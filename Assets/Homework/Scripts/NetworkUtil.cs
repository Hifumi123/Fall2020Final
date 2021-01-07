using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkUtil : MonoBehaviour
{
    public Button createHost;

    public Button linkHost;

    public InputField IPAddress;

    public Button ready;

    public GameObject kartDisplayForLobby;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private IEnumerator ChangeUI(NetworkClient client)
    {
        while (!client.isConnected)
            yield return null;

        createHost.gameObject.SetActive(false);
        linkHost.gameObject.SetActive(false);
        IPAddress.gameObject.SetActive(false);

        ready.gameObject.SetActive(true);
        kartDisplayForLobby.SetActive(true);
    }

    public void StartHost()
    {
        NetworkClient client = NetworkLobbyManager.singleton.StartHost();

        StartCoroutine(ChangeUI(client));
    }

    public void StartClient()
    {
        NetworkLobbyManager.singleton.networkAddress = IPAddress.text;

        NetworkClient client = NetworkLobbyManager.singleton.StartClient();

        StartCoroutine(ChangeUI(client));
    }

    public void StopHost()
    {
        NetworkLobbyManager.singleton.StopHost();
    }

    public void StopClient()
    {
        NetworkLobbyManager.singleton.StopClient();
    }
}
