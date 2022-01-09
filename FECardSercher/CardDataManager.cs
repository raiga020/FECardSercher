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
        #region singleton
        public static void Create()
        {
            if (sInstance != null) return;

            sInstance = new CardDataManager();
        }

        public static CardDataManager GetInstance() 
        {
            if(sInstance == null)
            {
                Create();
            }

            return sInstance; 
        }

        private static CardDataManager sInstance = null;
        #endregion

        //=======================================================================================================
        // ctor
        //=======================================================================================================
        public CardDataManager()
        {
            loadUnitName();
            loadCardData();
        }

        //=======================================================================================================
        // public method
        //=======================================================================================================
        public List<CardDataJsonDefine> Search(SearchOption option)
        {
            var ret = new List<CardDataJsonDefine>();

            // keyword検索
            ret.AddRange(JsonCardDataList.FindAll(one =>
               ((option.FromAll || option.FromCardName) && one.UnitName.Contains(option.KeyWord))
            ));

            return ret;
        }

        //=======================================================================================================
        // private method
        //=======================================================================================================
        private void loadUnitName()
        {
            mUnitNameList = new List<string>();

            // UnitNameList.txt からユニット名を読み込んでリストに格納
            string filePath = string.Format("{0}/Resources/UnitNameList.txt", Environment.CurrentDirectory);
            string data = "";
            using (StreamReader reader = new StreamReader(filePath))
            {
                data = reader.ReadToEnd();
            }

            var split = data.Split('\n');
            foreach (var one in split)
            {
                mUnitNameList.Add(one);
            }
        }

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
        public List<CardDataJsonDefine> JsonCardDataList { get { return mJsonDataList; } }

        //=======================================================================================================
        // field
        //=======================================================================================================
        private List<string> mUnitNameList = null;

        private List<CardData> mCardDataList = null;

        private List<CardDataJsonDefine> mJsonDataList = null;
    }
}
