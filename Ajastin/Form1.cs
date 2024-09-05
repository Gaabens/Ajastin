namespace Ajastin
{
    public partial class AjastinForm : Form
    {
        private int kokonaisaika;
        public AjastinForm()
        {
            InitializeComponent();
        }

        private void AjastinForm_Load(object sender, EventArgs e)
        {
            LopetaBT.Enabled = false;

            for (int i = 0; i < 60; i++)
            {
                MinuutitCB.Items.Add(i.ToString());
                SekunnitCB.Items.Add(i.ToString());
            }

            MinuutitCB.SelectedIndex = 0;
            SekunnitCB.SelectedIndex = 10;
        }

        private void KaynnistaBT_Click(object sender, EventArgs e)
        {
            KaynnistaBT.Enabled = false;
            LopetaBT.Enabled = true;

            int minuutit = int.Parse(MinuutitCB.SelectedItem.ToString());
            int sekunnit = int.Parse(SekunnitCB.SelectedItem.ToString());
            kokonaisaika = (minuutit * 60) + sekunnit;
            AjastinTM.Enabled = true;
        }

        private void LopetaBT_Click(object sender, EventArgs e)
        {
            KaynnistaBT.Enabled = true;
            LopetaBT.Enabled = false;
            kokonaisaika = 0;
            AjastinTM.Enabled = false;
            AikaLB.Text = "00:00";
        }

        private void AjastinTM_Tick(object sender, EventArgs e)
        {
            if (kokonaisaika > 0) 
            {
                kokonaisaika--;

                int minuutit = kokonaisaika / 60;
                int sekunnit = kokonaisaika - (minuutit * 60);
                AikaLB.Text = minuutit + ":" + sekunnit;
            }
            else
            {
                AjastinTM.Stop();
                MessageBox.Show("Aikasi loppui!");
            }
        }
    }
}