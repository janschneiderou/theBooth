using Microsoft.Kinect.Input;
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

namespace TheBooth
{
    /// <summary>
    /// Interaction logic for FirstQuestion.xaml
    /// </summary>
    public partial class FirstQuestion : UserControl
    {

        public MainWindow parent;
        public bool ready = false;
        public KinectCoreWindow window;
        public FirstQuestion()
        {
            InitializeComponent();
            window = KinectCoreWindow.GetForCurrentThread();
            window.PointerMoved += window_PointerMoved;
        }

        public void loaded()
        {
           // ready = false;
            ready = true;
            this.Visibility = Visibility.Collapsed;

            this.Width = 1200;
            this.Height =800;

            parent.firstLogString = "First = 1";
            if (parent.bodyFrameHandler.bodyFrameReader != null)
            {
                parent.bodyFrameHandler.bodyFrameReader.FrameArrived += this.Reader_FrameArrived;

            }
            if (parent.faceFrameHandler.bodyFrameReader != null)
            {
                // wire handler for body frame arrival
                parent.faceFrameHandler.bodyFrameReader.FrameArrived += this.Reader_BodyFrameArrived;

                for (int i = 0; i < parent.faceFrameHandler.bodyCount; i++)
                {
                    if (parent.faceFrameHandler.faceFrameReaders[i] != null)
                    {
                        // wire handler for face frame arrival
                        parent.faceFrameHandler.faceFrameReaders[i].FrameArrived += Reader_FaceFrameArrived;
                        //break;
                    }
                }
            }


        }

        private void Reader_FaceFrameArrived(object sender, Microsoft.Kinect.Face.FaceFrameArrivedEventArgs e)
        {
            parent.faceFrameHandler.Reader_FaceFrameArrived(sender, e);
        }

        private void Reader_BodyFrameArrived(object sender, Microsoft.Kinect.BodyFrameArrivedEventArgs e)
        {
            parent.faceFrameHandler.Reader_BodyFrameArrived(sender, e);
        }

        private void Reader_FrameArrived(object sender, Microsoft.Kinect.BodyFrameArrivedEventArgs e)
        {
            parent.bodyFrameHandler.Reader_FrameArrived(sender, e);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            parent.firstLogString = "First = 1";
            ready = true;
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            parent.firstLogString = "First = 2";
            ready = true;
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            parent.firstLogString = "First = 3";
            ready = true;
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            parent.firstLogString = "First = 4";
            ready = true;
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            parent.firstLogString = "First = 5";
            ready = true;
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
        }




        private void window_PointerMoved(object sender, KinectPointerEventArgs e)
        {
            var uriSource = new Uri(@"/TheBooth;component/Images/female_hero.png", UriKind.Relative);

          

            if ((!BodyFramePreAnalysis.rightHandUp && e.CurrentPoint.Properties.HandType == HandType.LEFT) ||
              (BodyFramePreAnalysis.rightHandUp && e.CurrentPoint.Properties.HandType == HandType.RIGHT))
            {
                if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button1) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button1) + button1.Width
               && e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button1) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button1) + button1.Height)
                {
                    button1.Width = 108;
                    button1.Height = 112;
                    button1Img.Width = 108;
                    button1Img.Height = 112;
                  //  uriSource = new Uri(@"/TheBooth;component/Images/Feel1a.png", UriKind.Relative);
                  //  button1Img.Source = new BitmapImage(uriSource);
                }
                else
                {
                    button1.Width = 98;
                    button1.Height = 102;
                    button1Img.Width = 98;
                    button1Img.Height = 102;
                //    uriSource = new Uri(@"/TheBooth;component/Images/Feel1.png", UriKind.Relative);
                //    button1Img.Source = new BitmapImage(uriSource);
                }

                if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button2) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button2) + button2.Width
                    && e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button2) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button2) + button2.Height)
                {
                    button2.Width = 108;
                    button2.Height = 112;
                    button2Img.Width = 108;
                    button2Img.Height = 112;
                    //uriSource = new Uri(@"/TheBooth;component/Images/Feel2a.png", UriKind.Relative);
                    //button2Img.Source = new BitmapImage(uriSource);
                }
                else
                {
                    button2.Width = 98;
                    button2.Height = 102;
                    button2Img.Width = 98;
                    button2Img.Height = 102;
                    //uriSource = new Uri(@"/TheBooth;component/Images/Feel2.png", UriKind.Relative);
                    //button2Img.Source = new BitmapImage(uriSource);
                }

                if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button3) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button3) + button2.Width
                    && e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button3) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button3) + button2.Height)
                {
                    button3.Width = 108;
                    button3.Height = 112;
                    button3Img.Width = 108;
                    button3Img.Height = 112;
                    //uriSource = new Uri(@"/TheBooth;component/Images/Feel3a.png", UriKind.Relative);
                    //button3Img.Source = new BitmapImage(uriSource);
                }
                else
                {
                    button3.Width = 98;
                    button3.Height = 102;
                    button3Img.Width = 98;
                    button3Img.Height = 102;
                    //uriSource = new Uri(@"/TheBooth;component/Images/Feel3.png", UriKind.Relative);
                    //button3Img.Source = new BitmapImage(uriSource);
                }

                if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button4) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button4) + button2.Width
                    && e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button4) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button4) + button2.Height)
                {
                    button4.Width = 108;
                    button4.Height = 112;
                    button4Img.Width = 108;
                    button4Img.Height = 112;
                    //uriSource = new Uri(@"/TheBooth;component/Images/Feel4a.png", UriKind.Relative);
                    //button4Img.Source = new BitmapImage(uriSource);
                }
                else
                {
                    button4.Width = 98;
                    button4.Height = 102;
                    button4Img.Width = 98;
                    button4Img.Height = 102;
                    //uriSource = new Uri(@"/TheBooth;component/Images/Feel4.png", UriKind.Relative);
                    //button4Img.Source = new BitmapImage(uriSource);
                }

                if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button5) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button5) + button2.Width
                    && e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button5) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button5) + button2.Height)
                {
                    button5.Width = 150;
                    button5.Height = 112;
                    button5Img.Width = 150;
                    button1Img.Height = 112;
                    //uriSource = new Uri(@"/TheBooth;component/Images/feel5a.png", UriKind.Relative);
                    //button5Img.Source = new BitmapImage(uriSource);
                }
                else
                {
                    button5.Width = 140;
                    button5.Height = 102;
                    button5Img.Width = 140;
                    button5Img.Height = 102;
                    //uriSource = new Uri(@"/TheBooth;component/Images/feel5.png", UriKind.Relative);
                    //button5Img.Source = new BitmapImage(uriSource);
                }

            }



        }


    }
}
