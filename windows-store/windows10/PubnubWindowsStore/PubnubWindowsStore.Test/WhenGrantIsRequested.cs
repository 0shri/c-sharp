﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PubNubMessaging.Core;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading;

namespace PubnubWindowsStore.Test
{
    [TestClass]
    public class WhenGrantIsRequested
    {

        ManualResetEvent grantManualEvent = new ManualResetEvent(false);
        ManualResetEvent revokeManualEvent = new ManualResetEvent(false);
        bool receivedGrantMessage = false;
        bool receivedRevokeMessage = false;
        int multipleChannelGrantCount = 5;
        int multipleAuthGrantCount = 5;
        string currentUnitTestCase = "";

        [TestMethod]
        public void ThenSubKeyLevelWithReadWriteShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenSubKeyLevelWithReadWriteShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenSubKeyLevelWithReadWriteShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.GrantAccess<string>("", true, true, 5, AccessToSubKeyLevelCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenSubKeyLevelWithReadWriteShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenSubKeyLevelWithReadWriteShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenSubKeyLevelWithReadShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenSubKeyLevelWithReadShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenSubKeyLevelWithReadShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.GrantAccess<string>("", true, false, 5, AccessToSubKeyLevelCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenSubKeyLevelWithReadShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenSubKeyLevelWithReadShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenSubKeyLevelWithWriteShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenSubKeyLevelWithWriteShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenSubKeyLevelWithWriteShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.GrantAccess<string>("", false, true, 5, AccessToSubKeyLevelCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenSubKeyLevelWithWriteShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenSubKeyLevelWithWriteShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenChannelLevelWithReadWriteShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenChannelLevelWithReadWriteShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenChannelLevelWithReadWriteShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            string channel = "hello_my_channel";
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.GrantAccess<string>(channel, true, true, 5, AccessToChannelLevelCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenChannelLevelWithReadWriteShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenChannelLevelWithReadWriteShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenChannelLevelWithReadShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenChannelLevelWithReadShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenChannelLevelWithReadShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            string channel = "hello_my_channel";
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.GrantAccess<string>(channel, true, false, 5, AccessToChannelLevelCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenChannelLevelWithReadShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenChannelLevelWithReadShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenChannelLevelWithWriteShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenChannelLevelWithWriteShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenChannelLevelWithWriteShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            string channel = "hello_my_channel";
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.GrantAccess<string>(channel, false, true, 5, AccessToChannelLevelCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenChannelLevelWithWriteShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenChannelLevelWithWriteShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenUserLevelWithReadWriteShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenUserLevelWithReadWriteShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenUserLevelWithReadWriteShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            string channel = "hello_my_authchannel";
            string authKey = "hello_my_authkey";
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.GrantAccess<string>(channel, authKey, true, true, 5, AccessToUserLevelCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenUserLevelWithReadWriteShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenUserLevelWithReadWriteShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenUserLevelWithReadShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenUserLevelWithReadShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenUserLevelWithReadShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            string channel = "hello_my_authchannel";
            string authKey = "hello_my_authkey";
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.GrantAccess<string>(channel, authKey, true, false, 5, AccessToUserLevelCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenUserLevelWithReadShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenUserLevelWithReadShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenUserLevelWithWriteShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenUserLevelWithWriteShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenUserLevelWithWriteShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            string channel = "hello_my_authchannel";
            string authKey = "hello_my_authkey";
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.GrantAccess<string>(channel, authKey, false, true, 5, AccessToUserLevelCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenUserLevelWithWriteShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenUserLevelWithWriteShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenMultipleChannelGrantShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenMultipleChannelGrantShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenMultipleChannelGrantShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            StringBuilder channelBuilder = new StringBuilder();
            for (int index = 0; index < multipleChannelGrantCount; index++)
            {
                if (index == multipleChannelGrantCount - 1)
                {
                    channelBuilder.AppendFormat("csharp-hello_my_channel-{0}", index);
                }
                else
                {
                    channelBuilder.AppendFormat("csharp-hello_my_channel-{0},", index);
                }
            }
            string channel = "";
            if (!unitTest.EnableStubTest)
            {
                channel = channelBuilder.ToString();
            }
            else
            {
                multipleChannelGrantCount = 5;
                channel = "csharp-hello_my_channel-0,csharp-hello_my_channel-1,csharp-hello_my_channel-2,csharp-hello_my_channel-3,csharp-hello_my_channel-4";
            }
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.GrantAccess<string>(channel, true, true, 5, AccessToMultiChannelGrantCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenMultipleChannelGrantShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenMultipleChannelGrantShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenMultipleAuthGrantShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenMultipleAuthGrantShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenMultipleAuthGrantShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            StringBuilder authKeyBuilder = new StringBuilder();
            for (int index = 0; index < multipleAuthGrantCount; index++)
            {
                if (index == multipleAuthGrantCount - 1)
                {
                    authKeyBuilder.AppendFormat("csharp-auth_key-{0}", index);
                }
                else
                {
                    authKeyBuilder.AppendFormat("csharp-auth_key-{0},", index);
                }
            }
            string channel = "hello_my_channel";
            string auth = "";
            if (!unitTest.EnableStubTest)
            {
                auth = authKeyBuilder.ToString();
            }
            else
            {
                multipleAuthGrantCount = 5;
                auth = "csharp-auth_key-0,csharp-auth_key-1,csharp-auth_key-2,csharp-auth_key-3,csharp-auth_key-4";
            }
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.GrantAccess<string>(channel, auth, true, true, 5, AccessToMultiAuthGrantCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenMultipleAuthGrantShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenMultipleAuthGrantShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenRevokeAtSubKeyLevelReturnSuccess()
        {
            currentUnitTestCase = "ThenRevokeAtSubKeyLevelReturnSuccess";

            receivedGrantMessage = false;
            receivedRevokeMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenRevokeAtSubKeyLevelReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;
            if (PubnubCommon.PAMEnabled)
            {
                if (!unitTest.EnableStubTest)
                {
                    grantManualEvent = new ManualResetEvent(false);
                    pubnub.GrantAccess<string>("", true, true, 5, AccessToSubKeyLevelCallback, DummyErrorCallback);
                    Task.Delay(1000);
                    grantManualEvent.WaitOne();
                }
                else
                {
                    receivedGrantMessage = true;
                }
                if (receivedGrantMessage)
                {
                    revokeManualEvent = new ManualResetEvent(false);
                    //Console.WriteLine("WhenGrantIsRequested -> ThenRevokeAtSubKeyLevelReturnSuccess -> Grant ok..Now trying Revoke");
                    pubnub.GrantAccess<string>("", false, false, 5, RevokeToSubKeyLevelCallback, DummyErrorCallback);
                    Task.Delay(1000);
                    revokeManualEvent.WaitOne();
                    pubnub.PubnubUnitTest = null;
                    pubnub = null;
                    Assert.IsTrue(receivedRevokeMessage, "WhenGrantIsRequested -> ThenRevokeAtSubKeyLevelReturnSuccess -> Grant success but revoke failed.");
                }
                else
                {
                    Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenRevokeAtSubKeyLevelReturnSuccess failed. -> Grant not occured, so is revoke");
                }
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenRevokeAtSubKeyLevelReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenRevokeAtChannelLevelReturnSuccess()
        {
            currentUnitTestCase = "ThenRevokeAtChannelLevelReturnSuccess";

            receivedGrantMessage = false;
            receivedRevokeMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenRevokeAtChannelLevelReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            string channel = "hello_my_channel";
            if (PubnubCommon.PAMEnabled)
            {
                if (!unitTest.EnableStubTest)
                {
                    grantManualEvent = new ManualResetEvent(false);
                    pubnub.GrantAccess<string>(channel, true, true, 5, AccessToChannelLevelCallback, DummyErrorCallback);
                    Task.Delay(1000);
                    grantManualEvent.WaitOne();
                }
                else
                {
                    receivedGrantMessage = true;
                }
                if (receivedGrantMessage)
                {
                    revokeManualEvent = new ManualResetEvent(false);
                    //Console.WriteLine("WhenGrantIsRequested -> ThenRevokeAtChannelLevelReturnSuccess -> Grant ok..Now trying Revoke");
                    pubnub.GrantAccess<string>("", false, false, 5, RevokeToChannelLevelCallback, DummyErrorCallback);
                    Task.Delay(1000);
                    revokeManualEvent.WaitOne();
                    pubnub.PubnubUnitTest = null;
                    pubnub = null;
                    Assert.IsTrue(receivedRevokeMessage, "WhenGrantIsRequested -> ThenRevokeAtChannelLevelReturnSuccess -> Grant success but revoke failed.");
                }
                else
                {
                    pubnub.PubnubUnitTest = null;
                    pubnub = null;
                    Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenRevokeAtChannelLevelReturnSuccess failed. -> Grant not occured, so is revoke");
                }
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenRevokeAtChannelLevelReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenRevokeAtUserLevelReturnSuccess()
        {
            currentUnitTestCase = "ThenRevokeAtUserLevelReturnSuccess";

            receivedGrantMessage = false;
            receivedRevokeMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenRevokeAtUserLevelReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            string channel = "hello_my_authchannel";
            string authKey = "hello_my_authkey";
            if (PubnubCommon.PAMEnabled)
            {
                if (!unitTest.EnableStubTest)
                {
                    grantManualEvent = new ManualResetEvent(false);
                    pubnub.GrantAccess<string>(channel, authKey, true, true, 5, AccessToUserLevelCallback, DummyErrorCallback);
                    Task.Delay(1000);
                    grantManualEvent.WaitOne();
                }
                else
                {
                    receivedGrantMessage = true;
                }
                if (receivedGrantMessage)
                {
                    revokeManualEvent = new ManualResetEvent(false);
                    //Console.WriteLine("WhenGrantIsRequested -> ThenRevokeAtUserLevelReturnSuccess -> Grant ok..Now trying Revoke");
                    pubnub.GrantAccess<string>(channel, authKey, false, false, 5, RevokeToUserLevelCallback, DummyErrorCallback);
                    Task.Delay(1000);
                    revokeManualEvent.WaitOne();
                    pubnub.PubnubUnitTest = null;
                    pubnub = null;
                    Assert.IsTrue(receivedRevokeMessage, "WhenGrantIsRequested -> ThenRevokeAtUserLevelReturnSuccess -> Grant success but revoke failed.");
                }
                else
                {
                    pubnub.PubnubUnitTest = null;
                    pubnub = null;
                    Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenRevokeAtUserLevelReturnSuccess failed. -> Grant not occured, so is revoke");
                }
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenRevokeAtUserLevelReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenChannelGroupLevelWithReadManageShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenChannelGroupLevelWithReadManageShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenChannelGroupLevelWithReadManageShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            string channelgroup = "hello_my_group";
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.ChannelGroupGrantAccess<string>(channelgroup, true, true, 5, AccessToChannelLevelCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenChannelGroupLevelWithReadManageShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenChannelGroupLevelWithReadManageShouldReturnSuccess.");
            }
        }

        [TestMethod]
        public void ThenChannelGroupLevelWithReadShouldReturnSuccess()
        {
            currentUnitTestCase = "ThenChannelGroupLevelWithReadShouldReturnSuccess";

            receivedGrantMessage = false;

            Pubnub pubnub = new Pubnub(PubnubCommon.PublishKey, PubnubCommon.SubscribeKey, PubnubCommon.SecretKey, "", false);

            PubnubUnitTest unitTest = new PubnubUnitTest();
            unitTest.TestClassName = "WhenGrantIsRequested";
            unitTest.TestCaseName = "ThenChannelGroupLevelWithReadShouldReturnSuccess";
            pubnub.PubnubUnitTest = unitTest;

            string channelgroup = "hello_my_group";
            if (PubnubCommon.PAMEnabled)
            {
                grantManualEvent = new ManualResetEvent(false);
                pubnub.ChannelGroupGrantAccess<string>(channelgroup, true, false, 5, AccessToChannelLevelCallback, DummyErrorCallback);
                Task.Delay(1000);

                grantManualEvent.WaitOne();

                pubnub.PubnubUnitTest = null;
                pubnub = null;
                Assert.IsTrue(receivedGrantMessage, "WhenGrantIsRequested -> ThenChannelGroupLevelWithReadShouldReturnSuccess failed.");
            }
            else
            {
                Assert.Inconclusive("PAM Not Enabled for WhenGrantIsRequested -> ThenChannelGroupLevelWithReadShouldReturnSuccess.");
            }
        }


        void AccessToSubKeyLevelCallback(string receivedMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(receivedMessage) && !string.IsNullOrEmpty(receivedMessage.Trim()))
                {
                    object[] serializedMessage = JsonConvert.DeserializeObject<object[]>(receivedMessage);
                    JContainer dictionary = serializedMessage[0] as JContainer;
                    if (dictionary != null)
                    {
                        int statusCode = dictionary.Value<int>("status");
                        string statusMessage = dictionary.Value<string>("message");
                        if (statusCode == 200 && statusMessage.ToLower() == "success")
                        {
                            var payload = dictionary.Value<JContainer>("payload");
                            if (payload != null)
                            {
                                bool read = payload.Value<bool>("r");
                                bool write = payload.Value<bool>("w");
                                string level = payload.Value<string>("level");
                                if (level == "subkey")
                                {
                                    switch (currentUnitTestCase)
                                    {
                                        case "ThenSubKeyLevelWithReadWriteShouldReturnSuccess":
                                        case "ThenRevokeAtSubKeyLevelReturnSuccess":
                                            if (read && write) receivedGrantMessage = true;
                                            break;
                                        case "ThenSubKeyLevelWithReadShouldReturnSuccess":
                                            if (read && !write) receivedGrantMessage = true;
                                            break;
                                        case "ThenSubKeyLevelWithWriteShouldReturnSuccess":
                                            if (!read && write) receivedGrantMessage = true;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            finally
            {
                grantManualEvent.Set();
            }
        }

        void AccessToChannelLevelCallback(string receivedMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(receivedMessage) && !string.IsNullOrEmpty(receivedMessage.Trim()))
                {
                    object[] serializedMessage = JsonConvert.DeserializeObject<object[]>(receivedMessage);
                    JContainer dictionary = serializedMessage[0] as JContainer;
                    string currentChannel = serializedMessage[1].ToString();
                    if (dictionary != null)
                    {
                        int statusCode = dictionary.Value<int>("status");
                        string statusMessage = dictionary.Value<string>("message");
                        if (statusCode == 200 && statusMessage.ToLower() == "success")
                        {
                            var payload = dictionary.Value<JContainer>("payload");
                            if (payload != null)
                            {
                                string level = payload.Value<string>("level");
                                if (level == "channel")
                                {
                                    var channels = payload.Value<JContainer>("channels");
                                    if (channels != null)
                                    {
                                        var channelContainer = channels.Value<JContainer>(currentChannel);
                                        if (channelContainer != null)
                                        {
                                            bool read = channelContainer.Value<bool>("r");
                                            bool write = channelContainer.Value<bool>("w");
                                            switch (currentUnitTestCase)
                                            {
                                                case "ThenChannelLevelWithReadWriteShouldReturnSuccess":
                                                case "ThenRevokeAtChannelLevelReturnSuccess":
                                                    if (read && write) receivedGrantMessage = true;
                                                    break;
                                                case "ThenChannelLevelWithReadShouldReturnSuccess":
                                                    if (read && !write) receivedGrantMessage = true;
                                                    break;
                                                case "ThenChannelLevelWithWriteShouldReturnSuccess":
                                                    if (!read && write) receivedGrantMessage = true;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                }
                                else if (level == "channel-group")
                                {
                                    var channelgroups = payload.Value<JContainer>("channel-groups");
                                    if (channelgroups != null)
                                    {
                                        var channelgroupContainer = channelgroups.Value<JContainer>(currentChannel);
                                        if (channelgroupContainer != null)
                                        {
                                            bool read = channelgroupContainer.Value<bool>("r");
                                            bool manage = channelgroupContainer.Value<bool>("m");
                                            switch (currentUnitTestCase)
                                            {
                                                case "ThenChannelGroupLevelWithReadManageShouldReturnSuccess":
                                                    if (read && manage) receivedGrantMessage = true;
                                                    break;
                                                case "ThenChannelGroupLevelWithReadShouldReturnSuccess":
                                                    if (read && !manage) receivedGrantMessage = true;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            finally
            {
                grantManualEvent.Set();
            }
        }

        void AccessToUserLevelCallback(string receivedMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(receivedMessage) && !string.IsNullOrEmpty(receivedMessage.Trim()))
                {
                    object[] serializedMessage = JsonConvert.DeserializeObject<object[]>(receivedMessage);
                    JContainer dictionary = serializedMessage[0] as JContainer;
                    string currentChannel = serializedMessage[1].ToString();
                    if (dictionary != null)
                    {
                        int statusCode = dictionary.Value<int>("status");
                        string statusMessage = dictionary.Value<string>("message");
                        if (statusCode == 200 && statusMessage.ToLower() == "success")
                        {
                            var payload = dictionary.Value<JContainer>("payload");
                            if (payload != null)
                            {
                                string level = payload.Value<string>("level");
                                string channel = payload.Value<string>("channel");
                                var auths = payload.Value<JContainer>("auths");
                                if (auths != null && auths.Count > 0)
                                {
                                    foreach(JToken auth in auths.Children())
                                    {
                                        if (auth is JProperty)
                                        {
                                            var authProperty = auth as JProperty;
                                            if (authProperty != null)
                                            {
                                                string authKey = authProperty.Name;
                                                var authKeyContainer = auths.Value<JContainer>(authKey);
                                                if (authKeyContainer != null && authKeyContainer.Count > 0)
                                                {
                                                    bool read = authKeyContainer.Value<bool>("r");
                                                    bool write = authKeyContainer.Value<bool>("w");
                                                    if (level == "user")
                                                    {
                                                        switch (currentUnitTestCase)
                                                        {
                                                            case "ThenUserLevelWithReadWriteShouldReturnSuccess":
                                                            case "ThenRevokeAtUserLevelReturnSuccess":
                                                                if (read && write) receivedGrantMessage = true;
                                                                break;
                                                            case "ThenUserLevelWithReadShouldReturnSuccess":
                                                                if (read && !write) receivedGrantMessage = true;
                                                                break;
                                                            case "ThenUserLevelWithWriteShouldReturnSuccess":
                                                                if (!read && write) receivedGrantMessage = true;
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            finally
            {
                grantManualEvent.Set();
            }
        }

        void AccessToMultiChannelGrantCallback(string receivedMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(receivedMessage) && !string.IsNullOrEmpty(receivedMessage.Trim()))
                {
                    object[] serializedMessage = JsonConvert.DeserializeObject<object[]>(receivedMessage);
                    JContainer dictionary = serializedMessage[0] as JContainer;
                    string currentChannel = serializedMessage[1].ToString();
                    if (dictionary != null)
                    {
                        int statusCode = dictionary.Value<int>("status");
                        string statusMessage = dictionary.Value<string>("message");
                        if (statusCode == 200 && statusMessage.ToLower() == "success")
                        {
                            var payload = dictionary.Value<JContainer>("payload");
                            if (payload != null)
                            {
                                string level = payload.Value<string>("level");
                                var channels = payload.Value<JContainer>("channels");
                                if (channels != null)
                                {
                                    //Console.WriteLine("{0} - AccessToMultiChannelGrantCallback - Grant MultiChannel Count (Received/Sent) = {1}/{2}", currentUnitTestCase, channels.Count, multipleChannelGrantCount);
                                    if (channels.Count == multipleChannelGrantCount)
                                    {
                                        receivedGrantMessage = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            finally
            {
                grantManualEvent.Set();
            }
        }

        void AccessToMultiAuthGrantCallback(string receivedMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(receivedMessage) && !string.IsNullOrEmpty(receivedMessage.Trim()))
                {
                    object[] serializedMessage = JsonConvert.DeserializeObject<object[]>(receivedMessage);
                    JContainer dictionary = serializedMessage[0] as JContainer;
                    string currentChannel = serializedMessage[1].ToString();
                    if (dictionary != null)
                    {
                        int statusCode = dictionary.Value<int>("status");
                        string statusMessage = dictionary.Value<string>("message");
                        if (statusCode == 200 && statusMessage.ToLower() == "success")
                        {
                            var payload = dictionary.Value<JContainer>("payload");
                            if (payload != null)
                            {
                                string level = payload.Value<string>("level");
                                string channel = payload.Value<string>("channel");
                                var auths = payload.Value<JContainer>("auths");
                                if (auths != null)
                                {
                                    //Console.WriteLine("{0} - AccessToMultiAuthGrantCallback - Grant Auth Count (Received/Sent) = {1}/{2}", currentUnitTestCase, auths.Count, multipleAuthGrantCount);
                                    if (auths.Count == multipleAuthGrantCount)
                                    {
                                        receivedGrantMessage = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            finally
            {
                grantManualEvent.Set();
            }
        }

        void RevokeToSubKeyLevelCallback(string receivedMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(receivedMessage) && !string.IsNullOrEmpty(receivedMessage.Trim()))
                {
                    object[] serializedMessage = JsonConvert.DeserializeObject<object[]>(receivedMessage);
                    JContainer dictionary = serializedMessage[0] as JContainer;
                    if (dictionary != null)
                    {
                        int statusCode = dictionary.Value<int>("status");
                        string statusMessage = dictionary.Value<string>("message");
                        if (statusCode == 200 && statusMessage.ToLower() == "success")
                        {
                            var payload = dictionary.Value<JContainer>("payload");
                            if (payload != null)
                            {
                                bool read = payload.Value<bool>("r");
                                bool write = payload.Value<bool>("w");
                                string level = payload.Value<string>("level");
                                if (level == "subkey")
                                {
                                    switch (currentUnitTestCase)
                                    {
                                        case "ThenRevokeAtSubKeyLevelReturnSuccess":
                                            if (!read && !write) receivedRevokeMessage = true;
                                            break;
                                        case "ThenSubKeyLevelWithReadShouldReturnSuccess":
                                            //if (read && !write) receivedGrantMessage = true;
                                            break;
                                        case "ThenSubKeyLevelWithWriteShouldReturnSuccess":
                                            //if (!read && write) receivedGrantMessage = true;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }

                        //if (dictionary.
                        //if (status == "200")
                        //{
                        //    receivedGrantMessage = true;
                        //}
                    }
                    //var level = dictionary["level"].ToString();
                }
            }
            catch { }
            finally
            {
                revokeManualEvent.Set();
            }
        }

        void RevokeToChannelLevelCallback(string receivedMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(receivedMessage) && !string.IsNullOrEmpty(receivedMessage.Trim()))
                {
                    object[] serializedMessage = JsonConvert.DeserializeObject<object[]>(receivedMessage);
                    JContainer dictionary = serializedMessage[0] as JContainer;
                    string currentChannel = serializedMessage[1].ToString();
                    if (dictionary != null)
                    {
                        int statusCode = dictionary.Value<int>("status");
                        string statusMessage = dictionary.Value<string>("message");
                        if (statusCode == 200 && statusMessage.ToLower() == "success")
                        {
                            var payload = dictionary.Value<JContainer>("payload");
                            if (payload != null)
                            {
                                string level = payload.Value<string>("level");
                                var channels = payload.Value<JContainer>("channels");
                                if (channels != null)
                                {
                                    var channelContainer = channels.Value<JContainer>(currentChannel);
                                    if (channelContainer == null)
                                    {
                                        receivedRevokeMessage = true;
                                    }
                                }
                                else
                                {
                                    receivedRevokeMessage = true;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            finally
            {
                revokeManualEvent.Set();
            }
        }

        void RevokeToUserLevelCallback(string receivedMessage)
        {
            try
            {
                if (!string.IsNullOrEmpty(receivedMessage) && !string.IsNullOrEmpty(receivedMessage.Trim()))
                {
                    object[] serializedMessage = JsonConvert.DeserializeObject<object[]>(receivedMessage);
                    JContainer dictionary = serializedMessage[0] as JContainer;
                    string currentChannel = serializedMessage[1].ToString();
                    if (dictionary != null)
                    {
                        int statusCode = dictionary.Value<int>("status");
                        string statusMessage = dictionary.Value<string>("message");
                        if (statusCode == 200 && statusMessage.ToLower() == "success")
                        {
                            var payload = dictionary.Value<JContainer>("payload");
                            if (payload != null)
                            {
                                string level = payload.Value<string>("level");
                                string channel = payload.Value<string>("channel");
                                var auths = payload.Value<JContainer>("auths");
                                if (auths != null && auths.Count >= 0)
                                {
                                    receivedRevokeMessage = true;
                                    foreach (JToken auth in auths.Children())
                                    {
                                        if (auth is JProperty)
                                        {
                                            var authProperty = auth as JProperty;
                                            if (authProperty != null)
                                            {
                                                string authKey = authProperty.Name;
                                                var authKeyContainer = auths.Value<JContainer>(authKey);
                                                if (authKeyContainer != null)
                                                {
                                                    receivedRevokeMessage = true;
                                                    break;
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    receivedRevokeMessage = false;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            finally
            {
                revokeManualEvent.Set();
            }
        }

        private void DummyErrorCallback(PubnubClientError result)
        {

        }

    }
}
