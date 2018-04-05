﻿using System.Management.Automation;

namespace psCheckPoint.Objects.MulticastAddressRange
{
    /// <api cmd="show-multicast-address-ranges">Get-CheckPointMulticastAddressRanges</api>
    /// <summary>
    /// <para type="synopsis">Retrieve all objects.</para>
    /// <para type="description"></para>
    /// </summary>
    /// <example></example>
    [Cmdlet(VerbsCommon.Get, "CheckPointMulticastAddressRanges")]
    [OutputType(typeof(Koopman.CheckPoint.Common.ObjectsPagingResults<Koopman.CheckPoint.MulticastAddressRange>))]
    public class GetCheckPointMulticastAddressRanges : GetCheckPointObjects
    {
        #region Methods

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            if (ParameterSetName == "Limit")
            {
                WriteObject(
                    Session.FindMulticastAddressRanges(
                            limit: Limit,
                            offset: Offset,
                            detailLevel: DetailsLevel), false);
            }
            else
            {
                WriteObject(
                    Session.FindAllMulticastAddressRanges(
                            limit: Limit,
                            detailLevel: DetailsLevel), false);
            }
        }

        #endregion Methods
    }
}