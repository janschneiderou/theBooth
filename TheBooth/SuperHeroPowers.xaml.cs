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
    /// Interaction logic for SuperHeroPowers.xaml
    /// </summary>
    public partial class SuperHeroPowers : UserControl
    {

        public static bool CONFIDENCE = false;
        public static bool WILLPOWER = false;
        public static bool INTELLIGENCE = false;
        public static bool CREATIVITY = false;
        public static bool EMPHATY = false;
        public static bool CONCENTRATION = false;
        public static bool PRESENCE = false;
        public static bool CHARISMA = false;
        public static bool MEMORY = false;
        public static bool ASSERTIVENESS = false;

        //public static bool selectionCONFIDENCE = false;
        //public static bool selectionWILLPOWER = false;
        //public static bool selectionINTELLIGENCE = false;
        //public static bool selectionCREATIVITY = false;
        //public static bool selectionEMPHATY = false;
        //public static bool selectionCONCENTRATION = false;
        //public static bool selectionPRESENCE = false;
        //public static bool selectionCHARISMA = false;
        //public static bool selectionMEMORY = false;
        //public static bool selectionASSERTIVENESS = false;

        public delegate void SelectionEvent(object sender);
        public event SelectionEvent nextEvent;

        public KinectCoreWindow window;

        public SuperHeroPowers()
        {
            InitializeComponent();
         
            setTexts();
            
        }
        public void loadSuperPowers()
        {
            this.Visibility = Visibility.Visible;
            window = KinectCoreWindow.GetForCurrentThread();
            window.PointerMoved += window_PointerMoved;
            kinectRegion.Height = 800;
            kinectRegion.Width = 1200;
        }

        public void resetbooleans()
        {
            HeroAnalysis.nextCommand = false;
            CONFIDENCE = false;
            WILLPOWER = false;
            INTELLIGENCE = false;
            CREATIVITY = false;
            EMPHATY = false;
            CONCENTRATION = false;
            PRESENCE = false;
            CHARISMA = false;
            MEMORY = false;
            ASSERTIVENESS = false;
        }

        private void window_PointerMoved(object sender, KinectPointerEventArgs e)
        {
            try
            {
                if(this.Visibility==Visibility.Visible)
                {

               
                var uriSource = new Uri(@"/TheBooth;component/Images/Button_start.png", UriKind.Relative);

                if ((!BodyFramePreAnalysis.rightHandUp && e.CurrentPoint.Properties.HandType == HandType.LEFT) ||
                 (BodyFramePreAnalysis.rightHandUp && e.CurrentPoint.Properties.HandType == HandType.RIGHT))
                {
                    if (e.CurrentPoint.Position.X * this.ActualWidth > Canvas.GetLeft(nextButton) && e.CurrentPoint.Position.X * this.ActualWidth < Canvas.GetLeft(nextButton) + nextButton.Width
                   && e.CurrentPoint.Position.Y * this.ActualHeight > Canvas.GetTop(nextButton) && e.CurrentPoint.Position.Y * this.ActualHeight < Canvas.GetTop(nextButton) + nextButton.Height)
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
                if (nextButton.Visibility == Visibility.Visible && this.Visibility == System.Windows.Visibility.Visible)
                {
                    if (HeroAnalysis.nextCommand == true)
                    {
                        Button_Click(null, null);
                    }
                }
                else if (this.Visibility == Visibility.Visible)
                {
                    HeroAnalysis.nextCommand = false;
                }
                }
            }
            catch
            {

            }
            
        }
        

        private void setTexts()
        {
           drop1.setText("Super", "Confidence");
            drop2.setText("Super", "Willpower");
            drop3.setText("Super", "Intelligence");
            drop4.setText("Super", "Creativity");
            drop5.setText("Super", "Empathy");
            drop6.setText("Super", "Concentration");
            drop7.setText("Super", "Presence");
            drop8.setText("Super", "Charisma");
            drop9.setText("Super", "Memory");
            drop10.setText("Super", "Assertiveness");
       
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HeroAnalysis.nextCommand = false;
            window.PointerMoved -= window_PointerMoved;
            nextEvent(this);
            this.Visibility = Visibility.Collapsed;

        }
    }
}
