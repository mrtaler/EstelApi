﻿namespace EstelApi.Core.Seedwork
{
    using System;

    /// <summary>
    /// The identity generator.
    /// </summary>
    internal static class IdentityGenerator
    {
        /// <summary>
        /// This algorithm generates sequential GUIDs across system boundaries, ideal for databases 
        /// </summary>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        public static Guid NewSequentialGuid()
        {
            byte[] uid = Guid.NewGuid().ToByteArray();
            byte[] binDate = BitConverter.GetBytes(DateTime.UtcNow.Ticks);

            byte[] sequentialGuid = new byte[uid.Length];

            sequentialGuid[0] = uid[0];
            sequentialGuid[1] = uid[1];
            sequentialGuid[2] = uid[2];
            sequentialGuid[3] = uid[3];
            sequentialGuid[4] = uid[4];
            sequentialGuid[5] = uid[5];
            sequentialGuid[6] = uid[6];

            // set the first part of the 8th byte to '1100' so     
            // later we'll be able to validate it was generated by us   
            sequentialGuid[7] = (byte)(0xc0 | (0xf & uid[7]));

            // the last 8 bytes are sequential,    
            // it minimizes index fragmentation   
            // to a degree as long as there are not a large    
            // number of sequential-Guid generated per millisecond  
            sequentialGuid[9] = binDate[0];
            sequentialGuid[8] = binDate[1];
            sequentialGuid[15] = binDate[2];
            sequentialGuid[14] = binDate[3];
            sequentialGuid[13] = binDate[4];
            sequentialGuid[12] = binDate[5];
            sequentialGuid[11] = binDate[6];
            sequentialGuid[10] = binDate[7];

            return new Guid(sequentialGuid);
        }
    }
}
