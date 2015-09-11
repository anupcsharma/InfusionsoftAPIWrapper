#region License

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

namespace InfusionsoftCoreLibrary
{
	internal partial class ContactServiceWrapper : ServiceBase<IContactServiceDefinition>, IContactService
	{

		public ContactServiceWrapper(IInfusionsoftConfiguration configuration, IMethodListenerProvider listenerProvider) :
			base(configuration, listenerProvider)
		{
		}

		public virtual int Add(System.Collections.IDictionary data)
		{
			return Invoke(d => d.Add(ApiKey, data));
		}

		public virtual bool AddToCampaign(int contactId, int campaignId)
		{
			return Invoke(d => d.AddToCampaign(ApiKey, contactId, campaignId));
		}

		public virtual bool AddToGroup(int contactId, int campaignId)
		{
			return Invoke(d => d.AddToGroup(ApiKey, contactId, campaignId));
		}

		public virtual int GetNextCampaignStep(int contactId, int followUpSequenceId)
		{
			return Invoke(d => d.GetNextCampaignStep(ApiKey, contactId, followUpSequenceId));
		}

		public virtual Contact[] FindByEmail(string email, string[] selectedFields)
		{
			return Invoke(d => d.FindByEmail(ApiKey, email, selectedFields));
		}

		public virtual Contact Load(int contactId, string[] selectedFields)
		{
			return Invoke(d => d.Load(ApiKey, contactId, selectedFields));
		}

		public virtual bool PauseCampaign(int contactId, int sequenceId)
		{
			return Invoke(d => d.PauseCampaign(ApiKey, contactId, sequenceId));
		}

		public virtual bool RemoveFromCampaign(int contactId, int followUpSequenceId)
		{
			return Invoke(d => d.RemoveFromCampaign(ApiKey, contactId, followUpSequenceId));
		}

		public virtual bool RemoveFromGroup(int contactId, int tagId)
		{
			return Invoke(d => d.RemoveFromGroup(ApiKey, contactId, tagId));
		}

		public virtual bool ResumeCampaignForContact(int contactId, int seqId)
		{
			return Invoke(d => d.ResumeCampaignForContact(ApiKey, contactId, seqId));
		}

		public virtual int RescheduleCampaignStep(int[] contactIds, int sequenceStepId)
		{
			return Invoke(d => d.RescheduleCampaignStep(ApiKey, contactIds, sequenceStepId));
		}

		public virtual RunActionSequenceResult[] RunActionSequence(int contactId, int actionSetId)
		{
			return Invoke(d => d.RunActionSequence(ApiKey, contactId, actionSetId));
		}

		public virtual int AddWithDupCheck(System.Collections.IDictionary data, string dupCheckType)
		{
			return Invoke(d => d.AddWithDupCheck(ApiKey, data, dupCheckType));
		}

		public virtual int Update(int contactId, System.Collections.IDictionary data)
		{
			return Invoke(d => d.Update(ApiKey, contactId, data));
		}
	}
}
