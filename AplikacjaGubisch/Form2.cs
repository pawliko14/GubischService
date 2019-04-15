using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Xml;
using System.Xml.Serialization;
using S7.Net;
namespace AplikacjaGubisch
{

    public partial class Form2 : Form
    {

        /* Mboxy - odpowiadaja za wyswietlanie message'ow 
            pobranych ze zmiennych DB[].DBX[].[]
            panela sa utworzone dla kazdego modulu, ale nie na wszystkich sa aktywne
        */

        private TextBox Mbox = new TextBox(); // dla TenonVisior text box z messegami
        private TextBox Mbox_Chip = new TextBox(); // dla ChipBreakera
        private TextBox Mbox_Saw = new TextBox(); // dla ChipBreakera
        private TextBox Mbox_STATION = new TextBox();
        private TextBox Mbox_Feedbeam = new TextBox();
        private TextBox Mbox_Spindle1 = new TextBox();
        private TextBox Mbox_Spindle2 = new TextBox();
        private TextBox Mbox_Spindle3 = new TextBox();
        private TextBox Mbox_Groove = new TextBox();
        private TextBox Mbox_Guidens = new TextBox();
        private TextBox Mbox_Clean = new TextBox();


        //Tenon Visior Lists
        List<string> lista_z_PLC;
        List<TextBox> textBox_z_plc;
        List<String> messages_VISIOR;
        List<TextBox> textBoxMessage;
        List<string> Numeracja_zdjecie_VISIOR;

        //Chip Breaker Lists
        List<string> lista_z_PLC_CHIP;
        List<TextBox> textBox_z_plc_CHIP;
        List<String> messages_CHIP;
        List<string> Numeracja_zdjecie_CHIP;

        //SawUnit Breaker Lists
        List<string> lista_z_PLC_SAW;
        List<TextBox> textBox_z_plc_SAW;
        List<String> messages_SAW;
        List<string> Numeracja_zdjecie_SAW;

        //UnloadStation lists
        List<string> lista_z_PLC_STATION;
        List<TextBox> textBox_z_plc_STATION;
        List<String> messages_STATION;
        List<string> Numeracja_zdjecie_STATION;

        //Feedbeam Rollers lists
        List<string> lista_z_PLC_FEEDBEAM;
        List<TextBox> textBox_z_plc_FEEDBEAM;
        List<String> messages_FEEDBEAM;
        List<string> Numeracja_zdjecie_FEEDBEAM;

        //Spindle1 Rollers lists
        List<string> lista_z_PLC_SPINDLE1;
        List<TextBox> textBox_z_plc_SPINDLE1;
        List<String> messages_SPINDLE1;
        List<string> Numeracja_zdjecie_SPINDLE1;

        //Spindle2 Rollers lists
        List<string> lista_z_PLC_SPINDLE2;
        List<TextBox> textBox_z_plc_SPINDLE2;
        List<String> messages_SPINDLE2;
        List<string> Numeracja_zdjecie_SPINDLE2;

        //Spindle3 Rollers lists
        List<string> lista_z_PLC_SPINDLE3;
        List<TextBox> textBox_z_plc_SPINDLE3;
        List<String> messages_SPINDLE3;
        List<string> Numeracja_zdjecie_SPINDLE3;

        //Groove Rollers lists
        List<string> lista_z_PLC_GROOVE;
        List<TextBox> textBox_z_plc_GROOVE;
        List<String> messages_GROOVE;
        List<string> Numeracja_zdjecie_GROOVE;

        //Guidens Lists;
        List<string> lista_z_PLC_GUIDENS;
        List<TextBox> textBox_z_plc_GUIDENS;
        List<String> messages_GUIDENS;
        List<string> Numeracja_zdjecie_GUIDENS;

        //Guidens Lists;
        List<string> lista_z_PLC_CLEAN;
        List<TextBox> textBox_z_plc_CLEAN;
        List<String> messages_CLEAN;
        List<string> Numeracja_zdjecie_CLEAN;

        Plc plc;

        // Panele
        private Panel TenonVisiorPanel = new Panel();
        private Panel ChipBreakerPanel = new Panel();
        private Panel SawUnitPanel = new Panel();
        private Panel UnloadStationPanel = new Panel();
        private Panel FeedbeamRollersPanel = new Panel();
        private Panel SpindlePanel1 = new Panel();
        private Panel SpindlePanel2 = new Panel();
        private Panel SpindlePanel3 = new Panel();
        private Panel GrooveSpindlePanel = new Panel();
        private Panel GuidensPanel = new Panel();
        private Panel CleanTablePanel = new Panel();

        private Panel StartingPanel = new Panel();

        private TenonMachineXML ob;

        // zmienne do rozmiarow boxow
        private static int BoxesHeigh = 20;
        private static int MarkerBoxWidth = 130; // 110
        private static int MarkerBoxLeft = 80;  // 60
        
        private static int DBWboxWidth = 92;

        private static string TenonLang;
        private static string ChipLang;
        private static string SawLang;
        private static string UnloadLang;
        private static string CleanLang;
        private static string FeedbeamLang;
        private static string Spindle1Lang;
        private static string Spindle2Lang;
        private static string Spindle3Lang;
        private static string grooveLang;
        private static string guidensLang;

        public Form2()
        {

            this.MinimumSize = new Size(640, 440);
            this.TenonVisiorPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ChipBreakerPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SawUnitPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UnloadStationPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FeedbeamRollersPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SpindlePanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SpindlePanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SpindlePanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GrooveSpindlePanel.Anchor =  System.Windows.Forms.AnchorStyles.None; 
            this.GuidensPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CleanTablePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackColor = Color.White;

            InitializeComponent();

            
            

            this.Text = "Gubisch CW180900 - Service module";

            //TENON VISIOR //
            TenonVisiorPanel.AutoScroll = false;
            TenonVisiorPanel.HorizontalScroll.Enabled = false;
            TenonVisiorPanel.HorizontalScroll.Visible = false;
            TenonVisiorPanel.HorizontalScroll.Maximum = 0;
            TenonVisiorPanel.AutoScroll = true;

            PictureBox pictureVISIOR = new PictureBox();
            pictureVISIOR.Location = new System.Drawing.Point(300, 50);
            pictureVISIOR.Name = "pictureVISIOR";
            pictureVISIOR.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureVISIOR.BackColor = Color.Black;

            pictureVISIOR.ImageLocation = Properties.Settings.Default.PATHtenonvisior;
            TenonVisiorPanel.Controls.Add(pictureVISIOR);

            // CHIP BREAKER // 
            ChipBreakerPanel.AutoScroll = false;
            ChipBreakerPanel.HorizontalScroll.Enabled = false;
            ChipBreakerPanel.HorizontalScroll.Visible = false;
            ChipBreakerPanel.HorizontalScroll.Maximum = 0;
            ChipBreakerPanel.AutoScroll = true;

            PictureBox picture_CHIP = new PictureBox();
            picture_CHIP.Location = new System.Drawing.Point(300, 50);
            picture_CHIP.Name = "picture_CHIP";
            picture_CHIP.SizeMode = PictureBoxSizeMode.AutoSize;
            picture_CHIP.BackColor = Color.Black;
            picture_CHIP.ImageLocation = Properties.Settings.Default.PATHchipbreaker;
            ChipBreakerPanel.Controls.Add(picture_CHIP);

            // Saw BREAKER // 
            SawUnitPanel.AutoScroll = false;
            SawUnitPanel.HorizontalScroll.Enabled = false;
            SawUnitPanel.HorizontalScroll.Visible = false;
            SawUnitPanel.HorizontalScroll.Maximum = 0;
            SawUnitPanel.AutoScroll = true;

            PictureBox picture_SAW = new PictureBox();
            picture_SAW.Location = new System.Drawing.Point(300, 50);
            picture_SAW.Name = "picture_SAW";
            picture_SAW.SizeMode = PictureBoxSizeMode.AutoSize;
            picture_SAW.BackColor = Color.Black;
            picture_SAW.ImageLocation = Properties.Settings.Default.PATHsawunit;
            SawUnitPanel.Controls.Add(picture_SAW);

            // Unload Station // 
            UnloadStationPanel.AutoScroll = false;
            UnloadStationPanel.HorizontalScroll.Enabled = false;
            UnloadStationPanel.HorizontalScroll.Visible = false;
            UnloadStationPanel.HorizontalScroll.Maximum = 0;
            UnloadStationPanel.AutoScroll = true;

            PictureBox picture_STATION = new PictureBox();
            picture_STATION.Location = new System.Drawing.Point(300, 50);
            picture_STATION.Name = "picture_STATION";
            picture_STATION.SizeMode = PictureBoxSizeMode.AutoSize;
            picture_STATION.BackColor = Color.Black;
            picture_STATION.ImageLocation = Properties.Settings.Default.PATHDP_Station;
            UnloadStationPanel.Controls.Add(picture_STATION);

            // Feedbeam Rollers // 
            UnloadStationPanel.AutoScroll = false;
            UnloadStationPanel.HorizontalScroll.Enabled = false;
            UnloadStationPanel.HorizontalScroll.Visible = false;
            UnloadStationPanel.HorizontalScroll.Maximum = 0;
            UnloadStationPanel.AutoScroll = true;

            PictureBox picture_FEEDBEAM = new PictureBox();
            picture_FEEDBEAM.Location = new System.Drawing.Point(222, 50);
            picture_FEEDBEAM.Name = "picture_FEEDBEAM";
            picture_FEEDBEAM.SizeMode = PictureBoxSizeMode.AutoSize;
            picture_FEEDBEAM.BackColor = Color.Black;
            picture_FEEDBEAM.ImageLocation = Properties.Settings.Default.PATHfeedbeamRollers;
            FeedbeamRollersPanel.Controls.Add(picture_FEEDBEAM);

            // Spindle1 Rollers // 
            SpindlePanel1.AutoScroll = false;
            SpindlePanel1.HorizontalScroll.Enabled = false;
            SpindlePanel1.HorizontalScroll.Visible = false;
            SpindlePanel1.HorizontalScroll.Maximum = 0;
            SpindlePanel1.AutoScroll = true;

            PictureBox picture_Spindle1 = new PictureBox();
            picture_Spindle1.Location = new System.Drawing.Point(220, 50);
            picture_Spindle1.Name = "picture_SPINDLE1";
            picture_Spindle1.SizeMode = PictureBoxSizeMode.AutoSize;
            picture_Spindle1.BackColor = Color.Black;
            picture_Spindle1.ImageLocation = Properties.Settings.Default.PATHspindlehorizontal;
            SpindlePanel1.Controls.Add(picture_Spindle1);

            // Spindle2 Rollers // 
            SpindlePanel2.AutoScroll = false;
            SpindlePanel2.HorizontalScroll.Enabled = false;
            SpindlePanel2.HorizontalScroll.Visible = false;
            SpindlePanel2.HorizontalScroll.Maximum = 0;
            SpindlePanel2.AutoScroll = true;

            PictureBox picture_Spindle2 = new PictureBox();
            picture_Spindle2.Location = new System.Drawing.Point(220, 50);
            picture_Spindle2.Name = "picture_SPINDLE2";
            picture_Spindle2.SizeMode = PictureBoxSizeMode.AutoSize;
            picture_Spindle2.BackColor = Color.Black;
            picture_Spindle2.ImageLocation = Properties.Settings.Default.PATHspindlehorizontal;
            SpindlePanel2.Controls.Add(picture_Spindle2);

            // Spindle3 Rollers // 
            SpindlePanel3.AutoScroll = false;
            SpindlePanel3.HorizontalScroll.Enabled = false;
            SpindlePanel3.HorizontalScroll.Visible = false;
            SpindlePanel3.HorizontalScroll.Maximum = 0;
            SpindlePanel3.AutoScroll = true;

            PictureBox picture_Spindle3 = new PictureBox();
            picture_Spindle3.Location = new System.Drawing.Point(220, 50);
            picture_Spindle3.Name = "picture_SPINDLE3";
            picture_Spindle3.SizeMode = PictureBoxSizeMode.AutoSize;
            picture_Spindle3.BackColor = Color.Black;
            picture_Spindle3.ImageLocation = Properties.Settings.Default.PATHspindlehorizontal;
            SpindlePanel3.Controls.Add(picture_Spindle3);

            // Groove spindle // 
            SpindlePanel3.AutoScroll = false;
            SpindlePanel3.HorizontalScroll.Enabled = false;
            SpindlePanel3.HorizontalScroll.Visible = false;
            SpindlePanel3.HorizontalScroll.Maximum = 0;
            SpindlePanel3.AutoScroll = true;

            PictureBox picture_Groove= new PictureBox();
            picture_Groove.Location = new System.Drawing.Point(220, 50);
            picture_Groove.Name = "picture_GROOVESPINLDE";
            picture_Groove.SizeMode = PictureBoxSizeMode.AutoSize;
            picture_Groove.BackColor = Color.Black;
            picture_Groove.ImageLocation = Properties.Settings.Default.PATHgroovespindle;
            GrooveSpindlePanel.Controls.Add(picture_Groove);

            // Guidens // 
            GuidensPanel.AutoScroll = false;
            GuidensPanel.HorizontalScroll.Enabled = false;
            GuidensPanel.HorizontalScroll.Visible = false;
            GuidensPanel.HorizontalScroll.Maximum = 0;
            GuidensPanel.AutoScroll = true;

            PictureBox picture_Guidens = new PictureBox();
            picture_Guidens.Location = new System.Drawing.Point(220, 50);
            picture_Guidens.Name = "picture_GUIDENS";
            picture_Guidens.SizeMode = PictureBoxSizeMode.AutoSize;
            picture_Guidens.BackColor = Color.Black;
            picture_Guidens.ImageLocation = Properties.Settings.Default.PATHguidens;
            GuidensPanel.Controls.Add(picture_Guidens);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string path = "";
            
            if(Properties.Settings.Default.LanguageOption == "0") // JESLI 0 TO ZALADUJE XML Z ANGIELSKIMI TEKSTAMI
            {
                 path = Properties.Settings.Default.PathToXMLENG;

                TenonLang = "Tenon Visior Module";
                ChipLang = "Chip Breaker Module";
                SawLang = "Saw Unit Module";
                UnloadLang = "Unload Station Module";

                CleanLang = "Clean Table Module";
                FeedbeamLang = "Feedbeam Rollers Module";
                Spindle1Lang = "HORIZONTAL SPINDLE -1- POSITION MODULE";
                Spindle2Lang = "HORIZONTAL SPINDLE -2- POSITION MODULE";
                Spindle3Lang = "HORIZONTAL SPINDLE -3- POSITION MODULE";
                grooveLang = "Groove Spindle Module";
                guidensLang = "Guidens Module";


            }
            else if (Properties.Settings.Default.LanguageOption == "1") // JESLI 1 TO ZALADUJE MXL Z NIEMIECKIMI TEKSTAMI
            {
                 path = Properties.Settings.Default.PathToXMLDEU;

                

                tenonMachineToolStripMenuItem.Text = "Tenonmaschine";
                chipBreakerToolStripMenuItem.Text = "Spanbrecher";
                sawUnitToolStripMenuItem.Text = "Sägeeinheit";
                unloadStationToolStripMenuItem.Text = "Entladestation";

                profileMachineToolStripMenuItem.Text = "Profilmaschine";
                cleanTableToolStripMenuItem.Text = "sauberer Tisch";
                feedbeamTableToolStripMenuItem.Text = "Vorschubstrahl";
                horizontalSpindlePOSToolStripMenuItem.Text = "horizontale Spindelposition";

                spindle1ToolStripMenuItem.Text = "Spindel 1";
                spindle2ToolStripMenuItem.Text = "Spindel 2";
                spindle3ToolStripMenuItem.Text = "Spindel 3";
                grooveSpindleToolStripMenuItem.Text = "Rille Spindel";
                guidensToolStripMenuItem.Text = "Führungsschiene";


                TenonLang = "Tenonmaschine";
                ChipLang = "Spanbrecher";
                SawLang = "Sägeeinheit";
                UnloadLang = "Entladestation";

                CleanLang = "Sauberer Tisch";
                FeedbeamLang = "Vorschubstrahl";
                Spindle1Lang = "Horizontale Spindel 1";
                Spindle2Lang = "Horizontale Spindel 2";
                Spindle3Lang = "Horizontale Spindel 3";
                grooveLang = "Rille Spindel";
                guidensLang = "Führungsschiene";

            }

            FileStream fs = File.OpenRead(path);
             ob = (TenonMachineXML)new XmlSerializer(typeof(TenonMachineXML)).Deserialize(fs); // deserializacja do obiektu klasy Produkty


            plc = new Plc(CpuType.S7300, Properties.Settings.Default.IP, Properties.Settings.Default.Rack, Properties.Settings.Default.Slot);


            lista_z_PLC_CHIP = new List<string>();
            textBox_z_plc_CHIP = new List<TextBox>();
            messages_CHIP = new List<string>();
            Numeracja_zdjecie_CHIP = new List<string>();

            StartStartingPanel();

            LoadChipBreakerToPanel(ob, ChipBreakerPanel, "Chipbreaker");
             CzytajzPLc(lista_z_PLC_CHIP, textBox_z_plc_CHIP, Mbox_Chip, messages_CHIP);

            LoadTenonVisiorToPanel(ob, TenonVisiorPanel, "TenonVisior1");
                CzytajzPLc(lista_z_PLC, textBox_z_plc, Mbox, messages_VISIOR);

               LoadSawUnitToPanel(ob, SawUnitPanel, "SawUnit");
                  CzytajzPLc(lista_z_PLC_SAW, textBox_z_plc_SAW, Mbox_Saw, messages_SAW);

               LoadUnloadStationToPanel(ob, UnloadStationPanel, "UnloadStation");
                 CzytajzPLc(lista_z_PLC_STATION, textBox_z_plc_STATION, Mbox_STATION, messages_STATION);

               LoadFeedbeamRollersToPanel(ob, FeedbeamRollersPanel, "FeedbeamRollers");
                 CzytajzPLc(lista_z_PLC_FEEDBEAM, textBox_z_plc_FEEDBEAM, Mbox_Feedbeam, messages_FEEDBEAM);

               LoadSpindle1ToPanel(ob, SpindlePanel1, "Spindle1");
                 CzytajzPLc(lista_z_PLC_SPINDLE1, textBox_z_plc_SPINDLE1, Mbox_Spindle1, messages_SPINDLE1);

             LoadSpindle2ToPanel(ob, SpindlePanel2, "Spindle2");
                  CzytajzPLc(lista_z_PLC_SPINDLE2, textBox_z_plc_SPINDLE2, Mbox_Spindle2, messages_SPINDLE2);

             LoadSpindle3ToPanel(ob, SpindlePanel3, "Spindle3");
                 CzytajzPLc(lista_z_PLC_SPINDLE3, textBox_z_plc_SPINDLE3, Mbox_Spindle3, messages_SPINDLE3);

            LoadGrooveSpindleToPanel(ob, GrooveSpindlePanel, "GrooveSpindle");
                CzytajzPLc(lista_z_PLC_GROOVE, textBox_z_plc_GROOVE, Mbox_Groove, messages_GROOVE);

            LoadGuidensToPanel(ob, GuidensPanel, "Guidens");
                CzytajzPLc(lista_z_PLC_GUIDENS, textBox_z_plc_GUIDENS, Mbox_Guidens, messages_GUIDENS);

            LoadCleanTableToPanel(ob, CleanTablePanel, "CleanTable");
                CzytajzPLc(lista_z_PLC_CLEAN, textBox_z_plc_CLEAN, Mbox_Clean, messages_CLEAN);


            InitTimer();
        }

