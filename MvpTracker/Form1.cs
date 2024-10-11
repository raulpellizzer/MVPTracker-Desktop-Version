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

namespace MvpTracker
{
    public partial class Form1 : Form
    {
        //public ArrayList mvpsKilled = new ArrayList();
        //public Dictionary<string, string> mvpKilled = new Dictionary<string, string>();

        ArrayList mvpsKilled = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            txtBoxNextRespawns.ForeColor = Color.Red;
        }


        private void btnBaphomet_Click(object sender, EventArgs e)
        {
            //DateTime nextRespawn = DateTime.Now.AddHours(1);
            DateTime nextRespawn = DateTime.Now.AddMinutes(1);

            Mvp mvp = new Mvp();
            mvp.Name = txtBoxNextRespawns.Text;
            mvp.Date = nextRespawn;

            mvpsKilled.Add(mvp);

            txtBoxNextRespawns.AppendText(btnBaphomet.Text + " - " + mvp.Date);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnDarkLord_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnDarkLord.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnDoppelganger_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnDoppelganger.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnDracula_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnDracula.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnDrake_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnDrake.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
        }

        private void btnEddga_Click(object sender, EventArgs e)
        {
            txtBoxNextRespawns.AppendText(btnEddga.Text);
            txtBoxNextRespawns.AppendText(Environment.NewLine);
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
            // code or function to be tested
            /*
            DateTime currentDate = DateTime.Now;
            DateTime nextRespawn = currentDate.AddHours(1);
            MessageBox.Show(currentDate.ToString() + "  -  " + nextRespawn.ToString());
            */
            //MessageBox.Show(mvpsKilled.Count.ToString());

            if(mvpsKilled.Count > 0)
            {
                for (int i = 0; i < mvpsKilled.Count; i++)
                {
                    MessageBox.Show(mvpsKilled.IndexOf("Baphomet"));
                }
            }
        }

        // perform all MVP checks in a single timer, every minute
        private void testTimer_Tick(object sender, EventArgs e)
        {
            if(mvpsKilled.Contains("Baphomet"))
            {
                MessageBox.Show("encontrei");
            }
            
        }
    }
}
