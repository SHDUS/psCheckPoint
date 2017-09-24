﻿using psCheckPoint.Objects.Service;
using System.Management.Automation;

namespace psCheckPoint.Objects.ServiceTCP
{
    /// <api cmd="add-service-tcp">New-CheckPointServiceTCP</api>
    /// <summary>
    /// <para type="synopsis">Create new object.</para>
    /// <para type="description"></para>
    /// </summary>
    /// <example>
    ///   <code></code>
    /// </example>
    [Cmdlet(VerbsCommon.New, "CheckPointServiceTCP")]
    [OutputType(typeof(CheckPointServiceTCP))]
    public class NewCheckPointServiceTCP : NewCheckPointService<CheckPointServiceTCP>
    {
        /// <summary>
        /// <para type="description">Check Point Web-API command that should be called.</para>
        /// </summary>
        public override string Command { get { return "add-service-tcp"; } }
    }
}