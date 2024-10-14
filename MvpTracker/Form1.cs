using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
    public partial class mvpTrackerForm : Form
    {
        public CultureInfo CultureInfo { get; set; } = new CultureInfo("pt-BR");
        List<Mvp> mvpsKilled = new List<Mvp>();
        List<Mvp> mvpsAlive = new List<Mvp>();
        public string environment = "dev";
        public Database db;

        public mvpTrackerForm()
        {
            InitializeComponent();
            txtBoxNextRespawns.ForeColor = Color.Red;
            txtBoxPossiblyAlive.ForeColor = Color.Green;
            db = new Database();
        }

        /*
         * Updates text in the text boxes, adding the MVP to either one of the lists, Next Respawn or Possibly Alive
         * 
         */
        public void UpdateTextBox(List<Mvp> mvpsKilled, string control)
        {
            // update here now by reading from database
            if (control == "nextrespawn")
            {
                txtBoxNextRespawns.Clear();
                foreach (var mvp in mvpsKilled)
                {
                    txtBoxNextRespawns.AppendText(mvp.Name + " - " + mvp.RespawnDate);
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




        public void UpdateTextBoxV2()
        {
            mvpsKilled = db.GetMvpList("dead");
            mvpsAlive = db.GetMvpList("alive");

            txtBoxNextRespawns.Clear();
            foreach (var mvp in mvpsKilled)
            {
                txtBoxNextRespawns.AppendText(mvp.Name + " - " + mvp.RespawnDate);
                txtBoxNextRespawns.AppendText(Environment.NewLine);
            }

            txtBoxPossiblyAlive.Clear();
            foreach (var mvp in mvpsAlive)
            {
                txtBoxPossiblyAlive.AppendText(mvp.Name);
                txtBoxPossiblyAlive.AppendText(Environment.NewLine);
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
        public string GetNextRespawnTime() 
        {
            string nextRespawn;

            if (environment == "prod")
                nextRespawn = DateTime.Now.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss.fff");
            else
                nextRespawn = DateTime.Now.AddSeconds(2).ToString("yyyy-MM-dd HH:mm:ss.fff");

            return nextRespawn;
        }

        /*
         * Create MVP object 
         * 
         */
        public Mvp InstantiateMvpObject(string mvpName, Control buttonControl, string nextRespawn)
        {
            Mvp mvp = new Mvp(-1, mvpName, "", nextRespawn, buttonControl);
            return mvp;
        }

        private void btnBaphomet_Click(object sender, EventArgs e)
        {
            /*
            btnBaphomet.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnBaphomet.Text, btnBaphomet, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
            */

            btnBaphomet.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnBaphomet.Text, btnBaphomet, nextRespawn);
            db.RegisterMvpAsKilled(mvp);
            //UpdateTextBox(mvpsKilled, "nextrespawn");
            UpdateTextBoxV2();




        }

        private void btnDarkLord_Click(object sender, EventArgs e)
        {
            btnDarkLord.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnDarkLord.Text, btnDarkLord, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDoppelganger_Click(object sender, EventArgs e)
        {
            btnDoppelganger.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnDoppelganger.Text, btnDoppelganger, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDracula_Click(object sender, EventArgs e)
        {
            btnDracula.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnDracula.Text, btnDracula, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnDrake_Click(object sender, EventArgs e)
        {
            btnDrake.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnDrake.Text, btnDrake, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnEddga_Click(object sender, EventArgs e)
        {
            btnEddga.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnEddga.Text, btnEddga, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnEvilSnakeLord_Click(object sender, EventArgs e)
        {
            btnEvilSnakeLord.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnEvilSnakeLord.Text, btnEvilSnakeLord, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnHatii_Click(object sender, EventArgs e)
        {
            btnHatii.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnHatii.Text, btnHatii, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnGTB_Click(object sender, EventArgs e)
        {
            btnGTB.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnGTB.Text, btnGTB, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnHela_Click(object sender, EventArgs e)
        {
            btnHela.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnHela.Text, btnHela, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnScaraba_Click(object sender, EventArgs e)
        {
            btnScaraba.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnScaraba.Text, btnScaraba, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnStormyKnight_Click(object sender, EventArgs e)
        {
            btnStormyKnight.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnStormyKnight.Text, btnStormyKnight, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnLordOfDeath_Click(object sender, EventArgs e)
        {
            btnLordOfDeath.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnLordOfDeath.Text, btnLordOfDeath, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMayaPurple_Click(object sender, EventArgs e)
        {
            btnMayaPurple.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnMayaPurple.Text, btnMayaPurple, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMaya_Click(object sender, EventArgs e)
        {
            btnMaya.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnMaya.Text, btnMaya, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMistress_Click(object sender, EventArgs e)
        {
            btnMistress.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnMistress.Text, btnMistress, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnMoonlightFlower_Click(object sender, EventArgs e)
        {
            btnMoonlightFlower.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnMoonlightFlower.Text, btnMoonlightFlower, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnOrcHero_Click(object sender, EventArgs e)
        {
            btnOrcHero.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnOrcHero.Text, btnOrcHero, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnOrcLord_Click(object sender, EventArgs e)
        {
            btnOrcLord.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnOrcLord.Text, btnOrcLord, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnOsiris_Click(object sender, EventArgs e)
        {
            btnOsiris.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnOsiris.Text, btnOsiris, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnPharaoh_Click(object sender, EventArgs e)
        {
            btnPharaoh.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnPharaoh.Text, btnPharaoh, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnPhreeoni_Click(object sender, EventArgs e)
        {
            btnPhreeoni.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnPhreeoni.Text, btnPhreeoni, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnTurtleGeneral_Click(object sender, EventArgs e)
        {
            btnTurtleGeneral.Enabled = false;
            string nextRespawn = GetNextRespawnTime();
            Mvp mvp = InstantiateMvpObject(btnTurtleGeneral.Text, btnTurtleGeneral, nextRespawn);

            mvpsKilled.Add(mvp);
            ClearMvpFromAliveList(mvp);
            UpdateTextBox(mvpsKilled, "nextrespawn");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            // code to be tested

            try
            {
                //SqlConnection conn = db.OpenSqlConnection();


                

                //SqlCommand command = new SqlCommand("select name from Mvp", Conn);
                // int result = command.ExecuteNonQuery();
                //using (SqlDataReader reader = command.ExecuteReader())
                //{
                    //if (reader.Read())
                    //{
                        //MessageBox.Show(String.Format("{0}", reader["name"]));
                    //}
                //}

                //db.CloseSqlConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //MessageBox.Show(db.ConnectionString);
        }

        // Perform all MVP checks in a single timer, every minute
        private void mvpTimer_Tick(object sender, EventArgs e)
        {
            mvpsKilled = db.GetMvpList("dead");
            db.RegisterMvpAsAlive(mvpsKilled, CultureInfo);
            mvpsKilled = db.GetMvpList("dead");
            //UpdateTextBox(mvpsKilled, "nextrespawn");
            UpdateTextBoxV2();


            /*
            for (int i = 0; i <= mvpsKilled.Count; i++)
            {
                foreach (var mvp in mvpsKilled)
                {

                    // Check if MVP spawned
                    if (DateTime.Now > DateTime.ParseExact(mvp.RespawnDate, "yyyyMMddHHmmss", CultureInfo))
                    {
                        mvp.buttonControl.Enabled = true;
                        mvpsKilled.Remove(mvp); // update MvpTracking - is_mvp_dead
                        mvpsAlive.Add(mvp);
                        UpdateTextBox(mvpsAlive, "alive");
                        break;
                    }
                }

                i = 0;
            }

            UpdateTextBox(mvpsKilled, "nextrespawn");
            */
        }

        private void mvpTrackerForm_Load(object sender, EventArgs e)
        {
            // updates form before is opens.
        }
    }
}
