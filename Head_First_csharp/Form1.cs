using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Head_First_csharp
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty;
        CheckBox fancyBox;
        CheckBox healthyBox;
        Label costLabel;

        public Form1()
        {
            InitializeComponent();
            dinnerParty = new DinnerParty() { NumberOfPeople = 5 };
            dinnerParty.SetHealthyOption(false);
            dinnerParty.CalculateCostOfDecorations(true);
            DisplayDinnerPartyCost();

            // 폼 조정
            this.Size = new Size(270, 300);
            this.Text = "Party Planner";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     // 크기 조정 불가

            // 컨트롤 생성
            CreateLabel("Number of People", new Point(20, 20));
            CreateLabel("Cost", new Point(20, 200));
            fancyBox = CreateCheckBox("Fancy Decorations", new Point(25, 100));
            healthyBox = CreateCheckBox("Healthy Option", new Point(25, 130));
            CreateNumeric(new Point(20, 50));
            costLabel = CreateCost(new Point(100, 200));
        }

        #region controls create
        public void CreateLabel(string text, Point point)
        {
            Label myLabel = new Label();

            myLabel.Text = text;
            myLabel.Location = point;
            if (text == "Cost")
                myLabel.Font = new Font("Arial", 15, FontStyle.Bold);
            else
                myLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            myLabel.AutoSize = true;

            // 폼에 추가
            this.Controls.Add(myLabel);
        }

        public CheckBox CreateCheckBox(string text, Point point)
        {
            CheckBox myCheckbox = new CheckBox();
            myCheckbox.Text = text;
            myCheckbox.Location = point;
            myCheckbox.Font = new Font("Arial", 10, FontStyle.Regular);
            myCheckbox.AutoSize = true;

            this.Controls.Add(myCheckbox);
            return myCheckbox;
        }

        public void CreateNumeric(Point point)
        {
            NumericUpDown myNumeric = new NumericUpDown();

            myNumeric.Location = point;
            myNumeric.Font = new Font("Arial", 10, FontStyle.Regular);
            myNumeric.Minimum = 1;      // 최소값
            myNumeric.Maximum = 20;     // 최대값
            myNumeric.Value = 5;        // 기본값
            myNumeric.AutoSize = true;

            this.Controls.Add(myNumeric);
        }

        public Label CreateCost(Point point)
        {
            Label myCost = new Label();
            myCost.Text = "";
            myCost.Location = point;
            myCost.Font = new Font("Arial", 15, FontStyle.Bold);
            myCost.BorderStyle = BorderStyle.Fixed3D;
            myCost.AutoSize = false;

            // 폼에 추가
            this.Controls.Add(myCost);
            return myCost;
        }

        #endregion

        private void DisplayDinnerPartyCost()
        {
            decimal Cost = dinnerParty.CalculateCost(fancyBox.Checked);
            costLabel.Text = "$" + Cost.ToString("F2");    // ToString 메서드에 "c"를 넘겨주면 통화값(돈)으로 서식을 지정함
        }

    }
}
