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
    /// Interaction logic for superHeroExit.xaml
    /// </summary>
    public partial class superHeroExit : UserControl
    {
        public MainWindow parent;
        public KinectCoreWindow window;

        public delegate void ExitButton(object sender);
        public  event ExitButton exitButton;


        public bool questionnaireVisibility = false;

        public superHeroExit()
        {
            InitializeComponent();
          
            
        }


        public void loadExit()
        {
            this.Visibility = Visibility.Visible;
           window = KinectCoreWindow.GetForCurrentThread();
           window.PointerMoved += window_PointerMoved;
            kinectRegion.Height = 800;
            kinectRegion.Width = 1200;
            hideQuestionnaire();
            HeroAnalysis.nextCommand = false;
        }




        private void window_PointerMoved(object sender, KinectPointerEventArgs e)
        {
            if (questionnaireVisibility == false)
            {
                hideQuestionnaire();
            }
            try
            {
                if (this.Visibility == Visibility.Visible)
                {
                    var uriSource = new Uri(@"/TheBooth;component/Images/Button_start.png", UriKind.Relative);

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
                        //  if (e.CurrentPoint.Position.X * this.ActualWidth > Canvas.GetLeft(nextButton) && e.CurrentPoint.Position.X * this.ActualWidth < Canvas.GetLeft(nextButton) + nextButton.Width
                        // && e.CurrentPoint.Position.Y * this.ActualHeight > Canvas.GetTop(nextButton) && e.CurrentPoint.Position.Y * this.ActualHeight < Canvas.GetTop(nextButton) + nextButton.Height)
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/Button_next_hover.png", UriKind.Relative);
                        //      imgButton.Source = new BitmapImage(uriSource);
                        //  }
                        //  else
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/Button_next.png", UriKind.Relative);
                        //      imgButton.Source = new BitmapImage(uriSource);
                        //  }

                        //  if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button1) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button1) + button1.Width
                        //&& e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button1) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button1) + button1.Height)
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/Feel1a.png", UriKind.Relative);
                        //      button1Img.Source = new BitmapImage(uriSource);
                        //  }
                        //  else
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/Feel1.png", UriKind.Relative);
                        //      button1Img.Source = new BitmapImage(uriSource);
                        //  }

                        //  if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button2) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button2) + button2.Width
                        //      && e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button2) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button2) + button2.Height)
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/Feel2a.png", UriKind.Relative);
                        //      button2Img.Source = new BitmapImage(uriSource);
                        //  }
                        //  else
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/Feel2.png", UriKind.Relative);
                        //      button2Img.Source = new BitmapImage(uriSource);
                        //  }

                        //  if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button3) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button3) + button2.Width
                        //      && e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button3) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button3) + button2.Height)
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/Feel3a.png", UriKind.Relative);
                        //      button3Img.Source = new BitmapImage(uriSource);
                        //  }
                        //  else
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/Feel3.png", UriKind.Relative);
                        //      button3Img.Source = new BitmapImage(uriSource);
                        //  }

                        //  if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button4) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button4) + button2.Width
                        //      && e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button4) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button4) + button2.Height)
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/Feel4a.png", UriKind.Relative);
                        //      button4Img.Source = new BitmapImage(uriSource);
                        //  }
                        //  else
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/Feel4.png", UriKind.Relative);
                        //      button4Img.Source = new BitmapImage(uriSource);
                        //  }

                        //  if (e.CurrentPoint.Position.X * this.Width > Canvas.GetLeft(button5) && e.CurrentPoint.Position.X * this.Width < Canvas.GetLeft(button5) + button2.Width
                        //      && e.CurrentPoint.Position.Y * this.Height > Canvas.GetTop(button5) && e.CurrentPoint.Position.Y * this.Height < Canvas.GetTop(button5) + button2.Height)
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/feel5a.png", UriKind.Relative);
                        //      button5Img.Source = new BitmapImage(uriSource);
                        //  }
                        //  else
                        //  {
                        //      uriSource = new Uri(@"/TheBooth;component/Images/feel5.png", UriKind.Relative);
                        //      button5Img.Source = new BitmapImage(uriSource);
                        //  }


                    }
                    if (HeroAnalysis.nextCommand == true && nextButton.Visibility == Visibility.Visible)
                    {
                        exitButton(this);
                    }
                }

            }
           catch
            {

            }

        }


        private void hideQuestionnaire()
        {
           // parent.firstLogString = parent.firstLogString + " Second = 1";

            sensei.Visibility = System.Windows.Visibility.Collapsed;
            bubble.Visibility = System.Windows.Visibility.Collapsed;
            button1.Visibility = System.Windows.Visibility.Collapsed;
            button2.Visibility = System.Windows.Visibility.Collapsed;
            button3.Visibility = System.Windows.Visibility.Collapsed;
            button4.Visibility = System.Windows.Visibility.Collapsed;
            button5.Visibility = System.Windows.Visibility.Collapsed;

            label1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;

            quoteLabel.Visibility = Visibility.Visible;
            quote.Visibility = Visibility.Visible;
            nextButton.Visibility = Visibility.Visible;

            
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            parent.firstLogString = parent.firstLogString + " Second = 1";

            sensei.Visibility = System.Windows.Visibility.Collapsed;
            bubble.Visibility = System.Windows.Visibility.Collapsed;
            button1.Visibility = System.Windows.Visibility.Collapsed;
            button2.Visibility = System.Windows.Visibility.Collapsed;
            button3.Visibility = System.Windows.Visibility.Collapsed;
            button4.Visibility = System.Windows.Visibility.Collapsed;
            button5.Visibility = System.Windows.Visibility.Collapsed;

            label1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;

            quoteLabel.Visibility = Visibility.Visible;
            quote.Visibility = Visibility.Visible;
            nextButton.Visibility = Visibility.Visible;

            parent.soundeffect.Stop();
            parent.soundeffect.Play();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            parent.firstLogString = parent.firstLogString + " Second = 2";

            sensei.Visibility = System.Windows.Visibility.Collapsed;
            bubble.Visibility = System.Windows.Visibility.Collapsed;
            button1.Visibility = System.Windows.Visibility.Collapsed;
            button2.Visibility = System.Windows.Visibility.Collapsed;
            button3.Visibility = System.Windows.Visibility.Collapsed;
            button4.Visibility = System.Windows.Visibility.Collapsed;
            button5.Visibility = System.Windows.Visibility.Collapsed;

            label1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;

            quoteLabel.Visibility = Visibility.Visible;
            quote.Visibility = Visibility.Visible;
            nextButton.Visibility = Visibility.Visible;

            parent.soundeffect.Stop();
            parent.soundeffect.Play();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            parent.firstLogString = parent.firstLogString + " Second = 3";

            sensei.Visibility = System.Windows.Visibility.Collapsed;
            bubble.Visibility = System.Windows.Visibility.Collapsed;
            button1.Visibility = System.Windows.Visibility.Collapsed;
            button2.Visibility = System.Windows.Visibility.Collapsed;
            button3.Visibility = System.Windows.Visibility.Collapsed;
            button4.Visibility = System.Windows.Visibility.Collapsed;
            button5.Visibility = System.Windows.Visibility.Collapsed;

            label1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;

            quoteLabel.Visibility = Visibility.Visible;
            quote.Visibility = Visibility.Visible;
            nextButton.Visibility = Visibility.Visible;

            parent.soundeffect.Stop();
            parent.soundeffect.Play();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            parent.firstLogString = parent.firstLogString + " Second = 4";

            sensei.Visibility = System.Windows.Visibility.Collapsed;
            bubble.Visibility = System.Windows.Visibility.Collapsed;
            button1.Visibility = System.Windows.Visibility.Collapsed;
            button2.Visibility = System.Windows.Visibility.Collapsed;
            button3.Visibility = System.Windows.Visibility.Collapsed;
            button4.Visibility = System.Windows.Visibility.Collapsed;
            button5.Visibility = System.Windows.Visibility.Collapsed;

            label1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;
            quoteLabel.Visibility = Visibility.Visible;
            quote.Visibility = Visibility.Visible;
            nextButton.Visibility = Visibility.Visible;

            parent.soundeffect.Stop();
            parent.soundeffect.Play();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            parent.firstLogString = parent.firstLogString + " Second = 5";

            sensei.Visibility = System.Windows.Visibility.Collapsed;
            bubble.Visibility = System.Windows.Visibility.Collapsed;
            button1.Visibility = System.Windows.Visibility.Collapsed;
            button2.Visibility = System.Windows.Visibility.Collapsed;
            button3.Visibility = System.Windows.Visibility.Collapsed;
            button4.Visibility = System.Windows.Visibility.Collapsed;
            button5.Visibility = System.Windows.Visibility.Collapsed;

            label1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;
            quoteLabel.Visibility = Visibility.Visible;
            quote.Visibility = Visibility.Visible;
            nextButton.Visibility = Visibility.Visible;

            parent.soundeffect.Stop();
            parent.soundeffect.Play();
        }





        //public void loaded()
        //{
        //    //ready = false;
        //    this.Width = 1200;
        //    this.Height = 800;

        //    if (parent.bodyFrameHandler.bodyFrameReader != null)
        //    {
        //        parent.bodyFrameHandler.bodyFrameReader.FrameArrived += this.Reader_FrameArrived;

        //    }
        //    if (parent.faceFrameHandler.bodyFrameReader != null)
        //    {
        //        // wire handler for body frame arrival
        //        parent.faceFrameHandler.bodyFrameReader.FrameArrived += this.Reader_BodyFrameArrived;

        //        for (int i = 0; i < parent.faceFrameHandler.bodyCount; i++)
        //        {
        //            if (parent.faceFrameHandler.faceFrameReaders[i] != null)
        //            {
        //                // wire handler for face frame arrival
        //              //  parent.faceFrameHandler.faceFrameReaders[i].FrameArrived += Reader_FaceFrameArrived;
        //                //break;
        //            }
        //        }
        //    }


        //}

        //private void Reader_BodyFrameArrived(object sender, Microsoft.Kinect.BodyFrameArrivedEventArgs e)
        //{
        //    parent.faceFrameHandler.Reader_BodyFrameArrived(sender, e);
        //}

        //private void Reader_FrameArrived(object sender, Microsoft.Kinect.BodyFrameArrivedEventArgs e)
        //{
        //    parent.bodyFrameHandler.Reader_FrameArrived(sender, e);
        //}

    }


}
