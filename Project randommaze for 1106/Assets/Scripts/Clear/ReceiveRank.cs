
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using LitJson;

public class ReceiveRank : MonoBehaviour
{
    // RankInfo 클래스 정의
    private class RankInfo
    {
        public int rank;
        public string nickname;
        public int score;
        public string gamerInDate;
        public int index;
    }

    void Start()
    {
        string rankUUID = "54e326d0-4cad-11ee-b1b7-4f4b7e685ede";
        var bro = Backend.URank.User.GetRankList(rankUUID);

        if (bro.IsSuccess() == false)
        {
            Debug.LogError("랭킹 조회중 오류가 발생했습니다. : " + bro);
            return;
        }
        Debug.Log("랭킹 조회에 성공했습니다. : " + bro);

        Debug.Log("총 랭킹 등록 유저 수 : " + bro.GetFlattenJSON()["totalCount"].ToString());

        List<RankInfo> rankList = new List<RankInfo>(); // 랭킹 정보를 저장할 리스트 생성

        foreach (JsonData jsonData in bro.FlattenRows())
        {
            RankInfo rankInfo = new RankInfo();
            rankInfo.rank = int.Parse(jsonData["rank"].ToString());
            rankInfo.nickname = jsonData["nickname"].ToString();
            rankInfo.score = int.Parse(jsonData["score"].ToString());
            rankInfo.gamerInDate = jsonData["gamerInDate"].ToString();
            rankInfo.index = int.Parse(jsonData["index"].ToString());

            rankList.Add(rankInfo); // 랭킹 정보를 리스트에 추가
        }

        // 첫 번째 항목을 뽑아서 Debug.Log로 출력
        if (rankList.Count > 0)
        {
            RankInfo firstItem = rankList[0];
            Debug.Log("첫 번째 항목 - 순위: " + firstItem.rank + ", 닉네임: " + firstItem.nickname + ", 점수: " + firstItem.score);
        }
        else
        {
            Debug.Log("랭킹 정보가 없습니다.");
        }
    }
}
