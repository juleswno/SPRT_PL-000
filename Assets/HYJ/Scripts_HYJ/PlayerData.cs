using System;
using System.Collections.Generic;

// 플레이어 상태 저장을 위한 데이터 클래스
[Serializable]
public class PlayerData
{
    public int hp;                            // 체력
    public List<string> inventory;            // 보유 아이템 목록
}

