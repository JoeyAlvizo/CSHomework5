using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharp_Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Boolean xTurn = true;
        public MainWindow()
        {
            InitializeComponent();
            uxTurn.Text = "X's turn";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button focus = (Button)sender;

            if (((String)focus.Content) == null)
            {
                if (xTurn)
                    focus.Content = "X";
                else
                    focus.Content = "O";
                xTurn = !xTurn;
                update_uxTurn();
                if (isWin((String)focus.Tag, (String)focus.Content))
                {
                    MessageBox.Show((String)focus.Content + " wins");
                    xTurn = true;
                    foreach (UIElement button in uxGrid.Children)
                    {
                        ((Button)button).Content = null;
                    }
                }
            }
        }
        private void update_uxTurn()
        {
            if(xTurn)
                uxTurn.Text = "X's turn";
            else
                uxTurn.Text = "O's turn";
        }
        private void update_uxTurn(String player)
        {
            uxTurn.Text = player + " is a winner";
        }
        private Boolean isWin(String corr, String player)
        {
            //int xCorr = Int32.Parse(corr.Substring(0,1));
            //int yCorr = Int32.Parse(corr.Substring(2, 1));

            switch(corr)
            { 
                case "0,0":
                    if (
                            (getButtonText(1, 0).Equals(player) && getButtonText(2, 0).Equals(player)) ||
                            (getButtonText(0, 1).Equals(player) && getButtonText(0, 2).Equals(player)) ||
                            (getButtonText(1, 1).Equals(player) && getButtonText(2, 2).Equals(player))
                        )
                    {
                        update_uxTurn(player);
                        return true;
                    }
                    break;
                case "0,1":
                    if (
                            (getButtonText(0, 0).Equals(player) && getButtonText(0, 2).Equals(player)) ||
                            (getButtonText(1, 1).Equals(player) && getButtonText(2, 1).Equals(player))
                        )
                    {
                        update_uxTurn(player);
                        return true;
                    }
                    break;
                case "0,2":
                    if (
                            (getButtonText(0, 0).Equals(player) && getButtonText(0, 1).Equals(player)) ||
                            (getButtonText(1, 2).Equals(player) && getButtonText(2, 2).Equals(player)) ||
                            (getButtonText(1, 1).Equals(player) && getButtonText(2, 0).Equals(player))
                        )
                    {
                        update_uxTurn(player);
                        return true;
                    }
                    break;
                case "1,0":
                    if (
                            (getButtonText(0, 0).Equals(player) && getButtonText(2, 0).Equals(player)) ||
                            (getButtonText(1, 1).Equals(player) && getButtonText(1, 2).Equals(player))
                        )
                    {
                        update_uxTurn(player);
                        return true;
                    }
                    break;
                case "1,1":
                    if (
                            (getButtonText(0, 0).Equals(player) && getButtonText(2, 2).Equals(player)) ||
                            (getButtonText(0, 2).Equals(player) && getButtonText(2, 0).Equals(player)) ||
                            (getButtonText(1, 0).Equals(player) && getButtonText(1, 2).Equals(player)) ||
                            (getButtonText(0, 1).Equals(player) && getButtonText(2, 1).Equals(player)) 
                        )
                    {
                        update_uxTurn(player);
                        return true;
                    }
                    break;
                case "1,2":
                    if (
                            (getButtonText(0, 2).Equals(player) && getButtonText(2, 2).Equals(player)) ||
                            (getButtonText(1, 1).Equals(player) && getButtonText(1, 0).Equals(player))
                        )
                    {
                        update_uxTurn(player);
                        return true;
                    }
                    break;
                case "2,0":
                    if (
                            (getButtonText(0, 0).Equals(player) && getButtonText(1, 0).Equals(player)) ||
                            (getButtonText(2, 1).Equals(player) && getButtonText(2, 2).Equals(player)) ||
                            (getButtonText(1, 1).Equals(player) && getButtonText(0, 2).Equals(player))
                        )
                    {
                        update_uxTurn(player);
                        return true;
                    }
                    break;
                case "2,1":
                    if (
                            (getButtonText(2, 0).Equals(player) && getButtonText(2, 2).Equals(player)) ||
                            (getButtonText(0, 1).Equals(player) && getButtonText(1, 1).Equals(player))
                        )
                    {
                        update_uxTurn(player);
                        return true;
                    }
                    break;
                case "2,2":
                    if (
                            (getButtonText(1, 1).Equals(player) && getButtonText(0, 0).Equals(player)) ||
                            (getButtonText(2, 0).Equals(player) && getButtonText(2, 1).Equals(player)) ||
                            (getButtonText(0, 2).Equals(player) && getButtonText(1, 2).Equals(player)) 
                        )
                    {
                        update_uxTurn(player);
                        return true;
                    }
                    break;
                default:
                    Console.WriteLine("Error button not found");
                    return false;
            }
            return false;
        }
        private Boolean isTie()
        {
            foreach (UIElement button in uxGrid.Children)
            {
                if (((Button)button).Content == null)
                    return false;
            }
            return true;
        }
        private String getButtonText(int x, int y)
        {
            String corrString = x + "," + y;

            Button target = uxGrid.Children.OfType<Button>()
                .Where(x => (String)x.Tag == corrString).FirstOrDefault();

            return target.Tag.ToString();
        }
        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            xTurn = true;
            update_uxTurn();

            foreach (UIElement button in uxGrid.Children)
            {
                ((Button)button).Content = null;
            }
        }
        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
