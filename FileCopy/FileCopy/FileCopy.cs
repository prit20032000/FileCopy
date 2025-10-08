using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Acty.Skillup.FileCopy
{
    /// <summary>
    /// Form class
    /// </summary>
    public partial class FileCopy : Form
    {
        #region Member Variables

        /// <summary>
        /// Thread object
        /// </summary>
        private Thread m_ObjThread;

        /// <summary>
        /// File process object
        /// </summary>
        private FileProcess objFileProcess = new FileProcess();

        #endregion

        #region Properties

        /// <summary>
        /// Application name
        /// </summary>
        public string ApplicationName
        {
            get { return Process.GetCurrentProcess().ProcessName; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Form constructor
        /// </summary>
        public FileCopy()
        {
            InitializeComponent();
            FormClosing += Form_FormClosing;
            objFileProcess.FileCopyError += ObjFileProcess_FileCopyError;
        }

        /// <summary>
        /// File copy error event
        /// </summary>
        /// <param name="sError">Error message</param>
        /// <param name="sApplicationName">Application name</param>
        /// <param name="objMessageBoxButton">Message box button</param>
        /// <param name="objMessageIcon">Message box icon</param>
        private void ObjFileProcess_FileCopyError(string sError, string sApplicationName, MessageBoxButtons objMessageBoxButton, MessageBoxIcon objMessageIcon)
        {
            MessageBox.Show(sError, ApplicationName, objMessageBoxButton, objMessageIcon);
        }

        #endregion

        #region private Methods

        /// <summary>
        /// Start button click event
        /// </summary>
        /// <param name="objSender">Sender object</param>
        /// <param name="sStartButtonEventArgs">Start button click event args</param>
        private void Start_Click(object objSender, EventArgs sStartButtonEventArgs)
        {
            switch (ButtonStart.Text)
            {
                case Constants.START:

                    if (AreTextBoxValid())
                    {   // If text box parameters are valid
                        StartFileCopy();
                    }

                    break;
                case Constants.CANCEL:
                    CancelFileCopy();
                    break;
            }
        }

        /// <summary>
        /// Start file copy process
        /// </summary>
        private void StartFileCopy()
        {
            objFileProcess.DestinationFilePath = TextBoxFilePath.Text;

            // Set start copy boolean as true to start execution of file copy process
            bool bIsStartCopy = true;

            if (File.Exists(Path.Combine(TextBoxFolderPath.Text, Path.GetFileName(TextBoxFilePath.Text))))
            {   // If file exists then ask user whether he/she wants to continue or not
                DialogResult objDialogBoxResult = MessageBox.Show(Constants.WANT_TO_CONTINUE_IF_FILE_EXISTS, ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (objDialogBoxResult == DialogResult.No)
                {   // If dialog result is no then Start file copy boolean as false to prevent file coy process
                    bIsStartCopy = false;
                }
                else
                {
                    CreateDestinationFile();
                }
            }

            if (bIsStartCopy)
            {   // If true then start copy process
                StartThread();
            }

        }

        /// <summary>
        /// Thread start method
        /// </summary>
        private void StartThread()
        {
            // Progress changed event
            objFileProcess.ProgressChangedEvent += ObjFileProcess_ProgressChangedEvent;

            // Progress completed event
            objFileProcess.ProgressCompletedEvent += ObjFileProcess_ProgressCompletedEvent;

            // If file is copied once and again copy is called
            objFileProcess.m_Cancel = false;

            objFileProcess.SourceFilePath = TextBoxFilePath.Text;
            objFileProcess.DestinationFilePath = Path.Combine(TextBoxFolderPath.Text, Path.GetFileName(objFileProcess.DestinationFilePath));

            // Thread created
            m_ObjThread = new Thread(objFileProcess.DoCopy);

            // Thread start
            m_ObjThread.Start();

            // Show controls on the basis of boolean passed
            ShowControls(true);
        }

        /// <summary>
        /// File name creation if exists
        /// </summary>
        /// <returns>File name</returns>
        private string CreateDestinationFile()
        {
            int iSerialNumber = Constants.MINIMUM_DUPLICATE_FILE_NUMBER;
            int iFileCount = Constants.SINGLE_FILE_COUNT;
            FileInfo objFileInfo = new FileInfo(TextBoxFilePath.Text);
            objFileProcess.DestinationFilePath = TextBoxFilePath.Text;

            // If file exists then check for its count 
            while (File.Exists(Path.Combine(TextBoxFolderPath.Text, Path.GetFileName(objFileProcess.DestinationFilePath))))
            {
                // Replace extension with empty string to append string as copy and its serial number to file name
                objFileProcess.DestinationFilePath = objFileInfo.FullName.Replace(objFileInfo.Extension, string.Empty);

                if (iFileCount == Constants.SINGLE_FILE_COUNT)
                {   // If it is first file then append copy as suffix
                    objFileProcess.DestinationFilePath = objFileProcess.DestinationFilePath + $"{Constants.COPY_FILE_SUFFIX}" + objFileInfo.Extension;
                    iFileCount++;
                }
                else
                {
                    objFileProcess.DestinationFilePath = objFileProcess.DestinationFilePath + $"{Constants.COPY_FILE_SUFFIX}({iSerialNumber++})" + objFileInfo.Extension;
                }
            }
            return objFileProcess.DestinationFilePath;
        }

        /// <summary>
        /// Cancel file copy process
        /// </summary>
        private void CancelFileCopy()
        {
            // Pause thread execution
            objFileProcess.objManualResetEvent.Reset();
            DialogResult objDialogBoxResult = MessageBox.Show(Constants.WANT_TO_CANCEL_QUESTION, ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (objDialogBoxResult == DialogResult.Yes)
            {
                // Set boolean for cancel as true
                objFileProcess.m_Cancel = true;
            }

            // Resume thread execution
            objFileProcess.objManualResetEvent.Set();
        }

        /// <summary>
        /// File select button click event
        /// </summary>
        /// <param name="objSender">Sender object</param>
        /// <param name="sFileOpenEventArgs">File dialog open event args</param>
        private void ButtonFile_Click(object objSender, EventArgs sFileOpenEventArgs)
        {
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Title = Constants.CHOOSE_FILE;
            objOpenFileDialog.Filter = Constants.FILE_SELECTION_FILTER;
            objOpenFileDialog.Multiselect = false;
            objOpenFileDialog.CheckPathExists = true;

            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextBoxFilePath.Text = objOpenFileDialog.FileName;
            }
        }

        /// <summary>
        /// Folder select button click event
        /// </summary>
        /// <param name="objSender">Sender object</param>
        /// <param name="sFolderOpenEventArgs">Folder dialog open event args</param>
        private void ButtonFolderSelect_Click(object objSender, EventArgs sFolderOpenEventArgs)
        {
            FolderBrowserDialog objFolderBrowserDialog = new FolderBrowserDialog();
            openFileDialog1 = new OpenFileDialog();

            if (objFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                TextBoxFolderPath.Text = objFolderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Form closing event
        /// </summary>
        /// <param name="objSender">Sender object</param>
        /// <param name="sFormClosingEventArgs">Form closing event args</param>
        private void Form_FormClosing(object objSender, FormClosingEventArgs sFormClosingEventArgs)
        {
            // Pause thread execution
            objFileProcess.objManualResetEvent.Reset();

            DialogResult objDialogBoxResult = MessageBox.Show(Constants.WANT_TO_EXIT_QUESTION, ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (objDialogBoxResult == DialogResult.No)
            {   // If dialog result is no

                // True to cancel closure of form
                sFormClosingEventArgs.Cancel = true;
            }
            else
            {

                // set boolean of cancel as true for cancellation
                objFileProcess.m_Cancel = true;
            }

            // Resume thread execution
            objFileProcess.objManualResetEvent.Set();
        }

        /// <summary>
        /// Progress completed event
        /// </summary>
        private void ObjFileProcess_ProgressCompletedEvent()
        {
            if (objFileProcess.m_Cancel)
            {   // If cancel is true

                // Delete file if file exists at specified location
                ErrorCode eErrorCode = Utility.DeleteIfExists(objFileProcess.DestinationFilePath);

                if (eErrorCode != ErrorCode.Success)
                {   // If error code is not success
                    Error.DisplayFileDeleteError(eErrorCode);
                }
            }
            else if (File.Exists(objFileProcess.DestinationFilePath))
            {
                MessageBox.Show(Constants.FILE_COPY_COMPLETED, ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (IsHandleCreated)
            {
                Invoke((Action)(() =>
                {
                    // Set progress bar value as 0
                    ProgressBarPercent.Value = Constants.DEFAULT_PROGRESS_BAR_VALUE;

                    // Show controls on the basis of boolean value
                    ShowControls(false);
                }));
            }

            // Aborted thread after its use because it is no longer usable
            m_ObjThread.Abort();
        }

        /// <summary>
        /// Progress changes event
        /// </summary>
        /// <param name="lTotalBytesCopied">Bytes copied</param>
        /// <param name="lTotalBytes">Total bytes</param>
        /// <param name="lSpeed">Speed</param>
        /// <param name="lTimeRemaining">Time remaining</param>
        /// <param name="iPercentValue">Percent value</param>
        private void ObjFileProcess_ProgressChangedEvent(long lTotalBytesCopied, long lTotalBytes, double lSpeed, long lTimeRemaining, int iPercentValue)
        {
            if (IsHandleCreated)
            {   // If control has handle then perform action

                Invoke((Action)(() =>
                {
                    string sTotalBytes = FormatedSize(lTotalBytes);
                    string sSpeed = FormatedSize((long)lSpeed);
                    string sBytesCopied = FormatedSize(lTotalBytesCopied);

                    Time objTime = new Time();
                    string sTimeRemaining = objTime.FormatTime(lTimeRemaining);

                    ProgressBarPercent.Value = iPercentValue;
                    LabelBytes.Text = $"{Constants.COPIED_DATA} {sBytesCopied} / {sTotalBytes}";
                    LabelSpeed.Text = $"{Constants.SPEED}{sSpeed}{Constants.SPEED_PER_SECOND}";
                    LabelTimeRemaining.Text = $"{Constants.TIME_REMAINING}{sTimeRemaining}";
                    LabelPercent.Text = $"{iPercentValue}%";
                }));
            }
        }

        /// <summary>
        /// Show Controls on the basis of boolean
        /// </summary>
        /// <param name="bIsShow">Show controls if boolean is true else hide controls</param>
        private void ShowControls(bool bIsShow)
        {
            ProgressBarPercent.Visible = bIsShow;
            LabelBytes.Visible = bIsShow;
            LabelPercent.Visible = bIsShow;
            LabelSpeed.Visible = bIsShow;
            LabelTimeRemaining.Visible = bIsShow;
            ButtonFileSelect.Enabled = !bIsShow;
            ButtonFolderSelect.Enabled = !bIsShow;
            TextBoxFilePath.Enabled = !bIsShow;
            TextBoxFolderPath.Enabled = !bIsShow;

            if (bIsShow)
            {   // If boolean is true for show
                ButtonStart.Text = Constants.CANCEL;
            }
            else
            {
                ButtonStart.Text = Constants.START;
            }
        }

        /// <summary>
        /// Text box parameters validation
        /// </summary>
        /// <returns>True if valid else false</returns>
        private bool AreTextBoxValid()
        {
            if (TextBoxFilePath.Text == string.Empty)
            {   // If file path text box is empty then show error
                MessageBox.Show(Constants.ENTER_FILE_PATH_ERROR, ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (!File.Exists(TextBoxFilePath.Text))
            {   // If text box file path not exists then show error
                MessageBox.Show(Constants.FILE_NOT_FOUND_ERROR, ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (TextBoxFolderPath.Text == string.Empty)
            {   // If folder path text box is empty then show error
                MessageBox.Show(Constants.ENTER_FOLDER_PATH_ERROR, ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (!Directory.Exists(TextBoxFolderPath.Text))
            {   // If folder path not exists then show error
                MessageBox.Show(Constants.FOLDER_NOT_FOUND_ERROR, ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get formated size
        /// </summary>
        /// <param name="lBytes">Total bytes</param>
        /// <returns>Formated string</returns>
        private string FormatedSize(long lBytes)
        {
            long KB = Constants.MAXIMUM_KILO_BYTES, MB = KB * Constants.MAXIMUM_KILO_BYTES, GB = MB * Constants.MAXIMUM_KILO_BYTES;
            double dSize = lBytes;
            string sSuffix = nameof(lBytes);

            if (lBytes >= GB)
            {
                dSize = Math.Round((double)lBytes / GB, 2);
                sSuffix = nameof(GB);
            }
            else if (lBytes >= MB)
            {
                dSize = Math.Round((double)lBytes / MB, 2);
                sSuffix = nameof(MB);
            }
            else if (lBytes >= KB)
            {
                dSize = Math.Round((double)lBytes / KB, 2);
                sSuffix = nameof(KB);
            }

            return $"{dSize} {sSuffix}";
        }
    }
    #endregion
}