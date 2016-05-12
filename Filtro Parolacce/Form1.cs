using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Filtro_Parolacce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool scrittoQualcosa()
        {
            if (txtTesto.Text == "")
            {
                return false;
            }
            return true;
        }








        private void btnPubblica_Click(object sender, EventArgs e)
        {
            bool contr = scrittoQualcosa();
            if (!contr)
            {
                MessageBox.Show("ERRORE: per postare la tua storia, inserisci del testo");
                return;
            }

            bool linguaTesto = linguaInglese(txtTesto.Text);
            if (linguaTesto)
                label1.Text = "Inglese";
            else
                label1.Text = "Italiano";

        }




        bool parolaInglese(string parola)
        {
            int primo, medio, ultimo;
            primo = 0;
            ultimo = paroleInglesi.Length - 1;
            while (primo <= ultimo)
            {
                medio = (primo + ultimo) / 2;
                string parolaMedia = paroleInglesi[medio];
                if (parolaMedia == parola)
                {
                    return true;
                }
                if (string.Compare(parolaMedia, parola) > 0)
                {
                    ultimo = medio - 1;
                    
                }
                else
                {
                    primo = medio + 1;
                    
                }
            }
            return false;
        }


        bool linguaInglese(string testo)
        {
            int paroleTrov = 0;
            int paroleNonTrov = 0;
            
            string[] parole = testo.Split(' ');         //ARRAY DELLE PAROLE SCRITTE DALL'UTENTE
            for(int i = 0; i < parole.Length; i++)
            {
                bool controllo = parolaInglese(parole[i]);
                if (controllo)
                {
                    paroleTrov++;
                }
                else if(!controllo)
                    paroleNonTrov++;
            }


            if(paroleTrov>=paroleNonTrov)
            {
                return true;
            }
            else
            {
                return false;
            }
        }








        string[] paroleInglesi = new string[0];



        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream parole = new FileStream("Lista parole Inglese.txt", FileMode.Open);
            StreamReader lettura = new StreamReader(parole);
            while (!lettura.EndOfStream)
            {
                string word = lettura.ReadLine();
                Array.Resize(ref paroleInglesi, paroleInglesi.Length + 1);
                paroleInglesi[paroleInglesi.Length - 1] = word;
            }
            lettura.Close();
            parole.Close();



        }

      
    }
}