        private void StartStartingPanel()
        {
            StartingPanel.Name = "Starting Panel";
            StartingPanel.Size = new System.Drawing.Size(650, 400);
            StartingPanel.Dock = DockStyle.Fill;
            this.Controls.Add(StartingPanel);

            PictureBox picture_Starting = new PictureBox();
            picture_Starting.Location = new System.Drawing.Point(120, 120);
            picture_Starting.Name = "Service Module";
            picture_Starting.SizeMode = PictureBoxSizeMode.AutoSize;
            picture_Starting.BackColor = Color.Black;
            picture_Starting.ImageLocation = Properties.Settings.Default.PATHservicemodulepic;
            StartingPanel.Controls.Add(picture_Starting);
        }


        private void LoadTenonVisiorToPanel(TenonMachineXML ob, Panel pane, string XMLGroup)
        {

            Create_Values_Bar(pane);

            pane.Name = "Tenon Visior";
            pane.Size = new System.Drawing.Size(650, 400);
            pane.Dock = DockStyle.Fill;
            this.Controls.Add(pane);

  
            int top = 70;
            int top2 = 70;

            int left_blokDanych = 50;
            int left_PlcData = 110;
            int left_ToPLC = 170;

            lista_z_PLC = new List<string>();
            textBox_z_plc = new List<TextBox>();
            messages_VISIOR = new List<string>();
            textBoxMessage = new List<TextBox>();

            Numeracja_zdjecie_VISIOR = new List<string>();

            int index = 0;

            foreach (var element in ob.TenonVisior1)
            {
                lista_z_PLC.Add(element.blok_danych.ToString());

                messages_VISIOR.Add(element.komentarz.ToString());

                Numeracja_zdjecie_VISIOR.Add(element.Message.ToString());

                if (!Numeracja_zdjecie_VISIOR[index].Contains("0"))
                {
                    if (lista_z_PLC[index].Contains("I") || lista_z_PLC[index].Contains("O"))
                    {
                        Console.WriteLine("I lub Q" + lista_z_PLC[index]);

                        TextBox box_zdjecie = new TextBox();
                        box_zdjecie.AutoSize = false;
                        box_zdjecie.Text = element.Message.ToString();
                        box_zdjecie.Left = left_blokDanych - 20;
                        box_zdjecie.Top = top;
                        box_zdjecie.Height = BoxesHeigh;
                        box_zdjecie.Width = 15;
                        box_zdjecie.ForeColor = Color.DarkBlue;


                        pane.Controls.Add(box_zdjecie);
                    }
                }
                // SET
                if (lista_z_PLC[index].Contains("M"))
                {
                    Button box3 = new Button();
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;     // topSave
                    pane.Controls.Add(box3);

                    box3.Click += new EventHandler(this.button_click); // event testowy
                }

                //blok danych
                if (!lista_z_PLC[index].Contains("DBX"))
                {
                    TextBox box = new TextBox();
                    box.AutoSize = false;
                    box.ReadOnly = true;
                    box.Text = element.blok_danych.ToString();
                    box.Left = left_blokDanych;
                    box.Top = top;
                    box.Height = BoxesHeigh;

                    if (lista_z_PLC[index].Contains("DBW"))
                    {
                        box.Width = DBWboxWidth;
                        box.Font = new Font("Microsoft Sans Serif", 6.5f);
                        box.Text = element.komentarz.ToString();
                        box.Left = left_blokDanych - 20;

                    }
                    else if (lista_z_PLC[index].Contains("M"))
                    {
                        box.Width = 45; // -5px
                        box.Left = left_blokDanych - 20; // - 10px
                        box.Visible = false;
                    }
                    else
                        box.Width = 50;

                    pane.Controls.Add(box);
                    top += box.Height + 5;

                }

                //PLC data
                TextBox box1 = new TextBox();
                if (!lista_z_PLC[index].Contains("DBX"))
                {  
                    box1.AutoSize = false;
                    box1.ReadOnly = true;
                    box1.Width = 50;
                    box1.Left = left_PlcData;
                    box1.Top = top2;
                    box1.Height = BoxesHeigh;

                    if (lista_z_PLC[index].Contains("DBW"))
                    {
                        box1.Width = 30;
                        box1.Left = left_PlcData + 20;
                    }
                    else if (lista_z_PLC[index].Contains("M"))
                    {
                        box1.Width = MarkerBoxWidth;
                        box1.Left = left_PlcData - MarkerBoxLeft;
                    }
                    else
                    {
                        box1.Width = 50;
                        box1.Left = left_PlcData;
                    }

                    pane.Controls.Add(box1);
                    top2 += box1.Height + 5;

                    
                }
                textBox_z_plc.Add(box1); // dodaj boxa do list gdzie maja byc wypisane dane z plc

               
                index++;
            }


           // Mbox = new TextBox();
            Mbox.Multiline = true;
            Mbox.AutoSize = false;
            Mbox.Top = top;
            Mbox.Left = left_blokDanych;
            Mbox.Width = 250;
            Mbox.Height = 100;


            pane.Controls.Add(Mbox);

        }


