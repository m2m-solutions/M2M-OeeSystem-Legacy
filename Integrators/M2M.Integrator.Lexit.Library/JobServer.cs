using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using M2M.DataCenter;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;

namespace M2M.Integrator.Lexit.Library
{
    public class JobServer
    {
        #region Properties

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private FileSystemWatcher watcher = null;
        private bool IsNetworkAvailable = true;
        
        #endregion

        #region Action methods

        public void Start()
        {
            try
            {
                this.watcher = new System.IO.FileSystemWatcher();
                StartMonitoring(watcher);
            }
            catch (Exception ex)
            {
                logger.ErrorException("Server start exception", ex);
            }
        }

        public void Stop()
        {
            try
            {
                if (this.watcher != null)
                    StopMonitoring(this.watcher);
            }
            catch (Exception ex)
            {
                logger.ErrorException("Server stop exception", ex);
            }
        }

        public void Pause()
        {
            try
            {
                if(this.watcher != null)
                    StopMonitoring(this.watcher);

            }
            catch (Exception ex)
            {
                logger.ErrorException("Server pause exception", ex);
            }
        }

        public void Continue()
        {
            try
            {
                this.watcher = new System.IO.FileSystemWatcher();
                StartMonitoring(watcher);
            }
            catch (Exception ex)
            {
                logger.ErrorException("Server continue exception", ex);
            }
        }

        private void StartMonitoring(FileSystemWatcher source)
        {
            ((System.ComponentModel.ISupportInitialize)(source)).BeginInit();
            source.EnableRaisingEvents = true;
            source.Path = LexitSettings.PollPath;
            source.NotifyFilter = System.IO.NotifyFilters.FileName;
            source.Created += new System.IO.FileSystemEventHandler(watcher_Changed);
            source.Error += new ErrorEventHandler(watcher_Error);
            ((System.ComponentModel.ISupportInitialize)(source)).EndInit();
            logger.Trace("Start monitoring direcory: {0}", source.Path );
        }

        private void StopMonitoring(FileSystemWatcher source)
        {
            source.EnableRaisingEvents = false;
            //source.Created -= watcher_Changed;
            //source.Error -= watcher_Error;
            source.Dispose();
            source = null;
        }

        private void NotAccessibleError(FileSystemWatcher source, ErrorEventArgs e)
        {
            int iTimeOut = 3000;
            int i = 0;
            while ((!Directory.Exists(source.Path) || source.EnableRaisingEvents == false))
            {
                i += 1;
                try
                {
                    source.EnableRaisingEvents = false;
                    if (!Directory.Exists(source.Path))
                    {
                        logger.Trace("Directory inaccesible " + source.Path);
                        System.Threading.Thread.Sleep(iTimeOut);
                    }
                    
                    if (Directory.Exists(source.Path))
                    {
                        StopMonitoring(source);
                        source = new System.IO.FileSystemWatcher();
                        StartMonitoring(source);
                        
                    }
                }
                catch (Exception ex)
                {
                    logger.ErrorException("Error trying restart monitoring", ex);
                    source.EnableRaisingEvents = false;
                    System.Threading.Thread.Sleep(iTimeOut);
                }
            }
        }

        public LexitObject ParseFile(string fullPath)
        {
            LexitObject lexitObject = new LexitObject();

            bool fileOpenOk = false;
            int attempt = 0;
            while (!fileOpenOk && attempt < 5)
            {
                try
                {
                    Thread.Sleep(500);

                    using (StreamReader reader = new StreamReader(fullPath))
                    {
                        fileOpenOk = true;
                        string line = null;
                        while (reader.Peek() > 0)
                        {
                            // Spool to last line. We cannot handle missed product changes at this point
                            line = reader.ReadLine();
                        }

                        if (line != null)
                            lexitObject.ParseData(line);
                    }
                }
                catch (IOException)
                {
                    attempt++;
                    logger.Error("File locked by other user. Attempt {0} of 10", attempt);
                }
                catch (Exception ex)
                {
                    
                    logger.ErrorException("Error parsing file", ex);
                }
            }

            return lexitObject;
        }

        public bool UpdateProductNumber(string productNumber)
        {
            logger.Info("ProductNumber {0} in file", productNumber);
            OpcClient opcClient = new OpcClient();
            try
            {
                if (LexitSettings.OpcTags.Count == 0)
                {
                    logger.Error("No target opc tags defined in settings");
                    return false;
                }

                opcClient.Connect(M2MDataCenter.SystemSettings.OpcServerName);

                foreach (string tag in LexitSettings.OpcTags)
                {
                    opcClient.Write(tag, productNumber);
                }

                return true;
            }
            catch (Exception ex)
            {
                logger.ErrorException("Error writing opc", ex);
            }
            finally
            {
                try { opcClient.Disconnect(); }
                catch { }
            }

            return false;
        }

        #endregion

        #region Handlers

        void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (e.ChangeType == WatcherChangeTypes.Created)
                {
                    LexitObject lexitObject = ParseFile(e.FullPath);

                    if (lexitObject.IsValid())
                    {
                        UpdateProductNumber(lexitObject.ProductNumber);

                        if(LexitSettings.DeleteFile)
                            File.Delete(e.FullPath);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.ErrorException("Error in watcher change handler", ex);
            }
            
                
        }

        void watcher_Error(object sender, ErrorEventArgs e)
        {
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                logger.ErrorException("Error: File System Watcher internal buffer overflow.", e.GetException());
            }
            else
            {
                logger.ErrorException("Error: Watched directory not accessible.", e.GetException());
            }

            NotAccessibleError(watcher, e);
        }

        #endregion

        //public void MonitorFolderAvailability()
        //{
        //    while (this.Run)
        //    {
        //        if (this.IsNetworkAvailable)
        //        {
        //            if (!Directory.Exists(base.Path))
        //            {
        //                this.IsNetworkAvailable = false;
        //                RaiseEventNetworkPathAvailablity();
        //            }
        //        }
        //        else
        //        {
        //            if (Directory.Exists(base.Path))
        //            {
        //                this.IsNetworkAvailable = true;
        //                RaiseEventNetworkPathAvailablity();
        //            }
        //        }
        //        Thread.Sleep(this.Interval);
        //    }
        //}
    }
}
