using System;
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

namespace ZaverecnyProjekt
{
    public partial class MainWindow : Window
    {
        // Scéna 1
        bool praceNalezena = false;
        bool batohVzaty = false;
        bool pizzaVzata = false;

        // Scéna 2
        bool logPrecten = false;
        bool hesloNalezeno = false;

        // Scéna 3
        bool usbNalezeno = false;
        bool adminPCProzkouman = false;
        bool sanonProzkouman = false;

        // Scéna 4
        bool terminalAnalyzed = false;
        bool boardAnalyzed = false;
        bool doorAccessed = false;
        bool optimizerStopped = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        //  START 
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartScreen.Visibility = Visibility.Hidden;
            RoomScreen.Visibility = Visibility.Visible;

            StoryText.Text = "7:12 ráno...\nProbouzíš se, něco je špatně.\nTvoje ročníková práce bezestopy zmizela z disku.";
        }

        //  SCÉNA 1
        private void PcButton_Click(object sender, RoutedEventArgs e)
        {
            if (!praceNalezena)
            {
                MessageBox.Show("Soubor nenalezen...\nERROR: rocnikova_prace", "Domácí PC");
                praceNalezena = true;
                StoryText.Text = "Někdo ji musel smazat na dálku!\nSbal si věci do batohu a utíkej prověřit školní síť.";
            }
            CheckProgress();
        }

        private void PizzaButton_Click(object sender, RoutedEventArgs e)
        {
            if (!pizzaVzata)
            {
                pizzaVzata = true;
                MessageBox.Show("Našel jsi studenou pizzu. Ta se může ještě hodit.", "Loot");

                InventoryText.Text += "\nPizza";
                SchoolInventoryText.Text += "\nPizza";
                ServerInventoryText.Text += "\nPizza";
            }
        }

        private void BagButton_Click(object sender, RoutedEventArgs e)
        {
            if (!batohVzaty)
            {
                batohVzaty = true;
                InventoryText.Text = "Batoh" + (pizzaVzata ? "\nPizza" : "");
                MessageBox.Show("Vzal jsi batoh na záda.", "Inventář");
            }
            CheckProgress();
        }

        private void CheckProgress()
        {
            if (praceNalezena && batohVzaty && pizzaVzata)
            {
                StoryText.Text = "Máš všechno. Teď rychle utíkej do školy!";
                NextButton.Visibility = Visibility.Visible;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            RoomScreen.Visibility = Visibility.Hidden;
            SchoolScreen.Visibility = Visibility.Visible;

            SchoolStoryText.Text = "Učebna informatiky je prázdná, ale na počítačích běží podivné procesy. Prohledej to tu.";
        }

        // SCÉNA 2
        private void MonitorButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("SYSTEM LOG: AUTOMATIC_DELETE -> project_final.html", "Školní monitor");
            logPrecten = true;

            SchoolStoryText.Text = "Školní síťový skript ti smazal práci! Potřebuješ admin práva, abys zjistil, odkud ten příkaz přišel.";
            CheckSchoolProgress();
        }