        private void LoadChipBreakerToPanel(TenonMachineXML ob, Panel pane, string XMLGroup)
        {


            Create_Values_Bar(pane);

            pane.Name = "Chip breaker";
            pane.Size = new System.Drawing.Size(650, 400);
            pane.Dock = DockStyle.Fill;
            this.Controls.Add(pane);
            

            int top = 70;
            int top2 = 70;

            int left_blokDanych = 50;
            int left_PlcData = 110;
            int left_ToPLC = 170;

            lista_z_PLC_CHIP = new List<string>();
            textBox_z_plc_CHIP = new List<TextBox>();
            messages_CHIP = new List<string>();
            Numeracja_zdjecie_CHIP = new List<string>();
            int index = 0;


            foreach (var element in ob.Chipbreaker)
            {
                lista_z_PLC_CHIP.Add(element.blok_danych.ToString());
                Console.WriteLine("chip braker dane: " + element.blok_danych.ToString());
                messages_CHIP.Add(element.komentarz.ToString());
                
                Numeracja_zdjecie_CHIP.Add(element.Message.ToString());

                if (!Numeracja_zdjecie_CHIP[index].Contains("0"))
                {
                    if (lista_z_PLC_CHIP[index].Contains("I") || lista_z_PLC_CHIP[index].Contains("O"))
                    {
                        Console.WriteLine("I lub Q" + lista_z_PLC_CHIP[index]);

                        TextBox box_zdjecie = new TextBox();
                        box_zdjecie.AutoSize = false;
                        box_zdjecie.Text = element.Message.ToString();
                        box_zdjecie.Left = left_blokDanych - 20;
                        box_zdjecie.Top = top;
                        box_zdjecie.Height = BoxesHeigh;
                        box_zdjecie.Width = 15;
                        box_zdjecie.ForeColor = Color.DarkBlue;


                        pane.Controls.Add(box_zdjecie);
                    }
                }

                // SET
                if (lista_z_PLC_CHIP[index].Contains("M"))
                {
                    Button box3 = new Button();
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;
                    pane.Controls.Add(box3);

                    box3.Click += new EventHandler(this.button_click); // event testowy
                }
                else if (lista_z_PLC_CHIP[index].Contains("DBW"))
                {
                    ComboBox box3 = new ComboBox();
                    box3.DropDownStyle = ComboBoxStyle.DropDownList;
                    box3.Items.Add("1");
                    box3.Items.Add("2");
                    box3.Items.Add("3");
                    box3.Items.Add("4");
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh+10;
                    box3.Left = left_ToPLC;
                    box3.Top = top;
                    pane.Controls.Add(box3);

                 //   box3.Click += new EventHandler(this.comboBox_SelectIndexChanged); // event testowy
                    box3.SelectedValueChanged += new EventHandler(this.comboBox_SelectIndexChanged);
                    
                }

                //blok danych
                if (!lista_z_PLC_CHIP[index].Contains("DBX"))
                {

                    TextBox box = new TextBox();
                    box.AutoSize = false;
                    box.ReadOnly = true;
                    box.Left = left_blokDanych;
                    box.Top = top;
                    box.Height = BoxesHeigh;
                    box.Text = element.blok_danych.ToString();


                    if (lista_z_PLC_CHIP[index].Contains("DBW"))
                    {
                        box.Height = BoxesHeigh + 10;
                        box.Font = new Font("Microsoft Sans Serif", 6.5f);
                        box.Multiline = true;
                        box.Width = DBWboxWidth;
                       
                        box.Text = element.komentarz.ToString();
                        box.Left = left_blokDanych - 20;
                    }
                    else if (lista_z_PLC_CHIP[index].Contains("M"))
                    {
                        box.Width = 45; // -5px
                        box.Left = left_blokDanych - 20; // - 10px
                        box.Visible = false;

                    }
                    else
                        box.Width = 50;

                    pane.Controls.Add(box);

                    if(lista_z_PLC_CHIP[index].Contains("DBW"))
                         top += box.Height + 15;
                    else
                        top += box.Height + 5;

                }

                //PLC data
                TextBox box1 = new TextBox();
                if (!lista_z_PLC_CHIP[index].Contains("DBX"))
                {
                    box1.TextAlign = HorizontalAlignment.Center;
                    box1.AutoSize = false;
                    box1.ReadOnly = true;
                    box1.Height = BoxesHeigh;

                    if (lista_z_PLC_CHIP[index].Contains("DBW"))
                    {
                        box1.Width = 30;
                        box1.Left = left_PlcData + 20;
                        box1.Height = BoxesHeigh + 10;
                    }
                    else if (lista_z_PLC_CHIP[index].Contains("M"))
                    {
                        box1.Width = MarkerBoxWidth;
                        box1.Left = left_PlcData - MarkerBoxLeft;
                    }
                    else
                    {
                        box1.Width = 50;
                        box1.Left = left_PlcData;
                    }

                    box1.Top = top2;

                    pane.Controls.Add(box1);

                    if (lista_z_PLC_CHIP[index].Contains("DBW"))
                        top2 += box1.Height + 15;
                    else
                        top2 += box1.Height + 5;



                }
                textBox_z_plc_CHIP.Add(box1); // dodaj boxa do list gdzie maja byc wypisane dane z plc

               
                index++;
            }
            
            Mbox_Chip.Multiline = true;
            Mbox_Chip.AutoSize = false;
            Mbox_Chip.Top = top;
            Mbox_Chip.Left = left_blokDanych;
            Mbox_Chip.Width = 250;
            Mbox_Chip.Height = 100;


            pane.Controls.Add(Mbox_Chip);
            
        }

        private void LoadSawUnitToPanel(TenonMachineXML ob, Panel pane, string XMLGroup)
        {

            Create_Values_Bar(pane);

            pane.Name = "Saw Unit";
            pane.Size = new System.Drawing.Size(650, 400);
            pane.Dock = DockStyle.Fill;
            this.Controls.Add(pane);


            int top = 70;
            int top2 = 70;

            int left_blokDanych = 50;
            int left_PlcData = 110;
            int left_ToPLC = 170;

            lista_z_PLC_SAW = new List<string>();
            textBox_z_plc_SAW = new List<TextBox>();
            messages_SAW = new List<string>();

            Numeracja_zdjecie_SAW = new List<string>();

            int index = 0;

            foreach (var element in ob.SawUnit)
            {
                lista_z_PLC_SAW.Add(element.blok_danych.ToString());

                messages_SAW.Add(element.komentarz.ToString());

                Numeracja_zdjecie_SAW.Add(element.Message.ToString());

                if (!Numeracja_zdjecie_SAW[index].Contains("0"))
                {
                    if (lista_z_PLC_SAW[index].Contains("I") || lista_z_PLC_SAW[index].Contains("O"))
                    {
                        Console.WriteLine("I lub Q" + lista_z_PLC_SAW[index]);

                        TextBox box_zdjecie = new TextBox();
                        box_zdjecie.AutoSize = false;
                        //   box_zdjecie.ReadOnly = true;
                        box_zdjecie.Text = element.Message.ToString();
                        box_zdjecie.Left = left_blokDanych - 20;
                        box_zdjecie.Top = top;
                        box_zdjecie.Height = BoxesHeigh;
                        box_zdjecie.Width = 15;
                        box_zdjecie.ForeColor = Color.DarkBlue;


                        pane.Controls.Add(box_zdjecie);
                        //top += box_zdjecie.Height + 5;
                    }
                }
                // SET
                if (lista_z_PLC_SAW[index].Contains("M"))
                {
                    Button box3 = new Button();
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;     // topSave
                    pane.Controls.Add(box3);

                    box3.Click += new EventHandler(this.button_click); // event testowy
                }

                //blok danych
                if (!lista_z_PLC_SAW[index].Contains("DBX"))
                {
                    TextBox box = new TextBox();
                    box.AutoSize = false;
                    box.ReadOnly = true;
                    box.Text = element.blok_danych.ToString();
                    box.Left = left_blokDanych;
                    box.Top = top;
                    box.Height = BoxesHeigh;

                    if (lista_z_PLC_SAW[index].Contains("DBW"))
                    {
                        box.Width = DBWboxWidth;
                        box.Font = new Font("Microsoft Sans Serif", 6.5f);
                        box.Text = element.komentarz.ToString();
                        box.Left = left_blokDanych - 20;

                    }
                    else if (lista_z_PLC_SAW[index].Contains("M"))
                    {
                        box.Width = 45; // -5px
                        box.Left = left_blokDanych - 20; // - 10px
                        box.Visible = false;
                    }
                    else
                        box.Width = 50;

                    pane.Controls.Add(box);
                    top += box.Height + 5;

                }

                //PLC data
                TextBox box1 = new TextBox();
                if (!lista_z_PLC_SAW[index].Contains("DBX"))
                {
                    box1.AutoSize = false;
                    box1.ReadOnly = true;
                    box1.Width = 50;
                    box1.Left = left_PlcData;
                    box1.Top = top2;
                    box1.Height = BoxesHeigh;

                    if (lista_z_PLC_SAW[index].Contains("DBW"))
                    {
                        box1.Width = 30;
                        box1.Left = left_PlcData + 20;
                    }
                    else if (lista_z_PLC_SAW[index].Contains("M"))
                    {
                        box1.Width = MarkerBoxWidth;
                        box1.Left = left_PlcData - MarkerBoxLeft;
                    }
                    else
                    {
                        box1.Width = 50;
                        box1.Left = left_PlcData;
                    }

                    pane.Controls.Add(box1);
                    top2 += box1.Height + 5;


                }
                textBox_z_plc_SAW.Add(box1); // dodaj boxa do list gdzie maja byc wypisane dane z plc


                index++;
            }


            // Mbox = new TextBox();
            
            Mbox_Saw.Multiline = true;
            Mbox_Saw.AutoSize = false;
            Mbox_Saw.Top = top;
            Mbox_Saw.Left = left_blokDanych;
            Mbox_Saw.Width = 250;
            Mbox_Saw.Height = 100;


            pane.Controls.Add(Mbox_Saw);
            

        }

        private void LoadUnloadStationToPanel(TenonMachineXML ob, Panel pane, string XMLGroup)
        {
            Create_Values_Bar(pane);

            pane.Name = "Unload Station";
            pane.Size = new System.Drawing.Size(650, 400);
            pane.Dock = DockStyle.Fill;
            this.Controls.Add(pane);


            int top = 70;
            int top2 = 70;

            int left_blokDanych = 50;
            int left_PlcData = 110;
            int left_ToPLC = 170;

            lista_z_PLC_STATION = new List<string>();
            textBox_z_plc_STATION = new List<TextBox>();
            messages_STATION = new List<string>();

            Numeracja_zdjecie_STATION = new List<string>();

            int index = 0;

            foreach (var element in ob.UnloadStation)
            {
                lista_z_PLC_STATION.Add(element.blok_danych.ToString());

                messages_STATION.Add(element.komentarz.ToString());

                Numeracja_zdjecie_STATION.Add(element.Message.ToString());

                if (!Numeracja_zdjecie_STATION[index].Contains("0"))
                {
                    if (lista_z_PLC_STATION[index].Contains("I") || lista_z_PLC_STATION[index].Contains("O"))
                    {
                        Console.WriteLine("I lub Q" + lista_z_PLC_STATION[index]);

                        TextBox box_zdjecie = new TextBox();
                        box_zdjecie.AutoSize = false;
                        //   box_zdjecie.ReadOnly = true;
                        box_zdjecie.Text = element.Message.ToString();
                        box_zdjecie.Left = left_blokDanych - 20;
                        box_zdjecie.Top = top;
                        box_zdjecie.Height = BoxesHeigh;
                        box_zdjecie.Width = 15;
                        box_zdjecie.ForeColor = Color.DarkBlue;

                        pane.Controls.Add(box_zdjecie);
                    }
                }
                // SET
                if (lista_z_PLC_STATION[index].Contains("M"))
                {
                    Button box3 = new Button();
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;     // topSave
                    pane.Controls.Add(box3);

                    box3.Click += new EventHandler(this.button_click); // event testowy
                }

                //blok danych
                if (!lista_z_PLC_STATION[index].Contains("DBX"))
                {
                    TextBox box = new TextBox();
                    box.AutoSize = false;
                    box.ReadOnly = true;
                    box.Text = element.blok_danych.ToString();
                    box.Left = left_blokDanych;
                    box.Top = top;
                    box.Height = BoxesHeigh;

                    if (lista_z_PLC_STATION[index].Contains("DBW"))
                    {
                        box.Width = DBWboxWidth;
                        box.Font = new Font("Microsoft Sans Serif", 6.5f);
                        box.Text = element.komentarz.ToString();
                        box.Left = left_blokDanych - 20;

                    }
                    else if (lista_z_PLC_STATION[index].Contains("M"))
                    {
                        box.Width = 45; // -5px
                        box.Left = left_blokDanych - 20; // - 10px
                        box.Visible = false;
                    }
                    else
                        box.Width = 50;


                    pane.Controls.Add(box);
                    top += box.Height + 5;

                }

                //PLC data
                TextBox box1 = new TextBox();
                if (!lista_z_PLC_STATION[index].Contains("DBX"))
                {
                    box1.AutoSize = false;
                    box1.ReadOnly = true;
                    box1.Width = 50;
                    box1.Left = left_PlcData;
                    box1.Top = top2;
                    box1.Height = BoxesHeigh;

                    if (lista_z_PLC_STATION[index].Contains("DBW"))
                    {
                        box1.Width = 30;
                        box1.Left = left_PlcData + 20;
                    }
                    else if (lista_z_PLC_STATION[index].Contains("M"))
                    {
                        box1.Width = MarkerBoxWidth;
                        box1.Left = left_PlcData - MarkerBoxLeft;
                    }
                    else
                    {
                        box1.Width = 50;
                        box1.Left = left_PlcData;
                    }

                    pane.Controls.Add(box1);
                    top2 += box1.Height + 5;


                }
                textBox_z_plc_STATION.Add(box1); // dodaj boxa do list gdzie maja byc wypisane dane z plc


                index++;
            }
            /*
            Mbox_STATION.Multiline = true;
            Mbox_STATION.AutoSize = false;
            Mbox_STATION.Top = top;
            Mbox_STATION.Left = left_blokDanych;
            Mbox_STATION.Width = 250;
            Mbox_STATION.Height = 100;


            pane.Controls.Add(Mbox_STATION);
            */
        }

