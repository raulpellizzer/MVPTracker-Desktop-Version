using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

/*
 * To-do's: - Add version number to front end
 * 
 * 
 * 
 */

namespace MvpTracker
{
    public partial class mvpTrackerForm : Form
    {
        public CultureInfo CultureInfo { get; set; } = new CultureInfo("pt-BR");
        public StatisticsForm StatisticsForm { get; set; }
        List<Mvp> mvpsKilled = new List<Mvp>();
        List<Mvp> mvpsAlive = new List<Mvp>();
        public string environment = "prod";
        public Database db;

        public mvpTrackerForm()
        {
            InitializeComponent();
            txtBoxNextRespawns.ForeColor = Color.Red;
            txtBoxPossiblyAlive.ForeColor = Color.Green;
            db = new Database();
        }

        /*
         * Updates text in the textboxes, adding the MVP to either one of the lists, Next Respawn or Possibly Alive
         * 
         */
        public void UpdateTextBox()
        {
            mvpsKilled = db.GetMvpList("dead");
            mvpsAlive = db.GetMvpList("alive");

            txtBoxNextRespawns.Clear();
            foreach (var mvp in mvpsKilled)
            {
                txtBoxNextRespawns.AppendText(mvp.Name + " - " + mvp.RespawnDate);
                txtBoxNextRespawns.AppendText(Environment.NewLine);
                DisableButtonControl(mvp.Name);
            }

            txtBoxPossiblyAlive.Clear();
            foreach (var mvp in mvpsAlive)
            {
                txtBoxPossiblyAlive.AppendText(mvp.Name);
                txtBoxPossiblyAlive.AppendText(Environment.NewLine);
                EnableButtonControl(mvp.Name);
            }
        }

        /*
         * Disables button when MVP is dead
         * 
         */
        public void DisableButtonControl(string mvpName)
        {
            switch (mvpName)
            {
                case "Baphomet":
                    btnBaphomet.Enabled = false;
                    break;

                case "Dark Lord":
                    btnDarkLord.Enabled = false;
                    break;

                case "Doppelganger":
                    btnDoppelganger.Enabled = false;
                    break;

                case "Dracula":
                    btnDracula.Enabled = false;
                    break;

                case "Drake":
                    btnDrake.Enabled = false;
                    break;

                case "Eddga":
                    btnEddga.Enabled = false;
                    break;

                case "Evil Snake Lord":
                    btnEvilSnakeLord.Enabled = false;
                    break;

                case "Hatii":
                    btnHatii.Enabled = false;
                    break;

                case "Golden Thief Bug":
                    btnGTB.Enabled = false;
                    break;

                case "Hela":
                    btnHela.Enabled = false;
                    break;

                case "Scaraba Queen":
                    btnScaraba.Enabled = false;
                    break;

                case "Stormy Knight":
                    btnStormyKnight.Enabled = false;
                    break;

                case "Lord of Death":
                    btnLordOfDeath.Enabled = false;
                    break;

                case "Maya Purple":
                    btnMayaPurple.Enabled = false;
                    break;

                case "Maya":
                    btnMaya.Enabled = false;
                    break;

                case "Mistress":
                    btnMistress.Enabled = false;
                    break;

                case "Moonlight Flower":
                    btnMoonlightFlower.Enabled = false;
                    break;

                case "Orc Hero":
                    btnOrcHero.Enabled = false;
                    break;

                case "Orc Lord":
                    btnOrcLord.Enabled = false;
                    break;

                case "Osiris":
                    btnOsiris.Enabled = false;
                    break;

                case "Pharaoh":
                    btnPharaoh.Enabled = false;
                    break;

                case "Phreeoni":
                    btnPhreeoni.Enabled = false;
                    break;

                case "Turtle General":
                    btnTurtleGeneral.Enabled = false;
                    break;

                default:
                    break;
            }
        }

