using System.Diagnostics;

namespace DataAccessLayer.Logger
{
    /// <summary>
    /// CAUTION: It is a Totally DUMMY implementation, just to pretend logging.
    /// In production full logging implementation needed. Also 3rd party logging tools(nLog, log4net, etc) could be wrapped
    /// </summary>
    public class Logger : ILogger
    {
        public void Error(string errorMessage)
        {
            Debug.WriteLine(errorMessage);
        }
    }
}