        private void LoadFeedbeamRollersToPanel(TenonMachineXML ob, Panel pane, string XMLGroup)
        {
            Create_Values_Bar(pane);

            pane.Name = "Unload Station";
            pane.Size = new System.Drawing.Size(650, 400);
            pane.Dock = DockStyle.Fill;
            this.Controls.Add(pane);


            int top = 70;
            int top2 = 70;

            int left_blokDanych = 50;
            int left_PlcData = 110;
            int left_ToPLC = 170;

            lista_z_PLC_FEEDBEAM = new List<string>();
            textBox_z_plc_FEEDBEAM = new List<TextBox>();
            messages_FEEDBEAM = new List<string>();

            Numeracja_zdjecie_FEEDBEAM = new List<string>();

            int index = 0;

            foreach (var element in ob.FeedbeamRollers)
            {
                lista_z_PLC_FEEDBEAM.Add(element.blok_danych.ToString());

                messages_FEEDBEAM.Add(element.komentarz.ToString());

                Numeracja_zdjecie_FEEDBEAM.Add(element.Message.ToString());

                if (!Numeracja_zdjecie_FEEDBEAM[index].Contains("0"))
                {
                    if (lista_z_PLC_FEEDBEAM[index].Contains("I") || lista_z_PLC_FEEDBEAM[index].Contains("O"))
                    {
                        Console.WriteLine("I lub Q" + lista_z_PLC_FEEDBEAM[index]);

                        TextBox box_zdjecie = new TextBox();
                        box_zdjecie.AutoSize = false;
                        //   box_zdjecie.ReadOnly = true;
                        box_zdjecie.Text = element.Message.ToString();
                        box_zdjecie.Left = left_blokDanych - 20;
                        box_zdjecie.Top = top;
                        box_zdjecie.Height = BoxesHeigh;
                        box_zdjecie.Width = 15;
                        box_zdjecie.ForeColor = Color.DarkBlue;

                        pane.Controls.Add(box_zdjecie);
                    }
                }
                // SET
                if (lista_z_PLC_FEEDBEAM[index].Contains("M"))
                {
                    Button box3 = new Button();
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;     // topSave
                    pane.Controls.Add(box3);

                    box3.Click += new EventHandler(this.button_click); // event testowy
                }
                else if (lista_z_PLC_FEEDBEAM[index].Contains("DBW"))
                {
                    ComboBox box3 = new ComboBox();
                    box3.DropDownStyle = ComboBoxStyle.DropDownList;
                    box3.Items.Add("1");
                    box3.Items.Add("2");
                    box3.Items.Add("3");
                    box3.Items.Add("4");
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;
                    pane.Controls.Add(box3);

                    //   box3.Click += new EventHandler(this.comboBox_SelectIndexChanged); // event testowy
                    box3.SelectedValueChanged += new EventHandler(this.comboBox_SelectIndexChanged);

                }

                //blok danych
                if (!lista_z_PLC_FEEDBEAM[index].Contains("DBX"))
                {
                    TextBox box = new TextBox();
                    box.AutoSize = false;
                    box.ReadOnly = true;
                    box.Text = element.blok_danych.ToString();
                    box.Left = left_blokDanych;
                    box.Top = top;
                    box.Height = BoxesHeigh;

                    if (lista_z_PLC_FEEDBEAM[index].Contains("DBW"))
                    {
                        box.Width = DBWboxWidth;
                        box.Font = new Font("Microsoft Sans Serif", 6.5f);
                        box.Text = element.komentarz.ToString();
                        box.Left = left_blokDanych - 20;

                    }
                    else if (lista_z_PLC_FEEDBEAM[index].Contains("M"))
                    {
                        box.Font = new Font("Microsoft Sans Serif", 6.5f);
                        box.Width = 45; // -5px
                        box.Left = left_blokDanych - 20; // - 10px
                        box.Visible = false;
                    }
                    else
                        box.Width = 50;


                    pane.Controls.Add(box);
                    top += box.Height + 5;

                }

                //PLC data
                TextBox box1 = new TextBox();
                if (!lista_z_PLC_FEEDBEAM[index].Contains("DBX"))
                {
                    box1.AutoSize = false;
                    box1.ReadOnly = true;
                    box1.Width = 50;
                    box1.Left = left_PlcData;
                    box1.Top = top2;
                    box1.Height = BoxesHeigh;

                    if (lista_z_PLC_FEEDBEAM[index].Contains("DBW"))
                    {
                        box1.Width = 30;
                        box1.Left = left_PlcData + 20;
                    }
                    else if (lista_z_PLC_FEEDBEAM[index].Contains("M"))
                    {
                        box1.Width = MarkerBoxWidth;
                        box1.Left = left_PlcData - MarkerBoxLeft;
                    }
                    else
                    {
                        box1.Width = 50;
                        box1.Left = left_PlcData;
                    }

                    pane.Controls.Add(box1);
                    top2 += box1.Height + 5;


                }
                textBox_z_plc_FEEDBEAM.Add(box1); // dodaj boxa do list gdzie maja byc wypisane dane z plc


                index++;
            }
            /*
            Mbox_Feedbeam.Multiline = true;
            Mbox_Feedbeam.AutoSize = false;
            Mbox_Feedbeam.Top = top;
            Mbox_Feedbeam.Left = left_blokDanych;
            Mbox_Feedbeam.Width = 250;
            Mbox_Feedbeam.Height = 100;


            pane.Controls.Add(Mbox_Feedbeam);
            */
        }

        private void LoadSpindle1ToPanel(TenonMachineXML ob, Panel pane, string XMLGroup)
        {
            Create_Values_Bar(pane);

            pane.Name = "Spindle 1";
            pane.Size = new System.Drawing.Size(650, 400);
            pane.Dock = DockStyle.Fill;
            this.Controls.Add(pane);


            int top = 70;
            int top2 = 70;

            int left_blokDanych = 50;
            int left_PlcData = 110;
            int left_ToPLC = 170;

            lista_z_PLC_SPINDLE1 = new List<string>();
            textBox_z_plc_SPINDLE1 = new List<TextBox>();
            messages_SPINDLE1 = new List<string>();

            Numeracja_zdjecie_SPINDLE1 = new List<string>();

            int index = 0;

            foreach (var element in ob.Spindle1)
            {
                lista_z_PLC_SPINDLE1.Add(element.blok_danych.ToString());

                messages_SPINDLE1.Add(element.komentarz.ToString());

                Numeracja_zdjecie_SPINDLE1.Add(element.Message.ToString());

                if (!Numeracja_zdjecie_SPINDLE1[index].Contains("0"))
                {
                    if (lista_z_PLC_SPINDLE1[index].Contains("I") || lista_z_PLC_SPINDLE1[index].Contains("O"))
                    {
                        Console.WriteLine("I lub Q" + lista_z_PLC_SPINDLE1[index]);

                        TextBox box_zdjecie = new TextBox();
                        box_zdjecie.AutoSize = false;
                        //   box_zdjecie.ReadOnly = true;
                        box_zdjecie.Text = element.Message.ToString();
                        box_zdjecie.Left = left_blokDanych - 20;
                        box_zdjecie.Top = top;
                        box_zdjecie.Height = BoxesHeigh;
                        box_zdjecie.Width = 15;
                        box_zdjecie.ForeColor = Color.DarkBlue;

                        pane.Controls.Add(box_zdjecie);
                    }
                }
                // SET
                if (lista_z_PLC_SPINDLE1[index].Contains("M"))
                {
                    Button box3 = new Button();
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;     // topSave
                    pane.Controls.Add(box3);

                    box3.Click += new EventHandler(this.button_click); // event testowy
                }
                else if (lista_z_PLC_SPINDLE1[index].Contains("DBW"))
                {
                    ComboBox box3 = new ComboBox();
                    box3.DropDownStyle = ComboBoxStyle.DropDownList;
                    box3.Items.Add("1");
                    box3.Items.Add("2");
                    box3.Items.Add("3");
                    box3.Items.Add("4");
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;
                    pane.Controls.Add(box3);

                    //   box3.Click += new EventHandler(this.comboBox_SelectIndexChanged); // event testowy
                    box3.SelectedValueChanged += new EventHandler(this.comboBox_SelectIndexChanged);

                }

                //blok danych
                if (!lista_z_PLC_SPINDLE1[index].Contains("DBX"))
                {
                    TextBox box = new TextBox();
                    box.AutoSize = false;
                    box.ReadOnly = true;
                    box.Text = element.blok_danych.ToString();
                    box.Left = left_blokDanych;
                    box.Top = top;
                    box.Height = BoxesHeigh;

                    if (lista_z_PLC_SPINDLE1[index].Contains("DBW"))
                    {
                        box.Width = DBWboxWidth;
                        box.Font = new Font("Microsoft Sans Serif", 6.5f);
                        box.Text = element.komentarz.ToString();
                        box.Left = left_blokDanych - 20;

                    }
                    else if (lista_z_PLC_SPINDLE1[index].Contains("M"))
                    {
                        box.Width = 45; // -5px
                        box.Left = left_blokDanych - 20; // - 10px
                        box.Visible = false;
                    }
                    else
                        box.Width = 50;


                    pane.Controls.Add(box);
                    top += box.Height + 5;

                }

                //PLC data
                TextBox box1 = new TextBox();
                if (!lista_z_PLC_SPINDLE1[index].Contains("DBX"))
                {
                    box1.AutoSize = false;
                    box1.ReadOnly = true;
                  //  box1.Width = 50;
                    box1.Left = left_PlcData;
                    box1.Top = top2;
                    box1.Height = BoxesHeigh;

                    if (lista_z_PLC_SPINDLE1[index].Contains("DBW"))
                    {
                        box1.Width = 30;
                        box1.Left = left_PlcData + 20;
                    }
                    else if (lista_z_PLC_SPINDLE1[index].Contains("M"))
                    {
                        box1.Width = MarkerBoxWidth;
                        box1.Left = left_PlcData - MarkerBoxLeft;

                    }
                    else
                    {
                        box1.Width = 50;
                        box1.Left = left_PlcData;
                    }

                    pane.Controls.Add(box1);
                    top2 += box1.Height + 5;


                }
                textBox_z_plc_SPINDLE1.Add(box1); // dodaj boxa do list gdzie maja byc wypisane dane z plc


                index++;
            }

            Mbox_Spindle1.Multiline = true;
            Mbox_Spindle1.AutoSize = false;
            Mbox_Spindle1.Top = top;
            Mbox_Spindle1.Left = left_blokDanych;
            Mbox_Spindle1.Width = 250;
            Mbox_Spindle1.Height = 100;


            pane.Controls.Add(Mbox_Spindle1);
        }