        /*
         * Enable button when MVP spawns
         * 
         */
        public void EnableButtonControl(string mvpName)
        {
            switch (mvpName)
            {
                case "Baphomet":
                    btnBaphomet.Enabled = true;
                    break;

                case "Dark Lord":
                    btnDarkLord.Enabled = true;
                    break;

                case "Doppelganger":
                    btnDoppelganger.Enabled = true;
                    break;

                case "Dracula":
                    btnDracula.Enabled = true;
                    break;

                case "Drake":
                    btnDrake.Enabled = true;
                    break;

                case "Eddga":
                    btnEddga.Enabled = true;
                    break;

                case "Evil Snake Lord":
                    btnEvilSnakeLord.Enabled = true;
                    break;

                case "Hatii":
                    btnHatii.Enabled = true;
                    break;

                case "Golden Thief Bug":
                    btnGTB.Enabled = true;
                    break;

                case "Hela":
                    btnHela.Enabled = true;
                    break;

                case "Scaraba Queen":
                    btnScaraba.Enabled = true;
                    break;

                case "Stormy Knight":
                    btnStormyKnight.Enabled = true;
                    break;

                case "Lord of Death":
                    btnLordOfDeath.Enabled = true;
                    break;

                case "Maya Purple":
                    btnMayaPurple.Enabled = true;
                    break;

                case "Maya":
                    btnMaya.Enabled = true;
                    break;

                case "Mistress":
                    btnMistress.Enabled = true;
                    break;

                case "Moonlight Flower":
                    btnMoonlightFlower.Enabled = true;
                    break;

                case "Orc Hero":
                    btnOrcHero.Enabled = true;
                    break;

                case "Orc Lord":
                    btnOrcLord.Enabled = true;
                    break;

                case "Osiris":
                    btnOsiris.Enabled = true;
                    break;

                case "Pharaoh":
                    btnPharaoh.Enabled = true;
                    break;

                case "Phreeoni":
                    btnPhreeoni.Enabled = true;
                    break;

                case "Turtle General":
                    btnTurtleGeneral.Enabled = true;
                    break;

                default:
                    break;
            }
        } 

        /*
         * Returns next respanw time, for RagnaClassic one hour from now
         * 
         */
        public string GetNextRespawnTime(int respawnTime) 
        {
            string nextRespawn;

            if (environment == "prod")
                nextRespawn = DateTime.Now.AddHours(respawnTime).ToString("yyyy-MM-dd HH:mm:ss.fff");
            else
                nextRespawn = DateTime.Now.AddSeconds(15).ToString("yyyy-MM-dd HH:mm:ss.fff");

            return nextRespawn;
        } 

        /*
         * Create MVP object 
         * 
         */
        public Mvp InstantiateMvpObject(string mvpName, Control buttonControl, string nextRespawn)
        {
            Mvp mvp = new Mvp(-1, mvpName, nextRespawn, "", buttonControl);
            return mvp;
        }

