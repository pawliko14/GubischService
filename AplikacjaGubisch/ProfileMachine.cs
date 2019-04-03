using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaGubisch
{
   public class ProfileMachine
    {
        public struct CLean_Table
        {
            private bool M602_1;
            private bool Q32_7;

            public bool M602_11 { get => M602_1; set => M602_1 = value; }
            public bool Q32_71 { get => Q32_7; set => Q32_7 = value; }
        }

        public struct FeedBeam_Rollers
        {
            private bool M602_2;
            private bool M602_3;
            private bool M602_4;
            private bool M602_5;
            private bool M602_6;
            private bool M602_7;
            private bool M603_0;
            private bool M603_1;

            private bool Q104_0;
            private bool Q104_2;
            private bool Q104_4;
            private bool Q104_6;

            public bool M602_21 { get => M602_2; set => M602_2 = value; }
            public bool M602_31 { get => M602_3; set => M602_3 = value; }
            public bool M602_41 { get => M602_4; set => M602_4 = value; }
            public bool M602_51 { get => M602_5; set => M602_5 = value; }
            public bool M602_61 { get => M602_6; set => M602_6 = value; }
            public bool M602_71 { get => M602_7; set => M602_7 = value; }
            public bool M603_01 { get => M603_0; set => M603_0 = value; }
            public bool M603_11 { get => M603_1; set => M603_1 = value; }
            public bool Q104_01 { get => Q104_0; set => Q104_0 = value; }
            public bool Q104_21 { get => Q104_2; set => Q104_2 = value; }
            public bool Q104_41 { get => Q104_4; set => Q104_4 = value; }
            public bool Q104_61 { get => Q104_6; set => Q104_6 = value; }
        }

        public struct Horizontal_Spindle_Position
        {
            public struct Spindle1
            {
                private int DB131_DBW8;

                private bool M500_4;
                private bool I36_3;
                private bool I36_2;
                private bool Q105_3;
                private bool Q105_2;
                private bool Q105_1;
                private bool Q105_0;
                private bool Q101_3;
                private bool Q101_2;

                private bool DB2_DBX196_0;
                private bool DB2_DBX196_1;

                public int DB131_DBW81 { get => DB131_DBW8; set => DB131_DBW8 = value; }
                public bool M500_41 { get => M500_4; set => M500_4 = value; }
                public bool I36_31 { get => I36_3; set => I36_3 = value; }
                public bool I36_21 { get => I36_2; set => I36_2 = value; }
                public bool Q105_31 { get => Q105_3; set => Q105_3 = value; }
                public bool Q105_21 { get => Q105_2; set => Q105_2 = value; }
                public bool Q105_11 { get => Q105_1; set => Q105_1 = value; }
                public bool Q105_01 { get => Q105_0; set => Q105_0 = value; }
                public bool Q101_31 { get => Q101_3; set => Q101_3 = value; }
                public bool Q101_21 { get => Q101_2; set => Q101_2 = value; }
                public bool DB2_DBX196_01 { get => DB2_DBX196_0; set => DB2_DBX196_0 = value; }
                public bool DB2_DBX196_11 { get => DB2_DBX196_1; set => DB2_DBX196_1 = value; }
            }
            public struct Spindle2
            {
                private int DB132_DBW8;
                private bool M500_5;
                private bool I36_5;
                private bool I36_4;

                private bool Q105_7;
                private bool Q105_6;
                private bool Q105_5;
                private bool Q105_4;
                private bool Q101_1;
                private bool Q101_0;

                private bool DB2_DBX196_2;
                private bool DB2_DBX196_3;

                public int DB132_DBW81 { get => DB132_DBW8; set => DB132_DBW8 = value; }
                public bool M500_51 { get => M500_5; set => M500_5 = value; }
                public bool I36_51 { get => I36_5; set => I36_5 = value; }
                public bool I36_41 { get => I36_4; set => I36_4 = value; }
                public bool Q105_71 { get => Q105_7; set => Q105_7 = value; }
                public bool Q105_61 { get => Q105_6; set => Q105_6 = value; }
                public bool Q105_51 { get => Q105_5; set => Q105_5 = value; }
                public bool Q105_41 { get => Q105_4; set => Q105_4 = value; }
                public bool Q101_11 { get => Q101_1; set => Q101_1 = value; }
                public bool Q101_01 { get => Q101_0; set => Q101_0 = value; }
                public bool DB2_DBX196_21 { get => DB2_DBX196_2; set => DB2_DBX196_2 = value; }
                public bool DB2_DBX196_31 { get => DB2_DBX196_3; set => DB2_DBX196_3 = value; }
            }
            public struct Spindle3
            {
                private int DB133_DBW8;
                private bool M500_6;
                private bool I36_7;
                private bool I36_6;

                private bool Q106_3;
                private bool Q106_2;
                private bool Q106_1;
                private bool Q106_0;
                private bool Q100_7;
                private bool Q100_6;

                private bool DB2_DBX196_4;
                private bool DB2_DBX196_5;

                public int DB133_DBW81 { get => DB133_DBW8; set => DB133_DBW8 = value; }
                public bool M500_61 { get => M500_6; set => M500_6 = value; }
                public bool I36_71 { get => I36_7; set => I36_7 = value; }
                public bool I36_61 { get => I36_6; set => I36_6 = value; }
                public bool Q106_31 { get => Q106_3; set => Q106_3 = value; }
                public bool Q106_21 { get => Q106_2; set => Q106_2 = value; }
                public bool Q106_11 { get => Q106_1; set => Q106_1 = value; }
                public bool Q106_01 { get => Q106_0; set => Q106_0 = value; }
                public bool Q100_71 { get => Q100_7; set => Q100_7 = value; }
                public bool Q100_61 { get => Q100_6; set => Q100_6 = value; }
                public bool DB2_DBX196_41 { get => DB2_DBX196_4; set => DB2_DBX196_4 = value; }
                public bool DB2_DBX196_51 { get => DB2_DBX196_5; set => DB2_DBX196_5 = value; }
            }
            public struct Groove_Spindle
            {
                private int DB143_DBW6;
                private bool M501_3;
                private bool I37_2;
                private bool I37_1;
                private bool I37_0;

                private bool Q101_6;
                private bool Q101_7;
                private bool Q102_0;
                private bool Q102_1;

                private bool DB2_DBX196_6;
                private bool DB2_DBX196_7;
                private bool DB2_DBX197_0;
                private bool DB2_DBX197_1;

                public int DB143_DBW61 { get => DB143_DBW6; set => DB143_DBW6 = value; }
                public bool M501_31 { get => M501_3; set => M501_3 = value; }
                public bool I37_21 { get => I37_2; set => I37_2 = value; }
                public bool I37_11 { get => I37_1; set => I37_1 = value; }
                public bool I37_01 { get => I37_0; set => I37_0 = value; }
                public bool Q101_61 { get => Q101_6; set => Q101_6 = value; }
                public bool Q101_71 { get => Q101_7; set => Q101_7 = value; }
                public bool Q102_01 { get => Q102_0; set => Q102_0 = value; }
                public bool Q102_11 { get => Q102_1; set => Q102_1 = value; }
                public bool DB2_DBX196_61 { get => DB2_DBX196_6; set => DB2_DBX196_6 = value; }
                public bool DB2_DBX196_71 { get => DB2_DBX196_7; set => DB2_DBX196_7 = value; }
                public bool DB2_DBX197_01 { get => DB2_DBX197_0; set => DB2_DBX197_0 = value; }
                public bool DB2_DBX197_11 { get => DB2_DBX197_1; set => DB2_DBX197_1 = value; }
            }
        }

        public struct Guidens
        {
            private bool M604_0;
            private bool M604_1;
            private bool Q102_6;

            private bool M604_2;
            private bool M604_3;
            private bool Q103_0;

            private bool M604_4;
            private bool M604_5;
            private bool Q103_2;

            public bool M604_01 { get => M604_0; set => M604_0 = value; }
            public bool M604_11 { get => M604_1; set => M604_1 = value; }
            public bool Q102_61 { get => Q102_6; set => Q102_6 = value; }
            public bool M604_21 { get => M604_2; set => M604_2 = value; }
            public bool M604_31 { get => M604_3; set => M604_3 = value; }
            public bool Q103_01 { get => Q103_0; set => Q103_0 = value; }
            public bool M604_41 { get => M604_4; set => M604_4 = value; }
            public bool M604_51 { get => M604_5; set => M604_5 = value; }
            public bool Q103_21 { get => Q103_2; set => Q103_2 = value; }
        }


    }
}