        private void LoadSpindle2ToPanel(TenonMachineXML ob, Panel pane, string XMLGroup)
        {
            Create_Values_Bar(pane);

            pane.Name = "Spindle 2";
            pane.Size = new System.Drawing.Size(650, 400);
            pane.Dock = DockStyle.Fill;
            this.Controls.Add(pane);


            int top = 70;
            int top2 = 70;

            int left_blokDanych = 50;
            int left_PlcData = 110;
            int left_ToPLC = 170;

            lista_z_PLC_SPINDLE2 = new List<string>();
            textBox_z_plc_SPINDLE2 = new List<TextBox>();
            messages_SPINDLE2 = new List<string>();

            Numeracja_zdjecie_SPINDLE2 = new List<string>();

            int index = 0;

            foreach (var element in ob.Spindle2)
            {
                lista_z_PLC_SPINDLE2.Add(element.blok_danych.ToString());

                messages_SPINDLE2.Add(element.komentarz.ToString());

                Numeracja_zdjecie_SPINDLE2.Add(element.Message.ToString());

                if (!Numeracja_zdjecie_SPINDLE2[index].Contains("0"))
                {
                    if (lista_z_PLC_SPINDLE2[index].Contains("I") || lista_z_PLC_SPINDLE2[index].Contains("O"))
                    {
                        Console.WriteLine("I lub Q" + lista_z_PLC_SPINDLE2[index]);

                        TextBox box_zdjecie = new TextBox();
                        box_zdjecie.AutoSize = false;
                        //   box_zdjecie.ReadOnly = true;
                        box_zdjecie.Text = element.Message.ToString();
                        box_zdjecie.Left = left_blokDanych - 20;
                        box_zdjecie.Top = top;
                        box_zdjecie.Height = BoxesHeigh;
                        box_zdjecie.Width = 15;
                        box_zdjecie.ForeColor = Color.DarkBlue;

                        pane.Controls.Add(box_zdjecie);
                    }
                }
                // SET
                if (lista_z_PLC_SPINDLE2[index].Contains("M"))
                {
                    Button box3 = new Button();
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;     // topSave
                    pane.Controls.Add(box3);

                    box3.Click += new EventHandler(this.button_click); // event testowy
                }
                else if (lista_z_PLC_SPINDLE2[index].Contains("DBW"))
                {
                    ComboBox box3 = new ComboBox();
                    box3.DropDownStyle = ComboBoxStyle.DropDownList;
                    box3.Items.Add("1");
                    box3.Items.Add("2");
                    box3.Items.Add("3");
                    box3.Items.Add("4");
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;
                    pane.Controls.Add(box3);

                    //   box3.Click += new EventHandler(this.comboBox_SelectIndexChanged); // event testowy
                    box3.SelectedValueChanged += new EventHandler(this.comboBox_SelectIndexChanged);

                }

                //blok danych
                if (!lista_z_PLC_SPINDLE2[index].Contains("DBX"))
                {
                    TextBox box = new TextBox();
                    box.AutoSize = false;
                    box.ReadOnly = true;
                    box.Text = element.blok_danych.ToString();
                    box.Left = left_blokDanych;
                    box.Top = top;
                    box.Height = BoxesHeigh;

                    if (lista_z_PLC_SPINDLE2[index].Contains("DBW"))
                    {
                        box.Width = DBWboxWidth;
                        box.Font = new Font("Microsoft Sans Serif", 6.5f);
                        box.Text = element.komentarz.ToString();
                        box.Left = left_blokDanych - 20;

                    }
                    else if (lista_z_PLC_SPINDLE2[index].Contains("M"))
                    {
                        box.Width = 45; // -5px
                        box.Left = left_blokDanych - 20; // - 10px
                        box.Visible = false;
                    }
                    else
                        box.Width = 50;


                    pane.Controls.Add(box);
                    top += box.Height + 5;

                }

                //PLC data
                TextBox box1 = new TextBox();
                if (!lista_z_PLC_SPINDLE2[index].Contains("DBX"))
                {
                    box1.AutoSize = false;
                    box1.ReadOnly = true;
                    box1.Left = left_PlcData;
                    box1.Top = top2;
                    box1.Height = BoxesHeigh;

                    if (lista_z_PLC_SPINDLE2[index].Contains("DBW"))
                    {
                        box1.Width = 30;
                        box1.Left = left_PlcData + 20;
                    }
                    else if (lista_z_PLC_SPINDLE2[index].Contains("M"))
                    {
                        box1.Width = MarkerBoxWidth;
                        box1.Left = left_PlcData - MarkerBoxLeft;
                    }
                    else
                    {
                        box1.Width = 50;
                        box1.Left = left_PlcData;
                    }

                    pane.Controls.Add(box1);
                    top2 += box1.Height + 5;


                }
                textBox_z_plc_SPINDLE2.Add(box1); // dodaj boxa do list gdzie maja byc wypisane dane z plc


                index++;
            }

            Mbox_Spindle2.Multiline = true;
            Mbox_Spindle2.AutoSize = false;
            Mbox_Spindle2.Top = top;
            Mbox_Spindle2.Left = left_blokDanych;
            Mbox_Spindle2.Width = 250;
            Mbox_Spindle2.Height = 100;


            pane.Controls.Add(Mbox_Spindle2);
        }

        private void LoadSpindle3ToPanel(TenonMachineXML ob, Panel pane, string XMLGroup)
        {
            Create_Values_Bar(pane);

            pane.Name = "Spindle 3";
            pane.Size = new System.Drawing.Size(650, 400);
            pane.Dock = DockStyle.Fill;
            this.Controls.Add(pane);


            int top = 70;
            int top2 = 70;

            int left_blokDanych = 50;
            int left_PlcData = 110;
            int left_ToPLC = 170;

            lista_z_PLC_SPINDLE3 = new List<string>();
            textBox_z_plc_SPINDLE3 = new List<TextBox>();
            messages_SPINDLE3 = new List<string>();

            Numeracja_zdjecie_SPINDLE3 = new List<string>();

            int index = 0;

            foreach (var element in ob.Spindle3)
            {
                lista_z_PLC_SPINDLE3.Add(element.blok_danych.ToString());

                messages_SPINDLE3.Add(element.komentarz.ToString());

                Numeracja_zdjecie_SPINDLE3.Add(element.Message.ToString());

                if (!Numeracja_zdjecie_SPINDLE3[index].Contains("0"))
                {
                    if (lista_z_PLC_SPINDLE3[index].Contains("I") || lista_z_PLC_SPINDLE3[index].Contains("O"))
                    {
                        Console.WriteLine("I lub Q" + lista_z_PLC_SPINDLE3[index]);

                        TextBox box_zdjecie = new TextBox();
                        box_zdjecie.AutoSize = false;
                        //   box_zdjecie.ReadOnly = true;
                        box_zdjecie.Text = element.Message.ToString();
                        box_zdjecie.Left = left_blokDanych - 20;
                        box_zdjecie.Top = top;
                        box_zdjecie.Height = BoxesHeigh;
                        box_zdjecie.Width = 15;
                        box_zdjecie.ForeColor = Color.DarkBlue;

                        pane.Controls.Add(box_zdjecie);
                    }
                }
                // SET
                if (lista_z_PLC_SPINDLE3[index].Contains("M"))
                {
                    Button box3 = new Button();
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;     // topSave
                    pane.Controls.Add(box3);

                    box3.Click += new EventHandler(this.button_click); // event testowy
                }
                else if (lista_z_PLC_SPINDLE3[index].Contains("DBW"))
                {
                    ComboBox box3 = new ComboBox();
                    box3.DropDownStyle = ComboBoxStyle.DropDownList;
                    box3.Items.Add("1");
                    box3.Items.Add("2");
                    box3.Items.Add("3");
                    box3.Items.Add("4");
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;
                    pane.Controls.Add(box3);

                    //   box3.Click += new EventHandler(this.comboBox_SelectIndexChanged); // event testowy
                    box3.SelectedValueChanged += new EventHandler(this.comboBox_SelectIndexChanged);

                }

                //blok danych
                if (!lista_z_PLC_SPINDLE3[index].Contains("DBX"))
                {
                    TextBox box = new TextBox();
                    box.AutoSize = false;
                    box.ReadOnly = true;
                    box.Text = element.blok_danych.ToString();
                    box.Left = left_blokDanych;
                    box.Top = top;
                    box.Height = BoxesHeigh;

                    if (lista_z_PLC_SPINDLE3[index].Contains("DBW"))
                    {
                        box.Width = DBWboxWidth;
                        box.Font = new Font("Microsoft Sans Serif", 6.5f);
                        box.Text = element.komentarz.ToString();
                        box.Left = left_blokDanych - 20;

                    }
                    else if (lista_z_PLC_SPINDLE3[index].Contains("M"))
                    {
                        box.Width = 45; // -5px
                        box.Left = left_blokDanych - 20; // - 10px
                        box.Visible = false;
                    }
                    else
                        box.Width = 50;


                    pane.Controls.Add(box);
                    top += box.Height + 5;

                }

                //PLC data
                TextBox box1 = new TextBox();
                if (!lista_z_PLC_SPINDLE3[index].Contains("DBX"))
                {
                    box1.AutoSize = false;
                    box1.ReadOnly = true;
                    box1.Left = left_PlcData;
                    box1.Top = top2;
                    box1.Height = BoxesHeigh;

                    if (lista_z_PLC_SPINDLE3[index].Contains("DBW"))
                    {
                        box1.Width = 30;
                        box1.Left = left_PlcData + 20;
                    }
                    else if (lista_z_PLC_SPINDLE3[index].Contains("M"))
                    {
                        box1.Width = MarkerBoxWidth;
                        box1.Left = left_PlcData - MarkerBoxLeft;
                    }
                    else
                    {
                        box1.Width = 50;
                        box1.Left = left_PlcData;
                    }

                    pane.Controls.Add(box1);
                    top2 += box1.Height + 5;


                }
                textBox_z_plc_SPINDLE3.Add(box1); // dodaj boxa do list gdzie maja byc wypisane dane z plc


                index++;
            }

            Mbox_Spindle3.Multiline = true;
            Mbox_Spindle3.AutoSize = false;
            Mbox_Spindle3.Top = top;
            Mbox_Spindle3.Left = left_blokDanych;
            Mbox_Spindle3.Width = 250;
            Mbox_Spindle3.Height = 100;


            pane.Controls.Add(Mbox_Spindle3);
        }

        private void LoadGrooveSpindleToPanel(TenonMachineXML ob, Panel pane, string XMLGroup)
        {
            Create_Values_Bar(pane);

            pane.Name = "Groove SPindle";
            pane.Size = new System.Drawing.Size(650, 400);
            pane.Dock = DockStyle.Fill;
            this.Controls.Add(pane);


            int top = 70;
            int top2 = 70;

            int left_blokDanych = 50;
            int left_PlcData = 110;
            int left_ToPLC = 170;

            lista_z_PLC_GROOVE = new List<string>();
            textBox_z_plc_GROOVE = new List<TextBox>();
            messages_GROOVE = new List<string>();

            Numeracja_zdjecie_GROOVE = new List<string>();

            int index = 0;

            foreach (var element in ob.GrooveSpindle)
            {
                lista_z_PLC_GROOVE.Add(element.blok_danych.ToString());

                messages_GROOVE.Add(element.komentarz.ToString());

                Numeracja_zdjecie_GROOVE.Add(element.Message.ToString());

                if (!Numeracja_zdjecie_GROOVE[index].Contains("0"))
                {
                    if (lista_z_PLC_GROOVE[index].Contains("I") || lista_z_PLC_GROOVE[index].Contains("O"))
                    {
                        Console.WriteLine("I lub Q" + lista_z_PLC_SPINDLE3[index]);

                        TextBox box_zdjecie = new TextBox();
                        box_zdjecie.AutoSize = false;
                        //   box_zdjecie.ReadOnly = true;
                        box_zdjecie.Text = element.Message.ToString();
                        box_zdjecie.Left = left_blokDanych - 20;
                        box_zdjecie.Top = top;
                        box_zdjecie.Height = BoxesHeigh;
                        box_zdjecie.Width = 15;
                        box_zdjecie.ForeColor = Color.DarkBlue;

                        pane.Controls.Add(box_zdjecie);
                    }
                }
                // SET
                if (lista_z_PLC_GROOVE[index].Contains("M"))
                {
                    Button box3 = new Button();
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;     // topSave
                    pane.Controls.Add(box3);

                    box3.Click += new EventHandler(this.button_click); // event testowy
                }
                else if (lista_z_PLC_GROOVE[index].Contains("DBW"))
                {
                    ComboBox box3 = new ComboBox();
                    box3.DropDownStyle = ComboBoxStyle.DropDownList;
                    box3.Items.Add("0");
                    box3.Items.Add("1");
                    box3.Items.Add("2");
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;
                    pane.Controls.Add(box3);

                    //   box3.Click += new EventHandler(this.comboBox_SelectIndexChanged); // event testowy
                    box3.SelectedValueChanged += new EventHandler(this.comboBox_SelectIndexChanged);

                }

                //blok danych
                if (!lista_z_PLC_GROOVE[index].Contains("DBX"))
                {
                    TextBox box = new TextBox();
                    box.AutoSize = false;
                    box.ReadOnly = true;
                    box.Text = element.blok_danych.ToString();
                    box.Left = left_blokDanych;
                    box.Top = top;
                    box.Height = BoxesHeigh;

                    if (lista_z_PLC_GROOVE[index].Contains("DBW"))
                    {
                        box.Width = DBWboxWidth;
                        box.Font = new Font("Microsoft Sans Serif", 6.5f);
                        box.Text = element.komentarz.ToString();
                        box.Left = left_blokDanych - 20;

                    }
                    else if (lista_z_PLC_GROOVE[index].Contains("M"))
                    {
                        box.Width = 45; // -5px
                        box.Left = left_blokDanych - 20; // - 10px
                        box.Visible = false;
                    }
                    else
                        box.Width = 50;


                    pane.Controls.Add(box);
                    top += box.Height + 5;

                }

                //PLC data
                TextBox box1 = new TextBox();
                if (!lista_z_PLC_GROOVE[index].Contains("DBX"))
                {
                    box1.AutoSize = false;
                    box1.ReadOnly = true;
                    box1.Width = 50;
                    box1.Left = left_PlcData;
                    box1.Top = top2;
                    box1.Height = BoxesHeigh;

                    if (lista_z_PLC_GROOVE[index].Contains("DBW"))
                    {
                        box1.Width = 30;
                        box1.Left = left_PlcData + 20;
                    }
                    else if (lista_z_PLC_GROOVE[index].Contains("M"))
                    {
                        box1.Width = MarkerBoxWidth;
                        box1.Left = left_PlcData - MarkerBoxLeft;
                    }
                    else
                    {
                        box1.Width = 50;
                        box1.Left = left_PlcData;
                    }

                    pane.Controls.Add(box1);
                    top2 += box1.Height + 5;


                }
                textBox_z_plc_GROOVE.Add(box1); // dodaj boxa do list gdzie maja byc wypisane dane z plc


                index++;
            }

            Mbox_Groove.Multiline = true;
            Mbox_Groove.AutoSize = false;
            Mbox_Groove.Top = top;
            Mbox_Groove.Left = left_blokDanych;
            Mbox_Groove.Width = 250;
            Mbox_Groove.Height = 100;


            pane.Controls.Add(Mbox_Groove);
        }

