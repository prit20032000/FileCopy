namespace Acty.Skillup.FileCopy
{
    /// <summary>
    /// 
    /// </summary>
    public class Constants
    {
        #region Constants

        #region Errors

        /// <summary>
        /// Invalid operation error
        /// </summary>
        public const string INVALID_OPERATION_ERROR = "Invalid operation.";

        /// <summary>
        /// Directory not found error
        /// </summary>
        public const string DIRECTORY_NOT_FOUND = "Directory not found.";

        /// <summary>
        /// Not supported operation
        /// </summary>
        public const string NOT_SUPPORTED_ERROR = "Failed to read file.";

        /// <summary>
        /// Argument out of range error
        /// </summary>
        public const string ARGUMENT_OUT_OF_RANGE = "Argument out of range.";

        /// <summary>
        /// Enter folder path error
        /// </summary>
        public const string ENTER_FOLDER_PATH_ERROR = "Enter folder path.";

        /// <summary>
        /// Path too long for command line argument
        /// </summary>
        public const string PATH_TOO_LONG_ERROR = "Path too long passed.";

        /// <summary>
        /// Folder not found error
        /// </summary>
        public const string FOLDER_NOT_FOUND_ERROR = "Folder not found.";

        /// <summary>
        /// Object disposed error
        /// </summary>
        public const string OBJECT_DISPOSED_ERROR = "Object disposed.";

        /// <summary>
        /// Unknown error
        /// </summary>
        public const string UNKNOWN_ERROR = "Unknown error occurred.";

        /// <summary>
        /// File not found error
        /// </summary>
        public const string FILE_NOT_FOUND_ERROR = "The file can not be found.";

        /// <summary>
        /// IO error
        /// </summary>
        public const string IO_ERROR = "Failed to read file.";

        /// <summary>
        /// Unauthorized access error
        /// </summary>
        public const string UNAUTHORIZED_ACCESS_ERROR = "Can not access to file.";

        /// <summary>
        /// Null argument error
        /// </summary>
        public const string ARGUMENT_NULL_ERROR = "Argument null.";

        /// <summary>
        /// Argument exception error
        /// </summary>
        public const string ARGUMENT_ERROR = "Argument exception occurred.";

        /// <summary>
        /// Enter file path error
        /// </summary>
        public const string ENTER_FILE_PATH_ERROR = "Enter file path";

        #endregion

        #region String Constants

        /// <summary>
        /// For single day
        /// </summary>
        public const string DAY = "Day";

        /// <summary>
        /// For single Hour
        /// </summary>
        public const string HOUR = "Hour";

        /// <summary>
        /// For single Minute
        /// </summary>
        public const string MINUTE = "Minute";

        /// <summary>
        /// For single Second
        /// </summary>
        public const string SECOND = "Second";

        /// <summary>
        /// Print Error:
        /// </summary>
        public const string ERROR = "Error:";

        /// <summary>
        /// Data copied
        /// </summary>
        public const string COPIED_DATA = "Copied Data : ";

        /// <summary>
        /// Speed of file copy
        /// </summary>
        public const string SPEED = "Speed : ";

        /// <summary>
        /// Time remaining
        /// </summary>
        public const string TIME_REMAINING = "Time Remaining : ";

        /// <summary>
        /// Speed per second
        /// </summary>
        public const string SPEED_PER_SECOND = "/sec";

        /// <summary>
        /// Suffix if file already present
        /// </summary>
        public const string COPY_FILE_SUFFIX = "-Copy";

        /// <summary>
        /// Choose file
        /// </summary>
        public const string CHOOSE_FILE = "Choose file";

        /// <summary>
        /// File selection filter
        /// </summary>
        public const string FILE_SELECTION_FILTER = "All|*.*";

        /// <summary>
        /// Start as button text
        /// </summary>
        public const string START = "&Start";

        /// <summary>
        /// Start as button text
        /// </summary>
        public const string CANCEL = "&Cancel";

        /// <summary>
        /// Percent symbol
        /// </summary>
        public const string PERCENT = "%";

        /// <summary>
        /// Are you sure want to quit question
        /// </summary>
        public const string WANT_TO_EXIT_QUESTION = "Are you sure you want to exit ?";

        /// <summary>
        /// Are you sure you want to cancel question
        /// </summary>
        public const string WANT_TO_CANCEL_QUESTION = "Are you sure you want to Cancel ?";

        /// <summary>
        /// Ask to copy if file already exists
        /// </summary>
        public const string WANT_TO_CONTINUE_IF_FILE_EXISTS = "File already exists, are you sure you want to continue ?";

        /// <summary>
        /// File copy completed message
        /// </summary>
        public const string FILE_COPY_COMPLETED = "File successfully copied";

        #endregion

        #region Integer Constants

        /// <summary>
        /// Buffer size to read bytes
        /// </summary>
        public const int BUFFER_SIZE = 400;

        /// <summary>
        /// File reading offset
        /// </summary>
        public const int READ_FILE_OFFSET = 0;

        /// <summary>
        /// File writing offset
        /// </summary>
        public const int WRITE_FILE_OFFSET = 0;

        /// <summary>
        /// Multiply to find percent
        /// </summary>
        public const int PERCENT_CONVERSION = 100;

        /// <summary>
        /// If file exists count
        /// </summary>
        public const int SINGLE_FILE_COUNT = 1;

        /// <summary>
        /// Minimum file number name for duplicate files
        /// </summary>
        public const int MINIMUM_DUPLICATE_FILE_NUMBER = 2;

        /// <summary>
        /// Max Kilo bytes
        /// </summary>
        public const int MAXIMUM_KILO_BYTES = 1024;

        /// <summary>
        /// Hours in a day
        /// </summary>
        public const int HOURS_PER_DAY = 24;

        /// <summary>
        /// Seconds in 1 hour
        /// </summary>
        public const int SECONDS_PER_HOUR = 3600;

        /// <summary>
        /// Total minute in 1 hour
        /// </summary>
        public const int MINUTES_PER_HOUR = 60;

        /// <summary>
        /// Progress bar default value
        /// </summary>
        public const int DEFAULT_PROGRESS_BAR_VALUE = 0;

        #endregion

        #endregion
    }
}