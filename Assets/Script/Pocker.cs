using Photon.Pun; // 유니티용 포톤 컴포넌트들
using Photon.Realtime; // 포톤 서비스 관련 라이브러리
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Pocker : MonoBehaviourPunCallbacks
{
    public Text s;
    public Text q;
    public int CurrPlayer;
    public Text ss;
    public GameObject button;
    public bool game;
    public Text mychip;
    public Text schip;
    public Photon.Realtime.Player Players;
    public int card;
    public int chip;
    PhotonView pv;
    public Text who;
    public int ship;
    string whoplayer;
    public int waiorcard;
    public Text test;
    public Text battingchip;
    public GameObject Call;
    public GameObject Die;
    public GameObject rade;
    public GameObject winpanel;
    public GameObject losepanel;
    public GameObject Cards;
    int bat;
    public int you;
    public PockerAudio PA;
    public Text mycard;
    void Start()
    {
        ship = 0;
        whoplayer = "미정";
        s.text = PhotonNetwork.NickName;
     
        CurrPlayer = PhotonNetwork.PlayerList.Length;
        pv = GameObject.Find("StartManager").GetComponent<PhotonView>();
        game = false;
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
        
        CurrPlayer = PhotonNetwork.PlayerList.Length;
        ss.text = "사람수" + CurrPlayer;

        if (CurrPlayer == 2)
        {
            button.gameObject.SetActive(false);
        }
        else
        {
            button.gameObject.SetActive(true);
        }

        if (game == true )
        {
            mychip.text = "내칩:"+chip.ToString();
            schip.text = " 상대칩:" + ship.ToString();
            if (bat != 0)
            {
                who.text = whoplayer + "플레이어 턴";
            }
            battingchip.text = "배팅된칩" + bat;
            if (waiorcard >= 1 && waiorcard <= 10)
            {
                test.text = "상대카드:" + waiorcard.ToString();
            }
         
        }

        if(game==false && CurrPlayer==2)
        {
           
            Settings();
            
            
        }
       
        if (game == true && card==0)
        {
            if (chip == 0)
            {
                losepanel.SetActive(true);
                pv.RPC("Winpanles", RpcTarget.Others);
                var singleton = Item.Instance;
                for (int i = 0; i <= 1000; i++)
                {
                    if (Itemmanager.Instance.Items[i] == -1)
                    {
                        Itemmanager.Instance.Items[i] = Random.Range(0,8);
                        break;
                    }
                }
                Invoke("Exit", 5f);
            }
            mycard.text = "내카드:비공개";
            Cards.gameObject.SetActive(false);
            bat = 0;
            card = Random.Range(1, 11);
            you = -1;
            if (PhotonNetwork.NickName==PhotonNetwork.PlayerList[0].NickName)
            {

                int what = Random.Range(0, 2);
                
                pv.RPC("Setting", RpcTarget.All,what);
                

            }
            int move=1;
            chip -= move;
            bat += 2;
            
            pv.RPC("Youchip", RpcTarget.Others, chip,card);

        }
        if (PhotonNetwork.NickName == whoplayer && card != 0)
        {
            Call.SetActive(true);
            Die.SetActive(true);
            rade.SetActive(true);
        }
        else
        {
            Call.SetActive(false);
            Die.SetActive(false);
            rade.SetActive(false);
        }
    }

    public void Calls()
    {
        pv.RPC("Callvoid", RpcTarget.All);
        if (you == -1)
        {
            
           if( PhotonNetwork.NickName == PhotonNetwork.PlayerList[0].NickName)
            {
                whoplayer = PhotonNetwork.PlayerList[1].NickName;
            }
            else
            {
                whoplayer = PhotonNetwork.PlayerList[0].NickName;
            }
            you = 0;
            pv.RPC("batting", RpcTarget.Others,you,bat, chip);
                
        }
        else
        {
            chip -= you;
            bat += you;
            pv.RPC("Calld", RpcTarget.Others,bat,chip);
            if (waiorcard > card)
            {
               pv.RPC("Win", RpcTarget.Others);
                lose();
            }else if (waiorcard < card)
            {
                pv.RPC("lose", RpcTarget.Others);
                Win();
            }
            else
            {
                pv.RPC("Draw", RpcTarget.All);
            }
        }
    }
    public void Lases(int a)
    {
        pv.RPC("Rasevoid", RpcTarget.All);
        if (you == -1)
        {
            you = 0;
        }

        chip -= you + a;
        bat += you+a;
        you = a;
        if (PhotonNetwork.NickName == PhotonNetwork.PlayerList[0].NickName)
        {
            whoplayer = PhotonNetwork.PlayerList[1].NickName;
        }
        else
        {
            whoplayer = PhotonNetwork.PlayerList[0].NickName;
        }
        pv.RPC("batting", RpcTarget.Others, you, bat,chip);
    }
    public void Dies()
    {
        pv.RPC("Dievoid", RpcTarget.All);
        if (card >= 1 && card <= 10)
        {
            mycard.text = "내카드:" + card.ToString();
            Cards.gameObject.SetActive(true);
        }
        if(card==10)
        {
            if (chip % 2 == 0)
            {
                bat += chip / 2;
                pv.RPC("Calld", RpcTarget.Others, bat,chip);
                chip = chip / 2;
            }
            else
            {
                bat += chip / 2;
                pv.RPC("Calld", RpcTarget.Others, bat,chip);
                chip = chip / 2 + 1;
            }
        }
        pv.RPC("Win", RpcTarget.Others);
        lose();
       
        
    }
    public void regame()
    {
        card = 0;
    }
    public void Settings()
    {
        chip = 10;
        card = 0;
        bat = 0;
        if (PhotonNetwork.NickName == PhotonNetwork.PlayerList[1].NickName)
        {
            pv.RPC("Gamego", RpcTarget.All);
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
        PlayerPrefs.SetInt("Gold", Itemmanager.Instance.Gold);
        PlayerPrefs.SetInt("Dojon", Itemmanager.Instance.Dojon);
        PlayerPrefs.Save();
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("start");


    }

   
    [PunRPC]
    void Setting(int a)
    {
        whoplayer = PhotonNetwork.PlayerList[a].NickName;
        for (int i = 0; i <= 1000; i++)
        {
            PlayerPrefs.SetInt("items" + i, Itemmanager.Instance.Items[i]);
        }
    


    }
    [PunRPC]
    void Youchip(int b,int c)
    {
        
        ship = b;
        waiorcard = c;

    }
    [PunRPC]
    public void Gamego()
    {
        game =true;

    }
    [PunRPC]
    public void Calld(int a,int b)
    {
        bat = a;
        ship = b;
    }
    [PunRPC]
    public void batting(int a, int b,int c)
    {
        bat = b;
        you = a;
        whoplayer = PhotonNetwork.NickName;
        ship = c;
    }
    [PunRPC]
    public void Win()
    {
        chip += bat;
        bat = 0;
       
        if (card >= 1 && card <= 10)
        {
            mycard.text = "내카드:" + card.ToString();
            Cards.gameObject.SetActive(true);
        }
        whoplayer = "없음";
        who.text = PhotonNetwork.NickName + "님이 이기셨습니다";
        Invoke("regame", 5f);
        

    }
    [PunRPC]
    public void lose()
    {
        bat = 0;

        if (card >= 1 && card <= 10)
        {
            mycard.text = "내카드:" + card.ToString();
            Cards.gameObject.SetActive(true);
        }
        whoplayer = "없음";
        if (card != 10)
        {
            who.text = PhotonNetwork.NickName + "님이 패배하셨습니다";
        }
        else
        {
            who.text = "10을 가지고 다이를 쳤으므로, 자신의 칩의 1/2를 상대에게 줍니다.";
        }
        Invoke("regame", 5f);
    }
    [PunRPC]
    public void Draw()
    {
        chip += bat / 2;
        bat = 0;
        mycard.text = "내카드:" + card.ToString();
        Cards.gameObject.SetActive(true);
        whoplayer = "없음";
        who.text ="비겼습니다! 칩은 반환됩니다!";
        Invoke("regame", 5f);
    }
    [PunRPC]
    public void Winpanles()
    {
        winpanel.SetActive(true);
        var singleton = Item.Instance;
        for (int i = 0; i <= 1000; i++)
        {
            if (Itemmanager.Instance.Items[i] == -1)
            {
                Itemmanager.Instance.Items[i] = Random.Range(0, 8);
                Itemmanager.Instance.Items[i+1] = Random.Range(0, 8);
                Itemmanager.Instance.Items[i + 2] = Random.Range(0, 8);
                break;
            }
        }
        Invoke("Exit", 5f);
    }
    [PunRPC] 
    public void Callvoid()
    {
        PA.Call();
    }
    [PunRPC]
    public void Rasevoid()
    {
        PA.Rase();
    }
    [PunRPC]
    public void Dievoid()
    {
        PA.Die();
    }

}