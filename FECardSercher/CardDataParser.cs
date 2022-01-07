using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FECardSercher
{
    public class CardDataParser
    {
        /// <summary>
        /// シンボルの解釈
        /// 複数シンボルもシンボルの1種として解釈する
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static CardData.ESymbol ParseSymbol(string symbol)
        {
            switch (symbol)
            {
                case "光の剣":
                    return CardData.ESymbol.Red;
                case "聖痕":
                    return CardData.ESymbol.Blue;
                case "光の剣聖痕":
                    return CardData.ESymbol.RedBlue;
                case "白夜":
                    return CardData.ESymbol.White;
                case "暗夜":
                    return CardData.ESymbol.Black;
                case "白夜暗夜":
                    return CardData.ESymbol.WhiteBlack;
                case "メダリオン":
                    return CardData.ESymbol.Green;
                case "神器":
                    return CardData.ESymbol.Purple;
                case "聖戦旗":
                    return CardData.ESymbol.Yellow;
                case "女神紋":
                    return CardData.ESymbol.Brown;
                case "（なし）":
                default:
                    return CardData.ESymbol.None;
            }
        }

        /// <summary>
        /// 武器の解釈
        /// </summary>
        /// <param name="arm"></param>
        /// <returns></returns>
        public static CardData.EArm ParseArm(string arm)
        {
            switch(arm)
            {
                case "剣":
                    return CardData.EArm.Sword;
                case "槍":
                    return CardData.EArm.Lance;
                case "斧":
                    return CardData.EArm.Axe;
                case "弓":
                    return CardData.EArm.Bow;
                case "暗器":
                    return CardData.EArm.Dagger;
                case "魔法":
                    return CardData.EArm.Magic;
                case "杖":
                    return CardData.EArm.Stuff;
                case "牙":
                    return CardData.EArm.Fang;
                case "竜石":
                    return CardData.EArm.Dragon;
                case "拳":
                    return CardData.EArm.Fist;
                case "（なし）":
                default:
                    return CardData.EArm.None;
            }
        }

        /// <summary>
        /// タイプの解釈
        /// タイプは複数持つことがありうるのでリストで返す
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<CardData.EType> ParseType(string type)
        {
            List<CardData.EType> ret = new List<CardData.EType>();

            // 「飛行獣馬 」のようなテキストで入っていたりするので
            // 各タイプに対応する文字列1つずつチェックしていく
            type = type.Trim();
            if(type.Contains("獣馬"))
            {
                ret.Add(CardData.EType.Hourse);
            }
            if (type.Contains("飛行"))
            {
                ret.Add(CardData.EType.Wing);
            }
            if (type.Contains("アーマー"))
            {
                ret.Add(CardData.EType.Armor);
            }
            if (type.Contains("竜"))
            {
                ret.Add(CardData.EType.Dragon);
            }
            if (type.Contains("幻影"))
            {
                ret.Add(CardData.EType.Mirage);
            }
            if (type.Contains("魔物"))
            {
                ret.Add(CardData.EType.Monster);
            }

            if (ret.Count == 0) { ret.Add(CardData.EType.None); }

            return ret;
        }

        /// <summary>
        /// 性別の解釈
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static CardData.ESex ParseSex(string sex)
        {
            switch(sex)
            {
                case "男":
                    return CardData.ESex.Male;
                case "女":
                    return CardData.ESex.Female;
                default:
                    return CardData.ESex.None;
            }
        }

        /// <summary>
        /// 射程の解釈
        /// </summary>
        /// <param name="range"></param>
        /// <param name="minRange"></param>
        /// <param name="maxRange"></param>
        public static void ParseRange(string range, out int minRange, out int maxRange)
        {
            // 射程なしのパターン
            if(string.IsNullOrEmpty(range) || range.Equals("（なし）"))
            {
                minRange = 0;
                maxRange = 0;
                return;
            }

            var split = range.Split('-');
            // 単射程
            if(split.Length == 0)
            {
                int.TryParse(split[0], out minRange);
                maxRange = minRange;
                return;
            }
            // 複数射程
            // min-max の形式
            else
            {
                int.TryParse(split[0], out minRange);
                int.TryParse(split[1], out maxRange);
            }
        }
    }
}
