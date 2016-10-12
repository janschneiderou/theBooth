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

using System.Drawing.Imaging;
using System.Drawing;
using System.IO;


namespace TheBooth
{
    /// <summary>
    /// Interaction logic for SuperHeroAffirmation.xaml
    /// </summary>
    /// 

    public partial class SuperHeroAffirmation : UserControl
    {

        int lessonNumber = 1;
        public delegate void NextEvent(object sender, int x);
        public event NextEvent nextEvent;
        public  string selections;
        public string inspiringValue;
        public static string impacts;
        public static string superPowerSelection;
        public Uri characterUrisource;
        public bool loaded=true;
        public KinectCoreWindow window;
        bool played = false;
        int counter = 0;

        public SuperHeroAffirmation()
        {


            InitializeComponent();
           // setStrings(1);
            
            
        }
        public void loadAffirmation()
        {
            this.Visibility = Visibility.Visible;
            window = KinectCoreWindow.GetForCurrentThread();
            window.PointerMoved += window_PointerMoved;
            loaded=false;
        }

        private void window_PointerMoved(object sender, KinectPointerEventArgs e)
        {
            try
            {
                var uriSource = new Uri(@"/TheBooth;component/Images/Button_start.png", UriKind.Relative);

                if (this.Visibility == Visibility.Visible)
                {

                    if ((!BodyFramePreAnalysis.rightHandUp && e.CurrentPoint.Properties.HandType == HandType.LEFT) ||
                     (BodyFramePreAnalysis.rightHandUp && e.CurrentPoint.Properties.HandType == HandType.RIGHT))
                    {
                        if (e.CurrentPoint.Position.X * this.ActualWidth > button1.Margin.Left && e.CurrentPoint.Position.X * this.ActualWidth < button1.Margin.Left + button1.Width
                       && e.CurrentPoint.Position.Y * this.ActualHeight > button1.Margin.Top && e.CurrentPoint.Position.Y * this.ActualHeight < button1.Margin.Top + button1.Height)
                        {
                            uriSource = new Uri(@"/TheBooth;component/Images/Button_next_hover.png", UriKind.Relative);
                            imgButton.Source = new BitmapImage(uriSource);
                        }
                        else
                        {
                            uriSource = new Uri(@"/TheBooth;component/Images/Button_next.png", UriKind.Relative);
                            imgButton.Source = new BitmapImage(uriSource);
                        }

                    }
                    if (HeroAnalysis.nextCommand == true && this.Visibility == System.Windows.Visibility.Visible)
                    {
                        Button_Click(null, null);

                    }

                    if (this.Visibility == Visibility.Visible && loaded == false)
                    {
                        loaded = true;
                        playsounds();
                    }
                }
            }
            catch
            {
            }
                    }

        private void playsounds()
        {
            switch (lessonNumber)
            {
                case 1:
                    if(played==false)
                    {
                        AffirmationDescription1.Stop();
                        AffirmationDescription1.Play();
                        played = true;
                    }
                     loaded = true;
                    break;
                case 2:
                    AffirmationDescription2.MediaEnded += lessonNumberAudio2_MediaEnded;
                     AffirmationDescription2.Stop();
                     AffirmationDescription2.Play();
                     counter = 0;
                    break;
                case 3:
                case 4:
                    AffirmationDescription3a.MediaEnded += lessonInspiration1_MediaEnded;
                    AffirmationDescription3a.Stop();
                    AffirmationDescription3a.Play();
                    break;
                case 6:
                    saveImage();
                    AffirmationDescription4a.MediaEnded += lessonWorld1_MediaEnded;
                    AffirmationDescription4a.Stop();
                    AffirmationDescription4a.Play();
                    break;
            }
        }

        #region world

        private void lessonWorld1_MediaEnded(object sender, RoutedEventArgs e)
        {
            SuperSound.MediaEnded += superWorldEnded1;
            SuperSound.Stop();
            SuperSound.Play();
        }

        private void superWorldEnded1(object sender, RoutedEventArgs e)
        {
            SuperSound.MediaEnded -= superWorldEnded1;
            SelectionPowers1.MediaEnded += lessonNumberWorld2_MediaEnded;
            SelectionPowers1.Stop();
            SelectionPowers1.Play();
        }

