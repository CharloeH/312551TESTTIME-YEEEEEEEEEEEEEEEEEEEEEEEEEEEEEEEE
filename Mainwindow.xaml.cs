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
using System.Windows.Forms;
using System.Windows.Threading;
using Cursor = System.Windows.Forms.Cursor;

namespace Break
{
    enum PlayerColour {Red, Blue, Yellow, Green}
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int counter = 0;
        PlayerSprite myPlayerSprite;
        ManipulatePlayer myManipulatePlayer;
        DispatcherTimer dTimer;
        public MainWindow()
        {
            dTimer = new DispatcherTimer();
            myPlayerSprite = new PlayerSprite();
            myManipulatePlayer = new ManipulatePlayer();
            InitializeComponent();
            myPlayerSprite.setPlayer(myCanvas);
            dTimer.Tick += dTimer_tick;
            dTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            myPlayerSprite._playerRectangle.Fill = Brushes.Blue;

            dTimer.Start();
        }

        private void dTimer_tick(object sender, EventArgs e)
        {
            myPlayerSprite.setPlayerColour();
            counter++;


            Console.WriteLine(counter.ToString());

        }
    }
        class PlayerSprite
        {
        PlayerColour myPlayerColour = PlayerColour.Red;
        ManipulatePlayer myManipulatePlayer = new ManipulatePlayer();

        public Rectangle _playerRectangle = new Rectangle();
        public Point _playerPoint = new Point(250, 250);
        public Point _mousePoint = new Point(Cursor.Position.X, Cursor.Position.Y);
        public Point setPlayer(Canvas c)
            {
                _playerRectangle.Height = 50;
                _playerRectangle.Width = 50;

                _playerRectangle.Fill = Brushes.Black;

                c.Children.Add(_playerRectangle);

                Canvas.SetTop(_playerRectangle, _playerPoint.Y);
                Canvas.SetLeft(_playerRectangle, _playerPoint.X);
                return _playerPoint;
            }
            public void setPlayerColour()
            {
            myManipulatePlayer.getPlayerColour(_playerRectangle, _playerPoint, _mousePoint);
            if (myPlayerColour == PlayerColour.Blue)
                _playerRectangle.Fill = Brushes.Blue;
            if (myPlayerColour == PlayerColour.Red)
                _playerRectangle.Fill = Brushes.Red;

        }
           
        }
        
    
    class ManipulatePlayer
    {
        PlayerColour PlayerColour;
        PlayerSprite myplayerSprite = new PlayerSprite();
        
        public void getPlayerColour(Rectangle r, Point p1, Point p2)
        {
            
            if (p1.X > p2.X)
            {
                Console.WriteLine("left");
                PlayerColour = PlayerColour.Red;
                return;
            }

            else if (p1.X < p2.X)
            {
                Console.WriteLine("right");
                PlayerColour = PlayerColour.Blue;
                return;
            }

        }

    }
}
