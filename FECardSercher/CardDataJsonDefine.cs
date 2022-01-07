using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FECardSercher
{
    public class CardDataJsonDefine
    {
        /// <summary>
        /// カード名
        /// 称号＋ユニット名
        /// </summary>
        [JsonPropertyName("_name")]
        public string CardName;

        /// <summary>
        /// カード画像名
        /// </summary>
        [JsonPropertyName("_number")]
        public string ImageName;

        /// <summary>
        /// 出撃コスト
        /// </summary>
        [JsonPropertyName("_cost")]
        public string Cost;

        /// <summary>
        /// CCコスト
        /// </summary>
        [JsonPropertyName("_ccost")]
        public string ClassChangeCost;

        /// <summary>
        /// シンボル
        /// </summary>
        [JsonPropertyName("_symbol")]
        public string Symbol;

        /// <summary>
        /// 性別
        /// </summary>
        [JsonPropertyName("_sex")]
        public string Sex;

        /// <summary>
        /// 武器
        /// </summary>
        [JsonPropertyName("_arms")]
        public string Arms;

        /// <summary>
        /// 兵種タイプ
        /// </summary>
        [JsonPropertyName("_type")]
        public string Type;

        /// <summary>
        /// 戦闘力
        /// </summary>
        [JsonPropertyName("_attack")]
        public string Attack;

        /// <summary>
        /// 射程
        /// </summary>
        [JsonPropertyName("_range")]
        public string Range;

        /// <summary>
        /// 支援
        /// </summary>
        [JsonPropertyName("_support")]
        public string Support;

        /// <summary>
        /// スキル
        /// </summary>
        [JsonPropertyName("_skill")]
        public string Skill;
    }
}
