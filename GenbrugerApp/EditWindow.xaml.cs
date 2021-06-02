﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GenbrugerApp
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public SkraldData skraldData;
        public EditWindow(SkraldData data)
        {
            InitializeComponent();

            skraldData = data;

            CvrTxt.Clear();
            AnsvarligTxt.Clear();
            BeskrivelseTxt.Clear();
            TidTxt.Clear();
            MængdeTxt.Clear();
            this.CvrTxt.Text = skraldData.CVR.Trim();
            this.AnsvarligTxt.Text = skraldData.Ansvarlig.Trim();
            this.BeskrivelseTxt.Text = skraldData.Beskrivelse.Trim();
            this.TidTxt.Text = skraldData.Tid.ToString("yyyy-MM-dd HH:mm").Trim();
            this.MængdeTxt.Text = skraldData.Mængde.Trim();

            comboBox1.Items.Add("Batterier");
            comboBox1.Items.Add("Biler");
            comboBox1.Items.Add("Elektronikaffald");
            comboBox1.Items.Add("Imprægneret træ");
            comboBox1.Items.Add("Inventar");
            comboBox1.Items.Add("Organisk affald");
            comboBox1.Items.Add("Pap og papir");
            comboBox1.Items.Add("Plastemballager");
            comboBox1.Items.Add("PVC");

            comboBox2.Items.Add("Colli");
            comboBox2.Items.Add("Stk.");
            comboBox2.Items.Add("Ton");
            comboBox2.Items.Add("Kilogram");
            comboBox2.Items.Add("Gram");
            comboBox2.Items.Add("M3");
            comboBox2.Items.Add("Liter");
            comboBox2.Items.Add("Hektoliter");
        }

        public string Mængde { get; set; }
        public string Måleenhed { get; set; }
        public string Kategori { get; set; }
        public string Beskrivelse { get; set; }
        public string Ansvarlig { get; set; }
        public string CVR { get; set; }


        public int KategoriInt;
        public int MåleenhedInt;
        public bool KategoriCheck = false;
        public bool MåleenhedCheck = false;
        public char currentCharacter;
        public bool CvrRequirements = false;
        public bool AnsvarligRequirements = false;
        public bool BeskrivelseRequirements = false;
        public bool MængdeRequirements = false;
        public bool TidRequirements = false;

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (CvrTxt.Text.Length == 8)
            {
                for (int i = 0; i < CvrTxt.Text.Length; i++)
                {
                    currentCharacter = CvrTxt.Text[i];

                    if (char.IsNumber(currentCharacter))
                    {
                        CvrRequirements = true;
                    }
                }
            }

            if (AnsvarligTxt.Text.Length > 0)
            {
                for (int i = 0; i < AnsvarligTxt.Text.Length; i++)
                {
                    currentCharacter = AnsvarligTxt.Text[i];
                    if (char.IsLetter(currentCharacter))
                    {
                        AnsvarligRequirements = true;
                    }
                }
            }

            if (BeskrivelseTxt.Text.Length > 0)
            {
                for (int i = 0; i < BeskrivelseTxt.Text.Length; i++)
                {
                    currentCharacter = BeskrivelseTxt.Text[i];
                    if (char.IsLetter(currentCharacter))
                    {
                        BeskrivelseRequirements = true;
                    }
                }
            }

            if (MængdeTxt.Text.Length > 0)
            {
                for (int i = 0; i < MængdeTxt.Text.Length; i++)
                {
                    currentCharacter = MængdeTxt.Text[i];
                    if (char.IsDigit(currentCharacter))
                    {
                        MængdeRequirements = true;
                    }
                }
            }

            if (TidTxt.Text.Length > 0)
            {
                for (int i = 0; i < TidTxt.Text.Length; i++)
                {
                    currentCharacter = TidTxt.Text[i];
                    if (char.IsDigit(currentCharacter))
                    {
                        TidRequirements = true;
                    }
                }
            }

            switch (comboBox1.SelectedItem)
            {
                case "Batterier":
                    KategoriInt = 1;
                    KategoriCheck = true;
                    break;
                case "Biler":
                    KategoriInt = 2;
                    KategoriCheck = true;
                    break;
                case "Elektronikaffald":
                    KategoriInt = 3;
                    KategoriCheck = true;
                    break;
                case "Imprægneret træ":
                    KategoriInt = 4;
                    KategoriCheck = true;
                    break;
                case "Inventar":
                    KategoriInt = 5;
                    KategoriCheck = true;
                    break;
                case "Organisk affald":
                    KategoriInt = 6;
                    KategoriCheck = true;
                    break;
                case "Pap og papir":
                    KategoriInt = 7;
                    KategoriCheck = true;
                    break;
                case "Plastemballager":
                    KategoriInt = 8;
                    KategoriCheck = true;
                    break;
                case "PVC":
                    KategoriInt = 9;
                    KategoriCheck = true;
                    break;
                default:
                    break;
            }

            switch (comboBox2.SelectedItem)
            {
                case "Colli":
                    MåleenhedInt = 1;
                    MåleenhedCheck = true;
                    break;
                case "Stk.":
                    MåleenhedInt = 2;
                    MåleenhedCheck = true;
                    break;
                case "Ton":
                    MåleenhedInt = 3;
                    MåleenhedCheck = true;
                    break;
                case "Kilogram":
                    MåleenhedInt = 4;
                    MåleenhedCheck = true;
                    break;
                case "Gram":
                    MåleenhedInt = 5;
                    MåleenhedCheck = true;
                    break;
                case "M3":
                    MåleenhedInt = 6;
                    MåleenhedCheck = true;
                    break;
                case "Liter":
                    MåleenhedInt = 7;
                    MåleenhedCheck = true;
                    break;
                case "Hektoliter":
                    MåleenhedInt = 8;
                    MåleenhedCheck = true;
                    break;
                default:
                    break;
            }

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringDelta"].ConnectionString);
                string cmd = string.Format("UPDATE Skrald SET Mængde = '{0}', Måleenhed = '{1}', Kategori = '{2}', Beskrivelse = '{3}', Ansvarlig = '{4}'" +
                    ", CVR = '{5}', Tid = '{6}' WHERE SkraldeID = '{8}'",
                    MængdeTxt.Text.Trim(), MåleenhedInt, KategoriInt, BeskrivelseTxt.Text.Trim(), AnsvarligTxt.Text.Trim(), 
                    CvrTxt.Text.Trim(), TidTxt.Text.Trim(), skraldData.SkraldeID);

                if (KategoriCheck && MåleenhedCheck && CvrRequirements && 
                    AnsvarligRequirements && BeskrivelseRequirements && MængdeRequirements && TidRequirements)
                {
                    SqlCommand command = new SqlCommand(cmd, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    MessageBox.Show("Dine ændringer er nu opdateret.");
                }
                else
                {
                    MessageBox.Show("Du SKAL udfylde alle felter, vælge kategori og måleenhed.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open) connection.Close();
            }
        }

        private void LUK_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}