        private void btnBaphomet_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnBaphomet.Text, btnBaphomet, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                } else
                    return;

            } else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnBaphomet.Text, btnBaphomet, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnDarkLord_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(2);
                    mvp = InstantiateMvpObject(btnDarkLord.Text, btnDarkLord, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(2);
                mvp = InstantiateMvpObject(btnDarkLord.Text, btnDarkLord, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnDoppelganger_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(2);
                    mvp = InstantiateMvpObject(btnDoppelganger.Text, btnDoppelganger, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);
                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(2);
                mvp = InstantiateMvpObject(btnDoppelganger.Text, btnDoppelganger, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnDracula_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnDracula.Text, btnDracula, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnDracula.Text, btnDracula, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnDrake_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnDrake.Text, btnDrake, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnDrake.Text, btnDrake, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnEddga_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnEddga.Text, btnEddga, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnEddga.Text, btnEddga, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnEvilSnakeLord_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnEvilSnakeLord.Text, btnEvilSnakeLord, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);
                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnEvilSnakeLord.Text, btnEvilSnakeLord, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnHatii_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnHatii.Text, btnHatii, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnHatii.Text, btnHatii, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnGTB_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnGTB.Text, btnGTB, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnGTB.Text, btnGTB, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnHela_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(2);
                    mvp = InstantiateMvpObject(btnHela.Text, btnHela, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(2);
                mvp = InstantiateMvpObject(btnHela.Text, btnHela, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnScaraba_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnScaraba.Text, btnScaraba, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnScaraba.Text, btnScaraba, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnStormyKnight_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnStormyKnight.Text, btnStormyKnight, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnStormyKnight.Text, btnStormyKnight, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnLordOfDeath_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(2);
                    mvp = InstantiateMvpObject(btnLordOfDeath.Text, btnLordOfDeath, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(2);
                mvp = InstantiateMvpObject(btnLordOfDeath.Text, btnLordOfDeath, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnMayaPurple_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnMayaPurple.Text, btnMayaPurple, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnMayaPurple.Text, btnMayaPurple, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnMaya_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnMaya.Text, btnMaya, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnMaya.Text, btnMaya, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnMistress_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnMistress.Text, btnMistress, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnMistress.Text, btnMistress, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnMoonlightFlower_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnMoonlightFlower.Text, btnMoonlightFlower, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnMoonlightFlower.Text, btnMoonlightFlower, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnOrcHero_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnOrcHero.Text, btnOrcHero, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnOrcHero.Text, btnOrcHero, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnOrcLord_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnOrcLord.Text, btnOrcLord, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnOrcLord.Text, btnOrcLord, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnOsiris_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnOsiris.Text, btnOsiris, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnOsiris.Text, btnOsiris, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnPharaoh_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnPharaoh.Text, btnPharaoh, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnPharaoh.Text, btnPharaoh, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnPhreeoni_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnPhreeoni.Text, btnPhreeoni, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnPhreeoni.Text, btnPhreeoni, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        private void btnTurtleGeneral_Click(object sender, EventArgs e)
        {
            string nextRespawn = "";
            Mvp mvp = null;
            bool trackForOtherPlayer = ckBoxTrackOtherPlayer.Checked;
            bool disclaimer;

            if (trackForOtherPlayer)
            {
                disclaimer = GetUserAnswer();

                if (disclaimer)
                {
                    nextRespawn = GetNextRespawnTime(1);
                    mvp = InstantiateMvpObject(btnTurtleGeneral.Text, btnTurtleGeneral, nextRespawn);
                    DisableButtonControl(mvp.Name);
                    db.RegisterMvpAsKilled(mvp, true);

                }
                else
                    return;

            }
            else
            {
                nextRespawn = GetNextRespawnTime(1);
                mvp = InstantiateMvpObject(btnTurtleGeneral.Text, btnTurtleGeneral, nextRespawn);
                DisableButtonControl(mvp.Name);
                db.RegisterMvpAsKilled(mvp, false);
            }

            UpdateTextBox();
        }

        /*
         * Displays and get user input as to tracking MVP for others
         * 
         */
        public bool GetUserAnswer()
        {
            bool userAnswer = false;
            string message = "You are tracking this MVP for another player and will not add it to your totals. ";
            message += "Do you wish to confirm?";

            DialogResult dialogResult = MessageBox.Show(message, "Tracking MVP for other player", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                userAnswer = true;
            else if (dialogResult == DialogResult.No)
                userAnswer = false;

            return userAnswer;
        }

        /*
         * Button for tests only
         * 
         */
        private void btnTest_Click(object sender, EventArgs e)
        {
            // code to be tested
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Perform all MVP checks in a single timer, every minute
        /*
         * MVP Checks performed on a timer. 'Did the MVP respawned?'
         * 
         */
        private void mvpTimer_Tick(object sender, EventArgs e)
        {
            mvpsKilled = db.GetMvpList("dead");
            db.RegisterMvpAsAlive(mvpsKilled, CultureInfo);
            UpdateTextBox();
        }

        /*
         * On form load actions
         * 
         */
        private void mvpTrackerForm_Load(object sender, EventArgs e)
        {
            mvpsKilled = db.GetMvpList("dead");
            db.RegisterMvpAsAlive(mvpsKilled, CultureInfo);
            UpdateTextBox();

            btnTest.Enabled = false;
            btnTest.Visible = false;
            ckBoxHideTimes.Checked = true;
        }

        /*
         * Display the statistics for each MVP
         * 
         */
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsForm = new StatisticsForm();
                StatisticsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
         * Hide / display MVP times uppon selection
         * 
         */
        private void ckBoxHideTimes_CheckedChanged(object sender, EventArgs e)
        {
            bool hideInfo = ckBoxHideTimes.Checked;

            if (hideInfo)
                txtBoxNextRespawns.PasswordChar = '*';
            else
                txtBoxNextRespawns.PasswordChar = '\0';
        }
    }
}
