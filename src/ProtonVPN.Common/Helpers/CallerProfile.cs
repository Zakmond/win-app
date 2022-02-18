﻿/*
 * Copyright (c) 2021 Proton Technologies AG
 *
 * This file is part of ProtonVPN.
 *
 * ProtonVPN is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ProtonVPN is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with ProtonVPN.  If not, see <https://www.gnu.org/licenses/>.
 */

using System;
using System.IO;

namespace ProtonVPN.Common.Helpers
{
    public class CallerProfile
    {
        public string SourceClassName { get; }
        public string SourceMemberName { get; }
        public int SourceLineNumber { get; }

        public CallerProfile(string sourceFilePath = "", string sourceMemberName = "", int sourceLineNumber = 0)
        {
            SourceClassName = GetSourceClass(sourceFilePath);
            SourceMemberName = sourceMemberName;
            SourceLineNumber = sourceLineNumber;
        }

        private string GetSourceClass(string sourceFilePath)
        {
            string sourceClass;
            try
            {
                sourceClass = Path.GetFileNameWithoutExtension(sourceFilePath);
            }
            catch (Exception)
            {
                sourceClass = sourceFilePath;
            }

            return sourceClass;
        }
    }
}