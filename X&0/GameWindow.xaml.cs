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
using System.Windows.Shapes;

namespace X_0
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private bool inProgress = true;
        private Char currentChar = 'X';
        public Char CurrentChar
        {
            get { return currentChar; }
            set { currentChar = value; }
        }

        public string[] details = new string[2];

        private void changeCurrentCharacter()
        {
            if (CurrentChar == 'X') CurrentChar = '0';
            else currentChar = 'X';
        }

        private char[,] board = new char[,] { { '-', '-', '-' }, { '-', '-', '-' }, { '-', '-', '-' } };
        public char this[int i, int j]
        {
            get { return board[i, j]; }
            set { board[i, j] = value; }
        }

        private void game()
        {
            bool ok;
            char firstChar;
            //rows
            for (int i = 0; i < 3; i++)
            {
                ok = true;
                firstChar = this[i, 0];
                if (firstChar != '-')
                {
                    for (int j = 1; j < 3; j++)
                    {
                        if (this[i, j] != firstChar)
                        {
                            ok = false;
                        }
                    }
                    if (ok == true)
                    {
                        if (firstChar == '0') t0.Text = details[1] + "  win";
                        else t0.Text = details[0] + "  win";
                        inProgress = false;
                        return;
                    }
                }
            }
            //column
            for (int i = 0; i < 3; i++)
            {
                ok = true;
                firstChar = this[0, i];
                if (firstChar != '-')
                {
                    for (int j = 1; j < 3; j++)
                    {
                        if (this[j, i] != firstChar)
                        {
                            ok = false;
                        }
                    }
                    if (ok == true)
                    {
                        if (firstChar == '0') t0.Text = details[1] + "  win";
                        else t0.Text = details[0] + "  win";
                        inProgress = false;
                        return;
                    }
                }
            }
            //first diaginal
            ok = true;
            if (this[0, 0] != '-')
            {
                for (int i = 1; i < 3; i++)
                {
                    if (this[i, i] != this[0, 0])
                        ok = false;
                }
                if (ok == true)
                {
                    if (this[0, 0] == '0') t0.Text = details[1] + "  win";
                    else t0.Text = details[0] + "  win";
                    inProgress = false;
                    return;
                }
            }
            //second diaginal
            ok = true;
            if (this[0, 2] != '-')
            {
                if (this[1, 1] != this[0, 2] || this[1, 1] != this[2, 0])
                    ok = false;
                if (ok == true)
                {
                    if (this[2, 0] == '0') t0.Text = details[1] + "  win";
                    else t0.Text = details[0] + "  win";
                    inProgress = false;
                    return;
                }
            }
        }
        private void b00_Click(object sender, RoutedEventArgs e)
        {
            if (inProgress)
            {
                b00.Content ??= CurrentChar.ToString();
                this[0, 0] = CurrentChar;
                changeCurrentCharacter();
                game();
            }
        }

        private void b01_Click(object sender, RoutedEventArgs e)
        {
            if (inProgress)
            {
                b01.Content ??= CurrentChar.ToString();
                this[0, 1] = CurrentChar;
                changeCurrentCharacter();
                game();
            }
        }

        private void b02_Click(object sender, RoutedEventArgs e)
        {
            if (inProgress)
            {
                b02.Content ??= CurrentChar.ToString();
                this[0, 2] = CurrentChar;
                changeCurrentCharacter();
                game();
            }
        }

        private void b10_Click(object sender, RoutedEventArgs e)
        {
            if (inProgress)
            {
                b10.Content ??= CurrentChar.ToString();
                this[1, 0] = CurrentChar;
                changeCurrentCharacter();
                game();
            }
        }

        private void b11_Click(object sender, RoutedEventArgs e)
        {
            if (inProgress)
            {
                b11.Content ??= CurrentChar.ToString();
                this[1, 1] = CurrentChar;
                changeCurrentCharacter();
                game();
            }
        }

        private void b12_Click(object sender, RoutedEventArgs e)
        {
            if (inProgress)
            {
                b12.Content ??= CurrentChar.ToString();
                this[1, 2] = CurrentChar;
                changeCurrentCharacter();
                game();
            }
        }

        private void b20_Click(object sender, RoutedEventArgs e)
        {
            if (inProgress)
            {
                b20.Content ??= CurrentChar.ToString();
                this[2, 0] = CurrentChar;
                changeCurrentCharacter();
                game();
            }
        }

        private void b21_Click(object sender, RoutedEventArgs e)
        {
            if (inProgress)
            {
                b21.Content ??= CurrentChar.ToString();
                this[2, 1] = CurrentChar;
                changeCurrentCharacter();
                game();
            }
        }

        private void b22_Click(object sender, RoutedEventArgs e)
        {
            if (inProgress)
            {
                b22.Content ??= CurrentChar.ToString();
                this[2, 2] = CurrentChar;
                changeCurrentCharacter();
                game();
            }
        }
        public GameWindow()
        {
            InitializeComponent();
        }
        public GameWindow(string[] names)
        {
            InitializeComponent();
            t1.Text = names[0] + '\n' + "vs" + '\n' + names[1];
            details = names;
        }
    }
}
