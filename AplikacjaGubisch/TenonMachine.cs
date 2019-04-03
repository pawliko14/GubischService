using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaGubisch
{
    public class TenonMachine
    {
        public struct ChipBreaker
        {
            private int DB115_DBW10;
            private bool M500_1;        // CMD  
            private bool I34_2;         // CMD  
            private bool I34_3;         // CONF
            private bool I34_6;         // CONF
            private bool I34_5;         // CONF
            private bool I23_4;         // CONF
            private bool Q103_6;        //Valve
            private bool Q103_4;        //Valve
            private bool M500_0;        //CONF

            private bool DB2_DBX188_0;  //Message
            private bool DB2_DBX188_1;  //Message
            private bool DB2_DBX188_2;  //Message
            private bool DB2_DBX188_3;  //Message
            private bool DB2_DBX188_4;  //Message
            private bool DB2_DBX188_5;  //Message

            public void DB115_DBW10Set(int n)
            {
                DB115_DBW10 = n;
            }
            public int DB115_DBW10Get()
            {
                return DB115_DBW10;
            }

            public void M500_1Set(bool n)
            {
                M500_1 = n;
            }
            public bool M500_1Get()
            {
                return M500_1;
            }

            public void I34_2Set(bool n)
            {
                I34_2 = n;
            }
            
            public bool I34_2Get()
            {
                return I34_2;
            }

            public void I34_3Set(bool n )
            {
                I34_3 = n;
            }
            public bool I34_3Get()
            {
                return I34_3;
            }

            public void I34_6Set(bool n)
            {
                I34_6 = n;
            }
            public bool I34_6Get()
            {
                return I34_6;
            }

            public void I34_5Set(bool n )
            {
                I34_5 = n;
            }
            public bool I34_5Get()
            {
                return I34_5;
            }
            public void I23_4Set(bool n )
            {
                I23_4 = n;
            }
            public bool I23_4Get()
            {
                return I23_4;
            }

            public void Q103_6Set(bool n )
            {
                Q103_6 = n;
            }

            public bool Q103_6Get()
            {
                return Q103_6;
            }

            public void Q103_4Set(bool n )
            {
                Q103_4 = n;
            }
               public bool Q103_4Get()
            {
                return Q103_4;
            }

            public void M500_0Set(bool n )
            {
                M500_0 = n;
            }

            public bool M500_0Get()
            {
                return M500_0;
            }


            ////
            ///
            public void DB2_DBX188_0Set(bool n )
            {
                DB2_DBX188_0 = n;
            }
            public bool DB2_DBX188_0Get()
            {
                return DB2_DBX188_0;
            }

            public void DB2_DBX188_1Set(bool n)
            {
                DB2_DBX188_1 = n;
            }
            public bool DB2_DBX188_1Get()
            {
                return DB2_DBX188_1;
            }

            public void DB2_DBX188_2Set(bool n)
            {
                DB2_DBX188_2 = n;
            }
            public bool DB2_DBX188_2Get()
            {
                return DB2_DBX188_2;
            }

            public void DB2_DBX188_3Set(bool n)
            {
                DB2_DBX188_3 = n;
            }
            public bool DB2_DBX188_3Get()
            {
                return DB2_DBX188_3;
            }

            public void DB2_DBX188_4Set(bool n)
            {
                DB2_DBX188_4 = n;
            }
            public bool DB2_DBX188_4Get()
            {
                return DB2_DBX188_4;
            }

            public void DB2_DBX188_5Set(bool n)
            {
                DB2_DBX188_5 = n;
            }
            public bool DB2_DBX188_5Get()
            {
                return DB2_DBX188_5;
            }


        }

        public struct TenonVisior
        {
            private bool M601_1;
            private bool M601_2;
            private bool I37_7;
            private bool I37_8; // sprawdzic czy u Pawla sie zgadza w plc
            private bool Q101_4;
            private bool Q101_5;
            private bool DB2_DBX192_0;
            private bool DB2_DBX192_1;
            private bool DB2_DBX188_6;
            private bool DB2_DBX188_7;

            public bool M601_11 { get => M601_1; set => M601_1 = value; }
            public bool M601_21 { get => M601_2; set => M601_2 = value; }
            public bool I37_71 { get => I37_7; set => I37_7 = value; }
            public bool I37_81 { get => I37_8; set => I37_8 = value; }
            public bool Q101_41 { get => Q101_4; set => Q101_4 = value; }
            public bool Q101_51 { get => Q101_5; set => Q101_5 = value; }
            public bool DB2_DBX192_01 { get => DB2_DBX192_0; set => DB2_DBX192_0 = value; }
            public bool DB2_DBX192_11 { get => DB2_DBX192_1; set => DB2_DBX192_1 = value; }
            public bool DB2_DBX188_61 { get => DB2_DBX188_6; set => DB2_DBX188_6 = value; }
            public bool DB2_DBX188_71 { get => DB2_DBX188_7; set => DB2_DBX188_7 = value; }
        }

        public struct SawUnit
        {
            private bool M601_3;
            private bool M601_4;
            private bool I33_1;
            private bool Q100_0;
            private bool Q100_1;
            private bool DB2_DBX192_6;
            private bool DB2_DBX192_7;
            private bool DB2_DBX189_2;
            private bool DB2_DBX189_3;

            public bool M601_31 { get => M601_3; set => M601_3 = value; }
            public bool M601_41 { get => M601_4; set => M601_4 = value; }
            public bool I33_11 { get => I33_1; set => I33_1 = value; }
            public bool Q100_01 { get => Q100_0; set => Q100_0 = value; }
            public bool Q100_11 { get => Q100_1; set => Q100_1 = value; }
            public bool DB2_DBX192_61 { get => DB2_DBX192_6; set => DB2_DBX192_6 = value; }
            public bool DB2_DBX192_71 { get => DB2_DBX192_7; set => DB2_DBX192_7 = value; }
            public bool DB2_DBX189_21 { get => DB2_DBX189_2; set => DB2_DBX189_2 = value; }
            public bool DB2_DBX189_31 { get => DB2_DBX189_3; set => DB2_DBX189_3 = value; }
        }
        public struct UnloadStation
        {
            private bool M601_5;
            private bool M601_6;
            private bool M601_7;
            private bool M602_0;
            private bool I35_2;
            private bool Q102_2;
            private bool Q102_3;
            private bool Q102_4;
            private bool Q102_5;

            public bool M601_51 { get => M601_5; set => M601_5 = value; }
            public bool M601_61 { get => M601_6; set => M601_6 = value; }
            public bool M601_71 { get => M601_7; set => M601_7 = value; }
            public bool M602_01 { get => M602_0; set => M602_0 = value; }
            public bool I35_21 { get => I35_2; set => I35_2 = value; }
            public bool Q102_21 { get => Q102_2; set => Q102_2 = value; }
            public bool Q102_31 { get => Q102_3; set => Q102_3 = value; }
            public bool Q102_41 { get => Q102_4; set => Q102_4 = value; }
            public bool Q102_51 { get => Q102_5; set => Q102_5 = value; }
        }
    }
}
