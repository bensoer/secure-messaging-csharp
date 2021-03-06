﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpMessenger.SecureMessaging;
using CSharpMessenger.SecureMessaging.Enums;
using System.Collections.Generic;

namespace CSharpMessengerTests
{
    [TestClass]
    public class SendMessageTests: BaseTestCase
    {

        [ClassInitialize]
        public static void BeforeClass(TestContext context)
        {
            BaseTestCase.BeforeClassLoader(context);
        }

        [TestMethod]
        public void TestSendBasicMessage()
        {
            SecureMessenger messenger = SecureMessenger.ResolveFromServiceCode(ServiceCode);
            Credentials credentials = new Credentials(Username, Password);
            messenger.Login(credentials);

            PreCreateConfiguration configuration = new PreCreateConfiguration();
            configuration.SetActionCode(ActionCodeEnum.New);

            Message message = messenger.PreCreateMessage(configuration);

            message.To = new List<String>()
            {
                RecipientEmail
            };
            message.Subject = "DeliverySlip C# Example";
            message.Body = "Hello Test Message From DeliverySlip C# Example";
            message.BodyFormat = BodyFormatEnum.Text;

            message = messenger.SaveMessage(message);
            messenger.SendMessage(message);

        }

        [TestMethod]
        public void TestSendFYEOMessageAccountPassword()
        {
            SecureMessenger messenger = SecureMessenger.ResolveFromServiceCode(ServiceCode);
            Credentials credentials = new Credentials(Username, Password);
            messenger.Login(credentials);

            PreCreateConfiguration configuration = new PreCreateConfiguration();
            configuration.SetActionCode(ActionCodeEnum.New);

            Message message = messenger.PreCreateMessage(configuration);

            message.To = new List<String>()
            {
                RecipientEmail
            };
            message.Subject = "DeliverySlip C# Example";
            message.Body = "Hello Test Message From DeliverySlip C# Example";
            message.BodyFormat = BodyFormatEnum.Text;

            message.MessageOptions.FyeoType = FyeoTypeEnum.AccountPassword;
            message.Password = Password;

            message = messenger.SaveMessage(message);
            messenger.SendMessage(message);
        }

        [TestMethod]
        public void TestSendFYEOMessageUniquePassword()
        {
            SecureMessenger messenger = SecureMessenger.ResolveFromServiceCode(ServiceCode);
            Credentials credentials = new Credentials(Username, Password);
            messenger.Login(credentials);

            PreCreateConfiguration configuration = new PreCreateConfiguration();
            configuration.SetActionCode(ActionCodeEnum.New);

            Message message = messenger.PreCreateMessage(configuration);

            message.To = new List<String>()
            {
                RecipientEmail
            };
            message.Subject = "DeliverySlip C# Example";
            message.Body = "Hello Test Message From DeliverySlip C# Example";
            message.BodyFormat = BodyFormatEnum.Text;

            message.MessageOptions.FyeoType = FyeoTypeEnum.UniquePassword;
            message.Password = "password";

            message = messenger.SaveMessage(message);
            messenger.SendMessage(message);
        }

        [TestMethod]
        public void TestSendMessageWithCRA()
        {
            SecureMessenger messenger = SecureMessenger.ResolveFromServiceCode(ServiceCode);
            Credentials credentials = new Credentials(Username, Password);
            messenger.Login(credentials);

            PreCreateConfiguration configuration = new PreCreateConfiguration();
            configuration.SetActionCode(ActionCodeEnum.New);

            Message message = messenger.PreCreateMessage(configuration);

            message.To = new List<String>()
            {
                RecipientEmail
            };
            message.Subject = "DeliverySlip C# Example";
            message.Body = "Hello Test Message From DeliverySlip C# Example";
            message.BodyFormat = BodyFormatEnum.Text;

            message.CraCode = "cracode";
            message.InviteNewUsers = true;
            message.SendNotification = true;

            message = messenger.SaveMessage(message);
            messenger.SendMessage(message);
        }
    }
}
