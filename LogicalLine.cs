using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace SuitDriver
{
    public interface LogicalLine
    {
        string ReadUpTo(int upTo);
        string ReadUpTo(int upTo1, int upTo2);
        string ReadByLength(int length);
        char ReadByte();
    }

    public class NetworkLine : LogicalLine
    {
        private TcpClient tcpClient;
        public NetworkLine(string ip, int port)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(ip, port);

        }

        public static string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
            {
                return reader.ReadToEnd();
            }
        }

        public string ReadUpTo(int upTo)
        {
            NetworkStream netStream = tcpClient.GetStream();
            netStream.ReadTimeout = 5000;
            byte[] bytes = new byte[2];
            MemoryStream writer = new MemoryStream();



            while (bytes[0] != upTo)
            {
                try
                {
                    // Read can return anything from 0 to numBytesToRead. 
                    // This method blocks until at least one byte is read.
                    netStream.Read(bytes, 0, (int)1);
                    writer.Write(bytes, 0, 1);
                }
                catch (IOException)
                {
                    // read timed out
                    return "";

                }

            }

            return StreamToString(writer);
        }
        public string ReadUpTo(int upTo1, int upTo2)
        {
            NetworkStream netStream = tcpClient.GetStream();
            netStream.ReadTimeout = 5000;
            byte[] bytes = new byte[2];
            MemoryStream writer = new MemoryStream();



            while (bytes[0] != upTo1 && bytes[0] != upTo2)
            {
                try
                {
                    // Read can return anything from 0 to numBytesToRead. 
                    // This method blocks until at least one byte is read.
                    netStream.Read(bytes, 0, (int)1);
                    writer.Write(bytes, 0, 1);
                }
                catch (IOException)
                {
                    // read timed out
                    return "";

                }
            }

            return StreamToString(writer);
        }

        public string ReadByLength(int length)
        {
            NetworkStream netStream = tcpClient.GetStream();
            netStream.ReadTimeout = 10000;
            byte[] data = new byte[length];
            using (MemoryStream ms = new MemoryStream())
            {

                try
                {
                    while (length > 0)
                    {
                        int numBytesRead;
                        numBytesRead = netStream.Read(data, 0, length);
                        ms.Write(data, 0, numBytesRead);
                        length -= numBytesRead;
                    }

                }
                catch (IOException)
                {
                    // read timed out
                    if (length>0)
                    {
                        Console.Write("unable to read all messahe");
                        return "";
                    }

                }
                return Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length);
            }
        }
        public char ReadByte()
        {
            NetworkStream netStream = tcpClient.GetStream();
            netStream.ReadTimeout = 5000;
            byte[] bytes = new byte[1];
            MemoryStream writer = new MemoryStream();


            try
            {
                // Read can return anything from 0 to numBytesToRead. 
                // This method blocks until at least one byte is read.
                netStream.Read(bytes, 0, (int)1);

            }
            catch (IOException)
            {
                // read timed out
                return '\0';

            }
            char[] asciiChars = new char[1];
            Encoding.ASCII.GetChars(bytes, 0, 1, asciiChars, 0);
            return asciiChars[0];
        }


        public bool Send (string message)
        {
            NetworkStream netStream = tcpClient.GetStream();
            byte[] myWriteBuffer = Encoding.ASCII.GetBytes(message);
            netStream.Write(myWriteBuffer, 0, myWriteBuffer.Length);
            return true;
        }

    }

}
