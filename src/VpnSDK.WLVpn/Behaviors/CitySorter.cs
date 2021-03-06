﻿// <copyright file="CitySorter.cs" company="StackPath, LLC">
// Copyright (c) StackPath, LLC. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VpnSDK.Public.Interfaces;

namespace VpnSDK.WLVpn.Behaviors
{
    /// <summary>
    /// Class CitySorter. Provides a sorter to sort by the city value on an <see cref="ILocation"/>.
    /// </summary>
    /// <seealso cref="ICustomSorter" />
    public class CitySorter : ICustomSorter
    {
        /// <inheritdoc />
        public ListSortDirection SortDirection { get; set; }

        /// <inheritdoc />
        public int Compare(object x, object y)
        {
            // Make Best Available always on top of the list.
            if (y is IBestAvailable)
            {
                return 1;
            }

            if (x is IBestAvailable)
            {
                return -1;
            }

            // Proceed with the countries sorting
            int result = string.Compare(((IRegion)x)?.City, ((IRegion)y)?.City, StringComparison.Ordinal);
            if (SortDirection == ListSortDirection.Descending)
            {
                return -result;
            }

            return result;
        }
    }
}