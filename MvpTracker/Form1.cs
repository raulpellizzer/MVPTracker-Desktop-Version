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
        public string environment = "dev";

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

        /*
         * Returns next respanw time, for RagnaClassic one hour from now
         * 
         */
        public DateTime GetNextRespawnTime() 
        {
            DateTime nextRespawn;

            if (environment == "prod")
                nextRespawn = DateTime.Now.AddHours(1);
            else
                nextRespawn = DateTime.Now.AddSeconds(15);

            return nextRespawn;
        }

        /*
         * Create MVP object 
         * 
         */
        public Mvp InstantiateMvpObject(string mvpName, Control buttonControl, DateTime nextRespawn)
        {
            Mvp mvp = new Mvp();
            mvp.Name = mvpName;
            mvp.Date = nextRespawn;
            mvp.buttonControl = buttonControl;

            return mvp;
        }

        private void btnBaphomet_Click(object sender, EventArgs e)
        {
            btnBaphomet.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnBaphomet.Text, btnBaphomet, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDarkLord_Click(object sender, EventArgs e)
        {
            btnDarkLord.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnDarkLord.Text, btnDarkLord, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDoppelganger_Click(object sender, EventArgs e)
        {
            btnDoppelganger.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnDoppelganger.Text, btnDoppelganger, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDracula_Click(object sender, EventArgs e)
        {
            btnDracula.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnDracula.Text, btnDracula, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDrake_Click(object sender, EventArgs e)
        {
            btnDrake.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnDrake.Text, btnDrake, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnEddga_Click(object sender, EventArgs e)
        {
            btnEddga.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnEddga.Text, btnEddga, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnEvilSnakeLord_Click(object sender, EventArgs e)
        {
            btnEvilSnakeLord.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnEvilSnakeLord.Text, btnEvilSnakeLord, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnHatii_Click(object sender, EventArgs e)
        {
            btnHatii.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnHatii.Text, btnHatii, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnGTB_Click(object sender, EventArgs e)
        {
            btnGTB.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnGTB.Text, btnGTB, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnHela_Click(object sender, EventArgs e)
        {
            btnHela.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnHela.Text, btnHela, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnScaraba_Click(object sender, EventArgs e)
        {
            btnScaraba.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnScaraba.Text, btnScaraba, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnStormyKnight_Click(object sender, EventArgs e)
        {
            btnStormyKnight.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnStormyKnight.Text, btnStormyKnight, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnLordOfDeath_Click(object sender, EventArgs e)
        {
            btnLordOfDeath.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnLordOfDeath.Text, btnLordOfDeath, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMayaPurple_Click(object sender, EventArgs e)
        {
            btnMayaPurple.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnMayaPurple.Text, btnMayaPurple, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMaya_Click(object sender, EventArgs e)
        {
            btnMaya.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnMaya.Text, btnMaya, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMistress_Click(object sender, EventArgs e)
        {
            btnMistress.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnMistress.Text, btnMistress, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMoonlightFlower_Click(object sender, EventArgs e)
        {
            btnMoonlightFlower.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnMoonlightFlower.Text, btnMoonlightFlower, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnOrcHero_Click(object sender, EventArgs e)
        {
            btnOrcHero.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnOrcHero.Text, btnOrcHero, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnOrcLord_Click(object sender, EventArgs e)
        {
            btnOrcLord.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnOrcLord.Text, btnOrcLord, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnOsiris_Click(object sender, EventArgs e)
        {
            btnOsiris.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnOsiris.Text, btnOsiris, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnPharaoh_Click(object sender, EventArgs e)
        {
            btnPharaoh.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnPharaoh.Text, btnPharaoh, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnPhreeoni_Click(object sender, EventArgs e)
        {
            btnPhreeoni.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnPhreeoni.Text, btnPhreeoni, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnTurtleGeneral_Click(object sender, EventArgs e)
        {
            btnTurtleGeneral.Enabled = false;
            DateTime nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnTurtleGeneral.Text, btnTurtleGeneral, nextRespawn);

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
