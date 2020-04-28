using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace InstantMessenger
{
    public class IMClient
    {
        Thread tcpThread;
        bool _conn = false;
        bool _logged = false;
        string _user;
        string _pass;
        bool reg;

        public string Server { get { return "localhost"; } }
        public int Port { get { return 2000; } }

        public bool IsLoggedIn { get { return _logged; } }
        public string UserName { get { return _user; } }
        public string Password { get { return _pass; } }

        void connect(string user, string password, bool register)
        {
            if (!_conn)
            {
                _conn = true;
                _user = user;
                _pass = password;
                reg = register;
                tcpThread = new Thread(new ThreadStart(SetupConn));
                tcpThread.Start();
            }
        }
        public void Login(string user, string password)
        {
            connect(user, password, false);
        }
        public void Register(string user, string password)
        {
            connect(user, password, true);
        }
        public void Disconnect()
        {
            if (_conn)
                CloseConn();
        }

        public void IsAvailable(string user)
        {
            if (_conn)
            {
                bw.Write(IM_IsAvailable);
                bw.Write(user);
                bw.Flush();
            }
        }
        public void SendMessage(string to, string msg)
        {
            if (_conn)
            {
                bw.Write(IM_Send);
                bw.Write(to);
                bw.Write(msg);
                bw.Flush();
            }
        }
        public void SendFile(string to, byte[] tmp)
        {
            if (_conn)
            {
                bw.Write(IM_SendFile);
                bw.Write(to);
                bw.Write(tmp);
                bw.Flush();
            }
        }


        public event EventHandler LoginOK;
        public event EventHandler RegisterOK;
        public event IMErrorEventHandler LoginFailed;
        public event IMErrorEventHandler RegisterFailed;
        public event EventHandler Disconnected;
        public event IMAvailEventHandler UserAvailable;
        public event IMReceivedEventHandler MessageReceived;
        public event IMReceivedEventHandler FileReceived;

        virtual protected void OnLoginOK()
        {
            if (LoginOK != null)
                LoginOK(this, EventArgs.Empty);
        }
        virtual protected void OnRegisterOK()
        {
            if (RegisterOK != null)
                RegisterOK(this, EventArgs.Empty);
        }
        virtual protected void OnLoginFailed(IMErrorEventArgs e)
        {
            if (LoginFailed != null)
                LoginFailed(this, e);
        }
        virtual protected void OnRegisterFailed(IMErrorEventArgs e)
        {
            if (RegisterFailed != null)
                RegisterFailed(this, e);
        }
        virtual protected void OnDisconnected()
        {
            if (Disconnected != null)
                Disconnected(this, EventArgs.Empty);
        }
        virtual protected void OnUserAvail(IMAvailEventArgs e)
        {
            if (UserAvailable != null)
                UserAvailable(this, e);
        }
        virtual protected void OnMessageReceived(IMReceivedEventArgs e)
        {
            if (MessageReceived != null)
                MessageReceived(this, e);
        }
        virtual protected void OnFileReceived(IMReceivedEventArgs e)
        {
            if (FileReceived != null)
            {
                FileReceived(this, e);
            }
        }

        TcpClient client;
        NetworkStream netStream;
        SslStream ssl;
        BinaryReader br;
        BinaryWriter bw;

        void SetupConn()
        {
            client = new TcpClient(Server, Port);
            netStream = client.GetStream();
            ssl = new SslStream(netStream, false, new RemoteCertificateValidationCallback(ValidateCert));
            ssl.AuthenticateAsClient("InstantMessengerServer");


            br = new BinaryReader(ssl, Encoding.UTF8);
            bw = new BinaryWriter(ssl, Encoding.UTF8);


            int hello = br.ReadInt32();
            if (hello == IM_Hello)
            {

                bw.Write(IM_Hello);

                bw.Write(reg ? IM_Register : IM_Login);
                bw.Write(UserName);
                bw.Write(Password);
                bw.Flush();

                byte ans = br.ReadByte();
                if (ans == IM_OK)
                {
                    if (reg)
                        OnRegisterOK();
                    OnLoginOK();
                    Receiver();
                }
                else
                {
                    IMErrorEventArgs err = new IMErrorEventArgs((IMError)ans);
                    if (reg)
                        OnRegisterFailed(err);
                    else
                        OnLoginFailed(err);
                }
            }
            if (_conn)
                CloseConn();
        }
        void CloseConn()
        {
            br.Close();
            bw.Close();
            ssl.Close();
            netStream.Close();
            client.Close();
            OnDisconnected();
            _conn = false;
        }
        void Receiver()
        {
            _logged = true;

            try
            {
                while (client.Connected)
                {
                    byte type = br.ReadByte();

                    if (type == IM_IsAvailable)
                    {
                        string user = br.ReadString();
                        bool isAvail = br.ReadBoolean();
                        OnUserAvail(new IMAvailEventArgs(user, isAvail));
                    }
                    else if (type == IM_Received)
                    {
                        string from = br.ReadString();
                        string msg = br.ReadString();
                        OnMessageReceived(new IMReceivedEventArgs(from, msg));
                    }
                    else if (type == IM_SendFile)
                    {
                        string from = br.ReadString();
                        string msg = br.ReadString();
                        OnFileReceived(new IMReceivedEventArgs(from, msg));
                    }
                }
            }
            catch (IOException) { }

            _logged = false;
        }

        // Packet types
        public const int IM_Hello = 2012;      // Hello
        public const byte IM_OK = 0;           // OK
        public const byte IM_Login = 1;        // Login
        public const byte IM_Register = 2;     // Register
        public const byte IM_TooUsername = 3;  // Too long username
        public const byte IM_TooPassword = 4;  // Too long password
        public const byte IM_Exists = 5;       // Already exists
        public const byte IM_NoExists = 6;     // Doesn't exist
        public const byte IM_WrongPass = 7;    // Wrong password
        public const byte IM_IsAvailable = 8;  // Is user available?
        public const byte IM_Send = 9;         // Send message
        public const byte IM_Received = 10;    // Message received
        public const byte IM_SendFile = 11;     // Send file

        public static bool ValidateCert(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
