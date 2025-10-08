using System.Collections.Generic;
using System.Windows.Forms;

namespace Acty.Skillup.FileCopy
{
    #region Enum
    /// <summary>
    /// ErrorCode enums
    /// </summary>
    public enum ErrorCode1
    {
        Success,
        ArgumentOutOfRange,
        Argument,
        NotSupported,
        ArgumentNull,
        InvalidOperation,
        ObjectDisposed,
        IO,
        UnAuthorizedAccess,
        DirectoryNotFound,
        PathTooLong,
        FileNotFound,
        UnKnownError
    }
    #endregion

    /// <summary>
    /// Error class
    /// </summary>
    public class Error
    {
        /// <summary>
        /// File delete error messages 
        /// </summary>
        public static Dictionary<ErrorCode, string> m_FileDeleteError = new Dictionary<ErrorCode, string>
        {
            {ErrorCode.ArgumentOutOfRange, $"{Constants.ARGUMENT_OUT_OF_RANGE}"},
            {ErrorCode.FileNotFound, $"{Constants.FILE_NOT_FOUND_ERROR}"},
            {ErrorCode.DirectoryNotFound, $"{Constants.DIRECTORY_NOT_FOUND}"},
            {ErrorCode.NotSupported, $"{Constants.NOT_SUPPORTED_ERROR}"},
            {ErrorCode.UnAuthorizedAccess, $"{Constants.UNAUTHORIZED_ACCESS_ERROR}"},
            {ErrorCode.ObjectDisposed, $"{Constants.OBJECT_DISPOSED_ERROR}"},
            {ErrorCode.Argument, $"{Constants.ARGUMENT_ERROR}"},
            {ErrorCode.IO, $"{Constants.IO_ERROR}"},
            {ErrorCode.InvalidOperation, $"{Constants.INVALID_OPERATION_ERROR}" },
            {ErrorCode.PathTooLong, $"{Constants.PATH_TOO_LONG_ERROR}"},
            {ErrorCode.UnKnownError, $"{Constants.UNKNOWN_ERROR}"},
        };

        /// <summary>
        /// Display file delete error message
        /// </summary>
        /// <param name="eErrorCode">File delete error enum</param>
        public static void DisplayFileDeleteError(ErrorCode eErrorCode)
        {   // If Dictionary contains key
            FileProcess objFileProcess = new FileProcess();

            if (m_FileDeleteError.ContainsKey(eErrorCode))
            {
                MessageBox.Show($"{m_FileDeleteError[eErrorCode]}" ,objFileProcess.sApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

