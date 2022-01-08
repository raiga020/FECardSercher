using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FECardSercher
{
    public partial class FECipherCardSearcher : Form
    {
        public FECipherCardSearcher()
        {
            InitializeComponent();

            // シングルトンの生成
            CardDataManager.Create();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            mSerachOption.KeyWord = KeywordTextBox.Text;
            var result = CardDataManager.GetInstance().Search(mSerachOption);

            if (result != null)
            {
                foreach(var card in result)
                {
                    System.Console.WriteLine(card.CardName);
                }
            }
        }

        private SearchOption mSerachOption = new SearchOption();
    }
}
