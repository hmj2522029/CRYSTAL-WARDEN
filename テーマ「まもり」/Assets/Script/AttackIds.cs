using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの攻撃ID
public static class PlayerAttackIds
{
    public const string RapidShot = "RapidShot";    //連射(弓)
    public const string SwordDownwardSlash = "SwordDownwardSlash";      //剣の下斬り
    public const string SwordHorizontalSlash = "SwordHorizontalSlash";  //剣の横斬り
}


//敵の攻撃ID

public static class OrcAttackIds
{
    public const string ChargedAxeChop = "ChargedAxeChop";    //チャージ斧斬り
    public const string VerticalAxeChop = "VerticalAxeChop";  //縦斧斬り
}

public static class DemonAttackIds
{
    public const string KnifeStab = "KnifeStab";    //ナイフ突き
    public const string VerticalKnifeSlash = "VerticalKnifeSlash";    //縦ナイフ斬り
}

public static class BloodMonsterAttackIds
{
    public const string FangBite = "FangBite";   //牙噛み
    public const string VerticalClawSlash = "VerticalClawSlash";   //縦爪斬り
}

