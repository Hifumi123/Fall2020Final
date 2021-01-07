using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LobbyPlayer : NetworkLobbyPlayer
{
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        if (isLocalPlayer)
        {
            GameObject button = GameObject.Find("Ready");

            if (button != null)
                button.GetComponent<Button>().onClick.AddListener(NetworkUISet);
        }
    }

    private void NetworkUISet()
    {
        base.SendReadyToBeginMessage();

        GameObject readyButton = GameObject.Find("Ready");

        if (readyButton != null)
        {
            Button button = readyButton.GetComponent<Button>();

            ColorBlock cb = button.colors;
            cb.disabledColor = Color.yellow;
            button.colors = cb;

            button.interactable = false;
        }
    }
}
