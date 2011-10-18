﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XBee;
using XBee.Exceptions;
using XBee.Frames;

namespace XBee.Test.Frames
{
    [TestFixture]
    class ExplicitAddressingTransmitTest
    {
        [Test]
        public void TestExplicitAddressingRequestBroadcastRadiusOptions()
        {
            XBeeNode broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            ExplicitAddressingTransmit frame = new ExplicitAddressingTransmit(broadcast);
            frame.FrameId = 1;
            frame.BroadcastRadius = 2;
            frame.Options = ExplicitAddressingTransmit.OptionValues.DISABLE_ACK | ExplicitAddressingTransmit.OptionValues.EXTENDED_TIMEOUT;

            frame.SourceEndpoint = 0xA0;
            frame.DestinationEndpoint = 0xA1;
            frame.ClusterId = 0x1554;
            frame.ProfileId = 0xC105;

            Assert.AreEqual(new byte[] { 0x11, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0xA0, 0xA1, 0x15, 0x54, 0xC1, 0x05, 0x02, 0x41 }, frame.ToByteArray());
        }

        [Test]
        public void TestExplicitAddressingRequestBroadcastRadiusOptionsData()
        {
            XBeeNode broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            ExplicitAddressingTransmit frame = new ExplicitAddressingTransmit(broadcast);
            frame.FrameId = 1;
            frame.BroadcastRadius = 2;
            frame.Options = ExplicitAddressingTransmit.OptionValues.DISABLE_ACK | ExplicitAddressingTransmit.OptionValues.EXTENDED_TIMEOUT;

            frame.SourceEndpoint = 0xA0;
            frame.DestinationEndpoint = 0xA1;
            frame.ClusterId = 0x1554;
            frame.ProfileId = 0xC105;

            frame.SetRFData(new byte[] { 0x11, 0x22, 0x33, 0x00 });

            Assert.AreEqual(new byte[] { 0x11, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0xA0, 0xA1, 0x15, 0x54, 0xC1, 0x05, 0x02, 0x41, 0x11, 0x22, 0x33, 0x00 }, frame.ToByteArray());
        }

        [Test]
        [ExpectedException(typeof(XBeeFrameException), ExpectedMessage = "Missing Profile ID")]
        public void TestExplicitAddressingRequestMissingProfile()
        {
            XBeeNode broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            ExplicitAddressingTransmit frame = new ExplicitAddressingTransmit(broadcast);
            frame.FrameId = 1;
            frame.BroadcastRadius = 2;
            frame.Options = ExplicitAddressingTransmit.OptionValues.DISABLE_ACK | ExplicitAddressingTransmit.OptionValues.EXTENDED_TIMEOUT;

            frame.SourceEndpoint = 0xA0;
            frame.DestinationEndpoint = 0xA1;
            frame.ClusterId = 0x1554;

            frame.SetRFData(new byte[] { 0x11, 0x22, 0x33, 0x00 });

            Assert.AreEqual(new byte[] { 0x11, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0xA0, 0xA1, 0x15, 0x54, 0xC1, 0x05, 0x02, 0x41, 0x11, 0x22, 0x33, 0x00 }, frame.ToByteArray());
        }

        [Test]
        [ExpectedException(typeof(XBeeFrameException), ExpectedMessage = "Missing Cluster ID")]
        public void TestExplicitAddressingRequestMissingCluster()
        {
            XBeeNode broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            ExplicitAddressingTransmit frame = new ExplicitAddressingTransmit(broadcast);
            frame.FrameId = 1;
            frame.BroadcastRadius = 2;
            frame.Options = ExplicitAddressingTransmit.OptionValues.DISABLE_ACK | ExplicitAddressingTransmit.OptionValues.EXTENDED_TIMEOUT;

            frame.SourceEndpoint = 0xA0;
            frame.DestinationEndpoint = 0xA1;
            frame.ProfileId = 0xC105;

            frame.SetRFData(new byte[] { 0x11, 0x22, 0x33, 0x00 });

            Assert.AreEqual(new byte[] { 0x11, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0xA0, 0xA1, 0x15, 0x54, 0xC1, 0x05, 0x02, 0x41, 0x11, 0x22, 0x33, 0x00 }, frame.ToByteArray());
        }

        [Test]
        [ExpectedException(typeof(XBeeFrameException), ExpectedMessage = "Missing Destination Endpoint")]
        public void TestExplicitAddressingRequestMissingDestination()
        {
            XBeeNode broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            ExplicitAddressingTransmit frame = new ExplicitAddressingTransmit(broadcast);
            frame.FrameId = 1;
            frame.BroadcastRadius = 2;
            frame.Options = ExplicitAddressingTransmit.OptionValues.DISABLE_ACK | ExplicitAddressingTransmit.OptionValues.EXTENDED_TIMEOUT;

            frame.SourceEndpoint = 0xA0;
            frame.ClusterId = 0x1554;
            frame.ProfileId = 0xC105;

            frame.SetRFData(new byte[] { 0x11, 0x22, 0x33, 0x00 });

            Assert.AreEqual(new byte[] { 0x11, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0xA0, 0xA1, 0x15, 0x54, 0xC1, 0x05, 0x02, 0x41, 0x11, 0x22, 0x33, 0x00 }, frame.ToByteArray());
        }

        [Test]
        [ExpectedException(typeof(XBeeFrameException), ExpectedMessage = "Missing Source Endpoint")]
        public void TestExplicitAddressingRequestMissingSource()
        {
            XBeeNode broadcast = new XBeeNode();
            broadcast.Address16 = XBeeAddress16.ZNET_BROADCAST;
            broadcast.Address64 = XBeeAddress64.BROADCAST;

            ExplicitAddressingTransmit frame = new ExplicitAddressingTransmit(broadcast);
            frame.FrameId = 1;
            frame.BroadcastRadius = 2;
            frame.Options = ExplicitAddressingTransmit.OptionValues.DISABLE_ACK | ExplicitAddressingTransmit.OptionValues.EXTENDED_TIMEOUT;

            frame.DestinationEndpoint = 0xA1;
            frame.ClusterId = 0x1554;
            frame.ProfileId = 0xC105;

            frame.SetRFData(new byte[] { 0x11, 0x22, 0x33, 0x00 });

            Assert.AreEqual(new byte[] { 0x11, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0xA0, 0xA1, 0x15, 0x54, 0xC1, 0x05, 0x02, 0x41, 0x11, 0x22, 0x33, 0x00 }, frame.ToByteArray());
        }
    }
}
