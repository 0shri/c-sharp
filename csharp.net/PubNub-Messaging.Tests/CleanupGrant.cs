﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.ComponentModel;
using System.Threading;
using System.Collections;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using PubNubMessaging.Core;

namespace PubNubMessaging.Tests
{
    [TestFixture]
    public class CleanupGrant
    {
        ManualResetEvent auditManualEvent = new ManualResetEvent(false);
        ManualResetEvent revokeManualEvent = new ManualResetEvent(false);
        bool receivedAuditMessage = false;
        bool receivedRevokeMessage = false;

        Pubnub pubnub = null;

        [Test]
        public void AtUserLevel()
        {
            if (!PubnubCommon.PAMEnabled)
            {
                Assert.Ignore("PAM not enabled; CleanupGrant -> AtUserLevel.");
                return;
            }

            if (!PubnubCommon.EnableStubTest)
            {
                receivedAuditMessage = false;
                auditManualEvent = new ManualResetEvent(false);

                pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);
                pubnub.AuditAccess(UserCallbackForCleanUpAccessAtUserLevel, ErrorCallbackForCleanUpAccessAtUserLevel);
                auditManualEvent.WaitOne();

                pubnub.EndPendingRequests();
                pubnub = null;
                Assert.IsTrue(receivedAuditMessage, "CleanupGrant -> AtUserLevel failed.");
            }
            else
            {
                Assert.Ignore("Only for live test; CleanupGrant -> AtUserLevel.");
            }
        }

        [Test]
        public void AtChannelLevel()
        {
            if (!PubnubCommon.PAMEnabled)
            {
                Assert.Ignore("PAM not enabled; CleanupGrant -> AtChannelLevel.");
                return;
            }

            if (!PubnubCommon.EnableStubTest)
            {
                receivedAuditMessage = false;
                auditManualEvent = new ManualResetEvent(false);

                pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);
                pubnub.AuditAccess(UserCallbackForCleanUpAccessAtChannelLevel, ErrorCallbackForCleanUpAccessAtChannelLevel);
                auditManualEvent.WaitOne();

                pubnub.EndPendingRequests();
                pubnub = null;
                Assert.IsTrue(receivedAuditMessage, "CleanupGrant -> AtChannelLevel failed.");
            }
            else
            {
                Assert.Ignore("Only for live test; CleanupGrant -> AtChannelLevel.");
            }
        }

        void UserCallbackForCleanUpAccessAtUserLevel(AuditAck receivedMessage)
        {
            try
            {
                if (receivedMessage != null)
                {
                    Console.WriteLine(pubnub.JsonPluggableLibrary.SerializeToJsonString(receivedMessage));
                    int statusCode = receivedMessage.StatusCode;
                    string statusMessage = receivedMessage.StatusMessage;
                    if (statusCode == 200 && statusMessage.ToLower() == "success")
                    {
                        if (receivedMessage.Payload != null)
                        {
                            Dictionary<string, AuditAck.Data.ChannelData> channels = receivedMessage.Payload.channels;
                            if (channels != null && channels.Count > 0)
                            {
                                Console.WriteLine("CleanupGrant / AtUserLevel / UserCallbackForCleanUpAccess - Channel Count = {0}", channels.Count);
                                foreach (string channelName in channels.Keys)
                                {
                                    AuditAck.Data.ChannelData channelContainer = channels[channelName];
                                    if (channelContainer != null && channelContainer.auths != null)
                                    {
                                        Dictionary<string, AuditAck.Data.ChannelData.AuthData> auths = channelContainer.auths;
                                        if (auths != null && auths.Count > 0)
                                        {
                                            foreach (string authKey in auths.Keys)
                                            {
                                                receivedRevokeMessage = false;
                                                Console.WriteLine("Auth Key = " + authKey);
                                                pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);
                                                pubnub.GrantAccess(channelName, authKey, false, false, UserCallbackForRevokeAccess, ErrorCallbackForRevokeAccess);
                                                revokeManualEvent.WaitOne();

                                            }
                                        }
                                    }
                                }
                            }
                            string level = receivedMessage.Payload.Level;
                            if (level == "subkey")
                            {
                                receivedAuditMessage = true;
                            }
                        }
                    }
                }
            }
            catch { }
            finally
            {
                auditManualEvent.Set();
            }
        }

        void ErrorCallbackForCleanUpAccessAtUserLevel(PubnubClientError receivedMessage)
        {
            if (receivedMessage != null)
            {
                Console.WriteLine(receivedMessage);
            }
            auditManualEvent.Set();
        }

        void UserCallbackForRevokeAccess(GrantAck receivedMessage)
        {
            if (receivedMessage != null)
            {
                Console.WriteLine(pubnub.JsonPluggableLibrary.SerializeToJsonString(receivedMessage));
                receivedRevokeMessage = true;
            }
            revokeManualEvent.Set();
        }

        void ErrorCallbackForRevokeAccess(PubnubClientError receivedMessage)
        {
            if (receivedMessage != null)
            {
                Console.WriteLine(receivedMessage);
            }
            revokeManualEvent.Set();
        }

        void UserCallbackForCleanUpAccessAtChannelLevel(AuditAck receivedMessage)
        {
            try
            {
                if (receivedMessage != null)
                {
                    Console.WriteLine(pubnub.JsonPluggableLibrary.SerializeToJsonString(receivedMessage));
                    int statusCode = receivedMessage.StatusCode;
                    string statusMessage = receivedMessage.StatusMessage;
                    if (statusCode == 200 && statusMessage.ToLower() == "success")
                    {
                        if (receivedMessage.Payload != null)
                        {
                            Dictionary<string, AuditAck.Data.ChannelData> channels = receivedMessage.Payload.channels;
                            if (channels != null && channels.Count > 0)
                            {
                                Console.WriteLine("CleanupGrant / AtUserLevel / UserCallbackForCleanUpAccess - Channel Count = {0}", channels.Count);
                                foreach (string channelName in channels.Keys)
                                {
                                    //Dictionary<string, object> channelContainer = pubnub.JsonPluggableLibrary.ConvertToDictionaryObject(channels[channelName]);
                                    Console.WriteLine(channelName);
                                    pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);
                                    pubnub.GrantAccess(channelName, false, false, UserCallbackForRevokeAccess, ErrorCallbackForRevokeAccess);
                                    revokeManualEvent.WaitOne();

                                }
                                //foreach (JToken channel in channels.Children())
                                //{
                                //    if (channel is JProperty)
                                //    {
                                //        var channelProperty = channel as JProperty;
                                //        if (channelProperty != null)
                                //        {
                                //            string channelName = channelProperty.Name;
                                //            Console.WriteLine(channelName);
                                //            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);
                                //            pubnub.GrantAccess<string>(channelName, false, false, UserCallbackForRevokeAccess, ErrorCallbackForRevokeAccess);
                                //            revokeManualEvent.WaitOne();
                                //        }
                                //    }
                                //}
                            }
                            string level = receivedMessage.Payload.Level;
                            if (level == "subkey")
                            {
                                receivedAuditMessage = true;
                            }
                        }
                    }

                }
            }
            catch { }
            finally
            {
                auditManualEvent.Set();
            }
        }

        void ErrorCallbackForCleanUpAccessAtChannelLevel(PubnubClientError receivedMessage)
        {
            if (receivedMessage != null)
            {
                Console.WriteLine(receivedMessage.Message);
            }
            auditManualEvent.Set();
        }

    }
}
