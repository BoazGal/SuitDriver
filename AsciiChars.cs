using System;
using System.Collections.Generic;
using System.Text;

namespace SuitDriver
{
    static class AsciiChars
    {

        public static int SOH = 1;
        public static int STX = 2;
        public static int ETX = 3;
        public static int EOT = 4;
        public static int ENQ = 5;
        public static int ACK = 6;
        public static int LF = '\n';
        public static int CR = '\r';
        public static int DLE = 16;
        public static int DC1 = 17;
        public static int NACK = 21;
        public static int SYN = 22;
        public static int ETB = 23;


        public static string S_SOH    = (Convert.ToChar(SOH)).ToString();
        public static string S_STX    = (Convert.ToChar(STX)).ToString();
        public static string S_ETX    = (Convert.ToChar(ETX)).ToString();
        public static string S_EOT    = (Convert.ToChar(EOT)).ToString();
        public static string S_ENQ    = (Convert.ToChar(ENQ)).ToString();
        public static string S_ACK    = (Convert.ToChar(ACK)).ToString();
        public static string S_LF     = (Convert.ToChar(LF)).ToString();
        public static string S_CR     = (Convert.ToChar(CR)).ToString();
        public static string S_DLE    = (Convert.ToChar(DLE)).ToString();
        public static string S_DC1    = (Convert.ToChar(DC1)).ToString();
        public static string S_NACK   = (Convert.ToChar(NACK)).ToString();
        public static string S_SYN    = (Convert.ToChar(SYN)).ToString();
        public static string S_ETB    = (Convert.ToChar(ETB)).ToString();
    }
}
