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
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchOption searchOption = new SearchOption()
            {
                KeyWord = KeywordTextBox.Text,
                FromCardName = CardNameCheckBox.Checked,
                FromUnitName = UnitNameCheckBox.Checked,
                FromTitle = CardTitleCheckBox.Checked,
                FromCardNo = CardNoCheckBox.Checked,
                FromIllustrator = IllustratorCheckBox.Checked,
                FromPhrase = PhraseCheckBox.Checked,
                FromJob = JobCheckBox.Checked,
                FromSkills = SkillsCheckBox.Checked,

                MinCost = getSelectedValueToInt(MinCostComboBox),
                MaxCost = getSelectedValueToInt(MaxCostComboBox),
                MinCCCost = getSelectedValueToInt(MinCCCostComboBox),
                MaxCCCost = getSelectedValueToInt(MaxCCCostComboBox),
                MinAttack = getSelectedValueToInt(MinAttackComboBox),
                MaxAttack = getSelectedValueToInt(MaxAttackComboBox),
                MinSupport = getSelectedValueToInt(MinSupportComboBox),
                MaxSupport = getSelectedValueToInt(MaxSupportComboBox),

                Symbol = isAssigned(SymbolComboBox) ? CardDataParser.ParseSymbol(SymbolComboBox.SelectedItem.ToString()) : (CardData.ESymbol?)null,
                Sex = isAssigned(SexComboBox) ? CardDataParser.ParseSex(SexComboBox.SelectedItem.ToString()) : (CardData.ESex?)null,
                Arm = isAssigned(ArmComboBox) ? CardDataParser.ParseArm(ArmComboBox.SelectedItem.ToString()) : (CardData.EArm?)null,
                Type = isAssigned(TypeComboBox) ? CardDataParser.ParseType(TypeComboBox.SelectedItem.ToString())[0] : (CardData.EType?)null,
                Rarity = isAssigned(RarityComboBox) ? CardDataParser.ParseRarity(RarityComboBox.SelectedItem.ToString()) : (CardData.ERarity ?)null,
            };

            if(isAssigned(RangeComboBox))
            {
                int maxRange = 0, minRange = 0;
                CardDataParser.ParseRange(RangeComboBox.SelectedItem.ToString(), out minRange, out maxRange);

                searchOption.MinRange = minRange;
                searchOption.MaxRange = maxRange;
            }
            else
            {
                searchOption.MaxRange = null;
                searchOption.MinRange = null;
            }


            var result = mCardDataManager.Search(searchOption);

            if (result != null)
            {
                foreach(var card in result)
                {
                    System.Console.WriteLine(card.CardName);
                }

                SearchResultListBox.Items.Clear();
                SearchResultListBox.Items.AddRange(result.ToArray());
            }

            SeachOptionPanel.Visible = false;
        }

        private int? getSelectedValueToInt(ComboBox comboBox)
        {
            if(comboBox.SelectedItem == null)return null;

            string value = comboBox.SelectedItem.ToString();
            if(value == "指定なし") return null;

            if (value == "X") return CardData.XValue;

            int ret = 0;
            int.TryParse(value, out ret);

            return ret;
        }

        private bool isAssigned(ComboBox comboBox)
        {
            return comboBox.SelectedItem != null && comboBox.SelectedItem.ToString() != "指定なし";
        }

        private void AppearSearchButton_Click(object sender, EventArgs e)
        {
            SeachOptionPanel.Visible = true;
        }

        private CardDataManager mCardDataManager = new CardDataManager();
    }
}
