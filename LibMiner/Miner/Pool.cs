﻿//
//  EmptyClass.cs
//
//  Author:
//       Shawn L. Djernes <sdjernes@gmail.com>
//
//  Copyright (c) 2014 Shawn L. Djernes & SD Consulting LLC All Rights Reserved
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;

namespace Mineboss.LibMiner
{
    public class Pool
    {
        public int id
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }

        public bool active
        {
            get;
            set;
        }
        public string status
        {
            get;
            set;
        }

        public int priority
        {
            get;
            set;
        }

        public Pool()
        {
        }
    }
}

