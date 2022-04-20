using MifareVB1;
using MifareVB1.Mifare_Change_Key;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFIDWindowsForm
{
    public partial class Form1 : Form
    {
        private PcscReader _pcscReader;
        private CardPolling _cardPolling;
        private CardSelector2 _cardSelector = new CardSelector2();

        private string tmpStr;
        private string tmpStr2;
        public long retCode, hContext, hCard, Protocol;
        public bool connActive, autoDet;
        public byte[] SendBuff = new byte[263], RecvBuff = new byte[263];
        public int SendLen, RecvLen, nBytesRet, reqType, Aprotocol;
        public int dwProtocol;
        public int cbPciLength;
        // Public RdrState As SCARD_READERSTATE
        public long dwState, dwActProtocol;
        // Public pioSendRequest, pioRecvRequest As SCARD_IO_REQUEST
        private ReaderFunction readerFunctions_;
        private MifareClassic mifareClassic;
        private MifareVB1.Acs.Readers.Pcsc.CardSelector cardSelector_;
        private byte currentSector;
        private byte currentSectorTrailer;
        private string sCardName = "";
        public Form1()
        {
            InitializeComponent();
        }
        #region RFID CARD READING FUNCTIONS
        public void OnThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void Init()
        {
            string[] readerList;

            try
            {
                _pcscReader = new PcscReader();
                _cardPolling = new CardPolling();

                // register to event on card found
                _cardPolling.OnCardFound += cardPolling_OnCardFound;

                // register to event on card remove
                _cardPolling.OnCardRemoved += cardPolling_OnCardRemoved;

                // register to event on error
                _cardPolling.OnError += cardPolling_OnError;

                _cardPolling.StopPolling();


                // get all smart card reader connected to computer
                readerList = _pcscReader.getReaderList();

                comboboxReaderNames.Items.Clear();

                if (readerList.Length > 0)
                {
                    TextBoxStatus.Text = "Start polling to detect card in reader.";

                    comboboxReaderNames.Items.AddRange(readerList);

                    comboboxReaderNames.SelectedIndex = 0;

                    // Get the reader name for contactless (picc) and contact reader
                    for (int i = 0; i <= comboboxReaderNames.Items.Count - 1; i++)
                        _cardPolling.add(comboboxReaderNames.Items[i].ToString());
                }
            }
            catch (PcscException pcscException)
            {
                MessageBox.Show("[" + pcscException.errorCode.ToString() + "] " + pcscException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // MessageBox.Show(pcscException.Message, "PCSC Exception")

            catch (Exception generalException)
            {
                MessageBox.Show(generalException.Message);
            }
        }

        private void startpolling()
        {
            if (_cardPolling == null)
                return;

            _cardPolling.start(comboboxReaderNames.Text);
        }

        private void Stoppolling()
        {
            _cardPolling.StopPolling();

            TextBoxStatus.Text = "Polling routine ended.";
            TextBoxATR.Text = string.Empty;
            TextBoxCardType.Text = string.Empty;
        }

        private void cardPolling_OnCardRemoved(object sender, CardPollingEventArg e)
        {
            TextBoxStatus.Text = "Card is removed";
            TextBoxATR.Text = string.Empty;
            TextBoxCardType.Text = string.Empty;
            lblcardnumber.Text = string.Empty;
            txtname.Text = string.Empty;
            Txtaddress.Text = string.Empty;
        }

        private void cardPolling_OnCardFound(object sender, CardPollingEventArg e)
        {
            try
            {
                _pcscReader.connect(comboboxReaderNames.Text);
                _cardSelector.pcscReader = _pcscReader;

                byte[] atr = _pcscReader.getAtr();

                TextBoxStatus.Text = "Card found";
                TextBoxATR.Text = Helper.byteAsString(atr, true);
                TextBoxCardType.Text = _cardSelector.readCardType(atr, (byte)atr.Length);

                Initialize();
                connect();
                Loadkey();
                Authenticate();
                ReadCardnumber();
                ReadName();
                ReadAddress();
                Authenticate2();
            }
            catch (Exception exception)
            {
                TextBoxStatus.Text = "Card Removed";
                TextBoxATR.Text = string.Empty;
                TextBoxCardType.Text = string.Empty;
            }
        }

        private void cardPolling_OnError(object sender, CardPollingErrorEventArg e)
        {
            _cardPolling.StopPolling();

            TextBoxStatus.Text = "Error in polling";
            TextBoxATR.Text = string.Empty;
            TextBoxCardType.Text = string.Empty;
        }

        private byte[] getBytes(string stringBytes, char delimeter)
        {
            int counter = 0;
            byte tmpByte;
            string[] arrayString = stringBytes.Split(delimeter);
            byte[] bytesResult = new byte[arrayString.Length - 1 + 1];


            foreach (string str in arrayString)
            {
                if (byte.TryParse(str, System.Globalization.NumberStyles.HexNumber, null, out tmpByte))
                {
                    bytesResult[counter] = tmpByte;
                    counter += 1;
                }
                else
                    return null;
            }

            return bytesResult;
        }

        private void readerFunction_OnSendCommand(object sender, TransmitApduEventArg e)
        {
            addMsgToLog("\r" + "\n" + "<< ", e.data, e.data.Length);
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Stoppolling();
            this.Close();
        }

        private void readerFunction_OnReceivedCommand(object sender, TransmitApduEventArg e)
        {
            addMsgToLog(">> ", e.data, e.data.Length);
        }

        private void Initialize()
        {
            try
            {
                string[] readerList;

                // InitMenu()

                readerFunctions_ = new ReaderFunction();

                // Register to event OnReceivedCommand
                readerFunctions_.OnReceivedCommand += readerFunction_OnReceivedCommand;

                // Register to event OnSendCommand
                readerFunctions_.OnSendCommand += readerFunction_OnSendCommand;

                // Get all smart card reader connected to computer
                readerList = readerFunctions_.getReaderList();
                comboboxReaderNames.Items.Clear();
                comboboxReaderNames.Items.AddRange(readerList);

                if (comboboxReaderNames.Items.Count > 0)
                    comboboxReaderNames.SelectedIndex = 0;


                addMsgToLog(" ");
                addMsgToLog("\n" + "Initialize success");
            }

            catch (PcscException pcscException)
            {
                addTitleToLog(false, "[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
                showErrorMessage("[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
            }
            catch (Exception generalException)
            {
                addMsgToLog(generalException.Message);
                showErrorMessage(generalException.Message);
            }
        }

        private void connect()
        {
            byte[] atr = null;

            try
            {
                if (comboboxReaderNames.SelectedItem == null)
                {
                    showErrorMessage("Please select a reader");
                    return;
                }

                readerFunctions_.connect(comboboxReaderNames.SelectedItem.ToString());
                addMsgToLog("\n" + "Successfully connected to " + comboboxReaderNames.Text);

                // Initialize Mifare classic class
                mifareClassic = new MifareClassic(readerFunctions_.pcscConnection);


                readerFunctions_.getStatusChange(ref atr);
                cardSelector_ = new MifareVB1.Acs.Readers.Pcsc.CardSelector();
                cardSelector_.pcscReader = readerFunctions_;

                sCardName = cardSelector_.readCardType(atr, System.Convert.ToByte(atr.Length));

                if (sCardName != "Mifare Standard 1K" && sCardName != "Mifare Standard 4K")
                {
                    showErrorMessage("Card not supported." + "\r" + "\n" + "Please present Mifare Classic card.");



                    return;
                }

                addMsgToLog("Chip Type: " + sCardName);
            }
            catch (PcscException pcscException)
            {
                addTitleToLog(false, "[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
                showErrorMessage("[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
            }
            catch (Exception generalException)
            {
                addMsgToLog(generalException.Message);
                showErrorMessage(generalException.Message);
            }
        }

        private void Loadkey()
        {
            byte[] key = new byte[6];
            byte keyNumber = 0x20;
            KEY_STRUCTURE keyStructure = KEY_STRUCTURE.VOLATILE;
            byte Keystore = 0x0;
            // Dim i As String = "&HFF &HFF &HFF &HFF &HFF &HFF"
            // key = "&HFF &HFF &HFF &HFF &HFF &HFF"

            try
            {
                if (!byte.TryParse(Keystore.ToString(), out keyNumber) || keyNumber > 1)
                {
                    showErrorMessage("Please key-in Key Store Number from 00 to 01.");
                    // textboxKeyStoreNumber.Focus()
                    return;
                }

                // Key should be 6 bytes long
                key = getBytes(MaskedTextBoxKeyValueInput.Text.Trim(), ' ');
                if (key == null || key.Length != 6)
                {
                    showErrorMessage("Please key-in hex value for Key Value");
                    MaskedTextBoxKeyValueInput.Focus();
                    return;
                }

                addTitleToLog(false, "Load Authentication Key");
                readerFunctions_.loadAuthKey(keyStructure, keyNumber, key);
                addMsgToLog("Load Key success" + "\r" + "\n");
            }

            // groupBoxAuthenticationFunction.Enabled = True
            // groupBoxKeyType.Enabled = True

            catch (PcscException pcscException)
            {
                addTitleToLog(false, "[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
                showErrorMessage("[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
            }
            catch (Exception generalException)
            {
                addMsgToLog(generalException.Message);
                showErrorMessage(generalException.Message);
            }
        }

        private void Authenticate()
        {
            byte blockNumber;
            KEYTYPES keyType;
            byte keyNumber;
            byte[] key = new byte[6];

            try
            {
                keyType = KEYTYPES.ACR122_KEYTYPE_A;
                blockNumber = 0x0;


                keyType = KEYTYPES.ACR122_KEYTYPE_A;

                // keyType = KEYTYPES.ACR122_KEYTYPE_B


                keyNumber = 0x0;
                string BLOCK = "04";


                blockNumber = System.Convert.ToByte(System.Convert.ToInt32(BLOCK));





                addTitleToLog(false, "Authenticate Key");
                readerFunctions_.authenticate(blockNumber, keyType, keyNumber);

                addMsgToLog("Authenticate success");



                return;
            }
            catch (PcscException pcscException)
            {
                addTitleToLog(false, "[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
                showErrorMessage("[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
            }
            catch (Exception generalException)
            {
                addMsgToLog(generalException.Message);
                showErrorMessage(generalException.Message);
            }
        }

        private void Authenticate2()
        {
            byte blockNumber;
            KEYTYPES keyType;
            byte keyNumber;
            byte[] key = new byte[6];

            try
            {
                keyType = KEYTYPES.ACR122_KEYTYPE_A;
                blockNumber = 0x4;


                keyType = KEYTYPES.ACR122_KEYTYPE_A;

                // keyType = KEYTYPES.ACR122_KEYTYPE_B


                keyNumber = 0x0;
                string BLOCK = "04";


                blockNumber = System.Convert.ToByte(System.Convert.ToInt32(BLOCK));





                addTitleToLog(false, "Authenticate Key");
                readerFunctions_.authenticate(blockNumber, keyType, keyNumber);

                addMsgToLog("Authenticate success");



                return;
            }
            catch (PcscException pcscException)
            {
                addTitleToLog(false, "[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
                showErrorMessage("[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
            }
            catch (Exception generalException)
            {
                addMsgToLog(generalException.Message);
                showErrorMessage(generalException.Message);
            }
        }

        private void ReadCardnumber()
        {
            byte blockNumber = 0x0;
            byte[] data;
            int indx;
            byte length = 0x0;

            try
            {



                // blockNumber = CInt(textBoxStartBlock.Text)
                // length = CInt(textBoxLength.Text)



                addTitleToLog(false, "Read Binary");
                data = mifareClassic.readBinary1(blockNumber, length);

                tmpStr = "";

                for (indx = 0; indx <= data.Length - 1; indx++)
                    tmpStr = tmpStr + (data[indx]).ToString("x4");

                lblcardnumber.Text = tmpStr;
                int i = Convert.ToInt32(lblcardnumber.Text, 16);
                lblcardnumber.Text = i.ToString();


                addMsgToLog("Read success");

                return;
            }
            catch (PcscException pcscException)
            {
                addTitleToLog(false, "[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
                showErrorMessage("[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
            }
            catch (Exception generalException)
            {
                addMsgToLog(generalException.Message);
                showErrorMessage(generalException.Message);
            }
        }

        private void ReadName()
        {
            byte blockNumber = 0x4;
            byte[] data;
            int indx;
            byte length = 0x10;

            try
            {



                // blockNumber = CInt(textBoxStartBlock.Text)
                // length = CInt(textBoxLength.Text)



                addTitleToLog(false, "Read Binary");
                data = mifareClassic.readBinary(blockNumber, length);

                tmpStr = "";

                for (indx = 0; indx <= data.Length - 1; indx++)
                    tmpStr = tmpStr + (char)(data[indx]);

                txtname.Text = tmpStr;
                // Dim i As Integer = Convert.ToInt32(lblcardnumber.Text, 16)
                // lblcardnumber.Text = i
                addMsgToLog("Read success");

                return;
            }
            catch (PcscException pcscException)
            {
                addTitleToLog(false, "[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
                showErrorMessage("[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
            }
            catch (Exception generalException)
            {
                addMsgToLog(generalException.Message);
                showErrorMessage(generalException.Message);
            }
        }

        private void ReadAddress()
        {
            byte blockNumber = 0x6;
            byte[] data;
            int indx;
            byte length = 0x10;

            try
            {



                // blockNumber = CInt(textBoxStartBlock.Text)
                // length = CInt(textBoxLength.Text)



                addTitleToLog(false, "Read Binary");
                data = mifareClassic.readBinary(blockNumber, length);

                tmpStr = "";

                for (indx = 0; indx <= data.Length - 1; indx++)
                    tmpStr = tmpStr + (char)(data[indx]);

                Txtaddress.Text = tmpStr;
                // Dim i As Integer = Convert.ToInt32(lblcardnumber.Text, 16)
                // lblcardnumber.Text = i
                addMsgToLog("Read success");

                return;
            }
            catch (PcscException pcscException)
            {
                addTitleToLog(false, "[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
                showErrorMessage("[" + pcscException.errorCode.ToString() + "] " + pcscException.Message);
            }
            catch (Exception generalException)
            {
                addMsgToLog(generalException.Message);
                showErrorMessage(generalException.Message);
            }
        }

        private void addTitleToLog(bool isBold, string msg)
        {
            if (isBold)
                RichTextBoxApduLogs.SelectionFont = new Font(RichTextBoxApduLogs.Font.Name, RichTextBoxApduLogs.Font.Size, FontStyle.Bold);
            else
                RichTextBoxApduLogs.SelectionFont = new Font(RichTextBoxApduLogs.Font.Name, RichTextBoxApduLogs.Font.Size, FontStyle.Regular);
            RichTextBoxApduLogs.Select(RichTextBoxApduLogs.Text.Length, 0);
            RichTextBoxApduLogs.SelectionColor = Color.Black;
            RichTextBoxApduLogs.SelectedText = "\r" + "\n" + msg;
            RichTextBoxApduLogs.ScrollToCaret();
        }

        private void addMsgToLog(string prefix, byte[] tmpBytes, int len)
        {
            string msg = Helper.byteAsString(tmpBytes, 0, len, true);

            addMsgToLog(prefix + msg);
        }

        private void addMsgToLog(string msg)
        {
            RichTextBoxApduLogs.Select(RichTextBoxApduLogs.Text.Length, 0);
            RichTextBoxApduLogs.SelectedText = msg + "\r" + "\n";
            RichTextBoxApduLogs.ScrollToCaret();
        }

        private void showWarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void showErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            Application.ThreadException += OnThreadException;
            Init();
            startpolling();
        }
    }
}
