using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CrossyRoadHack
{
    public partial class Form1 : Form
    {
        static string rawpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\Yodo1Ltd.CrossyRoad_s3s3f300emkze\";
        static string path1 = rawpath + @"RoamingState\latest-save.dat";
        static string path2 = rawpath + @"LocalState\CloudBackupSave.dat";
        static gamedata.Root currentsave { get; set; }
        public Form1()
        {
            InitializeComponent();
            currentsave = JsonConvert.DeserializeObject<gamedata.Root>(File.ReadAllText(path1));
            Icon = Icon.ExtractAssociatedIcon(AppDomain.CurrentDomain.FriendlyName);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue500, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.BLACK);
            coinstxt.Text = currentsave.cc.ToString();
            hstxt.Text = currentsave.hs.ToString();
        }

        private void materialSingleLineTextField1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                currentsave.cc = int.Parse(coinstxt.Text);
            }
            catch
            {
                coinstxt.Text = int.MaxValue.ToString();
                currentsave.cc = int.Parse(coinstxt.Text);
            }
            try
            {
                currentsave.hs = int.Parse(hstxt.Text);
            }
            catch
            {
                hstxt.Text = int.MaxValue.ToString();
                currentsave.hs = int.Parse(hstxt.Text);
            }
            File.WriteAllText(path1, JsonConvert.SerializeObject(currentsave));
            File.Copy(path1, path2, true);
            MessageBox.Show("Applied!", "Crossy Road Hack by Kye", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void materialRaisedButton2_Click(object sender, EventArgs e)=> Process.Start("crossyroad-launch://");
        
        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            List<gamedata.C> characterlist = new List<gamedata.C>();
            List<int> characterids = new List<int>();
            for (int i = 0; i < 500; i++)
                characterids.Add(i);

           
            foreach (int id in characterids)
            {
                gamedata.C skin = new gamedata.C();
                skin.id = id.ToString();
                skin.un = true;
                skin.pl = 1;
                skin.pa = true;
                skin.pr = 1;
                skin.vr = true;
                skin.tu = true;
                characterlist.Add(skin);
            }
            currentsave.cs = characterlist;
            File.WriteAllText(path1, JsonConvert.SerializeObject(currentsave));
            File.Copy(path1, path2, true);
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            List<gamedata.C> characterlist = new List<gamedata.C>();
            List<int> characterids = new List<int>();
            for (int i = 0; i < 500; i++)
                characterids.Add(i);


            foreach (int id in characterids)
            {
                gamedata.C skin = new gamedata.C();
                skin.id = id.ToString();
                skin.un = false;
                skin.pl = 1;
                skin.pa = true;
                skin.pr = 1;
                skin.vr = true;
                skin.tu = true;
                characterlist.Add(skin);
            }
            currentsave.cs = characterlist;
            File.WriteAllText(path1, JsonConvert.SerializeObject(currentsave));
            File.Copy(path1, path2, true);
        }
    }
}