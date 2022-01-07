using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FECardSercher
{
    public class CardData
    {
        public CardData(CardDataJsonDefine json)
        {
            mData = json;

            // パラメータ格納
            mCardName = json.CardName;
            // TODO: 称号とユニット名識別

            int.TryParse(json.Attack, out mAttack);
            int.TryParse(json.Support, out mSupport);
            if(mSupport == 0 && json.Support.Equals("Ｘ"))
            {
                mIsSupportX = true;
            }

            int.TryParse(json.Cost, out mCost);
            if (string.IsNullOrEmpty(json.ClassChangeCost))
            {
                mClassChangeCost = 0;
                mHasClassChangeCost = false;
            }
            else
            {
                int.TryParse(json.ClassChangeCost, out mClassChangeCost);
                mHasClassChangeCost = true;
            }


            mSymbol = CardDataParser.ParseSymbol(json.Symbol);
            mArm = CardDataParser.ParseArm(json.Arms);
            mTypes = CardDataParser.ParseType(json.Type);
            mSex = CardDataParser.ParseSex(json.Sex);

            CardDataParser.ParseRange(json.Range, out mMinRange, out mMaxRange);

            mSkill = json.Skill;
        }

        private CardDataJsonDefine mData = null;

        private string mCardName = "";
        private string mTitle = "";
        private string mUnitName = "";

        private int mCost = 0;
        private int mClassChangeCost = 0;
        private bool mHasClassChangeCost = false;

        private int mAttack = 0;
        private int mSupport = 0;
        private bool mIsSupportX = false;

        private ESymbol mSymbol = ESymbol.None;
        private EArm mArm = EArm.None;
        private List<EType> mTypes = new List<EType>();
        private ESex mSex = ESex.None;

        private int mMinRange = 0;
        private int mMaxRange = 0;

        private string mSkill = "";

        public enum ESymbol
        {
            None,
            Red,
            Blue,
            RedBlue,
            White,
            Black,
            WhiteBlack,
            Green,
            Purple,
            Yellow,
            Brown,
        }

        public enum EArm
        {
            None,
            Sword,      // 剣
            Lance,      // 槍
            Axe,        // 斧
            Bow,        // 弓
            Dagger,     // 暗器
            Magic,      // 魔法
            Stuff,      // 杖
            Fang,       // 牙
            Dragon,     // 竜石
            Fist,       // 拳
        }

        public enum EType
        {
            None,
            Hourse,     // 獣馬
            Wing,       // 飛行
            Armor,      // アーマー
            Dragon,     // 竜
            Mirage,     // 幻影
            Monster,    // 魔物
        }

        public enum ESex
        {
            None,
            Male,
            Female,
        }
    }
}
