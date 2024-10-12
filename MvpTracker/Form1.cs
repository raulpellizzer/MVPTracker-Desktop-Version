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
 * To-do: Implement function that when you kill the MVP again it REMOVES the MVP from the 'Possibly Alive' list.
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
                foreach (var mvp in mvpsKilled)
                {
                    txtBoxPossiblyAlive.AppendText(mvp.Name);
                    txtBoxPossiblyAlive.AppendText(Environment.NewLine);
                }
            }
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
            

            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDarkLord_Click(object sender, EventArgs e)
        {
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnDarkLord.Text;
            mvp.Date = nextRespawn;

            mvpsKilled.Add(mvp);

            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDoppelganger_Click(object sender, EventArgs e)
        {
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnDoppelganger.Text;
            mvp.Date = nextRespawn;

            mvpsKilled.Add(mvp);

            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDracula_Click(object sender, EventArgs e)
        {
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnDracula.Text;
            mvp.Date = nextRespawn;

            mvpsKilled.Add(mvp);

            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDrake_Click(object sender, EventArgs e)
        {
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnDrake.Text;
            mvp.Date = nextRespawn;

            mvpsKilled.Add(mvp);

            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnEddga_Click(object sender, EventArgs e)
        {
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddSeconds(15);

            Mvp mvp = new Mvp();
            mvp.Name = btnEddga.Text;
            mvp.Date = nextRespawn;

            mvpsKilled.Add(mvp);

            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnEvilSnakeLord_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnEvilSnakeLord.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnHatii_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnHatii.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnGTB_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnGTB.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnHela_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnHela.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnScaraba_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnScaraba.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnStormyKnight_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnStormyKnight.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnLordOfDeath_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnLordOfDeath.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnMayaPurple_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnMayaPurple.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnMaya_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnMaya.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnMistress_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnMistress.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnMoonlightFlower_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnMoonlightFlower.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnOrcHero_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnOrcHero.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnOrcLord_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnOrcLord.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnOsiris_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnOsiris.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnPharaoh_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnPharaoh.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnPhreeoni_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnPhreeoni.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnTurtleGeneral_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnTurtleGeneral.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            // code to be tested
        }

        // perform all MVP checks in a single timer, every minute
        private void mvpTimer_Tick(object sender, EventArgs e)
        {
            //for (int i = 0; i < mvpsKilled.Count; i++)
            foreach (var mvp in mvpsKilled)
            {
                if (DateTime.Now > mvp.Date)
                {
                    // think of a way to re-enable the mvp button
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
