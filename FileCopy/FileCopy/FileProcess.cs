using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Acty.Skillup.FileCopy
{
    #region Delegatesasd
    /// <summary>
    /// Progress changes delegate
    /// </summary>
    /// <param name="lBytesCopied">Bytes copied</param>
    /// <param name="lTotalBytes">Total size in bytes</param>
    /// <param name="lSpeed">Speed</param>
    /// <param name="lTimeRemaining">Time remaining</param>
    /// <param name="iPercentValue">Percentage</param>
    public delegate void ProgressChanged(long lTotalBytesCopied, long lTotalBytes, double lSpeed, long lTimeRemaining, int iPercentValue);

    /// <summary>
    /// Progress completed delegate
    /// </summary>
    public delegate void ProgressCompleted();

    /// <summary>
    /// Show file copy error delegate
    /// </summary>
    public delegate void ShowFileCopyError(string sError, string sApplicationName, MessageBoxButtons objMessageBoxButton, MessageBoxIcon objMessageIcon);

    #endregion

    /// <summary>
    /// File process
    /// </summary>
    public class FileProcess
    {
        #region Events

        /// <summary>
        /// Progress changes event args
        /// </summary>
        public event ProgressChanged ProgressChangedEvent;

        /// <summary>
        /// Progress completed event args
        /// </summary>
        public event ProgressCompleted ProgressCompletedEvent;

        /// <summary>
        /// Event when error occurs in file copy process
        /// </summary>
        public event ShowFileCopyError FileCopyError;

        #endregion

        #region Member variables 

        /// <summary>
        /// If true then cancel copy process
        /// </summary>
        public bool m_Cancel = false;

        /// <summary>
        /// Manual reset event to pause and resume thread
        /// </summary>
        public ManualResetEvent objManualResetEvent = new ManualResetEvent(true);

        /// <summary>
        /// Source file object
        /// </summary>
        private FileStream objSourceFile;

        /// <summary>
        /// Destination file object
        /// </summary>
        private FileStream objDestinationFile;

        /// <summary>
        /// Application name
        /// </summary>
        public string sApplicationName;

        #endregion

        #region Properties

        /// <summary>
        /// Destination file path
        /// </summary>
        public string DestinationFilePath { get; set; }

        /// <summary>
        /// Selected file path in text box
        /// </summary>
        public string SourceFilePath { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// File copy method
        /// </summary>
        public void DoCopy()
        {
            try
            {
                using (objSourceFile = new FileStream(SourceFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (objDestinationFile = new FileStream(DestinationFilePath, FileMode.Create))
                    {
                        byte[] btFileByte = new byte[Constants.BUFFER_SIZE];

                        int iByteRead = 0;
                        long lRemainingByte = 0;

                        // Noted starting time 
                        DateTime dtStartTime = DateTime.Now;
                        Stopwatch objStopwatch = new Stopwatch();

                        while ((iByteRead = objSourceFile.Read(btFileByte, Constants.READ_FILE_OFFSET, btFileByte.Length)) > 0)
                        {
                            if (m_Cancel)
                            {   // If bool is true for cancel
                                break;
                            }

                            DateTime dtCurrentTime = new DateTime();
                            objStopwatch = new Stopwatch();

                            // Noted current time
                            dtCurrentTime = DateTime.Now;
                            objStopwatch.Start();

                            objDestinationFile.Write(btFileByte, Constants.WRITE_FILE_OFFSET, iByteRead);

                            objStopwatch.Stop();

                            // Calculated Time remaining of file copy process by subtracting Start time from Current time
                            TimeSpan objTimeRemaining = dtCurrentTime - dtStartTime;

                            // Calculated remaining bytes by subtracting Destination file length from source file length
                            // to find time remaining to copy remaining bytes
                            lRemainingByte = objSourceFile.Length - objDestinationFile.Length;

                            // Update progress
                            UpdateProgress(lRemainingByte , iByteRead , objStopwatch, objTimeRemaining);
                            objManualResetEvent.WaitOne();
                        }
                    }
                }
            }
            catch (ArgumentNullException)
            {
                FileCopyError(Constants.ARGUMENT_NULL_ERROR, sApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentOutOfRangeException)
            {
                FileCopyError(Constants.ARGUMENT_OUT_OF_RANGE, sApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                FileCopyError(Constants.ARGUMENT_ERROR, sApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ObjectDisposedException)
            {
                FileCopyError(Constants.OBJECT_DISPOSED_ERROR, sApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                FileCopyError(Constants.UNAUTHORIZED_ACCESS_ERROR, sApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException)
            {
                FileCopyError(Constants.FILE_NOT_FOUND_ERROR, sApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException)
            {
                FileCopyError(Constants.NOT_SUPPORTED_ERROR, sApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PathTooLongException)
            {
                FileCopyError(Constants.PATH_TOO_LONG_ERROR, sApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                FileCopyError(Constants.IO_ERROR, sApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                FileCopyError(Constants.UNKNOWN_ERROR, sApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ProgressCompletedEvent();
            }
        }

        /// <summary>
        /// Update progress
        /// </summary>
        private void UpdateProgress(long lRemainingByte , int iByteRead , Stopwatch objStopwatch, TimeSpan objTimeRemaining)
        {
            // Calculated speed by dividing bytes read in 1 iteration by time elapsed in Milli-seconds to copy bytes
            long lSpeed = (long)(iByteRead / objStopwatch.Elapsed.TotalMilliseconds);

            // Calculated total time remaining by 
            long lTimeRemaining = (long)(objTimeRemaining.TotalMilliseconds * lRemainingByte /objDestinationFile.Length);

            // Calculated percent by division of source file length and 
            // Multiplication of destination file length and 100 for percentage
            int iPercentValue = (int)(objDestinationFile.Length * Constants.PERCENT_CONVERSION / objSourceFile.Length);

            ProgressChangedEvent(objDestinationFile.Length, objSourceFile.Length, lSpeed, lTimeRemaining, iPercentValue);
        }

        #endregion
    }

}
