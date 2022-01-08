using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FECardSercher.CardData;

namespace FECardSercher
{
    public class SearchOption
    {
        /// <summary>
        /// 全テキストから検索するか
        /// チェックボックスがすべて未指定なら全検索扱い
        /// </summary>
        public bool FromAll
        {
            get
            {
                return !FromCardName && !FromTitle && !FromUnitName && !FromSkills && !FromCardNo && !FromCardName && !FromCardNo && !FromJob && !FromPhrase && !FromIllustrator;
            }
        }

        /// <summary>
        /// キーワードと検索対象
        /// </summary>
        public string KeyWord { get; set; }
        public bool FromCardName { get; set; }
        public bool FromTitle { get; set; }
        public bool FromUnitName { get; set; }
        public bool FromSkills { get; set; }
        public bool FromCardNo { get; set; }
        public bool FromJob { get; set; }
        public bool FromPhrase { get; set; }
        public bool FromIllustrator { get; set; }

        public int MinCost { get; set;}
        public int MaxCost { get; set;}
        public int MinCCCost { get; set;}
        public int MaxCCCost { get; set;}
        public EClass Class { get; set; }
        public int MinAttack { get; set; }
        public int MaxAttack { get; set; }
        public int MinSupport { get; set; }
        public int MaxSupport { get; set; }
        public ESymbol Symbol { get; set; }
        public ESex Sex { get; set; }
        public EArm Arm { get; set; }
        public EType Type { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public ERarity Rarity { get; set; }

    }
}
