using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class LocalPlayer : NetworkBehaviour {

    public Text playerName;
    public Text nameLabel;
    public Transform namePosition;
    public string field_name = string.Empty;

    [SyncVar (hook= "OnChangeName")]
    public string sync_name = "player";

    public override void OnStartClient()
    {
        base.OnStartClient();
        Invoke("UpdateStates",1);
    }

    void UpdateStates()
    {
        OnChangeName(sync_name);
    }

    void OnChangeName(string name)
    {
        nameLabel.text = sync_name = name;
    }


    [Command]
    public void CmdChangeName(string newName)
    {
        nameLabel.text = sync_name = newName;
    }


    void OnGUI()
    {
        if(isLocalPlayer){
            field_name = GUI.TextField (new Rect(25,15,100,25),field_name);
            if(GUI.Button(new Rect(130,15,35,25),"Set")){
                CmdChangeName(field_name);
            }
        }
    }

    void Start()
    {
        if(isLocalPlayer)
        {
            GetComponent<PlayerController>().enabled = true;
            CameraControl.player =  this.gameObject.transform ;
        }
        else
        {
            GetComponent<PlayerController>().enabled = false;
        }

        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        nameLabel = Instantiate(playerName,Vector3.zero,Quaternion.identity) as Text;
        nameLabel.transform.SetParent(canvas.transform);
    }

    void Update()
    {
        Vector3 nameLabelPosition = Camera.main.WorldToScreenPoint(namePosition.position);
        nameLabel.transform.position = nameLabelPosition;
    }
}
