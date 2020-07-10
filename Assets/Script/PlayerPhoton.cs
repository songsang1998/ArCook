using Photon.Pun; // 유니티용 포톤 컴포넌트들
using Photon.Realtime; // 포톤 서비스 관련 라이브러리
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerPhoton : MonoBehaviourPunCallbacks
{ 
public Text s;
public Text q;
public int CurrPlayer;
    public Text ss;
public GameObject button;
   Text wintext;
    public Photon.Realtime.Player Players;
    public GameObject panel;
    public GameObject get;
void Start(){
        s.text = PhotonNetwork.NickName;
        CurrPlayer = PhotonNetwork.PlayerList.Length;
        wintext=GameObject.Find("Canvas").transform.Find("get").GetComponent<Text>();
      //  Debug.Log(PhotonNetwork.PlayerList[0].NickName);
        if (CurrPlayer == 2)
        {
           q.text = PhotonNetwork.PlayerList[0].NickName;
            Players = PhotonNetwork.PlayerList[0];


        }
        else
        {

            q.text = "비임";
        }

    }
private void Update()
    {
         CurrPlayer= PhotonNetwork.PlayerList.Length;
         ss.text = "사람수"+ CurrPlayer;
        if (CurrPlayer == 2)
        {
            button.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(false);
        }
    }
    public void Exit()
    {
        for (int i = 0; i <= 1000; i++)
        {
            PlayerPrefs.SetInt("items" + i, Itemmanager.Instance.Items[i]);
        }
        PlayerPrefs.SetInt("Gold", Itemmanager.Instance.Gold);
        PlayerPrefs.SetInt("Dojon", Itemmanager.Instance.Dojon);
        PlayerPrefs.Save();
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("start");
        //SceneManager.LoadScene("start");
    }
public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        q.text = newPlayer.NickName;
        Players = newPlayer;
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player newPlayer)
    {
        q.text = "비임";
    }
    [PunRPC]
    void Trade(int s)
    {
        var singleton = Item.Instance;
        for (int i = 0; i <= 1000; i++)
        {
            if (Itemmanager.Instance.Items[i] == -1)
            {
                Itemmanager.Instance.Items[i] = s;
                break;
            }
        }
        
        panel.SetActive(false);
        get.SetActive(true);
        wintext.text = (singleton.itemMap[s].Name + "\r\n을(를) 획득!!");
        
    }

}