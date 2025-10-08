using System;
using System.IO;

namespace Acty.Skillup.FileCopy
{
    /// <summary>
    /// Utility class
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Delete if file exists
        /// </summary>
        /// <param name="sDestinationFilePath">Destination file path</param>
        /// <returns></returns>
        public static ErrorCode DeleteIfExists(string sDestinationFilePath)
        {
            try
            {
                if (File.Exists(sDestinationFilePath))
                {
                    File.Delete(sDestinationFilePath);
                }
            }
            catch (ArgumentNullException)
            {
                return ErrorCode.ArgumentNull;
            }
            catch (ArgumentException)
            {
                return ErrorCode.Argument;
            }
            catch (DirectoryNotFoundException)
            {
                return ErrorCode.DirectoryNotFound;
            }
            catch (PathTooLongException)
            {
                return ErrorCode.PathTooLong;
            }
            catch (IOException)
            {
                 return ErrorCode.IO;
            }
            catch (NotSupportedException)
            {
                return ErrorCode.NotSupported;
            }
            catch (UnauthorizedAccessException)
            {
                return ErrorCode.UnAuthorizedAccess;
            }
            catch (Exception)
            {
                return ErrorCode.UnKnownError;
            }
            return ErrorCode.Success;
        }
    }
}
