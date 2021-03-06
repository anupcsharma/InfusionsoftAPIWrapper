﻿#region License

// Copyright (c) 2012, EventDay
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfusionsoftCoreLibrary
{
	internal partial class EmailServiceWrapper : ServiceBase<IEmailServiceDefinition>, IEmailService
	{

		public EmailServiceWrapper(IInfusionsoftConfiguration configuration, IMethodListenerProvider listenerProvider) :
			base(configuration, listenerProvider)
		{
		}

		public virtual int AddEmailTemplate(string pieceTitle, string categories, string toAddress, string ccAddress, string bccAddress, string subject, string textBody, string htmlBody, string contentType, string mergeContext)
		{
			return Invoke(d => d.AddEmailTemplate(ApiKey, pieceTitle, categories, toAddress, ccAddress, bccAddress, subject, textBody, htmlBody, contentType, mergeContext));
		}

		public virtual bool AttachEmail(int contactId, string fromName, string fromAddress, string toAddress, string ccAddresses, string bccAddresses, string contentType, string subject, string htmlBody, string textBody, string header, string receivedDate, string sentDate, int emailSentType)
		{
			return Invoke(d => d.AttachEmail(ApiKey, contactId, fromName, fromAddress, toAddress, ccAddresses, bccAddresses, contentType, subject, htmlBody, textBody, header, receivedDate, sentDate, emailSentType));
		}

		public virtual string[] GetAvailableMergeFields(string mergeContext)
		{
			return Invoke(d => d.GetAvailableMergeFields(ApiKey, mergeContext));
		}

		public virtual EmailTemplate GetEmailTemplate(int templateId)
		{
			return Invoke(d => d.GetEmailTemplate(ApiKey, templateId));
		}

		public virtual int GetOptStatus(string email)
		{
			return Invoke(d => d.GetOptStatus(ApiKey, email));
		}

		public virtual bool OptIn(string email, string optInReason)
		{
			return Invoke(d => d.OptIn(ApiKey, email, optInReason));
		}

		public virtual bool OptOut(string email, string optOutreason)
		{
			return Invoke(d => d.OptOut(ApiKey, email, optOutreason));
		}

		public virtual bool SendEmail(int[] contactList, string fromAddress, string toAddress, string ccAddresses, string bccAddresses, string contentType, string subject, string htmlBody, string textBody, int templateId)
		{
			return Invoke(d => d.SendEmail(ApiKey, contactList, fromAddress, toAddress, ccAddresses, bccAddresses, contentType, subject, htmlBody, textBody, templateId));
		}

		public virtual bool SendEmail(int[] contactList, string fromAddress, string toAddress, string ccAddresses, string bccAddresses, string contentType, string subject, string htmlBody, string textBody)
		{
			return Invoke(d => d.SendEmail(ApiKey, contactList, fromAddress, toAddress, ccAddresses, bccAddresses, contentType, subject, htmlBody, textBody));
		}

		public virtual bool SendTemplate(int[] contactList, string templateId)
		{
			return Invoke(d => d.SendTemplate(ApiKey, contactList, templateId));
		}

		public virtual bool UpdateEmailTemplate(int templateId, string pieceTitle, string category, string fromAddress, string toAddress, string ccAddress, string bccAddresses, string subject, string textBody, string htmlBody, string contentType, string mergeContext)
		{
			return Invoke(d => d.UpdateEmailTemplate(ApiKey, templateId, pieceTitle, category, fromAddress, toAddress, ccAddress, bccAddresses, subject, textBody, htmlBody, contentType, mergeContext));
		}
	}
}
