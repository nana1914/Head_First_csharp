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
        NumericUpDown pNumeric;

        public Form1()
        {
            InitializeComponent();
            dinnerParty = new DinnerParty(); //{ NumberOfPeople = 5 };
            

            // 폼 조정
            this.Size = new Size(270, 300);
            this.Text = "Party Planner";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;     // 크기 조정 불가

            // 컨트롤 생성
            CreateLabel("Number of People", new Point(20, 20));
            CreateLabel("Cost", new Point(20, 200));
            fancyBox = CreateCheckBox("Fancy Decorations", new Point(25, 100));
            fancyBox.Checked = true;
            healthyBox = CreateCheckBox("Healthy Option", new Point(25, 130));
            pNumeric = CreateNumeric(new Point(20, 50));
            costLabel = CreateCost(new Point(100, 200));

            // 이벤트 등록
            fancyBox.CheckedChanged += fancyBox_CheckedChanged;
            healthyBox.CheckedChanged += healthyBox_CheckedChanged;
            pNumeric.ValueChanged += pNumeric_ValueChanged;

            dinnerParty.CalculateCostOfDecorations(fancyBox.Checked);
            dinnerParty.SetHealthyOption(healthyBox.Checked);
            DisplayDinnerPartyCost();
        }

        #region create controls
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

        public NumericUpDown CreateNumeric(Point point)
        {
            NumericUpDown myNumeric = new NumericUpDown();

            myNumeric.Location = point;
            myNumeric.Font = new Font("Arial", 10, FontStyle.Regular);
            myNumeric.Minimum = 1;      // 최소값
            myNumeric.Maximum = 20;     // 최대값
            myNumeric.Value = 5;        // 기본값
            myNumeric.AutoSize = true;

            this.Controls.Add(myNumeric);
            return myNumeric;
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


        #region event callback method

        // object sender: 이벤트를 발생시킨 객체(컨트롤), 이벤트가 발생한 객체 자신을 가리킴, 이벤트가 연결된 컨트롤 확인할 때 사용
        // EventArgs e: 이벤트에 대한 추가 정보 제공, 
        private void pNumeric_ValueChanged(object sender, EventArgs e)      
        {
            //dinnerParty.NumberOfPeople = (int)pNumeric.Value;
            dinnerParty.SetPartyOptions((int)pNumeric.Value, fancyBox.Checked);

            DisplayDinnerPartyCost();
        }

        private void fancyBox_CheckedChanged(object sender, EventArgs e)
        {
            // as 연산자: 객체를 특정 타입으로 변환하는데 사용 (타입 변수 = 객체 as 타입)
            dinnerParty.CalculateCostOfDecorations(fancyBox.Checked);
            DisplayDinnerPartyCost();
        }

        private void healthyBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.SetHealthyOption(healthyBox.Checked);
            DisplayDinnerPartyCost();
        }
        #endregion

        private void DisplayDinnerPartyCost()
        {
            decimal Cost = dinnerParty.CalculateCost(healthyBox.Checked);
            costLabel.Text = "$" + Cost.ToString("F2");    // ToString 메서드에 "c"를 넘겨주면 통화값(돈)으로 서식을 지정함
        }
    }
}
