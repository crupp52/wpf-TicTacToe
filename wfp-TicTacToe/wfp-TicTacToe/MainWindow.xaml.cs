using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace wfp_TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Priavte Members

        /// <summary>
        /// Holds the current result of cells in this active game.
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if it is the player 1 is turn (X) or the palyer 2 is turn (O).
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if the game is ended.
        /// </summary>
        private bool mGameEnded;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }
          
        #endregion

        /// <summary>
        /// Start a new game and reset all values back to the start
        /// </summary>
        private void NewGame()
        {
            mResults = new MarkType[9];

            for (int i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }

            mPlayer1Turn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            mGameEnded = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            int index = column + (row * 3);

            if (mResults[index] != MarkType.Free)
            {
                return;
            }

            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            button.Content = mPlayer1Turn ? "X" : "O";

            button.Foreground = mPlayer1Turn ? Brushes.Red : Brushes.Blue;

            mPlayer1Turn = !mPlayer1Turn;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            #region Horizontal Wins
            if (WinCheck(0, 1, 2))
            {
                mGameEnded = true;

                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Aqua;
            }

            if (WinCheck(3, 4, 5))
            {
                mGameEnded = true;

                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Aqua;
            }

            if (WinCheck(6, 7, 8))
            {
                mGameEnded = true;

                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Aqua;
            }
            #endregion

            #region Vertical Wins
            if (WinCheck(0, 3, 6))
            {
                mGameEnded = true;

                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Aqua;
            }

            if (WinCheck(1, 4, 7))
            {
                mGameEnded = true;

                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Aqua;
            }

            if (WinCheck(2, 5, 8))
            {
                mGameEnded = true;

                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Aqua;
            }
            #endregion

            #region Diagonal Wins
            if (WinCheck(0, 4, 8))
            {
                mGameEnded = true;

                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Aqua;
            }

            if (WinCheck(2, 4, 6))
            {
                mGameEnded = true;

                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Aqua;
            }
            #endregion

            #region No Wins
            if (!mResults.Any(f => f == MarkType.Free) && !mGameEnded)
            {
                mGameEnded = true;

                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }
            #endregion
        }

        private bool WinCheck(int a, int b, int c)
        {
            return mResults[a] != MarkType.Free && mResults[a] == mResults[b] && mResults[b] == mResults[c];
        }
    }
}
