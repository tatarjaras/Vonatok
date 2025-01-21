using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace VonatokWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Varakozas> varakozasok = new List<Varakozas>();
        static HashSet<string> vonalak=new HashSet<string>();

        public MainWindow()
        {
            InitializeComponent();
            Feltolt("varakozas.txt");
            cbxvonalszam.ItemsSource=vonalak;
            
            
        }


        private static void Feltolt(string fileName)
        {
            string[] sorok =File.ReadAllLines(fileName).Skip(1).ToArray();
            foreach (string sor in sorok)
            {
                varakozasok.Add(new Varakozas());
                vonalak.Add(sor.Split('\t')[0]);
            }
        }



        private void btnMentés_Click(object sender, RoutedEventArgs e)
        {
            if (cbxvonalszam.SelectedItem!=null)
            {
                List<Varakozas>eredmeny=varakozasok.Where(x=>x.Vonal==cbxvonalszam.SelectedItem.ToString()).ToList();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = cbxvonalszam.SelectedItem.ToString()+".txt";
                saveFileDialog.DefaultExt = ".txt";
                saveFileDialog.Filter = "Text document (.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                    foreach (Varakozas v in eredmeny)
                    {
                        sw.WriteLine($"{v.Allomas} állomáson {v.Indulo} felé vár a(z) {v.Erkezo} felöl érkező vonatra.");
                    }
                    sw.Close();
                }
                

            }
            else
            {
                MessageBox.Show("Nincs kiválasztott vonal!");
            }
        }

        private void cbxvonalszam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxvonalszam.SelectedItem!=null)
            {
                string vonal=cbxvonalszam.SelectedItem.ToString();
                tbkadatok.Text = string.Join("\n", varakozasok.Where(x => x.Vonal == vonal));
            }
        }
    }
}