using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * To-do: -
 * 
 * 
 * 
 */

namespace MvpTracker
{
    public partial class Form1 : Form
    {
        List<Mvp> mvpsKilled = new List<Mvp>();
        List<Mvp> mvpsAlive = new List<Mvp>();

        public Form1()
        {
            InitializeComponent();
            txtBoxNextRespawns.ForeColor = Color.Red;
            txtBoxPossiblyAlive.ForeColor = Color.Green;
        }

        /*
         * Updates text in the text boxes, adding the MVP to either one of the lists, Next Respawn or Possibly Alive
         * 
         */
        public void UpdateTextBox(List<Mvp> mvpsKilled, string control)
        {
            if (control == "nextrespawn")
            {
                txtBoxNextRespawns.Clear();
                foreach (var mvp in mvpsKilled)
                {
                    txtBoxNextRespawns.AppendText(mvp.Name + " - " + mvp.Date);
                    txtBoxNextRespawns.AppendText(Environment.NewLine);
                }
            } else
            {
                txtBoxPossiblyAlive.Clear();
                foreach (var mvp in mvpsAlive)
                {
                    txtBoxPossiblyAlive.AppendText(mvp.Name);
                    txtBoxPossiblyAlive.AppendText(Environment.NewLine);
                }
            }
        }

        /*
         * When the MVP is killed, remove MVP from Possibly Alive
         * 
         */
        public void ClearMvpFromAliveList(Mvp mvpKilled)
        {
            for (int i = 0; i < mvpsAlive.Count; i++)
            {
                if (mvpsAlive[i].Name == mvpKilled.Name)
                {
                    mvpsAlive.RemoveAt(i);
                    break;
                }
            }

            UpdateTextBox(mvpsAlive, "alive");
        }

        private void btnBaphomet_Click(object sender, EventArgs e)
        {
            btnBaphomet.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnBaphomet.Text;
            mvp.Date = nextRespawn; 
            mvp.buttonControl = btnBaphomet;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDarkLord_Click(object sender, EventArgs e)
        {
            btnDarkLord.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnDarkLord.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnDarkLord;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDoppelganger_Click(object sender, EventArgs e)
        {
            btnDoppelganger.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnDoppelganger.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnDoppelganger;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDracula_Click(object sender, EventArgs e)
        {
            btnDracula.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnDracula.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnDracula;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDrake_Click(object sender, EventArgs e)
        {
            btnDrake.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnDrake.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnDrake;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnEddga_Click(object sender, EventArgs e)
        {
            btnEddga.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnEddga.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnEddga;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnEvilSnakeLord_Click(object sender, EventArgs e)
        {
            btnEvilSnakeLord.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnEvilSnakeLord.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnEvilSnakeLord;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnHatii_Click(object sender, EventArgs e)
        {
            btnHatii.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnHatii.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnHatii;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnGTB_Click(object sender, EventArgs e)
        {
            btnGTB.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnGTB.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnGTB;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnHela_Click(object sender, EventArgs e)
        {
            btnHela.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnHela.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnHela;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnScaraba_Click(object sender, EventArgs e)
        {
            btnScaraba.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnScaraba.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnScaraba;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnStormyKnight_Click(object sender, EventArgs e)
        {
            btnStormyKnight.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnStormyKnight.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnStormyKnight;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnLordOfDeath_Click(object sender, EventArgs e)
        {
            btnLordOfDeath.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnLordOfDeath.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnLordOfDeath;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMayaPurple_Click(object sender, EventArgs e)
        {
            btnMayaPurple.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnMayaPurple.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnMayaPurple;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMaya_Click(object sender, EventArgs e)
        {
            btnMaya.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnMaya.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnMaya;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMistress_Click(object sender, EventArgs e)
        {
            btnMistress.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnMistress.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnMistress;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMoonlightFlower_Click(object sender, EventArgs e)
        {
            btnMoonlightFlower.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnMoonlightFlower.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnMoonlightFlower;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnOrcHero_Click(object sender, EventArgs e)
        {
            btnOrcHero.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnOrcHero.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnOrcHero;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnOrcLord_Click(object sender, EventArgs e)
        {
            btnOrcLord.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnOrcLord.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnOrcLord;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnOsiris_Click(object sender, EventArgs e)
        {
            btnOsiris.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnOsiris.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnOsiris;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnPharaoh_Click(object sender, EventArgs e)
        {
            btnPharaoh.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnPharaoh.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnPharaoh;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnPhreeoni_Click(object sender, EventArgs e)
        {
            btnPhreeoni.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnPhreeoni.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnPhreeoni ;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnTurtleGeneral_Click(object sender, EventArgs e)
        {
            btnTurtleGeneral.Enabled = false;
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnTurtleGeneral.Text;
            mvp.Date = nextRespawn;
            mvp.buttonControl = btnTurtleGeneral;

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            // code to be tested
        }

        // perform all MVP checks in a single timer, every minute
        private void mvpTimer_Tick(object sender, EventArgs e)
        {
            foreach (var mvp in mvpsKilled)
            {
                if (DateTime.Now > mvp.Date)
                {
                    mvp.buttonControl.Enabled = true;
                    mvpsKilled.Remove(mvp);
                    mvpsAlive.Add(mvp);
                    UpdateTextBox(mvpsAlive, "alive");
                    break;
                }
            }

            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

    }
}
