using System;
using System.Collections.Generic;
using System.Text;

namespace SuitDriver
{

    class LogicDevice
    {
        NetworkLine _line;
        MessagesHandler _messagesHandler;

        public LogicDevice(string ip, int port)
        {
            _line = new NetworkLine(ip, port);
            _messagesHandler = new MessagesHandler();

        }
        public void ReadMessage()
        {

            string startChar = _line.ReadByLength(1);
            if (startChar != AsciiChars.S_ENQ)
                startChar = TransmitRequestMessage();

            // Accept the ENQ symbol
            if (startChar == AsciiChars.S_ENQ)
            {
                _line.Send(AsciiChars.S_ACK);
                ReadMsg();

            }
        }

        private void ReadMsg()
        {
            string startChar;
            do
            {
                // Skip the STX in the beginning
                startChar = _line.ReadByLength(1);
                if (startChar == AsciiChars.S_STX)
                {
                    // Read the actual message up to the ETX
                    string message = _line.ReadUpTo(AsciiChars.ETX, AsciiChars.ETB);

                    // Read The checksum.
                    string checksum = _line.ReadByLength(2);

                    // Calculate out own checksum and compare
                    // need to implement ASTM checksum


                    // Read the following <CR> and <LF>
                    _line.ReadByLength(2);

                    // Send ack that the message is OK
                    _line.Send(AsciiChars.S_ACK);
                    ReceiveResultMessage(message);
                }
                else if (startChar == AsciiChars.S_STX)
                    TransmitRequestMessage();
                else
                {
                    Console.Write("Unexpected character ");
                    Console.Write(startChar);
                }
            } while (startChar != AsciiChars.S_EOT);

        }
        public string TransmitRequestMessage()
        {
            return "";
        }

        public void ReceiveResultMessage(string message)
        {
            string[] words = message.Split('|');
            string messageType = words[0];
            char type = messageType[messageType.Length-1];
            switch (type)
            {
                case 'H':
                    _messagesHandler._level = ASTMStackLevel.COMM_START;
                    break;

                case 'M':
                    break;

                case 'P':
                    _messagesHandler._level = ASTMStackLevel.PATIENT_LEVEL;
                    _messagesHandler.PatientMessage(words);
                    break;

                case 'R':
                    _messagesHandler.OrderMessage(words);
                    break;

                case 'X':
                    _messagesHandler.ResultMessage(words);
                    break;

                case 'C':
                    _messagesHandler.ResultCommentMessage(words);
                    break;

                case 'S':
                    _messagesHandler.QCMessage(words);
                    break;

                case 'L':
                    _messagesHandler.TerminationMessage(words);
                    break;

                case 'Q':
                    _messagesHandler.QueryMessage(words);
                    break;

                default:
                    Console.WriteLine("No handler for type");
                    Console.WriteLine(type);
                    break;
            }


        }
    }

    //public 

}