        private void lessonNumberWorld2_MediaEnded(object sender, RoutedEventArgs e)
        {
            SelectionPowers1.MediaEnded -= lessonNumberWorld2_MediaEnded;
            SuperSound.MediaEnded += superWorldEnded2;
            SuperSound.Stop();
            SuperSound.Play();
        }

        private void superWorldEnded2(object sender, RoutedEventArgs e)
        {
            SuperSound.MediaEnded -= superWorldEnded2;
            SelectionPowers2.MediaEnded += lessonNumberWorld3_MediaEnded;
            SelectionPowers2.Stop();
            SelectionPowers2.Play();
        }

        private void lessonNumberWorld3_MediaEnded(object sender, RoutedEventArgs e)
        {
            SelectionPowers1.MediaEnded -= lessonNumberWorld3_MediaEnded;
            SuperSound.MediaEnded += superWorldEnded3;
            SuperSound.Stop();
            SuperSound.Play();
        }

        private void superWorldEnded3(object sender, RoutedEventArgs e)
        {
            SuperSound.MediaEnded -= superWorldEnded3;
            SelectionPowers3.MediaEnded += lessonNumberWorld4_MediaEnded;
            SelectionPowers3.Stop();
            SelectionPowers3.Play();
        }

        private void lessonNumberWorld4_MediaEnded(object sender, RoutedEventArgs e)
        {
            AffirmationDescription4b.MediaEnded += lessonWorld5_MediaEnded;
            AffirmationDescription4b.Stop();
            AffirmationDescription4b.Play();
        }

        private void lessonWorld5_MediaEnded(object sender, RoutedEventArgs e)
        {
            SelectionWorld1.MediaEnded += lessonNumberWorld5_MediaEnded;
            SelectionWorld1.Stop();
            SelectionWorld1.Play();
        }

        private void lessonNumberWorld5_MediaEnded(object sender, RoutedEventArgs e)
        {
            SelectionWorld2.MediaEnded += lessonNumberWorld6_MediaEnded;
            SelectionWorld2.Stop();
            SelectionWorld2.Play();
        }

        private void lessonNumberWorld6_MediaEnded(object sender, RoutedEventArgs e)
        {
            //SelectionWorld3.MediaEnded += lessonNumberWorld6_MediaEnded;
            SelectionWorld3.Stop();
            SelectionWorld3.Play();
        }

        #endregion

        #region inspiration

        private void lessonInspiration1_MediaEnded(object sender, RoutedEventArgs e)
        {

            switch (inspiringValue)
            {
                case "Confidence":
                    SelectionInspiration1 = SelectionConfidence;
                    break;
                case "Kindness":
                    SelectionInspiration1 = SelectionKindness;
                    break;
                case "Friendliness":
                    SelectionInspiration1 = SelectionFriendliness;
                    break;
                case "Fun":
                    SelectionInspiration1 = SelectionFun;
                    break;
                case "Discipline":
                    SelectionInspiration1 = SelectionDiscipline;
                    break;
                case "Courage":
                    SelectionInspiration1 = SelectionCourage;
                    break;
                case "Creativity":
                    SelectionInspiration1 = SelectionCreativity;
                    break;
                case "Flexibility":
                    SelectionInspiration1 = SelectionAdaptability;
                    break;
                case "Charm":
                    SelectionInspiration1 = SelectionCharm;
                    break;
                case "Brightness":
                    SelectionInspiration1 = SelectionBrightness;
                    break;
                case "Honesty":
                    SelectionInspiration1 = SelectionHonesty;
                    break;
                case "Wittiness":
                    SelectionInspiration1 = SelectionWittiness;
                    break;
                case "Reliability":
                    SelectionInspiration1 = SelectionReliability;
                    break;
                case "Modesty":
                    SelectionInspiration1 = SelectionModesty;
                    break;
                case "Loyalty":
                    SelectionInspiration1 = SelectionLoyalty;
                    break;

            }
            SelectionInspiration1.MediaEnded += lessonInspiration1_MediaEnded2;
            SelectionInspiration1.Stop();
            SelectionInspiration1.Play();
        }

