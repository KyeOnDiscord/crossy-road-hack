using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using System.IO;
using System.Diagnostics;
using System.Web.Script.Serialization;
namespace CrossyRoadHack
{
    public partial class Form1 : Form
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        private static string rawpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\Yodo1Ltd.CrossyRoad_s3s3f300emkze\";
        private static string path1 = rawpath + @"RoamingState\latest-save.dat";
        private static string path2 = rawpath + @"LocalState\CloudBackupSave.dat";
        private static gamedata.Root currentsave { get; set; }
        private void materialRaisedButton2_Click(object sender, EventArgs e) => Process.Start("crossyroad-launch://");
        private void materialRaisedButton4_Click(object sender, EventArgs e) => ChangeSkinLockStatus(true);
        private void materialRaisedButton3_Click(object sender, EventArgs e) => ChangeSkinLockStatus(false);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(path1))
                currentsave = js.Deserialize<gamedata.Root>(File.ReadAllText(path1));
            else
                currentsave = js.Deserialize<gamedata.Root>(File.ReadAllText(path2));



            Icon = Icon.ExtractAssociatedIcon(AppDomain.CurrentDomain.FriendlyName);
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue500, Primary.Green700, Primary.Green700, Accent.LightBlue200, TextShade.WHITE);
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
            currentsave.cc = CheckInt(coinstxt);
            currentsave.hs = CheckInt(hstxt);
            string gamesave = js.Serialize(currentsave);
            File.WriteAllText(path1, gamesave);
            File.WriteAllText(path2, gamesave);
            MessageBox.Show("Applied!", "Crossy Road Hack by Kye", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Gets a control and checks if its an int, if not returns 2147483647 and sets the control's text to 2147483647
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private static int CheckInt(Control src)
        {
            string number = src.Text;
            try
            {
                if (ulong.Parse(number) > int.MaxValue)
                {
                    src.Text = int.MaxValue.ToString();
                    return int.MaxValue;//Bigger than an int so return false
                }
                else
                    return int.Parse(number);//yay its an int
            }
            catch
            {
                src.Text = int.MaxValue.ToString();
                return int.MaxValue;//the string cannot be parsed coz its too long to be a ulong
            }
        }
        private void ChangeSkinLockStatus(bool unlocked)
        {
            List<gamedata.C> characterlist = new List<gamedata.C>();
            List<int> characterids = new List<int>();
            for (int i = 0; i < 800; i++)
                characterids.Add(i);

            foreach (int id in characterids)
            {
                gamedata.C skin = new gamedata.C();
                if (id.ToString().Length == 2)
                    skin.id = $"0{id}";
                else
                    skin.id = id.ToString();

                skin.un = unlocked;
                skin.pl = 1;
                skin.pa = true;
                skin.pr = 1;
                skin.vr = true;
                skin.tu = true;
                characterlist.Add(skin);
            }
            currentsave.cs = characterlist;
        }
    }
}