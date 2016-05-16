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



        string[] quote = new string[0];
        bool linguaInglese;
        string testo = "";
        double percentuale;
        int conta = 1;
        int x = 10;
        int y = 10;
        int c = 0;



        private void btnPubblica_Click(object sender, EventArgs e)
        {
            bool contr = scrittoQualcosa();
            if (!contr)
            {
                MessageBox.Show("ERRORE: per postare la tua storia, inserisci del testo");
                return;
            }
            testo = txtTesto.Text;                           //TESTO SCRITTO DALL'UTENTE

            linguaInglese = controlloLingua(testo);          //SE IL TESTO RISULTA SCRITTO IN INGLESE, QUESTO VALORE BOOLEANO SARA' TRUE, ALTRIMENTI FALSE;

            percentuale = percentualeParolacce(testo, linguaInglese);       //RESTITUISCE LA PERCENTUALE DELLE PAROLACCE TROVATE IN UN TESTO

            if(percentuale < 20)
            {
                
                

                FileStream file = new FileStream("txt.txt", FileMode.OpenOrCreate);
                StreamWriter scrivi = new StreamWriter(file);
                for (int i = 0; i < txtTesto.TextLength; i++)
                {
                    scrivi.WriteLine(txtTesto.Text);
                }
                scrivi.Close();
                file.Close();
                FileStream file2 = new FileStream("txt.txt", FileMode.Open);
                StreamReader a = new StreamReader(file2);
                while (!a.EndOfStream)
                {
                    a.ReadLine();
                    c++;

                }
                a.Close();
                file2.Close();


                RichTextBox lst = new RichTextBox();
                lst.Name = "rich_" + conta.ToString();

                lst.Location = new System.Drawing.Point(x,y);
                lst.Size = new Size(TextRenderer.MeasureText(txtTesto.Text,txtTesto.Font).Width+1, TextRenderer.MeasureText(txtTesto.Text[0].ToString(), txtTesto.Font).Height*(txtTesto.Lines.Length+1));


                Array.Resize(ref quote, quote.Length+1);
                quote[quote.Length - 1] = txtTesto.Text;
                


                
                MessageBox.Show("Pubblicato!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                tabPage2.Controls.Add(lst);
                foreach (string cont in quote)
                {
                    lst.Text = cont;
                }

                conta++;
                y += 100;
                


            }
            else
            {
                MessageBox.Show("Errore troppe parolacce! Non inserito!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



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
            for(int i=0; i < array.Length - 1; i++)
            {
                for(int j=0; j< array.Length; j++)
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
            double percentuale = 0;
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


            double parolacceTrovate = 0;
            double parolacceNonTrovate = 0;
            for (int i=0; i < paroleTesto.Length; i++)
            {
                bool trovataParola = ricercaParola(paroleTesto[i], parolacce);
                if (trovataParola)
                    parolacceTrovate++;
                else
                    parolacceNonTrovate++;
            }

            double paroleTotali = parolacceTrovate + parolacceNonTrovate;
            return percentuale =  (parolacceTrovate/ paroleTotali) * 100;

            

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
                bool controllo = ricercaParola(parole[i],paroleInglesi);
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


    }
}
