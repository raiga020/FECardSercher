using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FECardSercher
{
    /// <summary>
    /// カードを管理するためのシングルトンクラス
    /// カード名一覧やカードデータの辞書データを持つ
    /// </summary>
    public class CardDataManager
    {
        //=======================================================================================================
        // ctor
        //=======================================================================================================
        public CardDataManager()
        {
            loadCardData();
        }

        //=======================================================================================================
        // public method
        //=======================================================================================================
        public List<CardData> Search(SearchOption option)
        {
            var ret = new List<CardData>();

            // keyword検索
            ret.AddRange(CardDataList.FindAll(one =>
               ((option.FromAll || option.FromCardName) && one.UnitName.Contains(option.KeyWord))
            ));

            return ret;
        }

        //=======================================================================================================
        // private method
        //=======================================================================================================
        private void loadCardData()
        {
            mCardDataList = new List<CardData>();

            string filePath = string.Format("{0}/Resources/CardList.json", Environment.CurrentDirectory);
            string data = "";
            using (StreamReader reader = new StreamReader(filePath))
            {
                data = reader.ReadToEnd();
            }
            
            var deserialized = JsonConvert.DeserializeObject<List<CardDataJsonDefine>>(data);
            mJsonDataList = new List<CardDataJsonDefine>();
            deserialized.ForEach(one => mJsonDataList.Add(one));
            deserialized.ForEach(one => mCardDataList.Add(new CardData(one)));
        }

        private void debugPrint()
        {
            foreach(var card in mJsonDataList)
            {
                System.Console.WriteLine(String.Format("{0} ({1})", card.UnitName, card.Symbol));
            }
        }

        //=======================================================================================================
        // property
        //=======================================================================================================
        /// <summary>
        /// ユニット名のリスト
        /// </summary>
        public List<string> UnitNameList { get { return mUnitNameList; } }

        /// <summary>
        /// カード名 -> カードデータの辞書
        /// </summary>
        public List<CardData> CardDataList { get { return mCardDataList; } }

        //=======================================================================================================
        // field
        //=======================================================================================================
        private List<string> mUnitNameList = null;

        private List<CardData> mCardDataList = null;

        private List<CardDataJsonDefine> mJsonDataList = null;
    }
}
