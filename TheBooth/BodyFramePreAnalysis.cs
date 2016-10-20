/**
 * ****************************************************************************
 * Copyright (C) 2016 Open Universiteit Nederland
 * <p/>
 * This library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * <p/>
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.
 * <p/>
 * You should have received a copy of the GNU Lesser General Public License
 * along with this library.  If not, see <http://www.gnu.org/licenses/>.
 * <p/>
 * Contributors: Jan Schneider
 * ****************************************************************************
 */
using Microsoft.Kinect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBooth
{
    public class BodyFramePreAnalysis
    {
        public Body body;
        public static Dictionary<JointType, Joint> bodyOld = new Dictionary<JointType, Joint>();

        public bool armsCrossed = false;
        public bool legsCrossed = false;
        public bool rightHandUnderHips = false;
        public bool leftHandUnderHips = false;
        public bool rightHandBehindBack = false;
        public bool leftHandBehindBack = false;
        public bool hunch = false;
        public bool resetPosture = false;
        public bool leanIn = false;
        public bool rightArmClosePosture = false;
        public bool leftArmClosePosture = false;
        public bool rightLean = false;
        public bool leftLean = false;
        public bool areHandsMoving = false;

        public bool heroLegRight = false;
        public bool heroLegLeft = false;
        public bool heroArmsRight = false;
        public bool heroArmsLeft = false;
        public bool heroBack = false;
        public bool heroNeck = false;
        public bool heroMistake = true;
        public bool heroWinning = false;
        public bool handsUp = false;

        public static bool rightHandUp = false;


        public double shouldersAngle;
        public double hipsAngle;
        public int rightOpenness;
        public int leftOpenness;
        public int totalOpenness;
        CameraSpacePoint rightHandPrevious;
        CameraSpacePoint leftHandPrevious;

        public ArrayList currentMistakes;
        public ArrayList currentGoodies;

        public enum Posture { good, bad }; //TODO
        public enum HandMovement { good, notEnough, tooMuch };//TODO

        public Posture bodyPosture; //TODO
        public HandMovement handMovement; //TODO


        // This moving stuff I think should go to rulesAnalizer
        public bool needToMoveMore = false; //TODO
        public bool isMoving = false; //TODO
        public double startedMoving; //TODO
        public double stopMoving; //TODO
        public float ThresholdMovingTime = 1000; //TODO
        public float ThresholdIsMovingDistance = 0.035f; //TODO


        public double angleRightForearmRightArmA = 2000;
        public double angleRightForearmRightArmB = 2000;
        public double angleRightForearmRightArmC = 0;



        public double prevAngleRightForearmRightArmA = 2000;
        public double prevAngleRightForearmRightArmB = 2000;
        public double prevAngleRightForearmRightArmC = 0;


        public double angleRightArmShoulderLineA = 2000;
        public double angleRightArmShoulderLineB = 2000;
        public double angleRightArmShoulderLineC = 0;

        public double prevAngleRightArmShoulderLineA = 2000;
        public double prevAngleRightArmShoulderLineB = 2000;
        public double prevAngleRightArmShoulderLineC = 0;

        public double angleLeftForearmLeftArmA = 2000;
        public double angleLeftForearmLeftArmB = 2000;
        public double angleLeftForearmLeftArmC = 0;

        public double prevAngleLeftForearmLeftArmA = 2000;
        public double prevAngleLeftForearmLeftArmB = 2000;
        public double prevAngleLeftForearmLeftArmC = 0;

        public double angleLeftArmShoulderLineA = 0;
        public double angleLeftArmShoulderLineB = 2000;
        public double angleLeftArmShoulderLineC = 0;

        public double prevAngleLeftArmShoulderLineA = 0;
        public double prevAngleLeftArmShoulderLineB = 2000;
        public double prevAngleLeftArmShoulderLineC = 0;

        public BodyFramePreAnalysis(Body body)
        {
            this.body = body;
            if (body != null)
            {
                rightHandPrevious = body.Joints[JointType.HandRight].Position;
                leftHandPrevious = body.Joints[JointType.HandLeft].Position;
            }
            currentMistakes = new ArrayList();
            currentGoodies = new ArrayList();

        }

        public void setBody(Body body)
        {
            this.body = body;
            if (body != null)
            {
                rightHandPrevious = body.Joints[JointType.HandRight].Position;
                leftHandPrevious = body.Joints[JointType.HandLeft].Position;
            }
        }


        public void setOldBody()
        {
            if (this.body != null)
            {
                BodyFramePreAnalysis.bodyOld.Clear();
                foreach (KeyValuePair<JointType, Joint> kp in this.body.Joints)
                {
                    BodyFramePreAnalysis.bodyOld.Add(kp.Key, kp.Value);
                }


                int x = 0;
                x++;
            }

        }

        public void getbigGesture()
        {

        }

        public void getArmsAngles()
        {
            getAnglesForearm();
            getAnglesShoulder();


        }

        void getAnglesForearm()
        {
            double forearmLineX = body.Joints[JointType.WristRight].Position.X - body.Joints[JointType.ElbowRight].Position.X;
            double forearmLineZ = body.Joints[JointType.WristRight].Position.Z - body.Joints[JointType.ElbowRight].Position.Z;
            double forearmLineY = body.Joints[JointType.WristRight].Position.Y - body.Joints[JointType.ElbowRight].Position.Y;

            angleRightForearmRightArmA = Math.Atan(forearmLineY /
                (Math.Sqrt(forearmLineX * forearmLineX + forearmLineZ * forearmLineZ)) * 180 / Math.PI);
            angleRightForearmRightArmB = Math.Atan(forearmLineX / forearmLineZ) / Math.PI * 180;


            forearmLineX = body.Joints[JointType.WristLeft].Position.X - body.Joints[JointType.ElbowLeft].Position.X;
            forearmLineZ = body.Joints[JointType.WristLeft].Position.Z - body.Joints[JointType.ElbowLeft].Position.Z;
            forearmLineY = body.Joints[JointType.WristLeft].Position.Y - body.Joints[JointType.ElbowLeft].Position.Y;

            angleLeftForearmLeftArmA = Math.Atan(forearmLineY /
                (Math.Sqrt(forearmLineX * forearmLineX + forearmLineZ * forearmLineZ)) * 180 / Math.PI);
            angleLeftForearmLeftArmB = Math.Atan(forearmLineX /
                Math.Sqrt(forearmLineY * forearmLineY + forearmLineZ * forearmLineZ)) / Math.PI * 180;
        }
        void getAnglesShoulder()
        {
            double armLineX = body.Joints[JointType.ElbowRight].Position.X - body.Joints[JointType.ShoulderRight].Position.X;
            double armLineZ = body.Joints[JointType.ElbowRight].Position.Z - body.Joints[JointType.ShoulderRight].Position.Z;
            double armLineY = body.Joints[JointType.ElbowRight].Position.Y - body.Joints[JointType.ShoulderRight].Position.Y;

            angleRightArmShoulderLineA = Math.Atan(armLineX /
                Math.Sqrt(armLineZ * armLineZ + armLineY * armLineY)) / Math.PI * 180;
            angleRightArmShoulderLineB = Math.Atan(armLineZ /
                Math.Sqrt(armLineY * armLineY + armLineX * armLineX)) / Math.PI * 180;


            armLineX = body.Joints[JointType.ElbowLeft].Position.X - body.Joints[JointType.ShoulderLeft].Position.X;
            armLineZ = body.Joints[JointType.ElbowLeft].Position.Z - body.Joints[JointType.ShoulderLeft].Position.Z;
            armLineY = body.Joints[JointType.ElbowLeft].Position.Y - body.Joints[JointType.ShoulderLeft].Position.Y;

            angleLeftArmShoulderLineA = Math.Atan(armLineX /
                Math.Sqrt(armLineZ * armLineZ + armLineY * armLineY)) / Math.PI * 180;
            angleLeftArmShoulderLineB = Math.Atan(armLineZ /
                Math.Sqrt(armLineY * armLineY + armLineX * armLineX)) / Math.PI * 180;
        }

        public void getShouldersAngle()
        {
            double xLine = body.Joints[JointType.ShoulderRight].Position.X - body.Joints[JointType.ShoulderLeft].Position.X;
            double zLine = body.Joints[JointType.ShoulderRight].Position.Z - body.Joints[JointType.ShoulderLeft].Position.Z;

            shouldersAngle = Math.Asin(zLine /
                (Math.Sqrt(zLine * zLine + xLine * xLine)));


            CameraSpacePoint left = body.Joints[JointType.HandLeft].Position;
            CameraSpacePoint right = body.Joints[JointType.HandRight].Position;

            if (left.Y > right.Y)
                rightHandUp = false;
            else
                rightHandUp = true;
        }

        public void getHandsUp()
        {
            if (body.Joints[JointType.HandRight].Position.Y > body.Joints[JointType.Head].Position.Y ||
               body.Joints[JointType.HandLeft].Position.Y > body.Joints[JointType.Head].Position.Y )
            {
                handsUp = true;
            }
            else
            {
                handsUp = false;
            }
        }

        public void analyzeHero()
        {
            getShouldersAngle();
            //public bool heroLegs = false;
            //public bool heroArms = false;
            //public bool heroBack = false;
            //public bool heroNeck = false;
            ///heroMistake
            analyzeHeroLegRight();
            analyzeHeroLegLeft();
            analyzeHeroArmsRight();
            analyzeHeroArmsLeft();
            analyzeHeroBack();
            analyzeHeroNeck();
            analyzeHeroWinning();

        }



        private void analyzeHeroWinning()
        {
            if (heroLegRight == true)
            {
                if (body.Joints[JointType.HandRight].Position.Y > body.Joints[JointType.ElbowRight].Position.Y &&
                body.Joints[JointType.ElbowRight].Position.Y > body.Joints[JointType.ShoulderRight].Position.Y &&
                    body.Joints[JointType.HandLeft].Position.Y > body.Joints[JointType.ElbowLeft].Position.Y &&
                body.Joints[JointType.ElbowLeft].Position.Y > body.Joints[JointType.ShoulderLeft].Position.Y)
                {
                    heroWinning = true;
                }
            }
        }



        private void analyzeHeroNeck()
        {
            double x1 = body.Joints[JointType.Head].Position.X * Math.Sin(shouldersAngle);
            double z1 = body.Joints[JointType.Head].Position.Z * Math.Cos(shouldersAngle);

            double x2 = body.Joints[JointType.SpineShoulder].Position.X * Math.Sin(shouldersAngle);
            double z2 = body.Joints[JointType.SpineShoulder].Position.Z * Math.Cos(shouldersAngle);

            double distanceShoulders = Math.Sqrt( (body.Joints[JointType.ShoulderRight].Position.X - body.Joints[JointType.ShoulderLeft].Position.X) *
                (body.Joints[JointType.ShoulderRight].Position.X - body.Joints[JointType.ShoulderLeft].Position.X) +
                (body.Joints[JointType.ShoulderRight].Position.Z - body.Joints[JointType.ShoulderLeft].Position.Z) * 
                (body.Joints[JointType.ShoulderRight].Position.Z - body.Joints[JointType.ShoulderLeft].Position.Z));

            if (-x1 + z1 < -x2 + z2 -distanceShoulders*0.05)
            {

                heroNeck = false;

            }
            else
            {
                heroNeck = true;
            }
        }

        private void analyzeHeroBack()
        {
            double x1 = body.Joints[JointType.SpineShoulder].Position.X * Math.Sin(shouldersAngle);
            double z1 = body.Joints[JointType.SpineShoulder].Position.Z * Math.Cos(shouldersAngle);

            double x2 = body.Joints[JointType.SpineBase].Position.X * Math.Sin(shouldersAngle);
            double z2 = body.Joints[JointType.SpineBase].Position.Z * Math.Cos(shouldersAngle);

            double distanceShoulders = Math.Sqrt((body.Joints[JointType.ShoulderRight].Position.X - body.Joints[JointType.ShoulderLeft].Position.X) *
                (body.Joints[JointType.ShoulderRight].Position.X - body.Joints[JointType.ShoulderLeft].Position.X) +
                (body.Joints[JointType.ShoulderRight].Position.Z - body.Joints[JointType.ShoulderLeft].Position.Z) *
                (body.Joints[JointType.ShoulderRight].Position.Z - body.Joints[JointType.ShoulderLeft].Position.Z));

            if (-x1 + z1 < -x2 + z2 - distanceShoulders * 0.05)
            {

                heroBack = false;

            }
            else
            {
                heroBack = true;
            }
        }

        private void analyzeHeroArmsRight()
        {
            double x1 = body.Joints[JointType.WristRight].Position.X * Math.Cos(shouldersAngle);
            double z1 = body.Joints[JointType.WristRight].Position.Z * Math.Sin(shouldersAngle);

            double x2 = body.Joints[JointType.HipRight].Position.X * Math.Cos(shouldersAngle);
            double z2 = body.Joints[JointType.HipRight].Position.Z * Math.Sin(shouldersAngle);

            double calibration = Math.Abs(0.003 + body.Joints[JointType.WristRight].Position.Y - body.Joints[JointType.HandTipRight].Position.Y);

            if (body.Joints[JointType.WristRight].Position.Y >= body.Joints[JointType.HipRight].Position.Y &&
                body.Joints[JointType.HandTipRight].Position.Y < body.Joints[JointType.HipRight].Position.Y + calibration)
            {


                heroArmsRight = true;

            }
            else
            {
                heroArmsRight = false;
            }
        }

        private void analyzeHeroArmsLeft()
        {
            double x1 = body.Joints[JointType.WristLeft].Position.X * Math.Cos(shouldersAngle);
            double z1 = body.Joints[JointType.WristLeft].Position.Z * Math.Sin(shouldersAngle);

            double x2 = body.Joints[JointType.HipLeft].Position.X * Math.Cos(shouldersAngle);
            double z2 = body.Joints[JointType.HipLeft].Position.Z * Math.Sin(shouldersAngle);

            double calibration = Math.Abs(0.003 + body.Joints[JointType.WristLeft].Position.Y - body.Joints[JointType.HandTipLeft].Position.Y);

            if (body.Joints[JointType.WristLeft].Position.Y >= body.Joints[JointType.HipLeft].Position.Y &&
                body.Joints[JointType.HandTipLeft].Position.Y < body.Joints[JointType.HipLeft].Position.Y + calibration)
            {


                heroArmsLeft = true;

            }
            else
            {
                heroArmsLeft = false;
            }
        }

        private void analyzeHeroLegRight()
        {
            double x1 = body.Joints[JointType.FootRight].Position.X;
            double z1 = body.Joints[JointType.FootRight].Position.Z;

            double x2 = body.Joints[JointType.FootLeft].Position.X;
            double z2 = body.Joints[JointType.FootLeft].Position.Z;

            double lineFeet = (z1 - z2) * (z1 - z2) + (x1 - x2) * (x1 - x2);

            double x3 = body.Joints[JointType.ShoulderRight].Position.X;
            double z3 = body.Joints[JointType.ShoulderRight].Position.Z;

            double x4 = body.Joints[JointType.ShoulderLeft].Position.X;
            double z4 = body.Joints[JointType.ShoulderLeft].Position.Z;

            double lineShoulder = (z3 - z4) * (z3 - z4) + (x3 - x4) * (x3 - x4);

            if (lineFeet < lineShoulder)
            {

                heroLegRight = false;

            }
            else
            {
                heroLegRight = true;
            }
        }
        private void analyzeHeroLegLeft()
        {

        }

        
    }
}
