using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerControl : NetworkBehaviour
{
    GameObject PlayerGhost;
    GameObject PlayerSmooth;
    public float Speed = 20.0f;

	void Start ()
    {
        PlayerGhost = gameObject.transform.GetChild(0).gameObject;
        PlayerSmooth = gameObject.transform.GetChild(1).gameObject;
	}

	void Update ()
    {
        if (isLocalPlayer)
        {
            Vector3 pos = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            pos *= Time.deltaTime * Speed;

            PlayerSmooth.transform.position += pos;
            PlayerGhost.transform.position += pos;
        }
        else
        {
            PlayerSmooth.transform.position = Vector3.Lerp(PlayerSmooth.transform.position, PlayerGhost.transform.position, 0.2f);
        }
    }
}