        private void LoadGuidensToPanel(TenonMachineXML ob, Panel pane, string XMLGroup)
        {
            Create_Values_Bar(pane);

            pane.Name = "Guidens";
            pane.Size = new System.Drawing.Size(650, 400);
            pane.Dock = DockStyle.Fill;
            this.Controls.Add(pane);


            int top = 70;
            int top2 = 70;

            int left_blokDanych = 50;
            int left_PlcData = 110;
            int left_ToPLC = 170;

            lista_z_PLC_GUIDENS = new List<string>();
            textBox_z_plc_GUIDENS = new List<TextBox>();
            messages_GUIDENS = new List<string>();

            Numeracja_zdjecie_GUIDENS = new List<string>();

            int index = 0;

            foreach (var element in ob.Guidens)
            {
                lista_z_PLC_GUIDENS.Add(element.blok_danych.ToString());

                messages_GUIDENS.Add(element.komentarz.ToString());

                Numeracja_zdjecie_GUIDENS.Add(element.Message.ToString());

                if (!Numeracja_zdjecie_GUIDENS[index].Contains("0"))
                {
                    if (lista_z_PLC_GUIDENS[index].Contains("I") || lista_z_PLC_GUIDENS[index].Contains("O"))
                    {
                        Console.WriteLine("I lub Q" + lista_z_PLC_GUIDENS[index]);

                        TextBox box_zdjecie = new TextBox();
                        box_zdjecie.AutoSize = false;
                        //   box_zdjecie.ReadOnly = true;
                        box_zdjecie.Text = element.Message.ToString();
                        box_zdjecie.Left = left_blokDanych - 20;
                        box_zdjecie.Top = top;
                        box_zdjecie.Height = BoxesHeigh;
                        box_zdjecie.Width = 15;
                        box_zdjecie.ForeColor = Color.DarkBlue;

                        pane.Controls.Add(box_zdjecie);
                    }
                }
                // SET
                if (lista_z_PLC_GUIDENS[index].Contains("M"))
                {
                    Button box3 = new Button();
                    box3.AutoSize = false;



                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh+10;
                    box3.Left = left_ToPLC;
                    box3.Top = top;     // topSave
                    //box3.Top = top + 10;
                    pane.Controls.Add(box3);

                    box3.Click += new EventHandler(this.button_click); // event testowy
                }
                else if (lista_z_PLC_GUIDENS[index].Contains("DBW"))
                {
                    ComboBox box3 = new ComboBox();
                    box3.DropDownStyle = ComboBoxStyle.DropDownList;
                    box3.Items.Add("1");
                    box3.Items.Add("2");
                    box3.Items.Add("3");
                    box3.Items.Add("4");
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;
                    pane.Controls.Add(box3);

                    box3.SelectedValueChanged += new EventHandler(this.comboBox_SelectIndexChanged);

                }

                //blok danych
                if (!lista_z_PLC_GUIDENS[index].Contains("DBX"))
                {
                    TextBox box = new TextBox();
                    box.AutoSize = false;
                    box.ReadOnly = true;
                    box.Text = element.blok_danych.ToString();
                    box.Left = left_blokDanych;
                    box.Top = top;
                    box.Height = BoxesHeigh;

                    if (lista_z_PLC_GUIDENS[index].Contains("DBW"))
                    {
                        box.Width = DBWboxWidth;
                        box.Font = new Font("Microsoft Sans Serif", 6f);
                        box.Multiline = true;
                        box.Text = element.komentarz.ToString();
                        box.Left = left_blokDanych - 20;
                       

                    }
                    else if (lista_z_PLC_GUIDENS[index].Contains("M"))
                    {
                        box.Width = 45; // -5px
                        box.Left = left_blokDanych - 20; // - 10px
                        box.Visible = false;
                    }
                    else
                        box.Width = 50;


                    pane.Controls.Add(box);
                    if(lista_z_PLC_GUIDENS[index].Contains("M"))
                        top += box.Height + 25; // BYLO 10
                    else
                        top += box.Height + 5;

                }

                //PLC data
                TextBox box1 = new TextBox();
                if (!lista_z_PLC_GUIDENS[index].Contains("DBX"))
                {
                    box1.AutoSize = false;
                    box1.ReadOnly = true;
                    box1.Width = 50;
                    box1.Left = left_PlcData;
                    box1.Top = top2;
                    box1.Height = BoxesHeigh;

                    if (lista_z_PLC_GUIDENS[index].Contains("DBW"))
                    {
                        box1.Width = 30;
                        box1.Left = left_PlcData + 20;
                    }
                    else if (lista_z_PLC_GUIDENS[index].Contains("M"))
                    {
                        box1.Multiline = true; // dodane dzisiaj 10.04.19

                        box1.Width = MarkerBoxWidth;
                        box1.Left = left_PlcData - MarkerBoxLeft;
                        box1.Height = BoxesHeigh + 10;
                    }
                    else
                    {
                        box1.Width = 50;
                        box1.Left = left_PlcData;
                    }

                    pane.Controls.Add(box1);

                    if (lista_z_PLC_GUIDENS[index].Contains("M"))
                        top2 += box1.Height + 15;
                    else
                        top2 += box1.Height + 5;


                }
                textBox_z_plc_GUIDENS.Add(box1); // dodaj boxa do list gdzie maja byc wypisane dane z plc


                index++;
            }
        }

        private void LoadCleanTableToPanel(TenonMachineXML ob, Panel pane, string XMLGroup)
        {
            Create_Values_Bar(pane);

            pane.Name = "Clean Table";
            pane.Size = new System.Drawing.Size(650, 400);
            pane.Dock = DockStyle.Fill;
            this.Controls.Add(pane);


            int top = 70;
            int top2 = 70;

            int left_blokDanych = 50;
            int left_PlcData = 110;
            int left_ToPLC = 170;

            lista_z_PLC_CLEAN = new List<string>();
            textBox_z_plc_CLEAN = new List<TextBox>();
            messages_CLEAN = new List<string>();

            Numeracja_zdjecie_CLEAN = new List<string>();

            int index = 0;

            foreach (var element in ob.CleanTable)
            {
                lista_z_PLC_CLEAN.Add(element.blok_danych.ToString());

                messages_CLEAN.Add(element.komentarz.ToString());

                Numeracja_zdjecie_CLEAN.Add(element.Message.ToString());

                if (!Numeracja_zdjecie_CLEAN[index].Contains("0"))
                {
                    if (lista_z_PLC_CLEAN[index].Contains("I") || lista_z_PLC_CLEAN[index].Contains("O"))
                    {
                        Console.WriteLine("I lub Q" + lista_z_PLC_CLEAN[index]);

                        TextBox box_zdjecie = new TextBox();
                        box_zdjecie.AutoSize = false;
                        //   box_zdjecie.ReadOnly = true;
                        box_zdjecie.Text = element.Message.ToString();
                        box_zdjecie.Left = left_blokDanych - 20;
                        box_zdjecie.Top = top;
                        box_zdjecie.Height = BoxesHeigh;
                        box_zdjecie.Width = 15;
                        box_zdjecie.ForeColor = Color.DarkBlue;

                        pane.Controls.Add(box_zdjecie);
                    }
                }
                // SET
                if (lista_z_PLC_CLEAN[index].Contains("M"))
                {
                    Button box3 = new Button();
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;     // topSave
                    pane.Controls.Add(box3);

                    box3.Click += new EventHandler(this.button_click); // event testowy
                }

                // przypadek tylko dla clean table
                else if (lista_z_PLC_CLEAN[index].Contains("DBW"))
                {
                    ComboBox box3 = new ComboBox();
                    box3.DropDownStyle = ComboBoxStyle.DropDownList;
                    box3.Items.Add("500");
                    box3.Items.Add("1000");
                    box3.Items.Add("1500");
                    box3.Items.Add("2000");
                    box3.Items.Add("2500");
                    box3.Items.Add("3000");
                    box3.Items.Add("3500");
                    box3.AutoSize = false;

                    box3.Text = "SET";
                    box3.Name = index.ToString(); // jako sama cyfra
                    box3.Width = 50;
                    box3.Height = BoxesHeigh;
                    box3.Left = left_ToPLC;
                    box3.Top = top;
                    pane.Controls.Add(box3);

                    box3.SelectedValueChanged += new EventHandler(this.comboBox_SelectIndexChanged);

                }

                //blok danych
                if (!lista_z_PLC_CLEAN[index].Contains("DBX"))
                {
                    TextBox box = new TextBox();
                    box.AutoSize = false;
                    box.ReadOnly = true;
                    box.Text = element.blok_danych.ToString();
                    box.Left = left_blokDanych;
                    box.Top = top;
                    box.Height = BoxesHeigh;

                    if (lista_z_PLC_CLEAN[index].Contains("DBW"))
                    {
                        box.Width = DBWboxWidth;
                        box.Font = new Font("Microsoft Sans Serif", 6.5f);
                        box.Text = element.komentarz.ToString();
                        box.Left = left_blokDanych - 20;

                    }
                    else if (lista_z_PLC_CLEAN[index].Contains("M"))
                    {
                        box.Width = 45; // -5px
                      //  box.Multiline = true;
                        box.Left = left_blokDanych - 20; // - 10px
                        box.Visible = false;
                    }
                    else
                        box.Width = 50;



                    pane.Controls.Add(box);
                    top += box.Height + 5;

                }

                //PLC data
                TextBox box1 = new TextBox();
                if (!lista_z_PLC_CLEAN[index].Contains("DBX"))
                {
                    box1.TextAlign = HorizontalAlignment.Center;
                    box1.AutoSize = false;
                    box1.ReadOnly = true;
                    box1.Height = BoxesHeigh;


                    if (lista_z_PLC_CLEAN[index].Contains("DBW"))
                    {
                        box1.Width = 30;
                        box1.Left = left_PlcData + 20;
                    }
                    else if (lista_z_PLC_CLEAN[index].Contains("M"))
                    {
                        box1.Width = MarkerBoxWidth;
                        box1.Left = left_PlcData - MarkerBoxLeft;
                       // box1.Multiline = true;
                      //  box1.Height = BoxesHeigh + 10;

                    }
                    else
                    {
                        box1.Width = 50;
                        box1.Left = left_PlcData;
                    }

                    box1.Top = top2;
                    

                    pane.Controls.Add(box1);
                //    if (lista_z_PLC_CLEAN[index].Contains("M"))
                  //      top2 += box1.Height + 15;
                   // else

                        top2 += box1.Height + 5;


                }
                textBox_z_plc_CLEAN.Add(box1); // dodaj boxa do list gdzie maja byc wypisane dane z plc


                index++;
            }

            Mbox_Clean.Multiline = true;
            Mbox_Clean.AutoSize = false;
            Mbox_Clean.Top = top;
            Mbox_Clean.Left = left_blokDanych;
            Mbox_Clean.Width = 250;
            Mbox_Clean.Height = 100;


            pane.Controls.Add(Mbox_Clean);
        }