        private void NoteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!hesloNalezeno)
            {
                hesloNalezeno = true;
                MessageBox.Show("Na žlutém papírku je napsáno:\n\nadmin:1234_polda", "Nalezená poznámka");
                SchoolInventoryText.Text += "\nHeslo";
                ServerInventoryText.Text += "\nHeslo";
            }
            CheckSchoolProgress();
        }

        private void WhiteboardButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Na tabuli jsou základy programování:\n\n" +
                "- pole, cykly, podmínky, funkce...\n\n" +
                "Tohle ti teď nepomůže. Musíš vyřešit ten smazaný soubor.",
                "Školní tabule"
            );
        }

        private void CheckSchoolProgress()
        {
            if (logPrecten && hesloNalezeno)
            {
                SchoolStoryText.Text = "Máš přihlašovací údaje administrátora! Teď můžeš jít přímo do hlavní serverovny školy.";
                EndGameButton.Visibility = Visibility.Visible;
            }
        }

        private void EndGameButton_Click(object sender, RoutedEventArgs e)
        {
            SchoolScreen.Visibility = Visibility.Hidden;
            ServerRoomScreen.Visibility = Visibility.Visible;
            ServerStoryText.Text = "Jsi v hlavní serverovně. Školní firewall tě nechce pustit dál do centrály.\n" +
                                   "Musíš udělat 3 věci: Najít v šanonech manuál, zapojit USB a stáhnout logy a pak u Admin PC přepsat přístupová práva.";
        }

        // SCÉNA 3
        private void UsbButton_Click(object sender, RoutedEventArgs e)
        {
            if (!usbNalezeno)
            {
                usbNalezeno = true;
                MessageBox.Show("Zapojil jsi flashku do serveru a stáhl kompletní síťové logy útoků.", "Záloha logů");
                ServerInventoryText.Text += "\nSíťové logy";
                CheckServerProgress();
            }
        }

        private void AdminPcButton_Click(object sender, RoutedEventArgs e)
        {
            if (!adminPCProzkouman)
            {
                adminPCProzkouman = true;
                MessageBox.Show("Pomocí admin hesla z papírku se úspěšně přihlašuješ k terminálu serveru a připravuješ deaktivaci.", "Hlavní server");
                CheckServerProgress();
            }
        }

        private void FolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (!sanonProzkouman)
            {
                sanonProzkouman = true;
                MessageBox.Show("V zaprášeném šanonu jsi našel skrytý manuál k nouzovému ovládání školní sítě.", "Nález manuálu");
                ServerInventoryText.Text += "\nManuál sítě";
                CheckServerProgress();
            }
        }

        private void CheckServerProgress()
        {
            if (usbNalezeno && adminPCProzkouman && sanonProzkouman)
            {
                ServerStoryText.Text = "Všechny obranné protokoly serverovny jsou prolomeny. Dveře do hlavní řídící centrály se otevírají!";
                ToFinalButton.Visibility = Visibility.Visible;
            }
            else
            {
                string chybi = "Ještě ti zbývá: ";
                if (!sanonProzkouman) chybi += "[Prohledat šanony] ";
                if (!usbNalezeno) chybi += "[Stáhnout logy na USB] ";
                if (!adminPCProzkouman) chybi += "[Přihlásit se k Admin PC] ";
                ServerStoryText.Text = chybi;
            }
        }

        // SCÉNA 4
        private void ToFinalButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vstupuješ do skrytého operačního centra.", "Hlavní centrála");

            ServerRoomScreen.Visibility = Visibility.Hidden;
            FinalScreen.Visibility = Visibility.Visible;

            // Sjednocený přenos inventáře
            FinalInventoryText.Text = "Batoh" + (pizzaVzata ? "\nPizza" : "") + "\nAdmin Heslo\nSíťové logy\nManuál sítě";

            FinalStoryText.Text =
                "To je ono - místnost z tvých předtuch. Všude bzučí skříně serverů a venku za oknem prší.\n" +
                "Na monitorech uprostřed stolu běží škodlivý program SCHOOL_OPTIMIZER, který maže studentské práce.\n" +
                "Prověř monitory, nástěnku a zabezpečené dveře napravo.";
        }

        private void MainTerminalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!terminalAnalyzed)
            {
                terminalAnalyzed = true;
                MessageBox.Show(
                    "Díváš se na monitory se zdrojovým kódem.\n\n" +
                    "V jedné sekci narazíš na autorský komentář:\n" +
                    "// TODO: Nouzový kód k jističům za dveřmi je 8421",
                    "Hlavní terminál"
                );

                if (!FinalInventoryText.Text.Contains("Kód k zámku (8421)"))
                    FinalInventoryText.Text += "\nPIN k jističům (8421)";

                FinalStoryText.Text = "Skvěle! Našel jsi PIN kód (8421). Teď můžeš zkusit otevřít dveře v pravém rohu.";
            }
            else
            {
                MessageBox.Show("Software nelze vypnout softwarově, je zablokovaný. Musíš fyzicky shodit jističe za dveřmi.", "Hlavní terminál");
            }
            CheckFinalProgress();
        }

        private void BoardButton_Click(object sender, RoutedEventArgs e)
        {
            if (!boardAnalyzed)
            {
                boardAnalyzed = true;
                MessageBox.Show(
                    "Prohlížíš si detektivní nástěnku s červenými provázky.\n\n" +
                    "Někdo to na tebe narafičil! Jsou tu fotky tvé třídy a plány na smazání všech letošních projektů.",
                    "Nástěnka se stopami"
                );

                if (!FinalInventoryText.Text.Contains("Důkazy spiknutí"))
                    FinalInventoryText.Text += "\nDůkazy spiknutí";

                FinalStoryText.Text = "Nástěnka dokazuje, že šlo o plánovaný útok na studenty. Musíš to zastavit.";
            }
            else
            {
                MessageBox.Show("Červené provázky vedou přímo k tvému jménu. Tohle byl osobní útok.", "Nástěnka se stopami");
            }
            CheckFinalProgress();
        }

        private void DoorButton_Click(object sender, RoutedEventArgs e)
        {
            if (!doorAccessed)
            {
                if (!terminalAnalyzed)
                {
                    MessageBox.Show("Dveře jsou blokované kódovým zámkem. Potřebuješ čtyřmístný PIN kód, abys mohl vejít k jističům.", "Kódový zámek");
                    FinalStoryText.Text = "Elektronický zámek tě nepustí. Zkus prohledat běžící kód na hlavním terminálu na stole.";
                    return;
                }
                PinPanel.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Dveře do místnosti s napájením jsou už otevřené.", "Zabezpečené dveře");
            }
        }

        private void SubmitPin_Click(object sender, RoutedEventArgs e)
        {
            if (PinTextBox.Text == "8421")
            {
                doorAccessed = true;
                PinPanel.Visibility = Visibility.Collapsed;

                MessageBox.Show("Cvak! Zámek povolil a dveře se otevírají. Vidíš hlavní jističe celého systému.", "Elektronický zámek");
                FinalStoryText.Text = "Cesta k napájení je volná. Teď už můžeš bezpečně odpojit celý server z provozu!";

                CheckFinalProgress();
            }
            else
            {
                MessageBox.Show("Zablikalo červené světlo: NEPLATNÝ PIN. Zkus to znovu.", "Elektronický zámek");
                PinTextBox.Text = "";
            }
        }

        private void CancelPin_Click(object sender, RoutedEventArgs e)
        {
            PinPanel.Visibility = Visibility.Collapsed;
            PinTextBox.Text = "";
        }

        private void CoffeeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Sáhneš na hrnek stojící na stole.\n\n" +
                "Káva v něm je horká! Ten, kdo to celé spustil, musel před pár minutami utéct.",
                "Hrnek s kávou"
            );
            FinalStoryText.Text = "Horká káva značí, že pachatel tu před chvílí byl. Rychle, než se vrátí!";
        }

        private void CheckFinalProgress()
        {
            if (terminalAnalyzed && boardAnalyzed && doorAccessed)
                FinishGameButton.Visibility = Visibility.Visible;
        }

        private void FinishGameButton_Click(object sender, RoutedEventArgs e)
        {
            optimizerStopped = true;

            MessageBox.Show("Zatáhl jsi za hlavní páku jističe.\n\nBZZZT... Celá místnost utichla, servery zhasly.", "FINÁLE");

            FinalStoryText.Text = "SCHOOL_OPTIMIZER byl úspěšně zničen. Školní síť nahodila bezpečné zálohy a tvoje ročníková práce je kompletně zachráněna! Dokázal jsi to.";
            FinishGameButton.Content = "KONEC HRY";

            FinishGameButton.Click -= FinishGameButton_Click;
            FinishGameButton.Click += (s, ev) =>
            {
                Application.Current.Shutdown();
            };
        }
    }
}