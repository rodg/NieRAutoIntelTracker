using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveSplit.UI.Components;

namespace NieRAutoIntelTracker
{
    public partial class IntelDisplay : Form
    {
        public IntelDisplay(Settings settings)
        {
            InitializeComponent();
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void UpdateDisplay(byte[] buffer)
        {
            this.checkBox1.Checked = (buffer[0] & (byte)FishIntel.MACKEREL_MACHINE) != 0;
            this.checkBox2.Checked = (buffer[0] & (byte)FishIntel.COELACANTH_MACHINE) != 0;
            this.checkBox3.Checked = (buffer[0] & (byte)FishIntel.BREAM_MACHINE) != 0;
            this.checkBox4.Checked = (buffer[0] & (byte)FishIntel.STARFISH_MACHINE) != 0;
            this.checkBox5.Checked = (buffer[0] & (byte)FishIntel.SWORDFISH_MACHINE) != 0;
            this.checkBox6.Checked = (buffer[0] & (byte)FishIntel.BLOWFISH_MACHINE) != 0;
            this.checkBox7.Checked = (buffer[0] & (byte)FishIntel.BLOAT_FISH_MACHINE) != 0;
            this.checkBox8.Checked = (buffer[0] & (byte)FishIntel.CARP_MACHINE) != 0;

            this.checkBox9.Checked = (buffer[1] & (byte)FishIntel.ARAPAIMA_MACHINE) != 0;
            this.checkBox10.Checked = (buffer[1] & (byte)FishIntel.KOI_CARP_MACHINE) != 0;
            this.checkBox11.Checked = (buffer[1] & (byte)FishIntel.KILLIFISH_MACHINE) != 0;
            this.checkBox12.Checked = (buffer[1] & (byte)FishIntel.BASKING_SHARK) != 0;
            this.checkBox13.Checked = (buffer[1] & (byte)FishIntel.BREAM) != 0;
            this.checkBox14.Checked = (buffer[1] & (byte)FishIntel.STARFISH) != 0;
            this.checkBox15.Checked = (buffer[1] & (byte)FishIntel.BEETLE_FISH) != 0;
            this.checkBox16.Checked = (buffer[1] & (byte)FishIntel.HORSESHOE_CRAB) != 0;

            this.checkBox17.Checked = (buffer[2] & (byte)FishIntel.MACKEREL) != 0;
            this.checkBox18.Checked = (buffer[2] & (byte)FishIntel.SWORDFISH) != 0;
            this.checkBox19.Checked = (buffer[2] & (byte)FishIntel.BLOWFISH) != 0;
            this.checkBox20.Checked = (buffer[2] & (byte)FishIntel.COELACANTH) != 0;
            this.checkBox21.Checked = (buffer[2] & (byte)FishIntel.TWOFACE) != 0;
            this.checkBox22.Checked = (buffer[2] & (byte)FishIntel.WATER_FLEA) != 0;
            this.checkBox23.Checked = (buffer[2] & (byte)FishIntel.OIL_SARDINE) != 0;
            this.checkBox24.Checked = (buffer[2] & (byte)FishIntel.ARAPAIMA) != 0;

            this.checkBox25.Checked = (buffer[3] & (byte)FishIntel.FRESHWATER_RAY) != 0;
            this.checkBox26.Checked = (buffer[3] & (byte)FishIntel.FUR_CARP) != 0;
            this.checkBox27.Checked = (buffer[3] & (byte)FishIntel.KOI_CARP) != 0;
            this.checkBox28.Checked = (buffer[3] & (byte)FishIntel.BLOAT_FISH) != 0;
            this.checkBox29.Checked = (buffer[3] & (byte)FishIntel.CARP) != 0;
            this.checkBox30.Checked = (buffer[3] & (byte)FishIntel.KILLIFISH) != 0;
            this.checkBox31.Checked = (buffer[3] & (byte)FishIntel.TWINFISH) != 0;
            this.checkBox32.Checked = (buffer[3] & (byte)FishIntel.AROWANA) != 0;

            this.checkBox33.Checked = (buffer[4] & (byte)FishIntel.BROKEN_FIREARM) != 0;

            this.checkBox34.Checked = (buffer[5] & (byte)FishIntel.BATTERY) != 0;
            this.checkBox35.Checked = (buffer[5] & (byte)FishIntel.GAS_CYLINDER) != 0;
            this.checkBox36.Checked = (buffer[5] & (byte)FishIntel.TIRE) != 0;
            this.checkBox37.Checked = (buffer[5] & (byte)FishIntel.MACHINE_LIFEFORM_HEAD) != 0;
            this.checkBox38.Checked = (buffer[5] & (byte)FishIntel.FRESHWATER_RAY_MACHINE) != 0;
            this.checkBox39.Checked = (buffer[5] & (byte)FishIntel.BASKING_SHARK_MACHINE) != 0;
            this.checkBox40.Checked = (buffer[5] & (byte)FishIntel.AROWANA_MACHINE) != 0;
            this.checkBox41.Checked = (buffer[5] & (byte)FishIntel.HORSESHOE_CRAB_MACHINE) != 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void UpdateDebugDisplay(string text)
        {
            this.debugValue.Text = text;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