        private void lessonInspiration1_MediaEnded2(object sender, RoutedEventArgs e)
        {
            SelectionInspiration1.MediaEnded -= lessonInspiration1_MediaEnded2;
            AffirmationDescription3b.Stop();
            AffirmationDescription3b.Play();
        }

        #endregion


        #region superpowers

        private void lessonNumberAudio2_MediaEnded(object sender, RoutedEventArgs e)
        {
            
            SuperSound.MediaEnded  +=  superEnded1;
            SuperSound.Stop();
            SuperSound.Play();
            
            
        }

        private void superEnded1(object sender, RoutedEventArgs e)
        {
            SelectionPowers1.MediaEnded += lessonNumberSuper2_MediaEnded;
            SelectionPowers1.Stop();
            SelectionPowers1.Play();
            //switch (counter)
            //{
                
            //    case 1:
            //        SelectionPowers2.MediaEnded += lessonNumberAudio2_MediaEnded;
            //        SelectionPowers2.Stop();
            //        SelectionPowers2.Play();
                    
            //        break;
            //    case 2:
            //        SelectionPowers3.MediaEnded += SuperPowerSelection3_MediaEnded;
            //        SelectionPowers3.Stop();
            //        SelectionPowers3.Play();
                    
            //        break;
            //}
            //counter++;
        }

        private void lessonNumberSuper2_MediaEnded(object sender, RoutedEventArgs e)
        {
            SuperSound.MediaEnded -= superEnded1;
            SelectionPowers1.MediaEnded -= lessonNumberSuper2_MediaEnded;
            SuperSound.MediaEnded += superEnded2;
            SuperSound.Stop();
            SuperSound.Play();
        }

        private void superEnded2(object sender, RoutedEventArgs e)
        {
            SelectionPowers2.MediaEnded += lessonNumberSuper3_MediaEnded;
            SelectionPowers2.Stop();
            SelectionPowers2.Play();
        }

        private void lessonNumberSuper3_MediaEnded(object sender, RoutedEventArgs e)
        {
            SuperSound.MediaEnded -= superEnded2;
            SelectionPowers2.MediaEnded -= lessonNumberSuper3_MediaEnded;
            SuperSound.MediaEnded += superEnded3;
            SuperSound.Stop();
            SuperSound.Play();
        }

        private void superEnded3(object sender, RoutedEventArgs e)
        {
            SelectionPowers3.MediaEnded += SuperPowerSelection3_MediaEnded;
            SelectionPowers3.Stop();
            SelectionPowers3.Play();
                    
        }

        private void SuperPowerSelection3_MediaEnded(object sender, RoutedEventArgs e)
        {
            SuperSound.MediaEnded -= superEnded3;
            SelectionPowers3.MediaEnded -= SuperPowerSelection3_MediaEnded;
        }


        #endregion

       


