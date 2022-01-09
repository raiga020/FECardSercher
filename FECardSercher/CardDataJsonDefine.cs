using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FECardSercher
{ 
    public class CardDataJsonDefine
    {
        /// <summary>
        /// 称号名
        /// </summary>
        [JsonProperty("_title")]
        public string TitleName { get; set; }

        /// <summary>
        /// ユニット名
        /// </summary>
        [JsonProperty("_name")]
        public string UnitName { get; set; }

        /// <summary>
        /// カード画像名
        /// </summary>
        [JsonProperty("_image")]
        public string ImageName { get; set; }

        /// <summary>
        /// イラストレータ
        /// </summary>
        [JsonProperty("_illustrator")]
        public string Illusrator { get; set; }

        /// <summary>
        /// セリフ
        /// </summary>
        [JsonProperty("_phrase")]
        public string Phrase { get; set; }

        /// <summary>
        /// レアリティ
        /// </summary>
        [JsonProperty("_rarity")]
        public string Rarity { get; set; }

        /// <summary>
        /// クラス
        /// </summary>
        [JsonProperty("_class")]
        public string Class { get; set; }

        /// <summary>
        /// 職業
        /// </summary>
        [JsonProperty("_job")]
        public string Job { get; set; }

        /// <summary>
        /// 出撃コスト
        /// </summary>
        [JsonProperty("_cost")]
        public string Cost { get; set; }

        /// <summary>
        /// CCコスト
        /// </summary>
        [JsonProperty("_ccost")]
        public string ClassChangeCost { get; set; }

        /// <summary>
        /// シンボル
        /// </summary>
        [JsonProperty("_symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        [JsonProperty("_sex")]
        public string Sex { get; set; }

        /// <summary>
        /// 武器
        /// </summary>
        [JsonProperty("_arm")]
        public string Arms { get; set; }

        /// <summary>
        /// 兵種タイプ
        /// </summary>
        [JsonProperty("_type")]
        public string Type { get; set; }

        /// <summary>
        /// 戦闘力
        /// </summary>
        [JsonProperty("_attack")]
        public string Attack { get; set; }

        /// <summary>
        /// 射程
        /// </summary>
        [JsonProperty("_range")]
        public string Range { get; set; }

        /// <summary>
        /// 支援
        /// </summary>
        [JsonProperty("_support")]
        public string Support { get; set; }

        /// <summary>
        /// スキル
        /// </summary>
        [JsonProperty("_skill")]
        public string Skill { get; set; }
    }
}
