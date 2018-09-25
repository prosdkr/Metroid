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
using System.Windows.Threading;

namespace Metroid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KeyboardController kbc;

        public MainWindow()
        {
            InitializeComponent();

            CompositionTarget.Rendering += CompositionTarget_Rendering;

            //ImageDrawing idle = new ImageDrawing();
            //BitmapImage idleImage = new BitmapImage();
            //idleImage.BeginInit();
            //idleImage.UriSource = new Uri(@"\Assets\idle.png", UriKind.Relative);
            //idleImage.EndInit();

            //player.Source = idleImage;

            this.ResizeMode = ResizeMode.NoResize;

            EventHandler eh = new EventHandler(KeyboardFunction);
            kbc = new KeyboardController(this, eh);


        }




        private void KeyboardFunction(object sender, EventArgs e)
        {
            if ( kbc.KeyDown(Key.D)) //Right
            {
                Constants.SamusFacing = Constants.FacingDirection.RIGHT;
                if (Constants.SamusFacing != Constants.PreviousFacing)
                {
                    Constants.PreviousFacing = Constants.FacingDirection.RIGHT;
                    Constants.State = 0;
                }
                Constants.SamusPreviousPositionX = Constants.SamusPositionX;
                Constants.SamusPositionX += Constants.MoveSpeed;

            }
            if ( kbc.KeyDown(Key.A)) //Left
            {
                Constants.SamusFacing = Constants.FacingDirection.LEFT;
                if (Constants.SamusFacing != Constants.PreviousFacing)
                {
                    Constants.PreviousFacing = Constants.FacingDirection.LEFT;
                    Constants.State = 0;
                }
                Constants.SamusPreviousPositionX = Constants.SamusPositionX;
                Constants.SamusPositionX -= Constants.MoveSpeed;

            }
            if (kbc.KeyDown(Key.W)) //Up
            {

            }
            if (kbc.KeyDown(Key.D)) //Down
            {

            }
        }



        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
        
            Point mousePosition = Mouse.GetPosition(this);
            Console.WriteLine("Mouse at: " + mousePosition);


            //Canvas.SetTop(GameCursor, mousePosition.Y - Constants.TILE_HEIGHT / 2);
            //Canvas.SetLeft(GameCursor, mousePosition.X - Constants.TILE_WIDTH / 2);

            //GameCursor.Margin = new Thickness(mousePosition.X - TILE_WIDTH/2, mousePosition.Y - TILE_HEIGHT/2, 32, 32);

            double angle = Constants.AngleBetweenTwoPoints(new Point(Canvas.GetTop(RightTorso), Canvas.GetLeft(RightTorso)), new Point(Canvas.GetTop(GameCursor), Canvas.GetLeft(GameCursor)));

            Console.WriteLine("Angle from player to cursor: " + angle);
            RightTorso.RenderTransform = new RotateTransform(angle - 90);

            if ((Constants.State - Constants.State % 10) % 10 == 0)
            {
                int x = Constants.State - Constants.State % 10;
                if (x == 100)
                {
                    x = 0;
                    Constants.State = 0;
                }

                BitmapSource bs = new BitmapImage(new Uri(@"C:\Users\prosdkr\Desktop\Metroid\Metroid\Assets\leftrun.png"));
                BitmapSource bs2 = new BitmapImage(new Uri(@"C:\Users\prosdkr\Desktop\Metroid\Metroid\Assets\rightrun.png"));




                CroppedBitmap croppedBitmap = new CroppedBitmap(bs, new Int32Rect((x / Constants.LEFT_RUN_STATES) * Constants.SAMUS_STANDING_WIDTH,
                                                                                  0,
                                                                                  Constants.SAMUS_STANDING_WIDTH,
                                                                                  Constants.SAMUS_STANDING_HEIGHT));
                CroppedBitmap croppedBitmapR = new CroppedBitmap(bs2, new Int32Rect((x / Constants.LEFT_RUN_STATES) * Constants.SAMUS_STANDING_WIDTH,
                                                                  0,
                                                                  Constants.SAMUS_STANDING_WIDTH,
                                                                  Constants.SAMUS_STANDING_HEIGHT));

                if (Constants.SamusFacing == Constants.FacingDirection.LEFT)
                    LeftRun.Source = croppedBitmap;
                if (Constants.SamusFacing == Constants.FacingDirection.RIGHT)
                    LeftRun.Source = croppedBitmapR;

                Canvas.SetTop(LeftRun, Constants.SamusPositionY);
                Canvas.SetLeft(LeftRun, Constants.SamusPositionX);



            }
            if (Constants.SamusPositionX != Constants.SamusPreviousPositionX)
            {

                Constants.State += 2;
               
            }
            else if (Constants.SamusPositionX == Constants.SamusPreviousPositionX && Constants.SamusFacing == Constants.FacingDirection.LEFT)
            {
                BitmapSource left = new BitmapImage(new Uri(@"C:\Users\prosdkr\Desktop\Metroid\Metroid\Assets\FaceLeft.png"));
                Constants.State = 0;
                LeftRun.Source = left;
            }
            else if (Constants.SamusPositionX == Constants.SamusPreviousPositionX && Constants.SamusFacing == Constants.FacingDirection.RIGHT)
            {
                BitmapSource right = new BitmapImage(new Uri(@"C:\Users\prosdkr\Desktop\Metroid\Metroid\Assets\FaceRight.png"));
                Constants.State = 0;
                LeftRun.Source = right;
            }


            //else if (Constants.SamusFacing == Constants.FacingDirection.RIGHT)
            //{
            //    BitmapSource bs = new BitmapImage(new Uri(@"C:\Users\prosdkr\Desktop\Metroid\Metroid\Assets\FaceLeft.png"));
            //    LeftRun.Source = bs;
            //}
        }



    }
}