         public void setStrings(int lesson)
        {
            lessonNumber = lesson;
            setgridsInvisible();
            HeroAnalysis.nextCommand = false;
            switch(lesson)
            {
                case 1:
                    superPosture.Visibility = System.Windows.Visibility.Visible;
                    postureCharacter.Source =  new BitmapImage( MainWindow.characterUri );
                    postureImage.Source = MainWindow.heroSource;
                   // saveImage();
                    break;
                case 2:
                    superPowers.Visibility = Visibility.Visible;
                    LabelLessonNumberPowers.Content = "2";
                    LabelLessonNamePowers.Content = "\"Super Powers\"";
                    LabelLessonExplanationPowers.Content =  selections;
                    SuperHeroAffirmation.superPowerSelection = selections;
                    powerCharacter.Source =  new BitmapImage( MainWindow.characterUri );
                    powerImage.Source = MainWindow.heroSource;
                    break;
                case 3:
                    superInspiration.Visibility = System.Windows.Visibility.Visible;
                    LabelLessonNumberInspiration.Content = "3";
                    LabelLessonNameInspiration.Content = "\"Inspiration\"";
                    LabelLessonExplanationInspiration.Content = "How can you welcome more  " + inspiringValue + ": \nto your daily life?";
                    break;
                case 4:
                    superInspiration.Visibility = System.Windows.Visibility.Visible;
                    LabelLessonNumberInspiration.Content = "3";
                    LabelLessonNameInspiration.Content = "\"Inspiration\"";
                    LabelLessonExplanationInspiration.Content = "How can you welcome  more " + inspiringValue + " \nto your daily life?";
                    break;
                case 5:
                    superImpact.Visibility = Visibility.Visible;
                    LabelLessonNumberImpact.Content = "4";
                    LabelLessonImpactPowers.Content = SuperHeroAffirmation.superPowerSelection;
                    LabelLessonImpactSelection.Content = selections;
                    SuperHeroAffirmation.impacts = selections;
                    postureImpactCharacter.Source = new BitmapImage(MainWindow.characterUri);
                    postureImpactImage.Source = MainWindow.heroSource;
                    
                    break;
                case 6:
                    superImpact.Visibility = Visibility.Visible;
                    LabelLessonNumberImpact.Content = "4";

                    LabelLessonImpactPowers.Content = SuperHeroAffirmation.superPowerSelection;
                   LabelLessonImpactSelection.Content = selections;
                   SuperHeroAffirmation.impacts = selections;
                    postureImpactCharacter.Source = new BitmapImage(MainWindow.characterUri);
                    postureImpactImage.Source = MainWindow.heroSource;
                   
                    break;
                case 7:
                    superCelebration.Visibility = System.Windows.Visibility.Visible;
                    LabelLessonNumberCelebration.Content = "5";
                    LabelLessonNameCelebration.Content = "\"Celebration\"";
                    LabelLessonExplanationImpact.Content = "Don't fake it till you make it,\nfake it til you become it.";
                    break;
            }
        }


        private void saveImage()
        {
            save2();

            //string fileName = "sample.jpg";
            //System.Drawing.Rectangle rect = new System.Drawing.Rectangle((int)(Canvas.GetLeft(postureImpactImage) + Canvas.GetLeft(this)), (int)( Canvas.GetTop(postureImpactImage)+ Canvas.GetTop(this)), 280, 370);
            //Bitmap bmp = new Bitmap(1650, 825, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            //Graphics g = Graphics.FromImage(bmp);
            ////int a = (int)(Canvas.GetLeft(postureImpactImage) + Canvas.GetLeft(this));
            ////int b = (int)(Canvas.GetTop(postureImpactImage) + Canvas.GetTop(this));

            //int a = 530;
            //int b = 310;
            ////g.CopyFromScreen()
            //g.CopyFromScreen(a, b, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            //bmp.Save(fileName, ImageFormat.Jpeg); 
        }

        public void save2()
        {
            double scale = 1;

            double actualHeight = source.RenderSize.Height;
            double actualWidth = source.RenderSize.Width;

            double renderHeight = actualHeight * scale;
            double renderWidth = actualWidth * scale;

            RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96, 96, PixelFormats.Pbgra32);
            VisualBrush sourceBrush = new VisualBrush(source);

            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            using (drawingContext)
            {
                drawingContext.PushTransform(new ScaleTransform(scale, scale));
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new System.Windows.Point(0, 0), new System.Windows.Point(actualWidth, actualHeight)));
            }
            renderTarget.Render(drawingVisual);

            JpegBitmapEncoder jpgEncoder = new JpegBitmapEncoder();
            jpgEncoder.QualityLevel = 80;
            jpgEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

           

            

            using (System.IO.MemoryStream outputStream = new System.IO.MemoryStream())
            {
                jpgEncoder.Save(outputStream);

                FileStream file = new FileStream("sample.jpg", FileMode.Create, FileAccess.Write);
                outputStream.WriteTo(file);
                file.Close();
                outputStream.Close();
            }
        }

        private void setgridsInvisible ()
         {
             superCelebration.Visibility = System.Windows.Visibility.Collapsed;
             superPosture.Visibility = System.Windows.Visibility.Collapsed;
             superPowers.Visibility = Visibility.Collapsed;
             superImpact.Visibility = Visibility.Collapsed;
             superInspiration.Visibility = System.Windows.Visibility.Collapsed;
         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HeroAnalysis.nextCommand = false;
            nextEvent(this, lessonNumber);
            window.PointerMoved -= window_PointerMoved;
            this.Visibility = Visibility.Collapsed;
            
        }
    }
  
}
