using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public class ItemData
    {
        public string Name;
        public int Gold;
        public int Number;
        public string maintext;
        public ItemData(string name, int gold, int mixnumber, string s)
        {
            Name = name;
            Gold = gold;
            Number = mixnumber;
            maintext = s;
        }
    }
    public static Item instance;
    private static Item _Instance = null;
    public int max;
    public Dictionary<int, ItemData> itemMap;
    public static Item Instance
    {
        get
        {
            if (instance == null)

            {
                var obj = FindObjectOfType<Item>();

                if (_Instance != null)
                {
                   
                    instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject("Item").AddComponent<Item>();

                    _Instance = newSingleton;
                }
            }
            return _Instance;
        }

    }

    void Awake()
    {

        if (_Instance == null)
        {
            _Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        itemMap = new Dictionary<int, ItemData>();
        int s;
        s = 0;
        itemMap.Add(s, new ItemData("사과", 50, 101, "맛좋은 사과다. 초록색이 몸에 더좋다던가?"));
        s = 1;
        itemMap.Add(s, new ItemData("밀가루", 50, 102, "밀가루는 강력분,중력분,박력분이있다."));
        s = 2;
        itemMap.Add(s, new ItemData("얼음", 50, 103, "물이 어는점은 영하0C"));
        s = 3;
        itemMap.Add(s, new ItemData("닭", 50, 104, "닭의조상은 티라노라는데..?"));
        s = 4;
        itemMap.Add(s, new ItemData("우유", 50, 105, "젖소가 우유면, 황소는 초코우유"));
        s = 5;
        itemMap.Add(s, new ItemData("감자", 50, 106, "조선시대 감자는 고구마를 가르키는 말이였다."));
        s = 6;
        itemMap.Add(s, new ItemData("계란", 50, 107, "쌍란이 나올확률은 1/1000이라는데"));
        s = 7;
        itemMap.Add(s, new ItemData("쌀", 50, 108, "경기미 10KG 29900원"));
        s = 8;
        itemMap.Add(s, new ItemData("과일무더기", 300, 101 * 101, "과일 모듬이다 비타민이 풍부해보인다."));
        s = 9;
        itemMap.Add(s, new ItemData("애플 파이", 300, 101 * 102, "사과파이 한조각에 300칼로리"));
        s = 10;
        itemMap.Add(s, new ItemData("과일 아이스크림", 300, 101 * 103, "오렌지 아이스크림이 개인적으로 제일맛있다"));
        s = 11;
        itemMap.Add(s, new ItemData("애플 우유", 300, 101 * 105, "사과를 우유에넣다니 누구아이디어야?"));
        s = 12;
        itemMap.Add(s, new ItemData("빵", 300, 102 * 102, "면과 더불어 밀가루 요리의 모티브"));
        s = 13;
        itemMap.Add(s, new ItemData("치킨", 300, 102 * 104, "이겼다 오늘저녁은 치킨이닭"));
        s = 14;
        itemMap.Add(s, new ItemData("우유 식빵", 300, 102 * 105, "우유가 들어가 촉촉하고 부드러운 식빵"));
        s = 15;
        itemMap.Add(s, new ItemData("감자 칩", 300, 102 * 106, "질소반 공기반!"));
        s = 16;
        itemMap.Add(s, new ItemData("에그타르트", 300, 102 * 107, "계란으로 만드는요리중 가장 맛있음"));
        s = 17;
        itemMap.Add(s, new ItemData("아이스크림", 300, 103 * 105, "북한에서는 얼음보숭이보단 에스키모라 부른다"));
        s = 18;
        itemMap.Add(s, new ItemData("닭감자 스튜", 300, 104 * 106, "닭과 감자가 들어갔으니 맛있을수밖에?"));
        s = 19;
        itemMap.Add(s, new ItemData("오야꼬동", 300, 104 * 107, "꿩먹고 알먹고"));
        s = 20;
        itemMap.Add(s, new ItemData("삼계탕정식", 300, 104 * 108, "닭이랑 밥의 조화! 몸보신"));
        s = 21;
        itemMap.Add(s, new ItemData("감자수프", 300, 105 * 106, "뜨끈한 수프와 감자의 조화"));
        s = 22;
        itemMap.Add(s, new ItemData("계란찜", 300, 105 * 107, "전자레인지로도 해먹을수 있다던데?"));
        s = 23;
        itemMap.Add(s, new ItemData("감자오믈렛", 300, 106 * 107, "스페인식 감자오믈렛, 브런치로 좋다"));
        s = 24;
        itemMap.Add(s, new ItemData("쓰레기", 10, 1234567, "팔수는 있으련지(누군가 수집하고 있다는 소문이 있다!)"));
        s = 25;
        itemMap.Add(s, new ItemData("감자 아이스크림", 300, 103 * 106, "생각보다 맛있다"));
        s = 26;
        itemMap.Add(s, new ItemData("불", 100, 109, "자나깨나 불조심"));
        s = 27;
        itemMap.Add(s, new ItemData("향신료", 100, 110, "대표적으로 소금과 설탕이있다."));
        s= 28;
        itemMap.Add(s, new ItemData("생선", 100, 111, "어장속에 같인 고기들"));
        s= 29;
        itemMap.Add(s, new ItemData("초콜릿", 100, 112, "초콜릿의 주재료인  카카오는 대한민국의 IT 기업이다"));
        s= 30;
        itemMap.Add(s, new ItemData("닭바베큐", 500, 109*104, "겉바속촉"));
        s = 31;
        itemMap.Add(s, new ItemData("구운감자", 500, 109 * 106, "과자 보단 맛있다."));
        s = 32;
        itemMap.Add(s, new ItemData("계란프라이", 500, 109 * 107, "I can 프라이~"));
        s = 33;
        itemMap.Add(s, new ItemData("파리의 브런치", 2500, (109 * 107)*(102*102), "히든음식입니다[더이상 상위조합은 없습니다]"));
        s = 34;
        itemMap.Add(s, new ItemData("라면", 500, 110 * 102, "꼬불꼬불 꼬불꼬불 맛좋은 라면"));
        s = 35;
        itemMap.Add(s, new ItemData("찐감자", 500, 110 * 106, "감자+소금조합은 진리다"));
        s = 36;
        itemMap.Add(s, new ItemData("소금밥", 500, 110 * 108, "가장 처음해본요리"));
        s = 37;
        itemMap.Add(s, new ItemData("과일청", 1000, (101 * 101)*110, "과일 모듬을 설탕에 절였다!"));
        s = 38;
        itemMap.Add(s, new ItemData("꽈배기", 1000, (102 * 102)*110, "꽈배기의 원산지는 중국이라는데!?"));
        s = 39;
        itemMap.Add(s, new ItemData("양념치킨", 1000, (102 * 104) * 110, "B와(Birth)과 D의(Death)사이에는 치킨이있다."));
        s = 40;
        itemMap.Add(s, new ItemData("생선까스", 500, 111 * 102, "사실 타트타르소스가 맛을 다내준다"));
        s = 41;
        itemMap.Add(s, new ItemData("연어", 500, 111 * 103, "알레스카에 사는 그 생선"));
        s = 42;
        itemMap.Add(s, new ItemData("참치볶음밥", 500, 111 * 108, "참치는 진리다"));
        s = 43;
        itemMap.Add(s, new ItemData("생선구이", 700, 111 * 109, "가정집 메인 메뉴"));
        s = 44;
        itemMap.Add(s, new ItemData("참치라면", 1700, (110 * 102)*111, "히든음식입니다[더이상 상위조합은 없습니다]"));
        s = 45;
        itemMap.Add(s, new ItemData("초코파이", 500, 112 * 102, "눈물젖은 초코파이 ㅜㅜ"));
        s = 46;
        itemMap.Add(s, new ItemData("초코아이스크림", 500, 112 * 103, "아이스크림 3대장(초,바,딸)"));
        s = 47;
        itemMap.Add(s, new ItemData("초코우유", 500, 112 * 105, "황소가 드디어 우유를?"));
        s = 48;
        itemMap.Add(s, new ItemData("초코빵", 1000, 112 * 102 * 102, "초코소라빵이 빵중진리!"));
        s = 49;
        itemMap.Add(s, new ItemData("다크초코", 700, (112*112), "초코 두개를 합쳐서 진한 다크초코가 되었다"));
        s = 50;
        itemMap.Add(s, new ItemData("초밥", 500, 111 *108, "비싸서 못먹는 초밥 ㅜㅜ"));
        s = 51;
        itemMap.Add(s, new ItemData("일식의 미", 3500, (111 * 108) *(110 * 102), "축하드립니다! 작중 최고의 요리입니다."));
        s = 52;
        max = s;
    }


    

   
}
