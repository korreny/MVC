using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Synchronization;
using System.IO;
using Microsoft.Synchronization.Files;

namespace com.iflysse.helper
{
    /// <summary>
    /// FileName: FileSyncHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 
    /// DateTime: 2014/5/19 17:04:18
    /// </summary>
   public class FileSyncHelper
    {
        #region Private Data Members
        Guid sourceReplicaID;
        Guid destinationReplicaID;
        FileSyncProvider sourceProvider;
        FileSyncProvider destinationProvider;
        #endregion

        public bool Synchronize(String source, String destination)
        {
            SyncOperationStatistics syncOperationStatistics;

            //Assign Unique Guids to the source and destination replicas
            sourceReplicaID = GetReplicaID(Path.Combine(source, "ReplicaID"));
            destinationReplicaID = GetReplicaID(Path.Combine(destination, "ReplicaID"));

            //Create the source Sync Provider, attach the path and assign the ReplicaID
            sourceProvider = new FileSyncProvider(sourceReplicaID, source);
            //Create the destination Sync Provider, attach the path and assign the ReplicaID
            destinationProvider = new FileSyncProvider(destinationReplicaID, destination);

            SyncOrchestrator synchronizationAgent = new SyncOrchestrator();
            synchronizationAgent.LocalProvider = sourceProvider;
            synchronizationAgent.RemoteProvider = destinationProvider;

            try
            {
                syncOperationStatistics = synchronizationAgent.Synchronize();
            }
            catch (Microsoft.Synchronization.SyncException se)
            {
                //MessageBox.Show(se.Message, "Sync Files - Error");
                return false;
            }
            finally
            {
                // Release resources once done
                if (sourceProvider != null)
                    sourceProvider.Dispose();
                if (destinationProvider != null)
                    destinationProvider.Dispose();
            }

            return true;
        }

        /// <summary>
        /// 得到复制ID
        /// </summary>
        /// <param name="guidPath"></param>
        /// <returns></returns>
        private Guid GetReplicaID(string guidPath)
        {
            if (!File.Exists(guidPath)) //Create a new GUID and store it in a file
            {
                Guid replicaID = Guid.NewGuid();
                using (FileStream fileStream = File.Open(guidPath, FileMode.Create))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.WriteLine(replicaID.ToString());
                    }
                }
                return replicaID;
            }
            else //Read and return the GUID from the file
            {
                using (FileStream fileStream = File.Open(guidPath, FileMode.Open))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        return new Guid(streamReader.ReadLine());
                    }
                }
            }
        }
    }
}
