using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FECardSercher
{
    /// <summary>
    /// カードデータ本体
    /// Jsonを解釈して扱いやすい形式にしたもの
    /// </summary>
    public class CardData
    {
        //=======================================================================================================
        // ctor
        //=======================================================================================================
        public CardData(CardDataJsonDefine json)
        {
            // パラメータ格納
            mTitle = json.TitleName;
            mUnitName = json.UnitName;
            mCardName = string.Format("{0} {1}", mTitle, mUnitName);

            mImagePath = json.ImageName;
            mCardNumber = CardDataParser.ParseCardNo(mImagePath);
            mRarity = CardDataParser.ParseRarity(json.Rarity);

            mPhrase = json.Phrase;
            mIllustrator = json.Illusrator;
            mJob = json.Job;

            int.TryParse(json.Attack, out mAttack);

            if(json.Support == "Ｘ")
            {
                mSupport = XValue;
            }
            else
            {
                int.TryParse(json.Support, out mSupport);
            }
            
            if(json.Cost == "Ｘ")
            {
                mCost = XValue;
            }
            else
            {
                int.TryParse(json.Cost, out mCost);
            }
            
            if (string.IsNullOrEmpty(json.ClassChangeCost) || json.ClassChangeCost == "（なし）")
            {
                mClassChangeCost = -1;
                mHasClassChangeCost = false;
            }
            else
            {
                if(json.ClassChangeCost == "Ｘ")
                {
                    mClassChangeCost = XValue;
                }
                else
                {
                    int.TryParse(json.ClassChangeCost, out mClassChangeCost);
                }
                mHasClassChangeCost = true;
            }


            mSymbol = CardDataParser.ParseSymbol(json.Symbol);
            mArm = CardDataParser.ParseArm(json.Arms);
            mTypes = CardDataParser.ParseType(json.Type);
            mSex = CardDataParser.ParseSex(json.Sex);
            mClass = CardDataParser.ParseClass(json.Class);

            CardDataParser.ParseRange(json.Range, out mMinRange, out mMaxRange);

            mSkill = json.Skill;
        }

        public bool IsMatch(SearchOption option)
        {
            // パラメータ検索
            if (option.MinCost.HasValue && option.MinCost.Value > Cost) return false;
            if (option.MaxCost.HasValue && option.MaxCost.Value < Cost) return false;
            if (option.MinCCCost.HasValue && option.MinCost.Value > ClassChangeCost) return false;
            if (option.MaxCCCost.HasValue && option.MaxCost.Value < ClassChangeCost) return false;
            if (option.Class.HasValue && option.Class.Value != Class) return false;
            if (option.MinAttack.HasValue && option.MinAttack.Value > Attack) return false;
            if (option.MaxAttack.HasValue && option.MaxAttack.Value < Attack) return false;
            if (option.MinSupport.HasValue && option.MinSupport.Value > Support) return false;
            if (option.MaxSupport.HasValue && option.MaxSupport.Value < Support) return false;
            if (option.Symbol.HasValue && option.Symbol.Value != Symbol) return false;
            if (option.Sex.HasValue && option.Sex.Value != Sex) return false;
            if (option.Arm.HasValue && option.Arm.Value != Arm) return false;
            if (option.Type.HasValue && Types.Contains(option.Type.Value)) return false;
            if (option.MinRange.HasValue && option.MinRange.Value != MinRange) return false;
            if (option.MaxRange.HasValue && option.MaxRange.Value != MaxRange) return false;
            if (option.Rarity.HasValue && option.Rarity.Value != Rarity) return false;

            if (!string.IsNullOrEmpty(option.KeyWord))
            {
                // keyword 検索
                if ((option.FromAll || option.FromCardName) && CardName.Contains(option.KeyWord)) return true;
                if ((option.FromAll || option.FromUnitName) && UnitName.Contains(option.KeyWord)) return true;
                if ((option.FromAll || option.FromTitle) && Title.Contains(option.KeyWord)) return true;
                if ((option.FromAll || option.FromPhrase) && Phrase.Contains(option.KeyWord)) return true;
                if ((option.FromAll || option.FromJob) && Job.Contains(option.KeyWord)) return true;
                if ((option.FromAll || option.FromCardNo) && CardNumber.Contains(option.KeyWord)) return true;

                return false;
            }
            else
            {
                // キーワード指定なしでここまで抜けてきたら全条件通過しているので true を返す
                return true;
            }
            
        }

        //=======================================================================================================
        // property
        //=======================================================================================================
        public string CardName { get { return mCardName; } }
        public string Title { get { return mTitle; } }
        public string UnitName { get { return mUnitName; } }
        public string CardNumber { get { return mCardNumber; } }
        public string Phrase { get { return mPhrase; } }
        public string Illustrator { get { return mIllustrator; } }
        public ERarity Rarity { get { return mRarity; } }
        public string Job { get { return mJob; } }
        public int Cost { get { return mCost; } }
        public int ClassChangeCost { get { return mClassChangeCost;} }
        public bool HasClassChangeCost { get { return mHasClassChangeCost; } }
        public int Attack { get { return mAttack; } }
        public int Support { get { return mSupport; } }
        public bool IsSupportX { get { return mIsSupportX; } }
        public ESymbol Symbol { get { return mSymbol; } }
        public EArm Arm { get { return mArm; } }
        public List<EType> Types { get { return mTypes; } }
        public ESex Sex { get { return mSex; } }
        public EClass Class { get { return mClass; } }
        public int MinRange { get { return mMinRange; } }
        public int MaxRange { get { return mMaxRange; } }

        public string Skill { get { return mSkill; } }

        //=======================================================================================================
        // field
        //=======================================================================================================
        private string mCardName = "";
        private string mTitle = "";
        private string mUnitName = "";
        private string mPhrase = "";
        private string mIllustrator = "";
        private string mJob = "";

        private string mImagePath = "";
        private string mCardNumber = "";
        private ERarity mRarity = ERarity.N;

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
        private EClass mClass = EClass.None;

        private int mMinRange = 0;
        private int mMaxRange = 0;

        private string mSkill = "";

        public static int XValue = 999;

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

        public enum EClass
        {
            None,
            Low,        // 下級
            Middle,     // 中級
            High,       // 上級
            Top,        // 最上級
            Beginner,   // 初級
            Unique,      // 固定
            Special,    // 特殊
            Over,       // オーバークラス
            Prime,      // 特級
        }

        public enum ERarity
        {
            ST,
            STPlus,
            SR,
            SRPlus,
            R,
            RPlus,
            RPlusX,
            HN,
            HNX,
            HR,
            N,
            NPlusX,
            PlusX,
            PR,
            PRr,
            PRPlus,
            PRX,
        }
    }
}
