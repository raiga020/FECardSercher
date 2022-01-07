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
        /// カード名
        /// 称号＋ユニット名
        /// </summary>
        [JsonProperty("_name")]
        public string CardName { get; set; }

        /// <summary>
        /// カード画像名
        /// </summary>
        [JsonProperty("_number")]
        public string ImageName { get; set; }

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
        [JsonProperty("_arms")]
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