        /*
         uniwersalna funkcja czytajaca z plc
         */
        private void CzytajzPLc(List<string> listaP, List<TextBox> textBoxPLC, TextBox mmm, List<String> messs)
        {
            TextBox tempb = new TextBox();
            plc.Open();
            mmm.Text = ""; // zeruj textBoxa zeby wpisac na czysto
            int index_Mess = 0;

            for (int i = 0; i < listaP.Count; i++)
            {
                if (listaP[i].StartsWith("M")) // ODCZYTANIE TYLKO MARKEROW - MARKERY MUSZA BYC W BAJTACH!
                {

                    string last = listaP[i].Substring(listaP[i].Length - 1, 1); // np M601.2 to odczyta 2
                    int lastToBit = Convert.ToInt32(last);

                    byte tempByte = 8;         // bo byte to 0...7 bitow
                    bool temp;
                    tempByte = Convert.ToByte(plc.Read(listaP[i]));
                    temp = tempByte.SelectBit(lastToBit);
                  //  textBoxPLC[i].Text = temp.ToString(); // zamianka na ponizszy wiersz
                    textBoxPLC[i].Text = messs[i];
                    textBoxPLC[i].Font = new Font("Microsoft Sans Serif", 6.5f);

                    /*
                   if (textBoxPLC[i].Text == "False")
                   {
                       textBoxPLC[i].BackColor = Color.OrangeRed;
                    //   textBoxPLC[i].ForeColor = Color.OrangeRed;
                   }
                   else if (textBoxPLC[i].Text == "True")
                   {
                    //   textBoxPLC[i].ForeColor = Color.GreenYellow;
                      textBoxPLC[i].BackColor = Color.GreenYellow;
                   }
                   */
                }
                else if (listaP[i].Contains("DBW"))
                {
                    textBoxPLC[i].Text = Convert.ToInt32(plc.Read(listaP[i])).ToString();
                    
                }
                else
                {
                 
                   textBoxPLC[i].Text = Convert.ToBoolean(plc.Read(listaP[i])).ToString();

                    if (textBoxPLC[i].Text == "False")
                    {
                        textBoxPLC[i].BackColor = Color.OrangeRed;
                        textBoxPLC[i].ForeColor = Color.OrangeRed;
                    }
                    else if (textBoxPLC[i].Text == "True")
                    {
                        textBoxPLC[i].ForeColor = Color.GreenYellow;
                        textBoxPLC[i].BackColor = Color.GreenYellow;
                    }
                }
                 

                // WCZYTANIE TEKTOW DO MESSEG BOXA
                if (listaP[i].Contains("DBX"))
                {
            
                      Console.WriteLine(" DBX'y: " + listaP[i]);
                    if(textBoxPLC[i].Text == "False")
                    {
                        Console.WriteLine(" DBX'y: FALSE ");
                    }
                    else
                    {                    
                            index_Mess++;
                        tempb.AppendText("Message " + index_Mess + ":  " + messs[i] + Environment.NewLine);                       
                    }

                }
                  
                mmm.Text = tempb.Text;
            }
       
            plc.Close();
  
        }

       private void button_click(object sender, EventArgs e)
        {
            //get the button clicked
            Button btn = sender as Button;

            if (TenonVisiorPanel.Visible == true)
            {
                ZapiszDoPlc(lista_z_PLC[Convert.ToInt32(btn.Name)], "TRUE");
            }
            else if (ChipBreakerPanel.Visible == true)
            {
                ZapiszDoPlc(lista_z_PLC_CHIP[Convert.ToInt32(btn.Name)], "TRUE");
            }
            else if(SawUnitPanel.Visible == true)
            {
                ZapiszDoPlc(lista_z_PLC_SAW[Convert.ToInt32(btn.Name)], "TRUE");
            }
            else if (UnloadStationPanel.Visible == true)
            {
                ZapiszDoPlc(lista_z_PLC_STATION[Convert.ToInt32(btn.Name)], "TRUE");
            }
            else if (FeedbeamRollersPanel.Visible == true)
            {
                ZapiszDoPlc(lista_z_PLC_FEEDBEAM[Convert.ToInt32(btn.Name)], "TRUE");
            }
            else if (SpindlePanel1.Visible == true)
            {
                ZapiszDoPlc(lista_z_PLC_SPINDLE1[Convert.ToInt32(btn.Name)], "TRUE");
            }
            else if (SpindlePanel2.Visible == true)
            {
                ZapiszDoPlc(lista_z_PLC_SPINDLE2[Convert.ToInt32(btn.Name)], "TRUE");
            }
            else if (SpindlePanel3.Visible == true)
            {
                ZapiszDoPlc(lista_z_PLC_SPINDLE3[Convert.ToInt32(btn.Name)], "TRUE");
            }

            else if (GrooveSpindlePanel.Visible == true)
            {
                ZapiszDoPlc(lista_z_PLC_GROOVE[Convert.ToInt32(btn.Name)], "TRUE");
            }
            else if (GuidensPanel.Visible == true)
            {
                ZapiszDoPlc(lista_z_PLC_GUIDENS[Convert.ToInt32(btn.Name)], "TRUE");
            }
            else if(CleanTablePanel.Visible == true)
            {
                ZapiszDoPlc(lista_z_PLC_CLEAN[Convert.ToInt32(btn.Name)], "TRUE");
            }

        }
        private void comboBox_SelectIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox1 = sender as ComboBox;
       
            string selectedEmployee = (string)comboBox1.SelectedItem;

            //chip breaker
            if (ChipBreakerPanel.Visible == true)
            {
                ZapiszDoPLCInt(lista_z_PLC_CHIP[Convert.ToInt32(comboBox1.Name)], selectedEmployee);
            }

            //tenon visior
            else if (TenonVisiorPanel.Visible == true)
            {
                ZapiszDoPLCInt(lista_z_PLC[Convert.ToInt32(comboBox1.Name)], selectedEmployee);
            }
            else if (SawUnitPanel.Visible == true)
            {
                ZapiszDoPLCInt(lista_z_PLC_SAW[Convert.ToInt32(comboBox1.Name)], selectedEmployee);
            }
            else if(CleanTablePanel.Visible == true)
            {
                ZapiszDoPLCInt(lista_z_PLC_CLEAN[Convert.ToInt32(comboBox1.Name)], selectedEmployee);
            }
            else if (UnloadStationPanel.Visible == true)
            {
                ZapiszDoPLCInt(lista_z_PLC_STATION[Convert.ToInt32(comboBox1.Name)], selectedEmployee);
            }
            else if (FeedbeamRollersPanel.Visible == true)
            {
                ZapiszDoPLCInt(lista_z_PLC_FEEDBEAM[Convert.ToInt32(comboBox1.Name)], selectedEmployee);
            }
            else if (SpindlePanel1.Visible == true)
            {
                ZapiszDoPLCInt(lista_z_PLC_SPINDLE1[Convert.ToInt32(comboBox1.Name)], selectedEmployee);
            }
            else if (SpindlePanel2.Visible == true)
            {
                ZapiszDoPLCInt(lista_z_PLC_SPINDLE2[Convert.ToInt32(comboBox1.Name)], selectedEmployee);
            }
            else if (SpindlePanel3.Visible == true)
            {
                ZapiszDoPLCInt(lista_z_PLC_SPINDLE3[Convert.ToInt32(comboBox1.Name)], selectedEmployee);
            }
            else if (GrooveSpindlePanel.Visible == true)
            {
                ZapiszDoPLCInt(lista_z_PLC_GROOVE[Convert.ToInt32(comboBox1.Name)], selectedEmployee);
            }


        }


            private void ZapiszDoPLCInt(String dbName, String value)
            {
            plc.Open();
             plc.Write(dbName, UInt16.Parse(value)); // parsuje ze stringa na uinta
            plc.Close();
        }

        private void ZapiszDoPlc(String dbName, String value)
        {
            plc.Open();
                plc.Write(dbName, bool.Parse(value)); // parse na boola
            plc.Close();

        }  

        private void Create_Values_Bar(Panel pan)
        {
            TextBox Reg = new TextBox();
            Reg.ReadOnly = true;
                Reg.Top = 45;
                Reg.Left = 30;
                Reg.Width = 130;
                Reg.Height = 20;

                Reg.Name = "RegisterValues";
                Reg.Text = "Register";

            pan.Controls.Add(Reg);

            TextBox PLC_data = new TextBox();
            PLC_data.ReadOnly = true;
                PLC_data.Top = 45;
                PLC_data.Left = 170;
                PLC_data.Width = 50;
                PLC_data.Height = 20;

                PLC_data.Name = "PlcData";
                PLC_data.Text = "PlcData";

            pan.Controls.Add(PLC_data);
        }

        private void chipBreakerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenonVisiorPanel.Visible = false;
            ChipBreakerPanel.Visible = true;
            SawUnitPanel.Visible = false;
            UnloadStationPanel.Visible = false;
            FeedbeamRollersPanel.Visible = false;
            SpindlePanel1.Visible = false;
            SpindlePanel2.Visible = false;
            SpindlePanel3.Visible = false;
            GrooveSpindlePanel.Visible = false;
            GuidensPanel.Visible = false;
            CleanTablePanel.Visible = false;
            StartingPanel.Visible = false;



            Mbox_Chip.Visible = true;
            Mbox.Visible = false;
            Mbox_Saw.Visible = false;
            Mbox_STATION.Visible = false;
            Mbox_Feedbeam.Visible = false;
            Mbox_Spindle1.Visible = false;
            Mbox_Spindle2.Visible = false;
            Mbox_Spindle3.Visible = false;
            Mbox_Groove.Visible = false;
            Mbox_Guidens.Visible = false;
            Mbox_Clean.Visible = false;

