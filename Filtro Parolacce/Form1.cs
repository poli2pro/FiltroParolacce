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
        bool scrittoAutore()
        {
            if (textBox1.Text == "")
                return false;

            return true;
        }



        bool linguaInglese;
        string testo = "";
        double percentuale;
        string autore = "";


        private void btnPubblica_Click(object sender, EventArgs e)
        {
            bool scritto = true;

            bool contr = scrittoQualcosa();
            if (!contr)
            {
                MessageBox.Show("ERRORE: per postare la tua storia, inserisci del testo");
                return;
            }
            contr = scrittoAutore();
            if (!contr)
            {
                MessageBox.Show("ERRORE: per postare la tua storia, inserisci l'autore");
                return;
            }
            testo = txtTesto.Text;                           //TESTO SCRITTO DALL'UTENTE

            linguaInglese = controlloLingua(testo);          //SE IL TESTO RISULTA SCRITTO IN INGLESE, QUESTO VALORE BOOLEANO SARA' TRUE, ALTRIMENTI FALSE;

            percentuale = percentualeParolacce(testo, linguaInglese);       //RESTITUISCE LA PERCENTUALE DELLE PAROLACCE TROVATE IN UN TESTO

            autore = textBox1.Text;

            MessageBox.Show("CONGRATULAZIONI: la tua storia è stata postata con successo");

        }








        string[] estrazioneParole(string percorso)
        {
            string[] paroleTesto = new string[0];
            FileStream parole = new FileStream(percorso, FileMode.Open);
            StreamReader lettura = new StreamReader(parole);
            while (!lettura.EndOfStream)
            {
                string word = lettura.ReadLine();
                Array.Resize(ref paroleTesto, paroleTesto.Length + 1);
                paroleTesto[paroleTesto.Length - 1] = word;
            }
            lettura.Close();
            parole.Close();
            return paroleTesto;
        }

        void ordinaArrayStringhe(string[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (string.Compare(array[i], array[j]) < 0)
                    {
                        string tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
        }




        double percentualeParolacce(string testo, bool linguaInglese)
        {
            string[] parolacce;
            string[] paroleTesto = testo.Split(' ');
            if (linguaInglese)
            {
                parolacce = estrazioneParole("parolacceInglesi.txt");
            }
            else
            {
                parolacce = estrazioneParole("parolacceItaliane.txt");
            }

            ordinaArrayStringhe(parolacce);


            int parolacceTrovate = 0;
            int parolacceNonTrovate = 0;
            for (int i = 0; i < paroleTesto.Length; i++)
            {
                bool trovataParola = ricercaParola(paroleTesto[i], parolacce);
                if (trovataParola)
                    parolacceTrovate++;
                else
                    parolacceNonTrovate++;
            }

            int paroleTotali = parolacceTrovate + parolacceNonTrovate;
            double percentuale = (paroleTotali / ((parolacceTrovate == 0) ? 1 : parolacceTrovate)) * 100;

            return percentuale;

        }








        bool ricercaParola(string parola, string[] testo)
        {
            int primo, medio, ultimo;
            primo = 0;

            ultimo = testo.Length - 1;
            while (primo <= ultimo)
            {
                medio = (primo + ultimo) / 2;
                string parolaMedia = testo[medio];
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


        bool controlloLingua(string testo)
        {
            int paroleTrov = 0;
            int paroleNonTrov = 0;

            string[] parole = testo.Split(' ');         //ARRAY DELLE PAROLE SCRITTE DALL'UTENTE
            for (int i = 0; i < parole.Length; i++)
            {
                bool controllo = ricercaParola(parole[i], paroleInglesi);
                if (controllo)
                {
                    paroleTrov++;
                }
                else if (!controllo)
                    paroleNonTrov++;
            }


            if (paroleTrov >= paroleNonTrov)
            {
                return true;
            }
            else
            {
                return false;
            }
        }








        string[] paroleInglesi;



        private void Form1_Load(object sender, EventArgs e)
        {

            paroleInglesi = estrazioneParole("Lista parole Inglese.txt");



        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("attenzione: srivi nel posto adatto!");
            txtTesto.Focus();
        }

        private void txtTesto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
