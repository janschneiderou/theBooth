using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TheBooth
{
    public class HeroAnalysis
    {
        public MainWindow parent;

        public static double targetLeft1;
        public static double targetLeft2;
        public static double targetTop1;
        public static double targetTop2;
        public static bool nextCommand =false;
        public static bool startCommand = false;

        public bool startCelebration = false;
        public bool finishCelebration = false;
        public bool firstCelebration = false;
        public bool secondCelebration = false;
        public double celebrationStarted;
        public double celebrationContinued;
        public double endCelebration;
        public double timeToMoveCelebration=3000;

        public double counterSmile;
        public double counterLegs;
        public double counterNeck;
        public double counterBack;
        public double timeForAction = 5000;
        public int currentDrop = 0;

        public static bool selectionCONFIDENCE = false;
        public static bool selectionWILLPOWER = false;
        public static bool selectionINTELLIGENCE = false;
        public static bool selectionCREATIVITY = false;
        public static bool selectionEMPHATY = false;
        public static bool selectionCONCENTRATION = false;
        public static bool selectionPRESENCE = false;
        public static bool selectionCHARISMA = false;
        public static bool selectionMEMORY = false;
        public static bool selectionASSERTIVENESS = false;

        public static bool selectionJUSTICE = false;
        public static bool selectionCLARITY = false;
        public static bool selectionPASSION = false;
        public static bool selectionUNDERSTANDING = false;
        public static bool selectionLOVE = false;
        public static bool selectionPEACE = false;
        public static bool selectionRESPECT = false;
        public static bool selectionACCEPTANCE = false;
        public static bool selectionJOY = false;
        public static bool selectionKINDNESS = false;

        string stringPowerSelection = "Select 3 Super powers that you identify with.";
        string stringPostureTeaching = "Lets learn the Super Hero Posture.";
        string stringInspiration2 = "Select 3 values that you find inspiring in others";
        string stringInspiration1 = "Select a personality trait that you find inspiring";
        string stringImpact = "Select 3 values that as Super Hero you'll bring to the world?";
        string stringSavingTown = "Select 3 values that as Super Hero you'll bring to the world?";
        string stringCelebration = "Celebrate as a hero!";
        string stringCorrectPosture = "Go back to your Super Hero Posture";

        public enum States { Start, PostureTeaching, PowerSelection, Inspiration1, Inspiration2, Impact, SavingTown, Celebration,Finish, Pause, ValueSelection };
        public States myState;
        public BodyFramePreAnalysis bfpa;
        public FaceFramePreAnalisys ffpa;

        public HeroAnalysis(MainWindow parent)
        {
            this.parent = parent;
            myState = States.Start;
            
        }

        public void loadStuff()
        {
            parent.heroMode.countdown.countdownFinished += countdown_countdownFinished;
          //  parent.heroMode.values.selectionEvent += values_selectionEvent;
            parent.heroMode.HeroLesson.nextEvent += HeroLesson_nextEvent;
            parent.heroMode.HeroAffirmation.nextEvent += HeroAffirmation_nextEvent;
            parent.heroMode.heroPower.nextEvent += heroPower_nextEvent;
            parent.heroMode.inspiration1.selectionEvent += inspiration1_selectionEvent;
            parent.heroMode.heroInspiration2.nextEvent += heroInspiration2_nextEvent;
            parent.heroMode.heroImpact.nextEvent += heroImpact_nextEvent;
            parent.heroMode.heroCelebration.nextEvent += heroCelebration_nextEvent;
            
            
        }

        void heroCelebration_nextEvent(object sender)
        {
            myState = States.Pause;
            parent.heroMode.heroCelebration.nextButton.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.heroExit.Visibility = System.Windows.Visibility.Visible;
            parent.heroMode.myCanvas.Children.Add(parent.heroMode.heroExit);

            parent.heroMode.heroExit.loadExit();
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
            
        }

        void heroImpact_nextEvent(object sender)
        {
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
            myState = States.Pause;
            parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.HeroAffirmation.setStrings(6); //should be 5
            parent.heroMode.HeroAffirmation.Visibility = System.Windows.Visibility.Visible;
            parent.heroMode.heroImpact.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;

            var uriSource = new Uri(@"/TheBooth;component/Images/background4.png", UriKind.Relative);
            parent.heroMode.backgroundImg.Source = new BitmapImage(uriSource);
        }

        void heroInspiration2_nextEvent(object sender)
        {
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
            myState = States.Pause;
            parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.HeroAffirmation.setStrings(4);
            parent.heroMode.HeroAffirmation.Visibility = System.Windows.Visibility.Visible;
            parent.heroMode.heroInspiration2.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;
        }

        void inspiration1_selectionEvent(object sender, string x)
        {
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
            myState = States.Pause;
          //  parent.heroMode.coin.Stop();
          //  parent.heroMode.coin.Play();
            parent.heroMode.HeroAffirmation.inspiringValue = x;
            parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.HeroAffirmation.setStrings(4);
            parent.heroMode.HeroAffirmation.Visibility = System.Windows.Visibility.Visible;
            parent.heroMode.inspiration1.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;

            var uriSource = new Uri(@"/TheBooth;component/Images/backgroundg.png", UriKind.Relative);
            parent.heroMode.backgroundImg.Source = new BitmapImage(uriSource);
        }

        void heroPower_nextEvent(object sender)
        {
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
         
            myState = States.Pause;
            parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.HeroAffirmation.setStrings(2);
            parent.heroMode.HeroAffirmation.Visibility = System.Windows.Visibility.Visible;
            parent.heroMode.heroPower.Visibility = System.Windows.Visibility.Collapsed;
            parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;
           // parent.heroMode.HeroAffirmation.loaded = false;
            var uriSource = new Uri(@"/TheBooth;component/Images/background3.png", UriKind.Relative);
            parent.heroMode.backgroundImg.Source = new BitmapImage(uriSource);
        }

        void HeroAffirmation_nextEvent(object sender, int x)
        {
            parent.soundeffect.Stop();
            parent.soundeffect.Play();
            parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;
            if(x<=7)
            {
                x++;
                parent.heroMode.HeroAffirmation.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.HeroLesson.setStrings(x);
                parent.heroMode.HeroLesson.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.HeroLesson.lessonDescription2.Stop();
               // parent.heroMode.HeroLesson.loaded = false;
                

                if(x==1)
                {
                    var uriSource = new Uri(@"/TheBooth;component/Images/background2.png", UriKind.Relative);
                    parent.heroMode.backgroundImg.Source = new BitmapImage(uriSource);
                }
                
                
            }
        }

        void HeroLesson_nextEvent(object sender, int x)
        {
            parent.soundeffect.Stop();
            parent.soundeffect.Play();

            parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;

            switch(x)
            {
                case 1:
                    myState = States.PostureTeaching;
                    parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Content = stringPostureTeaching;
                    
                    parent.heroMode.heroPower.resetbooleans();
                    break;
                case 2:
                    myState = States.PowerSelection;
                    currentDrop = 0;
                    parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Content = stringPowerSelection;
                    parent.heroMode.myCanvas.Children.Add(parent.heroMode.heroPower);

                    parent.heroMode.heroPower.loadSuperPowers();
                    resetBooleans();
                    targetLeft1 = 537;
                    targetLeft2 = 647;
                    targetTop1 = 250;
                    targetTop2 = 374;
                    parent.heroMode.inspiration1.resetbooleans();
                    break;
                case 3:
                    myState = States.Inspiration1;
                    parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Content = stringInspiration1;
                    parent.heroMode.myCanvas.Children.Add(parent.heroMode.inspiration1);

                    Canvas.SetLeft(parent.heroMode.inspiration1, 61);
                    Canvas.SetTop(parent.heroMode.inspiration1, 195);
                   

                    parent.heroMode.inspiration1.loadInspiration();
                    parent.heroMode.inspiration1.resetbooleans();
                    parent.heroMode.heroImpact.resetbooleans();
                    resetBooleans();
                    break;
                case 4:
                    myState = States.Inspiration2;
                    currentDrop = 0;
                    parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Content = stringInspiration2;

                    parent.heroMode.myCanvas.Children.Add(parent.heroMode.inspiration1);

                    Canvas.SetLeft(parent.heroMode.inspiration1, 61);
                    Canvas.SetTop(parent.heroMode.inspiration1, 195);
                    parent.heroMode.inspiration1.loadInspiration();
                    targetLeft1 = 537;
                    targetLeft2 = 647;
                    targetTop1 = 250;
                    targetTop2 = 374;
                    parent.heroMode.heroImpact.resetbooleans();
                    break;
                case 5:
                    myState = States.Impact;
                    currentDrop = 0;
                    parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Content = stringImpact;

                    parent.heroMode.myCanvas.Children.Add(parent.heroMode.heroImpact);
                    parent.heroMode.heroImpact.loadImpact();
                    targetLeft1 = 433;
                    targetLeft2 = 848;
                    targetTop1 = 179;
                    targetTop2 = 584;
                    parent.heroMode.heroImpact.resetbooleans();
                    resetBooleans();
                    break;
                case 6:
                    myState = States.SavingTown;
                    currentDrop = 0;
                    parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Content = stringSavingTown;
                    parent.heroMode.heroImpact.resetbooleans();
                    break;
                case 7:
                    myState = States.Celebration;
                    currentDrop = 0;
                    parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Visible;
                    parent.heroMode.instructionsLabel.Content = stringCelebration;
                    parent.heroMode.myCanvas.Children.Add(parent.heroMode.heroCelebration);

                    parent.heroMode.heroCelebration.loadCelebration();
                    parent.heroMode.claps.Stop();
                    parent.heroMode.claps.Play();
                    parent.heroMode.claps.Volume = 0.3;
                    break;
                
            }
        }

        private void resetBooleans()
        {
            selectionCONFIDENCE = false;
            selectionWILLPOWER = false;
            selectionINTELLIGENCE = false;
            selectionCREATIVITY = false;
            selectionEMPHATY = false;
            selectionCONCENTRATION = false;
            selectionPRESENCE = false;
            selectionCHARISMA = false;
            selectionMEMORY = false;
            selectionASSERTIVENESS = false;

            selectionJUSTICE = false;
            selectionCLARITY = false;
            selectionPASSION = false;
            selectionUNDERSTANDING = false;
            selectionLOVE = false;
            selectionPEACE = false;
            selectionRESPECT = false;
            selectionACCEPTANCE = false;
            selectionJOY = false;
            selectionKINDNESS = false;
        }

        private void countdown_countdownFinished(object sender)
        {
            switch(myState)
            {
                case States.PostureTeaching:
                    myState = States.ValueSelection;
                   
                    break;
            }
        }

       
        public void analyseCycle()
        {
            try
            {
               

                bfpa = parent.bodyFrameHandler.bodyFramePreAnalysis;
                ffpa = parent.faceFrameHandler.faceFramePreAnalysis;
                switch (myState)
                {
                    case States.PostureTeaching:
                        postureTeaching();
                        break;
                    case States.ValueSelection:
                    case States.PowerSelection:
                        PowerSelection();
                        break;
                    case States.Inspiration1:
                        InspirationOne();
                        break;
                    case States.Inspiration2:
                        InspirationTwo();
                        break;
                    case States.Impact:
                        Impact();
                        break;
                    case States.Celebration:
                        Celebration();
                        break;
                    
                }
            }
            catch
            {

            }
           
        }

        private void Celebration()
        {
            timeForAction = 6000;
            double currentTime = DateTime.Now.TimeOfDay.TotalMilliseconds;
            if(finishCelebration==false)
            {
            if (checkingPosture() == true)
            {

                parent.heroMode.instructionsLabel.Content = stringCelebration;
                parent.heroMode.heroCelebration.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.herofeedback.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.talkBubble.Visibility = System.Windows.Visibility.Visible;

                parent.heroMode.herofeedback.Content = "Raise Arms!";
                parent.heroMode.feedbackImage.Visibility = System.Windows.Visibility.Collapsed;

                if(bfpa.heroWinning==true)
                {
                    if(startCelebration==false)
                    {
                        parent.heroMode.music.Stop();
                        parent.heroMode.music.Play();
                        parent.heroMode.music.Volume = 0.9;
                        startCelebration = true;
                        celebrationStarted = currentTime;
                    }
                    if(currentTime-celebrationStarted>timeToMoveCelebration && firstCelebration==false)
                    {
                        parent.heroMode.heroCelebration.instructionRectangle1.Visibility = System.Windows.Visibility.Visible;
                        parent.heroMode.heroCelebration.instructionsLabel1.Visibility = System.Windows.Visibility.Visible;
                        firstCelebration = true;
                        parent.heroMode.heroCelebration.celebration1.Stop();
                        parent.heroMode.heroCelebration.celebration1.Play();
                        celebrationContinued = currentTime;
                        
                    }
                    if (currentTime - celebrationContinued > timeToMoveCelebration && firstCelebration == true && secondCelebration==false)
                    {
                        parent.heroMode.heroCelebration.instructionRectangle2.Visibility = System.Windows.Visibility.Visible;
                        parent.heroMode.heroCelebration.instructionsLabel2.Visibility = System.Windows.Visibility.Visible;
                        firstCelebration = true;
                        secondCelebration = true;
                        parent.heroMode.heroCelebration.celebration2.Stop();
                        parent.heroMode.heroCelebration.celebration2.Play();
                        endCelebration = currentTime;
                    }
                    if (currentTime - endCelebration > timeToMoveCelebration && secondCelebration == true )
                    {
                        parent.heroMode.heroCelebration.nextButton.Visibility = System.Windows.Visibility.Visible;
                        parent.heroMode.heroCelebration.nextButton.IsEnabled = true;
                        finishCelebration = true;
                    }
                    
                }

            }
            else
            {
                celebrationStarted = currentTime;
                celebrationContinued = currentTime;
                endCelebration = currentTime;
                parent.heroMode.feedbackImage.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.instructionsLabel.Content = stringCorrectPosture;
                parent.heroMode.heroCelebration.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.herofeedback.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.talkBubble.Visibility = System.Windows.Visibility.Visible;
            }
            }
           
        }

        private void Impact()
        {
            if (checkingPosture() == true)
            {

                float xHead = 0.1f;
                float factor = 345.45f;
                float displacement = 573;
                if (parent.bodyFrameHandler.bodyFramePreAnalysis.body != null)
                {
                    xHead = parent.bodyFrameHandler.bodyFramePreAnalysis.body.Joints[JointType.Head].Position.X;
                }

                Canvas.SetLeft(parent.heroMode.heroImpact.backgroundImg, factor * xHead + displacement);
                parent.heroMode.instructionsLabel.Content = stringImpact;
                parent.heroMode.heroImpact.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.herofeedback.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.talkBubble.Visibility = System.Windows.Visibility.Collapsed;
                checkWordsImpact();
                checkDropsImpact();
                
            }
            else
            {
                parent.heroMode.instructionsLabel.Content = stringCorrectPosture;
                parent.heroMode.heroImpact.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.herofeedback.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.talkBubble.Visibility = System.Windows.Visibility.Visible;
            }
        }

        

        private void InspirationTwo()
        {
            if (checkingPosture() == true)
            {

                float xHead = 0.1f;
                float factor = 345.45f;
                float displacement = 573;
                if (parent.bodyFrameHandler.bodyFramePreAnalysis.body != null)
                {
                    xHead = parent.bodyFrameHandler.bodyFramePreAnalysis.body.Joints[JointType.Head].Position.X;
                }

                Canvas.SetLeft(parent.heroMode.heroInspiration2.backgroundImg, factor * xHead + displacement);
                Canvas.SetLeft(parent.heroMode.heroInspiration2.ellipse, factor * xHead + displacement + 50);
                Canvas.SetLeft(parent.heroMode.heroInspiration2.line1, factor * xHead + displacement - 40);
                Canvas.SetLeft(parent.heroMode.heroInspiration2.line2, factor * xHead + displacement + 110);
                Canvas.SetLeft(parent.heroMode.heroInspiration2.line3, factor * xHead + displacement + 190);

                targetLeft1 = factor * xHead + displacement;
                targetLeft2 = targetLeft1 + 110;



                parent.heroMode.instructionsLabel.Content = stringInspiration2;
                parent.heroMode.heroInspiration2.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.herofeedback.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.talkBubble.Visibility = System.Windows.Visibility.Collapsed;
                checkDropsInspiration2();
            }
            else
            {
                parent.heroMode.instructionsLabel.Content = stringCorrectPosture;
                parent.heroMode.heroInspiration2.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.herofeedback.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.talkBubble.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void InspirationOne()
        {
            if (checkingPosture() == true)
            {
                parent.heroMode.instructionsLabel.Content = stringInspiration1;
                parent.heroMode.inspiration1.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.herofeedback.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.talkBubble.Visibility = System.Windows.Visibility.Collapsed;
                
            }
            else
            {
                parent.heroMode.instructionsLabel.Content = stringCorrectPosture;
                parent.heroMode.inspiration1.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.herofeedback.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.talkBubble.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void GamePlay()
        {
            

        }

       

        private void PowerSelection()
        {
            if(checkingPosture()==true)
            {

                float xHead=0.1f;
                float factor = 345.45f;
                float displacement = 573;
                if (parent.bodyFrameHandler.bodyFramePreAnalysis.body != null)
                {
                    xHead = parent.bodyFrameHandler.bodyFramePreAnalysis.body.Joints[JointType.Head].Position.X;
                }
                
                Canvas.SetLeft(parent.heroMode.heroPower.backgroundImg, factor * xHead + displacement);
                Canvas.SetLeft(parent.heroMode.heroPower.ellipse, factor * xHead + displacement+50);
                Canvas.SetLeft(parent.heroMode.heroPower.line1, factor * xHead + displacement-40);
                Canvas.SetLeft(parent.heroMode.heroPower.line2, factor * xHead + displacement+110);
                Canvas.SetLeft(parent.heroMode.heroPower.line3, factor * xHead + displacement + 190);

                targetLeft1 = factor * xHead + displacement;
                targetLeft2 = targetLeft1 + 110;

                parent.heroMode.instructionsLabel.Content = stringPowerSelection;
                parent.heroMode.heroPower.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.herofeedback.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.talkBubble.Visibility = System.Windows.Visibility.Collapsed;
                checkWords();
                checkDrops();
                
            }
            else
            {
                parent.heroMode.instructionsLabel.Content = stringCorrectPosture;
                parent.heroMode.heroPower.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroAvatar.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.herofeedback.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.talkBubble.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void checkWords()
        {
            if(SuperHeroPowers.CONFIDENCE==true )
            {
                parent.heroMode.heroPower.Element1.dropCorrecly = true;
                parent.heroMode.heroPower.Element1.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.resetbooleans();
                
            }
            if (SuperHeroPowers.WILLPOWER == true)
            {
                parent.heroMode.heroPower.Element2.dropCorrecly = true;
                parent.heroMode.heroPower.Element2.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.resetbooleans();
            }
            if (SuperHeroPowers.INTELLIGENCE == true)
            {
                parent.heroMode.heroPower.Element3.dropCorrecly = true;
                parent.heroMode.heroPower.Element3.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.resetbooleans();
            }
            if (SuperHeroPowers.CREATIVITY == true)
            {
                parent.heroMode.heroPower.Element4.dropCorrecly = true;
                parent.heroMode.heroPower.Element4.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.resetbooleans();
            }
            if (SuperHeroPowers.EMPHATY == true)
            {
                parent.heroMode.heroPower.Element5.dropCorrecly = true;
                parent.heroMode.heroPower.Element5.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.resetbooleans();
            }
            if (SuperHeroPowers.CONCENTRATION == true)
            {
                parent.heroMode.heroPower.Element6.dropCorrecly = true;
                parent.heroMode.heroPower.Element6.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.resetbooleans();
            }
            if (SuperHeroPowers.PRESENCE == true)
            {
                parent.heroMode.heroPower.Element7.dropCorrecly = true;
                parent.heroMode.heroPower.Element7.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.resetbooleans();
            }
            if (SuperHeroPowers.CHARISMA == true)
            {
                parent.heroMode.heroPower.Element8.dropCorrecly = true;
                parent.heroMode.heroPower.Element8.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.resetbooleans();
            }
            if (SuperHeroPowers.MEMORY == true)
            {
                parent.heroMode.heroPower.Element9.dropCorrecly = true;
                parent.heroMode.heroPower.Element9.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.resetbooleans();
            }
            if (SuperHeroPowers.ASSERTIVENESS == true)
            {
                parent.heroMode.heroPower.Element10.dropCorrecly = true;
                parent.heroMode.heroPower.Element10.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.resetbooleans();
            }

        }
        private void checkDrops()
        {
            parent.heroMode.HeroAffirmation.selections = "";
            int dropcount = 0;
            if (parent.heroMode.heroPower.Element1.dropCorrecly == true  )
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroPower.Element1.Child).getText() + "\n";
                HeroMode.superPowers = HeroMode.superPowers + ((DropInterface)parent.heroMode.heroPower.Element1.Child).getText() + "\n";
                
                if (parent.heroMode.heroPower.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionCONFIDENCE = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers1 = parent.heroMode.HeroAffirmation.SelectionConfidence;
                }
                else if (parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Collapsed && 
                    selectionCONFIDENCE==false)
                {
                    selectionCONFIDENCE = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers2 = parent.heroMode.HeroAffirmation.SelectionConfidence;
                }
                else if (parent.heroMode.heroPower.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionCONFIDENCE == false)
                {
                    selectionCONFIDENCE = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers3 = parent.heroMode.HeroAffirmation.SelectionConfidence;
                }
                dropcount++;
            }
            if (parent.heroMode.heroPower.Element2.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroPower.Element2.Child).getText() + "\n";
                HeroMode.superPowers = HeroMode.superPowers + ((DropInterface)parent.heroMode.heroPower.Element2.Child).getText() + "\n";
                if (parent.heroMode.heroPower.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionWILLPOWER = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers1 = parent.heroMode.HeroAffirmation.SelectionWillpower;
                }
                else if (parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionWILLPOWER == false)
                {
                    selectionWILLPOWER = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers2 = parent.heroMode.HeroAffirmation.SelectionWillpower;
                }
                else if (parent.heroMode.heroPower.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionWILLPOWER ==false)
                {
                    selectionWILLPOWER = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers3 = parent.heroMode.HeroAffirmation.SelectionWillpower;
                }
                dropcount++;
            }
            if (parent.heroMode.heroPower.Element3.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroPower.Element3.Child).getText() + "\n";
                HeroMode.superPowers = HeroMode.superPowers + ((DropInterface)parent.heroMode.heroPower.Element3.Child).getText() + "\n";
                if (parent.heroMode.heroPower.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionINTELLIGENCE = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers1 = parent.heroMode.HeroAffirmation.SelectionIntelligence;
                }
                else if (parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionINTELLIGENCE ==false)
                {
                    selectionINTELLIGENCE = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers2 = parent.heroMode.HeroAffirmation.SelectionIntelligence;
                }
                else if (parent.heroMode.heroPower.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionINTELLIGENCE == false)
                {
                    selectionINTELLIGENCE = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers3 = parent.heroMode.HeroAffirmation.SelectionIntelligence;
                }
                dropcount++;
            }
            if (parent.heroMode.heroPower.Element4.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroPower.Element4.Child).getText() + "\n";
                HeroMode.superPowers = HeroMode.superPowers + ((DropInterface)parent.heroMode.heroPower.Element4.Child).getText() + "\n";
                if (parent.heroMode.heroPower.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionCREATIVITY = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers1 = parent.heroMode.HeroAffirmation.SelectionCreativity;
                }
                else if (parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Collapsed &&
                     selectionCREATIVITY == false)
                {
                    selectionCREATIVITY = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers2 = parent.heroMode.HeroAffirmation.SelectionCreativity;
                }
                else if (parent.heroMode.heroPower.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Visible &&
                     selectionCREATIVITY == false)
                {
                    selectionCREATIVITY = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers3 = parent.heroMode.HeroAffirmation.SelectionCreativity;
                }
                dropcount++;
            }
            if (parent.heroMode.heroPower.Element5.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroPower.Element5.Child).getText() + "\n";
                HeroMode.superPowers = HeroMode.superPowers + ((DropInterface)parent.heroMode.heroPower.Element5.Child).getText() + "\n";
                if (parent.heroMode.heroPower.line1.Visibility == System.Windows.Visibility.Collapsed )
                {
                    selectionEMPHATY = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers1 = parent.heroMode.HeroAffirmation.SelectionEmphaty;
                }
                else if (parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionEMPHATY == false)
                {
                    selectionEMPHATY = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers2 = parent.heroMode.HeroAffirmation.SelectionEmphaty;
                }
                else if (parent.heroMode.heroPower.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionEMPHATY == false)
                {
                    selectionEMPHATY = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers3 = parent.heroMode.HeroAffirmation.SelectionEmphaty;
                }
                dropcount++;
            }
            if (parent.heroMode.heroPower.Element6.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroPower.Element6.Child).getText() + "\n";
                HeroMode.superPowers = HeroMode.superPowers + ((DropInterface)parent.heroMode.heroPower.Element6.Child).getText() + "\n";
                if (parent.heroMode.heroPower.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionCONCENTRATION = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers1 = parent.heroMode.HeroAffirmation.SelectionConcentration;
                }
                else if (parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Collapsed
                    && selectionCONCENTRATION == false)
                {
                    selectionCONCENTRATION = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers2 = parent.heroMode.HeroAffirmation.SelectionConcentration;
                }
                else if (parent.heroMode.heroPower.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionCONCENTRATION == false)
                {
                    selectionCONCENTRATION = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers3 = parent.heroMode.HeroAffirmation.SelectionConcentration;
                }
                dropcount++;
            }
            if (parent.heroMode.heroPower.Element7.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroPower.Element7.Child).getText() + "\n";
                HeroMode.superPowers = HeroMode.superPowers + ((DropInterface)parent.heroMode.heroPower.Element7.Child).getText() + "\n";
                if (parent.heroMode.heroPower.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionPRESENCE = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers1 = parent.heroMode.HeroAffirmation.SelectionPresence;
                }
                else if (parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Collapsed
                    && selectionPRESENCE == false)
                {
                    selectionPRESENCE = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers2 = parent.heroMode.HeroAffirmation.SelectionPresence;
                }
                else if (parent.heroMode.heroPower.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Visible
                    && selectionPRESENCE==false)
                {
                    selectionPRESENCE = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers3 = parent.heroMode.HeroAffirmation.SelectionPresence;
                }
                dropcount++;
            }
            if (parent.heroMode.heroPower.Element8.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroPower.Element8.Child).getText() + "\n";
                HeroMode.superPowers = HeroMode.superPowers + ((DropInterface)parent.heroMode.heroPower.Element8.Child).getText() + "\n";
                if (parent.heroMode.heroPower.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionCHARISMA = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers1 = parent.heroMode.HeroAffirmation.SelectionCharisma;
                }
                else if (parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Collapsed
                    && selectionCHARISMA == false)
                {
                    selectionCHARISMA = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers2 = parent.heroMode.HeroAffirmation.SelectionCharisma;
                }
                else if (parent.heroMode.heroPower.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Visible
                    && selectionCHARISMA == false)
                {
                    selectionCHARISMA = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers3 = parent.heroMode.HeroAffirmation.SelectionCharisma;
                }
                dropcount++;
            }
            if (parent.heroMode.heroPower.Element9.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroPower.Element9.Child).getText() + "\n";
                HeroMode.superPowers = HeroMode.superPowers + ((DropInterface)parent.heroMode.heroPower.Element9.Child).getText() + "\n";
                if (parent.heroMode.heroPower.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionMEMORY = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers1 = parent.heroMode.HeroAffirmation.SelectionMemory;
                }
                else if (parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Collapsed
                    && selectionMEMORY == false)
                {
                    selectionMEMORY = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers2 = parent.heroMode.HeroAffirmation.SelectionMemory;
                }
                else if (parent.heroMode.heroPower.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Visible
                    && selectionMEMORY == false)
                {
                    selectionMEMORY = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers3 = parent.heroMode.HeroAffirmation.SelectionMemory;
                }
                dropcount++;
            }
            if (parent.heroMode.heroPower.Element10.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroPower.Element10.Child).getText() + "\n";
                HeroMode.superPowers = HeroMode.superPowers + ((DropInterface)parent.heroMode.heroPower.Element10.Child).getText() + "\n";
                if (parent.heroMode.heroPower.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionASSERTIVENESS = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers1 = parent.heroMode.HeroAffirmation.SelectionAssertivenes;
                }
                else if (parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Collapsed
                    && selectionASSERTIVENESS == false)
                {
                    selectionASSERTIVENESS = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers2 = parent.heroMode.HeroAffirmation.SelectionAssertivenes;
                }
                else if (parent.heroMode.heroPower.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroPower.line2.Visibility == System.Windows.Visibility.Visible
                    && selectionASSERTIVENESS == false)
                {
                    selectionASSERTIVENESS = true;
                    parent.heroMode.HeroAffirmation.SelectionPowers3 = parent.heroMode.HeroAffirmation.SelectionAssertivenes;
                }
                dropcount++;
            }

            if(currentDrop<dropcount)
            {
                currentDrop = dropcount;
                parent.heroMode.coin.Stop();
                parent.heroMode.coin.Play();
            }

            if (dropcount == 1)
            {
                parent.heroMode.heroPower.line1.Visibility = System.Windows.Visibility.Visible;
            }
            else if (dropcount == 2)
            {
                parent.heroMode.heroPower.line2.Visibility = System.Windows.Visibility.Visible;
            }
            else if (dropcount == 3)
            {
                parent.heroMode.heroPower.line3.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.heroPower.nextButton.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.heroPower.nextButton.IsEnabled = true;
                
                parent.heroMode.heroPower.Element10.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.Element1.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.Element2.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.Element3.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.Element4.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.Element5.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.Element6.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.Element7.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.Element8.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroPower.Element9.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

       

        public void checkWordsImpact()
        {
            if (SuperHeroImpact.JUSTICE == true)
            {
                parent.heroMode.heroImpact.Element1.dropCorrecly = true;
                parent.heroMode.heroImpact.Element1.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.resetbooleans();
            }
            if (SuperHeroImpact.CLARITY == true)
            {
                parent.heroMode.heroImpact.Element2.dropCorrecly = true;
                parent.heroMode.heroImpact.Element2.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.resetbooleans();
            }
            if (SuperHeroImpact.PASSION == true)
            {
                parent.heroMode.heroImpact.Element3.dropCorrecly = true;
                parent.heroMode.heroImpact.Element3.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.resetbooleans();
            }
            if (SuperHeroImpact.UNDERSTANDING == true)
            {
                parent.heroMode.heroImpact.Element4.dropCorrecly = true;
                parent.heroMode.heroImpact.Element4.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.resetbooleans();
            }
            if (SuperHeroImpact.LOVE == true)
            {
                parent.heroMode.heroImpact.Element5.dropCorrecly = true;
                parent.heroMode.heroImpact.Element5.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.resetbooleans();
            }
            if (SuperHeroImpact.PEACE == true)
            {
                parent.heroMode.heroImpact.Element6.dropCorrecly = true;
                parent.heroMode.heroImpact.Element6.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.resetbooleans();
            }
            if (SuperHeroImpact.RESPECT == true)
            {
                parent.heroMode.heroImpact.Element7.dropCorrecly = true;
                parent.heroMode.heroImpact.Element7.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.resetbooleans();
            }
            if (SuperHeroImpact.ACCEPTANCE == true)
            {
                parent.heroMode.heroImpact.Element8.dropCorrecly = true;
                parent.heroMode.heroImpact.Element8.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.resetbooleans();
            }
            if (SuperHeroImpact.JOY == true)
            {
                parent.heroMode.heroImpact.Element9.dropCorrecly = true;
                parent.heroMode.heroImpact.Element9.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.resetbooleans();
            }
            if (SuperHeroImpact.KINDNESS == true)
            {
                parent.heroMode.heroImpact.Element10.dropCorrecly = true;
                parent.heroMode.heroImpact.Element10.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.resetbooleans();
            }
        }

       

        private void checkDropsImpact()
        {
            parent.heroMode.HeroAffirmation.selections = "";
            int dropcount = 0;
            if (parent.heroMode.heroImpact.Element1.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroImpact.Element1.Child).getText() + "\n";
                HeroMode.impacts = HeroMode.impacts + ((DropInterface)parent.heroMode.heroImpact.Element1.Child).getText() + "\n";

                if (parent.heroMode.heroImpact.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionJUSTICE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld1 = parent.heroMode.HeroAffirmation.SelectionJustice;
                }
                else if (parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionJUSTICE == false)
                {
                    selectionJUSTICE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld2 = parent.heroMode.HeroAffirmation.SelectionJustice;
                }
                else if (parent.heroMode.heroImpact.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionJUSTICE == false)
                {
                    selectionJUSTICE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld3 = parent.heroMode.HeroAffirmation.SelectionJustice;
                }

                dropcount++;
            }
            if (parent.heroMode.heroImpact.Element2.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroImpact.Element2.Child).getText() + "\n";
                HeroMode.impacts = HeroMode.impacts + ((DropInterface)parent.heroMode.heroImpact.Element2.Child).getText() + "\n";

                if (parent.heroMode.heroImpact.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionCLARITY = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld1 = parent.heroMode.HeroAffirmation.SelectionClarity;
                }
                else if (parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionCLARITY == false)
                {
                    selectionCLARITY = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld2 = parent.heroMode.HeroAffirmation.SelectionClarity;
                }
                else if (parent.heroMode.heroImpact.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionCLARITY == false)
                {
                    selectionCLARITY = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld3 = parent.heroMode.HeroAffirmation.SelectionClarity;
                }

                dropcount++;
            }
            if (parent.heroMode.heroImpact.Element3.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroImpact.Element3.Child).getText() + "\n";
                HeroMode.impacts = HeroMode.impacts + ((DropInterface)parent.heroMode.heroImpact.Element3.Child).getText() + "\n";

                if (parent.heroMode.heroImpact.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionPASSION = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld1 = parent.heroMode.HeroAffirmation.SelectionPassion;
                }
                else if (parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionPASSION == false)
                {
                    selectionPASSION = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld2 = parent.heroMode.HeroAffirmation.SelectionPassion;
                }
                else if (parent.heroMode.heroImpact.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionPASSION == false)
                {
                    selectionPASSION = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld3 = parent.heroMode.HeroAffirmation.SelectionPassion;
                }
                dropcount++;
            }
            if (parent.heroMode.heroImpact.Element4.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroImpact.Element4.Child).getText() + "\n";
                HeroMode.impacts = HeroMode.impacts + ((DropInterface)parent.heroMode.heroImpact.Element4.Child).getText() + "\n";

                if (parent.heroMode.heroImpact.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionUNDERSTANDING = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld1 = parent.heroMode.HeroAffirmation.SelectionUnderstanding;
                }
                else if (parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionUNDERSTANDING == false)
                {
                    selectionUNDERSTANDING = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld2 = parent.heroMode.HeroAffirmation.SelectionUnderstanding;
                }
                else if (parent.heroMode.heroImpact.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionUNDERSTANDING == false)
                {
                    selectionUNDERSTANDING = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld3 = parent.heroMode.HeroAffirmation.SelectionUnderstanding;
                }

                dropcount++;
            }
            if (parent.heroMode.heroImpact.Element5.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroImpact.Element5.Child).getText() + "\n";
                HeroMode.impacts = HeroMode.impacts + ((DropInterface)parent.heroMode.heroImpact.Element5.Child).getText() + "\n";

                if (parent.heroMode.heroImpact.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionLOVE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld1 = parent.heroMode.HeroAffirmation.SelectionLove;
                }
                else if (parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionLOVE == false)
                {
                    selectionLOVE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld2 = parent.heroMode.HeroAffirmation.SelectionLove;
                }
                else if (parent.heroMode.heroImpact.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionLOVE == false)
                {
                    selectionLOVE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld3 = parent.heroMode.HeroAffirmation.SelectionLove;
                }

                dropcount++;
            }
            if (parent.heroMode.heroImpact.Element6.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroImpact.Element6.Child).getText() + "\n";
                HeroMode.impacts = HeroMode.impacts + ((DropInterface)parent.heroMode.heroImpact.Element6.Child).getText() + "\n";

                if (parent.heroMode.heroImpact.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionPEACE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld1 = parent.heroMode.HeroAffirmation.SelectionPeace;
                }
                else if (parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionPEACE == false)
                {
                    selectionPEACE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld2 = parent.heroMode.HeroAffirmation.SelectionPeace;
                }
                else if (parent.heroMode.heroImpact.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionPEACE == false)
                {
                    selectionPEACE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld3 = parent.heroMode.HeroAffirmation.SelectionPeace;
                }

                dropcount++;
            }
            if (parent.heroMode.heroImpact.Element7.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroImpact.Element7.Child).getText() + "\n";
                HeroMode.impacts = HeroMode.impacts + ((DropInterface)parent.heroMode.heroImpact.Element7.Child).getText() + "\n";

                if (parent.heroMode.heroImpact.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionRESPECT = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld1 = parent.heroMode.HeroAffirmation.SelectionRespect;
                }
                else if (parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionRESPECT == false)
                {
                    selectionRESPECT = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld2 = parent.heroMode.HeroAffirmation.SelectionRespect;
                }
                else if (parent.heroMode.heroImpact.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionRESPECT == false)
                {
                    selectionRESPECT = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld3 = parent.heroMode.HeroAffirmation.SelectionRespect;
                }

                dropcount++;
            }
            if (parent.heroMode.heroImpact.Element8.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroImpact.Element8.Child).getText() + "\n";
                HeroMode.impacts = HeroMode.impacts + ((DropInterface)parent.heroMode.heroImpact.Element8.Child).getText() + "\n";

                if (parent.heroMode.heroImpact.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionACCEPTANCE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld1 = parent.heroMode.HeroAffirmation.SelectionAcceptance;
                }
                else if (parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionACCEPTANCE == false)
                {
                    selectionACCEPTANCE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld2 = parent.heroMode.HeroAffirmation.SelectionAcceptance;
                }
                else if (parent.heroMode.heroImpact.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionACCEPTANCE == false)
                {
                    selectionACCEPTANCE = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld3 = parent.heroMode.HeroAffirmation.SelectionAcceptance;
                }

                dropcount++;
            }
            if (parent.heroMode.heroImpact.Element9.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroImpact.Element9.Child).getText() + "\n";
                HeroMode.impacts = HeroMode.impacts + ((DropInterface)parent.heroMode.heroImpact.Element9.Child).getText() + "\n";

                if (parent.heroMode.heroImpact.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionJOY = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld1 = parent.heroMode.HeroAffirmation.SelectionJoy;
                }
                else if (parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionJOY == false)
                {
                    selectionJOY = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld2 = parent.heroMode.HeroAffirmation.SelectionJoy;
                }
                else if (parent.heroMode.heroImpact.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionJOY == false)
                {
                    selectionJOY = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld3 = parent.heroMode.HeroAffirmation.SelectionJoy;
                }

                dropcount++;
            }
            if (parent.heroMode.heroImpact.Element10.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroImpact.Element10.Child).getText() + "\n";
                HeroMode.impacts = HeroMode.impacts + ((DropInterface)parent.heroMode.heroImpact.Element10.Child).getText() + "\n";

                if (parent.heroMode.heroImpact.line1.Visibility == System.Windows.Visibility.Collapsed)
                {
                    selectionKINDNESS = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld1 = parent.heroMode.HeroAffirmation.SelectionKindness;
                }
                else if (parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Collapsed &&
                    selectionKINDNESS == false)
                {
                    selectionKINDNESS = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld2 = parent.heroMode.HeroAffirmation.SelectionKindness;
                }
                else if (parent.heroMode.heroImpact.line3.Visibility == System.Windows.Visibility.Collapsed
                    && parent.heroMode.heroImpact.line2.Visibility == System.Windows.Visibility.Visible &&
                    selectionKINDNESS == false)
                {
                    selectionKINDNESS = true;
                    parent.heroMode.HeroAffirmation.SelectionWorld3 = parent.heroMode.HeroAffirmation.SelectionKindness;
                }

                dropcount++;
            }

            if (currentDrop < dropcount)
            {
                currentDrop = dropcount;
                parent.heroMode.coin.Stop();
                parent.heroMode.coin.Play();
            }

            if (dropcount == 1)
            {
                parent.heroMode.heroImpact.line1.Visibility = System.Windows.Visibility.Visible;
            }
            else if (dropcount == 2)
            {
                parent.heroMode.heroImpact.line2.Visibility = System.Windows.Visibility.Visible;
            }
            else if (dropcount == 3)
            {
                parent.heroMode.heroImpact.line3.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.heroImpact.nextButton.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.heroImpact.nextButton.IsEnabled = true;
                parent.heroMode.heroImpact.Element10.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.Element1.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.Element2.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.Element3.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.Element4.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.Element5.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.Element6.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.Element7.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.Element8.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroImpact.Element9.Visibility = System.Windows.Visibility.Collapsed;
            }
        }


        private void checkDropsInspiration2()
        {
            parent.heroMode.HeroAffirmation.selections = "";
            int dropcount = 0;
            if (parent.heroMode.heroInspiration2.Element1.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroInspiration2.Element1.Child).getText() + "\n";
                dropcount++;
            }
            if (parent.heroMode.heroInspiration2.Element2.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroInspiration2.Element2.Child).getText() + "\n"; ;
                dropcount++;
            }
            if (parent.heroMode.heroInspiration2.Element3.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroInspiration2.Element3.Child).getText() + "\n";
                dropcount++;
            }
            if (parent.heroMode.heroInspiration2.Element4.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroInspiration2.Element4.Child).getText() + "\n";
                dropcount++;
            }
            if (parent.heroMode.heroInspiration2.Element5.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroInspiration2.Element5.Child).getText() + "\n";
                dropcount++;
            }
            if (parent.heroMode.heroInspiration2.Element6.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroInspiration2.Element6.Child).getText() + "\n";
                dropcount++;
            }
            if (parent.heroMode.heroInspiration2.Element7.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroInspiration2.Element7.Child).getText() + "\n";
                dropcount++;
            }
            if (parent.heroMode.heroInspiration2.Element8.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroInspiration2.Element8.Child).getText() + "\n";
                dropcount++;
            }
            if (parent.heroMode.heroInspiration2.Element9.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroInspiration2.Element9.Child).getText() + "\n";
                dropcount++;
            }
            if (parent.heroMode.heroInspiration2.Element10.dropCorrecly == true)
            {
                parent.heroMode.HeroAffirmation.selections = parent.heroMode.HeroAffirmation.selections + ((DropInterface)parent.heroMode.heroInspiration2.Element10.Child).getText() + "\n";
                dropcount++;
            }

            if (currentDrop < dropcount)
            {
                currentDrop = dropcount;
                parent.heroMode.coin.Stop();
                parent.heroMode.coin.Play();
            }

            if (dropcount == 1)
            {
                parent.heroMode.heroInspiration2.line1.Visibility = System.Windows.Visibility.Visible;
            }
            else if (dropcount == 2)
            {
                parent.heroMode.heroInspiration2.line2.Visibility = System.Windows.Visibility.Visible;
            }
            else if (dropcount == 3)
            {
                parent.heroMode.heroInspiration2.line3.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.heroInspiration2.nextButton.Visibility = System.Windows.Visibility.Visible;
                parent.heroMode.heroInspiration2.nextButton.IsEnabled = true;
                parent.heroMode.heroInspiration2.Element10.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroInspiration2.Element1.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroInspiration2.Element2.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroInspiration2.Element3.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroInspiration2.Element4.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroInspiration2.Element5.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroInspiration2.Element6.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroInspiration2.Element7.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroInspiration2.Element8.Visibility = System.Windows.Visibility.Collapsed;
                parent.heroMode.heroInspiration2.Element9.Visibility = System.Windows.Visibility.Collapsed;
            }
        }


        public void postureTeaching()
        {
            var uriSource = new Uri(@"/TheBooth;component/Images/postureIconLegs.png", UriKind.Relative); ;
            if(parent.heroMode!=null)
            {
                
              //  parent.heroMode.instructionsLabel.Content = parent.heroMode.InstructionHeroPosture;
                if (bfpa.heroLegRight == false)
                {
                    parent.heroMode.herofeedback.Content = "Spread legs";
                    uriSource = new Uri(@"/TheBooth;component/Images/postureIconLegs.png", UriKind.Relative);
                    parent.heroMode.feedbackImage.Source = new BitmapImage(uriSource);
                    
                }
                else if (bfpa.heroBack == false)
                {
                    parent.heroMode.herofeedback.Content = "Shoulders Back";
                    uriSource = new Uri(@"/TheBooth;component/Images/postureIconShoulders.png", UriKind.Relative);
                    parent.heroMode.feedbackImage.Source = new BitmapImage(uriSource);
                }
                else if (bfpa.heroNeck == false)
                {
                    parent.heroMode.herofeedback.Content = "Head back";
                    uriSource = new Uri(@"/TheBooth;component/Images/postureIconHead.png", UriKind.Relative);
                    parent.heroMode.feedbackImage.Source = new BitmapImage(uriSource);
                }
                else if (bfpa.heroArmsLeft == false)
                {
                    parent.heroMode.herofeedback.Content = "Left Hand \non Hip";
                    uriSource = new Uri(@"/TheBooth;component/Images/postureIconLeftArm.png", UriKind.Relative);
                    parent.heroMode.feedbackImage.Source = new BitmapImage(uriSource);
                }
                else if (bfpa.heroArmsRight == false)
                {
                    parent.heroMode.herofeedback.Content = "Right Hand \non Hip";
                    uriSource = new Uri(@"/TheBooth;component/Images/postureIconRightArm.png", UriKind.Relative);
                    parent.heroMode.feedbackImage.Source = new BitmapImage(uriSource);
                }
                else if (ffpa.smiling == false)
                {
                    parent.heroMode.herofeedback.Content = "Now Smile";
                    uriSource = new Uri(@"/TheBooth;component/Images/postureIconSmile.png", UriKind.Relative);
                    parent.heroMode.feedbackImage.Source = new BitmapImage(uriSource);
                }
                else
                {
                    parent.heroMode.herofeedback.Content = "That's the \nposture!";
                    MainWindow.heroSource = parent.videoHandler.kinectImage.Source.CloneCurrentValue();
                    myState = States.Pause;
                    parent.heroMode.instructionRectangle.Visibility = System.Windows.Visibility.Collapsed;
                    parent.heroMode.instructionsLabel.Visibility = System.Windows.Visibility.Collapsed;
                    parent.heroMode.myCanvas.Children.Add(parent.heroMode.HeroAffirmation);
                    Canvas.SetLeft(parent.heroMode.HeroAffirmation, 260);
                    Canvas.SetTop(parent.heroMode.HeroAffirmation, 50);

                    parent.heroMode.HeroAffirmation.setStrings(1);
                    parent.heroMode.HeroAffirmation.Visibility = System.Windows.Visibility.Visible;
                    

                    parent.heroMode.HeroAffirmation.loadAffirmation();
                    //parent.heroMode.HeroAffirmation.loaded = false;
                    parent.soundeffect.Stop();
                    parent.soundeffect.Play();
                }
            }
            
            
        }

        public bool checkingPosture()
        {
            bool value = true;

           double currentTime = DateTime.Now.TimeOfDay.TotalMilliseconds;

           if (bfpa.heroLegRight == false ) 
            {
                if (currentTime - counterLegs > timeForAction)
                value = false;
            }
            else
            {
                counterLegs = currentTime;
            }
           if (bfpa.heroBack == false) if( currentTime - counterBack > timeForAction)
            {
                if (currentTime - counterBack > timeForAction)
                value = false;
            }
            else
            {
                counterBack = currentTime;
            }
           if (bfpa.heroNeck == false ) 
            {
                if (currentTime - counterNeck > timeForAction)
                value = false;
            }
            else
            {
                counterNeck = currentTime;
            }
           if (ffpa.smiling == false) 
            {
                if (currentTime - counterSmile > timeForAction)
                value = false;
            }
            else
            {
                counterSmile = currentTime;
            }
            if(value==false)
            {
                postureTeaching();
            }

         
            return value;
        }

        void values_selectionEvent(object sender, string x)
        {
          //  parent.heroMode.value = x;
       //     parent.heroMode.values.Visibility = System.Windows.Visibility.Collapsed;
            

        }
    }
}