            //  this.Text = "CHIP BREAKER MODULE";
            this.Text = ChipLang;

        }

        private void tenonVisiorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenonVisiorPanel.Visible = true;
            ChipBreakerPanel.Visible = false;
            SawUnitPanel.Visible = false;
            UnloadStationPanel.Visible = false;
            FeedbeamRollersPanel.Visible = false;
            SpindlePanel1.Visible = false;
            SpindlePanel2.Visible = false;
            SpindlePanel3.Visible = false;
            GrooveSpindlePanel.Visible = false;
            GuidensPanel.Visible = false;
            CleanTablePanel.Visible = false;
            StartingPanel.Visible = false;


            Mbox_Chip.Visible = false;
            Mbox.Visible = true;
            Mbox_Saw.Visible = false;
            Mbox_STATION.Visible = false;
            Mbox_Feedbeam.Visible = false;
            Mbox_Spindle1.Visible = false;
            Mbox_Spindle2.Visible = false;
            Mbox_Spindle3.Visible = false;
            Mbox_Groove.Visible = false;
            Mbox_Guidens.Visible = false;
            Mbox_Clean.Visible = false;

           // this.Text = "TENON VISIOR MODULE";
           this.Text = TenonLang;
        }

        private void sawUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenonVisiorPanel.Visible = false;
            ChipBreakerPanel.Visible = false;
            SawUnitPanel.Visible = true;
            UnloadStationPanel.Visible = false;
            FeedbeamRollersPanel.Visible = false;
            SpindlePanel1.Visible = false;
            SpindlePanel2.Visible = false;
            SpindlePanel3.Visible = false;
            GrooveSpindlePanel.Visible = false;
            GuidensPanel.Visible = false;
            CleanTablePanel.Visible = false;
            StartingPanel.Visible = false;


            Mbox_Chip.Visible = false;
            Mbox.Visible = false;
            Mbox_Saw.Visible = true;
            Mbox_STATION.Visible = false;
            Mbox_Feedbeam.Visible = false;
            Mbox_Spindle1.Visible = false;
            Mbox_Spindle2.Visible = false;
            Mbox_Spindle3.Visible = false;
            Mbox_Groove.Visible = false;
            Mbox_Guidens.Visible = false;
            Mbox_Clean.Visible = false;

            // this.Text = "SAW UNIT MODULE";
            this.Text = SawLang;
        }

        private void unloadStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenonVisiorPanel.Visible = false;
            ChipBreakerPanel.Visible = false;
            SawUnitPanel.Visible = false;
            UnloadStationPanel.Visible = true;
            FeedbeamRollersPanel.Visible = false;
            SpindlePanel1.Visible = false;
            SpindlePanel2.Visible = false;
            SpindlePanel3.Visible = false;
            GrooveSpindlePanel.Visible = false;
            GuidensPanel.Visible = false;
            CleanTablePanel.Visible = false;
            StartingPanel.Visible = false;


            Mbox_Chip.Visible = false;
            Mbox.Visible = false;
            Mbox_Saw.Visible = false;
            Mbox_STATION.Visible = true;
            Mbox_Feedbeam.Visible = false;
            Mbox_Spindle1.Visible = false;
            Mbox_Spindle2.Visible = false;
            Mbox_Spindle3.Visible = false;
            Mbox_Groove.Visible = false;
            Mbox_Guidens.Visible = false;
            Mbox_Clean.Visible = false;

            //  this.Text = "UNLOAD STATION MODULE";
            this.Text = UnloadLang;
        }

        private void feedbeamTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenonVisiorPanel.Visible = false;
            ChipBreakerPanel.Visible = false;
            SawUnitPanel.Visible = false;
            UnloadStationPanel.Visible = false;
            FeedbeamRollersPanel.Visible = true;
            SpindlePanel1.Visible = false;
            SpindlePanel2.Visible = false;
            SpindlePanel3.Visible = false;
            GrooveSpindlePanel.Visible = false;
            GuidensPanel.Visible = false;
            CleanTablePanel.Visible = false;
            StartingPanel.Visible = false;


            Mbox_Chip.Visible = false;
            Mbox.Visible = false;
            Mbox_Saw.Visible = false;
            Mbox_STATION.Visible = false;
            Mbox_Feedbeam.Visible = true;
            Mbox_Spindle1.Visible = false;
            Mbox_Spindle2.Visible = false;
            Mbox_Spindle3.Visible = false;

            Mbox_Groove.Visible = false;
            Mbox_Guidens.Visible = false;
            Mbox_Clean.Visible = false;

            // this.Text = "FEEDBEAM ROLLERS MODULE";
            this.Text = FeedbeamLang;
        }

        private void spindle1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenonVisiorPanel.Visible = false;
            ChipBreakerPanel.Visible = false;
            SawUnitPanel.Visible = false;
            UnloadStationPanel.Visible = false;
            FeedbeamRollersPanel.Visible = false;
            SpindlePanel1.Visible = true;
            SpindlePanel2.Visible = false;
            SpindlePanel3.Visible = false;
            GrooveSpindlePanel.Visible = false;
            GuidensPanel.Visible = false;
            CleanTablePanel.Visible = false;
            StartingPanel.Visible = false;


            Mbox_Chip.Visible = false;
            Mbox.Visible = false;
            Mbox_Saw.Visible = false;
            Mbox_STATION.Visible = false;
            Mbox_Feedbeam.Visible = false;
            Mbox_Spindle1.Visible = true;
            Mbox_Spindle2.Visible = false;
            Mbox_Spindle3.Visible = false;
            Mbox_Groove.Visible = false;
            Mbox_Guidens.Visible = false;
            Mbox_Clean.Visible = false;

            //  this.Text = "HORIZONTAL SPINDLE -1- POSITION MODULE";
            this.Text = Spindle1Lang;
        }

        private void spindle2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenonVisiorPanel.Visible = false;
            ChipBreakerPanel.Visible = false;
            SawUnitPanel.Visible = false;
            UnloadStationPanel.Visible = false;
            FeedbeamRollersPanel.Visible = false;
            SpindlePanel1.Visible = false;
            SpindlePanel2.Visible = true;
            SpindlePanel3.Visible = false;
            GrooveSpindlePanel.Visible = false;
            GuidensPanel.Visible = false;
            CleanTablePanel.Visible = false;
            StartingPanel.Visible = false;


            Mbox_Chip.Visible = false;
            Mbox.Visible = false;
            Mbox_Saw.Visible = false;
            Mbox_STATION.Visible = false;
            Mbox_Feedbeam.Visible = false;
            Mbox_Spindle1.Visible = false;
            Mbox_Spindle2.Visible = true;
            Mbox_Spindle3.Visible = false;
            Mbox_Groove.Visible = false;
            Mbox_Guidens.Visible = false;
            Mbox_Clean.Visible = false;

            // this.Text = "HORIZONTAL SPINDLE -2- POSITION MODULE";
            this.Text = Spindle2Lang;


        }

        private void spindle3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenonVisiorPanel.Visible = false;
            ChipBreakerPanel.Visible = false;
            SawUnitPanel.Visible = false;
            UnloadStationPanel.Visible = false;
            FeedbeamRollersPanel.Visible = false;
            SpindlePanel1.Visible = false;
            SpindlePanel2.Visible = false;
            SpindlePanel3.Visible = true;
            GrooveSpindlePanel.Visible = false;
            GuidensPanel.Visible = false;
            CleanTablePanel.Visible = false;
            StartingPanel.Visible = false;


            Mbox_Chip.Visible = false;
            Mbox.Visible = false;
            Mbox_Saw.Visible = false;
            Mbox_STATION.Visible = false;
            Mbox_Feedbeam.Visible = false;
            Mbox_Spindle1.Visible = false;
            Mbox_Spindle2.Visible = false;
            Mbox_Spindle3.Visible = true;
            Mbox_Groove.Visible = false;
            Mbox_Guidens.Visible = false;
            Mbox_Clean.Visible = false;

            //    this.Text = "HORIZONTAL SPINDLE -3- POSITION MODULE";
            this.Text = Spindle3Lang;


        }
        private void grooveSpindleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenonVisiorPanel.Visible = false;
            ChipBreakerPanel.Visible = false;
            SawUnitPanel.Visible = false;
            UnloadStationPanel.Visible = false;
            FeedbeamRollersPanel.Visible = false;
            SpindlePanel1.Visible = false;
            SpindlePanel2.Visible = false;
            SpindlePanel3.Visible = false;
            GrooveSpindlePanel.Visible = true;
            GuidensPanel.Visible = false;
            CleanTablePanel.Visible = false;
            StartingPanel.Visible = false;


            Mbox_Chip.Visible = false;
            Mbox.Visible = false;
            Mbox_Saw.Visible = false;
            Mbox_STATION.Visible = false;
            Mbox_Feedbeam.Visible = false;
            Mbox_Spindle1.Visible = false;
            Mbox_Spindle2.Visible = false;
            Mbox_Spindle3.Visible = false;
            Mbox_Groove.Visible = true;
            Mbox_Guidens.Visible = false;
            Mbox_Clean.Visible = false;

            // this.Text = "GROOVE SPINDLE MODULE";
            this.Text = grooveLang;

        }

        private void guidensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenonVisiorPanel.Visible = false;
            ChipBreakerPanel.Visible = false;
            SawUnitPanel.Visible = false;
            UnloadStationPanel.Visible = false;
            FeedbeamRollersPanel.Visible = false;
            SpindlePanel1.Visible = false;
            SpindlePanel2.Visible = false;
            SpindlePanel3.Visible = false;
            GrooveSpindlePanel.Visible = false;
            GuidensPanel.Visible = true;
            CleanTablePanel.Visible = false;
            StartingPanel.Visible = false;


            Mbox_Chip.Visible = false;
            Mbox.Visible = false;
            Mbox_Saw.Visible = false;
            Mbox_STATION.Visible = false;
            Mbox_Feedbeam.Visible = false;
            Mbox_Spindle1.Visible = false;
            Mbox_Spindle2.Visible = false;
            Mbox_Spindle3.Visible = false;
            Mbox_Groove.Visible = false;
            Mbox_Guidens.Visible = true;
            Mbox_Clean.Visible = false;

            //    this.Text = "GUIDENS MODULE";
            this.Text = guidensLang;


        }
        private void cleanTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TenonVisiorPanel.Visible = false;
            ChipBreakerPanel.Visible = false;
            SawUnitPanel.Visible = false;
            UnloadStationPanel.Visible = false;
            FeedbeamRollersPanel.Visible = false;
            SpindlePanel1.Visible = false;
            SpindlePanel2.Visible = false;
            SpindlePanel3.Visible = false;
            GrooveSpindlePanel.Visible = false;
            GuidensPanel.Visible = false;
            CleanTablePanel.Visible = true;
            StartingPanel.Visible = false;


            Mbox_Chip.Visible = false;
            Mbox.Visible = false;
            Mbox_Saw.Visible = false;
            Mbox_STATION.Visible = false;
            Mbox_Feedbeam.Visible = false;
            Mbox_Spindle1.Visible = false;
            Mbox_Spindle2.Visible = false;
            Mbox_Spindle3.Visible = false;
            Mbox_Groove.Visible = false;
            Mbox_Guidens.Visible = false;
            Mbox_Clean.Visible = true;

            // this.Text = "CLEAN TABLE MODULE";
            this.Text = CleanLang;

        }

        private void BitOfLife()
        {
            plc.Open();
            bool temp;
            byte tempByte = Convert.ToByte(plc.Read("M600.0"));
            temp = tempByte.SelectBit(0);
            if(temp == false)
            {
                if(Properties.Settings.Default.LanguageOption == "0")
                    ConnectionBox.Text = "Connected";
                else
                     ConnectionBox.Text = "verbunden";

                ConnectionBox.BackColor = Color.LightGreen;
                ConnectionBox.ForeColor = Color.Black;
            }
            else
            {
                if (Properties.Settings.Default.LanguageOption == "0")
                    ConnectionBox.Text = "NOT Connected";

                else
                    ConnectionBox.Text = "nicht verbunden";

                ConnectionBox.BackColor = Color.PaleVioletRed;
                ConnectionBox.ForeColor = Color.Black;

            }
            plc.Close();
        }

        private void getTime(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss tt");
            TimeBox.Text = time;
        }

        private Timer timer1;
        private Timer timer2;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = Properties.Settings.Default.RefreshFreq; // in miliseconds
            timer1.Start();

            timer2 = new Timer();
            timer2.Tick += new EventHandler(getTime);
            timer2.Interval = 1000; // in miliseconds
            timer2.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                BitOfLife(); // sprawdza bit M600.0, jesli 1 to Connected, inczaj NOT connected
                

                if (TenonVisiorPanel.Visible == true)
                    CzytajzPLc(lista_z_PLC, textBox_z_plc, Mbox, messages_VISIOR);
                else if(ChipBreakerPanel.Visible == true)
                    CzytajzPLc(lista_z_PLC_CHIP, textBox_z_plc_CHIP, Mbox_Chip, messages_CHIP);
                else if(SawUnitPanel.Visible == true)
                    CzytajzPLc(lista_z_PLC_SAW, textBox_z_plc_SAW, Mbox_Saw, messages_SAW);
                else if(UnloadStationPanel.Visible == true)
                    CzytajzPLc(lista_z_PLC_STATION, textBox_z_plc_STATION, Mbox_STATION, messages_STATION);
                else if(FeedbeamRollersPanel.Visible == true)
                    CzytajzPLc(lista_z_PLC_FEEDBEAM, textBox_z_plc_FEEDBEAM, Mbox_Feedbeam, messages_FEEDBEAM);
                else if(SpindlePanel1.Visible == true)
                    CzytajzPLc(lista_z_PLC_SPINDLE1, textBox_z_plc_SPINDLE1, Mbox_Spindle1, messages_SPINDLE1);
                else if (SpindlePanel2.Visible == true)
                    CzytajzPLc(lista_z_PLC_SPINDLE2, textBox_z_plc_SPINDLE2, Mbox_Spindle2, messages_SPINDLE2);
                else if (SpindlePanel3.Visible == true)
                    CzytajzPLc(lista_z_PLC_SPINDLE3, textBox_z_plc_SPINDLE3, Mbox_Spindle3, messages_SPINDLE3);
                else if (GrooveSpindlePanel.Visible == true)
                    CzytajzPLc(lista_z_PLC_GROOVE, textBox_z_plc_GROOVE, Mbox_Groove, messages_GROOVE);
                else if (GuidensPanel.Visible == true)
                    CzytajzPLc(lista_z_PLC_GUIDENS, textBox_z_plc_GUIDENS, Mbox_Guidens, messages_GUIDENS);
                else if(CleanTablePanel.Visible == true)
                    CzytajzPLc(lista_z_PLC_CLEAN, textBox_z_plc_CLEAN, Mbox_Clean, messages_CLEAN);


            }
            catch (Exception x)
            {
                Console.WriteLine("connection lost" + x);
            }
        }

     
    }
}
