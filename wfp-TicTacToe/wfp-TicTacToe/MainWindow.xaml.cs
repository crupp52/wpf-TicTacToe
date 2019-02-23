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

        }
    }
}
