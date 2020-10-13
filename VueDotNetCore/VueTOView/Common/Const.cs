﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueTOView.Common
{
    public class Const
    {
		internal const string LiveAuth = "http://bogemaslive:8092/bodegaAuthorizerInternal";
		internal const string LiveTO = "http://bogemaslive:8190/bodegaWebToolExtendedService";
		internal const string TestAuth = "http://aib-web01:8092/bodegaAuthorizerInternal";
		internal const string TestTO = "http://aib-dev02:8190/bodegaWebToolExtendedService";
		internal const string EduAuth = "http://aib-dev02:8092/bodegaAuthorizerInternal/EDU";
		internal const string EduTO = "http://aib-dev02:8190/bodegaWebToolExtendedService/EDU";
		internal const string LocalAuth = "http://localhost:8092/bodegaAuthorizerInternal";
		internal const string LocalTO = "http://localhost:8190/bodegaWebToolExtendedService";

	}
}
