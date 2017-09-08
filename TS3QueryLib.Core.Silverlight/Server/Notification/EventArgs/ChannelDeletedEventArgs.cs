﻿using System;
using System.Collections.Generic;
using System.Linq;
using TS3QueryLib.Core.CommandHandling;
using TS3QueryLib.Core.Common;

namespace TS3QueryLib.Core.Server.Notification.EventArgs
{
    public class ChannelDeletedEventArgs : System.EventArgs, IDump
    {
        #region Properties

        public int? ChannelId { get; protected set; }
        public List<int> SubChannelIdList { get; protected set; }
        public int? InvokerId { get; protected set; }
        public string InvokerName { get; protected set; }

        #endregion

        #region Constructors


        public ChannelDeletedEventArgs(CommandParameterGroupList commandParameterGroupList)
        {
            if (commandParameterGroupList == null)
                throw new ArgumentNullException(nameof(commandParameterGroupList));

            ChannelId = commandParameterGroupList.GetParameterValue<int?>("cid");
            InvokerId = commandParameterGroupList.GetParameterValue<int?>("invokerid");
            InvokerName = commandParameterGroupList.GetParameterValue<string>("invokername");

            SubChannelIdList = commandParameterGroupList.Skip(1).Select(pg => pg.GetParameterValue<int>("cid")).ToList();
        }

        #endregion
    }
}