﻿// <copyright file="IccDataToPcsConverter.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.ColorSpaces.Conversion.Implementation.Icc
{
    /// <summary>
    /// Color converter for ICC profiles
    /// </summary>
    internal class IccDataToPcsConverter : IccConverterBase
    {
        private readonly ConversionDelegate conversionDelegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="IccDataToPcsConverter"/> class.
        /// </summary>
        /// <param name="profile">The ICC profile to use for the conversions</param>
        public IccDataToPcsConverter(IccProfile profile)
        {
            Guard.NotNull(profile, nameof(profile));
            this.conversionDelegate = this.Init(profile, true, profile.Header.RenderingIntent);
        }

        /// <summary>
        /// Converts colors with the initially provided ICC profile
        /// </summary>
        /// <param name="values">The values to convert</param>
        /// <returns>The converted values</returns>
        public float[] Convert(float[] values)
        {
            Guard.NotNull(values, nameof(values));
            return this.conversionDelegate.Invoke(values);
        }
    }
}
